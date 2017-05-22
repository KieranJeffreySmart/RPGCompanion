using System;
using System.Collections.Generic;
using System.Text;
using RPGCompanion.Domain.Abstract;

namespace RPGCompanion.Domain.Model
{
    public class UnitType: LookupEntity
    {
        private Name name;
        
        public UnitType(long id, Name name) : base(id)
        {
        }

        public Name Name { get; set; }
    }
}
