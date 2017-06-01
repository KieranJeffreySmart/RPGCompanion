namespace RPGCompanion.Application.Narrative
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Domain.Mediator;

    public class QuickStartStoryHandler: IPrivateMessageHandler<QuickStartStory, IEnumerable<Guid>>
    {
        private readonly IManagedMediator _mediator;

        public QuickStartStoryHandler(IManagedMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IEnumerable<Guid>> Handle(QuickStartStory command)
        {
            command.Story.ContextId = command.ContextId;
            var storyResponse = await _mediator.Send(command.Story);
            command.Environment.ContextId = command.ContextId;
            var environmentResponse = await _mediator.Send(command.Environment);
            var environmentId = environmentResponse.Result;
            command.Moment.EnvironmentId = environmentId;
            var momentResponse = await _mediator.Send(command.Moment);
            var momentId = momentResponse.Result;
            command.Start.MomentId = momentId;
            command.Start.EnviroinmentId = environmentId;
            command.Start.StroyId = storyResponse.Result;
            var storyLinesResponse = await _mediator.Send(command.Start);
            return storyLinesResponse.Result;
        }
    }
}