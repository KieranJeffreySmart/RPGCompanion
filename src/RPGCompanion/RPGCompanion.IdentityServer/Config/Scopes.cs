using IdentityServer3.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RPGCompanion.IdentityServer.Config
{
    public static class Scopes
    {
        public static IEnumerable<Scope> Get()
        {
            return new List<Scope>
            {
                new Scope
                {
                    Name = "charactermanagement",
                    DisplayName = "Character Management",
                    Description = "Manage Your Character",
                    Type = ScopeType.Resource
                }
            };
        }
    }
}