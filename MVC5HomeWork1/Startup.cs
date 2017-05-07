using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC5HomeWork1.Startup))]
namespace MVC5HomeWork1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
