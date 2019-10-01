using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BudgetGuru.Startup))]
namespace BudgetGuru
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
