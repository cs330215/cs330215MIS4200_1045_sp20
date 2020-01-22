using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(cs330215MIS4200_1045_sp20.Startup))]
namespace cs330215MIS4200_1045_sp20
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
