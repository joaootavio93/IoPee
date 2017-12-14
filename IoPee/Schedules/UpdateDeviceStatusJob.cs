using System;
using Quartz;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using IoPee.Data;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace IoPee.Schedules
{
    public class UpdateDeviceStatusJob : IJob
    {
        private readonly string devicesAddress = @"http://dmesquita.pythonanywhere.com/iopee/api/v1.0/devices";

        public void Execute(IJobExecutionContext context)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(devicesAddress);

            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                var json = new JavaScriptSerializer();
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                string jsonStr = reader.ReadToEnd();
                DeviceListJson deviceList = json.Deserialize<DeviceListJson>(jsonStr);
                foreach (var device in deviceList.devices)
                {
                    var deviceRegistered = Util.Devices.Where(d => d.Mac.Code == device.MacId).FirstOrDefault();
                    if (deviceRegistered != null)
                    {
                        deviceRegistered.Humidity = int.Parse(device.Humidity);

                        bool lastStage = deviceRegistered.Active;

                        if (deviceRegistered.Humidity <= deviceRegistered.Diaper.Humidity)
                            deviceRegistered.Active = true;
                        else
                            deviceRegistered.Active = false;

                        if (lastStage && !deviceRegistered.Active)
                            deviceRegistered.LastChangeTime = DateTime.Now;
                    }
                }
            }
        }
    }
}