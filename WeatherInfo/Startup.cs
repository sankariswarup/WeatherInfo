using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WeatherInfo.Startup))]
namespace WeatherInfo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
