using Owin;
using Microsoft.Owin;

[assembly: OwinStartupAttribute(typeof(BirthdaySite.Startup))]
namespace BirthdaySite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
