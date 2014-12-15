using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ICT4EVENTS.Startup))]
namespace ICT4EVENTS
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
