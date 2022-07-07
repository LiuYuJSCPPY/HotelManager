using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HotelManager.Web.Startup))]
namespace HotelManager.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
