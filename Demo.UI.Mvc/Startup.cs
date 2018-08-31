using Demo.Infra.Ioc;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Demo.UI.Mvc.Startup))]
namespace Demo.UI.Mvc
{
    public partial class Startup
    {
        //Not used, i'm use this configuration in Global.asax
        public void Configuration(IAppBuilder app)
        {
            IoC.Start();
        }
    }
}