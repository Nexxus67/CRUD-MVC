using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(crudl123.Startup))]
namespace crudl123
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
