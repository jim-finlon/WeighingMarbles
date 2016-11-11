using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WeighingMarbles.Startup))]
namespace WeighingMarbles
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
