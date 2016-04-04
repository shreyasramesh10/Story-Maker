using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IPFinalPrj.Startup))]
namespace IPFinalPrj
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
