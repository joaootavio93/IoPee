using IoPee.Data;
using Quartz;
using System;

namespace IoPee.Schedules
{
    public class ChangeDeviceStatusJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            var random = new Random();

            foreach(var device in Util.Devices)
            {
                int sortedNumber = random.Next(2);
                bool lastState = device.Active;

                // 0 = not change; 1 = change
                if (sortedNumber == 1)
                    device.Active = !device.Active;

                if(!device.Active && lastState)
                    device.LastChangeTime = DateTime.Now;
            }
        }
    }
}