using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(RPGCompanion.Api.Startup1))]

namespace RPGCompanion.Api
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
