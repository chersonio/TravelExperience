using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TravelExperience.MVC.Startup))]
namespace TravelExperience.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

        }
    }
}
