﻿using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using IdentityServer3.Core.Configuration;
using RPGCompanion.IdentityServer.Config;
using System.Security.Cryptography.X509Certificates;

[assembly: OwinStartup(typeof(RPGCompanion.IdentityServer.Startup1))]

namespace RPGCompanion.IdentityServer
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            app.Map("/identity", idsvrapp =>
            {
                var idServerServiceFactory = new IdentityServerServiceFactory()
                .UseInMemoryUsers(Users.Get())
                .UseInMemoryClients(Clients.Get())
                .UseInMemoryScopes(Scopes.Get());



                var options = new IdentityServerOptions
                {
                    Factory = idServerServiceFactory,
                    SiteName = "RPG Companion Security Token Service",
                    IssuerUri = Constants.SecurityConstants.IssuerUri,
                    PublicOrigin = Constants.SecurityConstants.OriginUri,
                    SigningCertificate = LoadCertificate()
                };

                idsvrapp.UseIdentityServer(options);
            });
        }


        X509Certificate2 LoadCertificate()
        {
            return new X509Certificate2(string.Format(@"{0}\certificates\idsrv3test.pfx", AppDomain.CurrentDomain.BaseDirectory), "idsrv3test");
        }
    }
}