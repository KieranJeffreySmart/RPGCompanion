using RPGCompanion.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using RPGCompanion.Domain.Services;

namespace RPGCompanion.Domain.Model
{
    public class Thing : Entity
    {
        public Thing(Timeline timeline, Character character, Name name) : base(timeline, character, name)
        {
        }
    }
}
