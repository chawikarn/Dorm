using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DormitoryWeb.Startup))]
namespace DormitoryWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
