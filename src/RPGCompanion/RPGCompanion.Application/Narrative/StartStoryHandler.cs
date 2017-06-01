namespace RPGCompanion.Application.Narrative
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Domain.Mediator;

    public class StartStoryHandler : IPrivateMessageHandler<StartStory, IEnumerable<Guid>>
    {
        public Task<IEnumerable<Guid>> Handle(StartStory command)
        {
            throw new NotImplementedException();
        }
    }
}