using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Get_IT_Done.Startup))]
namespace Get_IT_Done
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
