using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(aspNet_Identity_MySql_Practice2.Startup))]
namespace aspNet_Identity_MySql_Practice2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
