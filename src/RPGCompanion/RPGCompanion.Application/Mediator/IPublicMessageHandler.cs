﻿namespace RPGCompanion.Application.Mediator
{
    using System.Threading.Tasks;

    public interface IPublicMessageHandler<in TMessage> where TMessage : IPublicMessage
    {
        Task<IResponse> Handle(TMessage command);
    }
}