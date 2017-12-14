using IoPee.Controllers;
using IoPee.Schedules;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IoPee.Startup))]
namespace IoPee
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            DevicesController controller = new DevicesController();
            //new ChangeDeviceStatusScheduler();
            //new SendDeviceDataScheduler();
            new UpdateDeviceStatusScheduler();
        }
    }
}
