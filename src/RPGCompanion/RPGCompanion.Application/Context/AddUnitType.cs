﻿namespace RPGCompanion.Application.Context
{
    using System;
    using Domain;
    using RPGCompanion.Domain.Model.Values;

    public class AddUnitType : DomainCommand
    {
        public Name Name { get; set; }
        public Guid ContextId { get; set; }
        public Description Description { get; set; }
    }
}