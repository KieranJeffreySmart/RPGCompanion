using System;
using RPGCompanion.Domain.Abstract;
using RPGCompanion.Domain.Services;
using System.Collections.Generic;

namespace RPGCompanion.Domain.Model
{
    public class Creature : Entity
    {
        public Creature(Timeline timeline, Character character, Name name, List<Item> items) : base(timeline, character, name)
        {
            Items = items;
        }

        new List<Item> Items { get; }

        internal Creature Clone()
        {
            throw new NotImplementedException();
        }
    }
}
