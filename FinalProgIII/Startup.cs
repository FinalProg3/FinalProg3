using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FinalProgIII.Startup))]
namespace FinalProgIII
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
