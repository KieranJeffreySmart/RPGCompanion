﻿using IdentityServer3.Core.Services.InMemory;
using System;
using System.Collections.Generic;

namespace RPGCompanion.IdentityServer.Config
{
    public static class Users
    {
         public static List<InMemoryUser> Get()
        {
            return new List<InMemoryUser>
            {
                new InMemoryUser
                {
                    Username = "Kieran",
                    Password = "password",
                    Subject = Guid.NewGuid().ToString()
                },
                new InMemoryUser
                {
                    Username = "Rheya",
                    Password = "password",
                    Subject = Guid.NewGuid().ToString()
                }
            };
        }
    }
}