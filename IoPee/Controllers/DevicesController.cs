using IoPee.Data;
using IoPee.Entities;
using IoPee.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace IoPee.Controllers
{
    public class DevicesController : Controller
    {
        private readonly string devicesAddress = @"http://dmesquita.pythonanywhere.com/iopee/api/v1.0/devices";
        private readonly string deviceAddress = @"http://dmesquita.pythonanywhere.com/iopee/api/v1.0/setconfig/";

        // GET: Devices
        public ActionResult Index()
        {
            var deviceList = new DeviceListViewModel();
            deviceList.Devices = GetDeviceList();
            return View(deviceList);
        }

        // GET: Register
        public ActionResult Register()
        {
            try
            {
                GetDevicesRequest(devicesAddress);
                var device = new DeviceViewModel();
                device.Diapers = GetDiapers();
                device.Sectors = GetSectors();
                device.Macs = GetAvailableMacs();
                return View(device);
            }
            catch(Exception e)
            {
                Console.WriteLine("An exception has been thrown: " + e.Message);
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(DeviceViewModel model)
        {
            try
            {
                var device = new Device
                {
                    Id = Util.Devices.Count + 1,
                    Name = model.Name,
                    Humidity = (int)Util.MaxHumidity,
                    Temperature = 0,
                    Enable = true,
                    Active = false,
                    DiaperId = (int)model.DiaperId,
                    Diaper = Util.Diapers.Where(d => d.Id == model.DiaperId).FirstOrDefault(),
                    MacId = Util.Macs.Where(m => m.Id != 0).ToList().Count + 1,
                    Mac = Util.Macs.Where(m => m.Code == model.MacCode).FirstOrDefault(),
                    BedId = (int)model.BedId,
                    Bed = Util.Sectors.Where(s => s.Id == model.SectorId).FirstOrDefault().Beds.Where(b => b.Id == model.BedId).FirstOrDefault(),
                    LastChangeTime = DateTime.Now
                };

                Util.Macs.Where(m => m.Code == model.MacCode).FirstOrDefault().Id = Util.Macs.Where(m => m.Id != 0).ToList().Count + 1;      
                Util.Devices.Add(device);

                SetDeviceHumidityThresholhRequest(deviceAddress, device.Mac.ExternalId, device.Diaper.Humidity);

                return RedirectToAction("Index", "Devices");
            }
            catch (Exception e)
            {
                Console.WriteLine("An exception has been thrown: " + e.Message);
            }
            return View(model);
        }

        private IEnumerable<SelectListItem> GetDiapers()
        {
            var items = new List<SelectListItem>();

            foreach(var diaper in Util.Diapers)
            {
                items.Add(new SelectListItem
                {
                    Value = diaper.Id.ToString(),
                    Text = diaper.Name.ToString()
                });
            }

            return items;
        }

        private IEnumerable<SelectListItem> GetSectors()
        {
            var items = new List<SelectListItem>();

            foreach (var sector in Util.Sectors)
            {
                items.Add(new SelectListItem
                {
                    Value = sector.Id.ToString(),
                    Text = sector.Name.ToString()
                });
            }

            return items;
        }

        private IEnumerable<SelectListItem> GetAvailableMacs()
        {
            var items = new List<SelectListItem>();

            foreach (var mac in Util.Macs.Where(m => m.Id == 0).ToList())
            {
                items.Add(new SelectListItem
                {
                    Value = mac.Code.ToString(),
                    Text = mac.Code.ToString()
                });
            }

            return items;
        }

        private List<DeviceViewModel> GetDeviceList()
        {
            var deviceList = new List<DeviceViewModel>();
            foreach(var device in Util.Devices)
            {
                deviceList.Add(new DeviceViewModel
                {
                    Id = device.Id,
                    Name = device.Name,
                    Humidity = device.Humidity,
                    Temperature = device.Temperature,
                    Enable = device.Enable,
                    Active = device.Active,
                    DiaperId = device.DiaperId,
                    DiaperName = device.Diaper.Name,
                    SectorId = device.Bed.SectorId,
                    SectorName = Util.Sectors.Where(s => s.Id == device.Bed.SectorId).FirstOrDefault().Name,
                    BedId = device.BedId,
                    BedName = device.Bed.Name,
                    MacId = device.Mac.Id,
                    MacCode = device.Mac.Code,
                    LastChangeTime = device.LastChangeTime
                });
            }
            return deviceList;
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetBedsBySector(string sectorId)
        {
            var sector = Data.Util.Sectors.Where(s => s.Id == int.Parse(sectorId)).FirstOrDefault();
            var items = new List<SelectListItem>();

            foreach (var bed in sector.Beds)
            {
                items.Add(new SelectListItem
                {
                    Value = bed.Id.ToString(),
                    Text = bed.Name.ToString()
                });
            }

            return Json(items, JsonRequestBehavior.AllowGet);
        }

        public void GetDevicesRequest(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                var json = new JavaScriptSerializer();
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                string jsonStr = reader.ReadToEnd();
                DeviceListJson deviceList = json.Deserialize<DeviceListJson>(jsonStr);
                foreach (var device in deviceList.devices)
                {
                    if (Util.Macs.Where(m => m.Code == device.MacId).FirstOrDefault() == null)
                        Util.Macs.Add(new Mac
                        {
                            Id = 0,
                            ExternalId = int.Parse(device.id),
                            Code = device.MacId
                        });
                }
            }
        }

        public void SetDeviceHumidityThresholhRequest(string baseAddress, int externalId, int humidity)
        {
            string address = baseAddress + externalId + "?humidity=" + humidity;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(address);

            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                var json = new JavaScriptSerializer();
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                string jsonStr = reader.ReadToEnd();
            }
        }

    }
}