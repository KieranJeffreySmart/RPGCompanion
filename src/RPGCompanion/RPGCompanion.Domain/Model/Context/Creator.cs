namespace RPGCompanion.Domain.Model.Context
{
    using System;

    public class Creator
    {
        public Creator(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}