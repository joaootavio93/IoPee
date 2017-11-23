using System;
using Quartz;
using IoPee.Data;
using System.Linq;
using IoPee.Controllers;

namespace IoPee.Schedules
{
    public class SendDeviceDataJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            var random = new Random();
            var devicesCount = StaticData.Devices.ToList().Count;

            int index = random.Next(0, devicesCount + 1);
            string sortedMac = StaticData.Devices.ToList().ElementAt(index).Mac.Code;
            int sortedHumidity = random.Next(875, 1000);

            var webApi = new WebApiController();

            webApi.SendData(sortedMac, sortedHumidity);
        }
    }
}