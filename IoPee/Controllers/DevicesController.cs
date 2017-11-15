using IoPee.Data;
using IoPee.Entities;
using IoPee.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace IoPee.Controllers
{
    public class DevicesController : Controller
    {
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
                var device = new DeviceViewModel();
                device.Diapers = GetDiapers();
                device.Sectors = GetSectors();
                device.Macs = GetAvailableMacs();
                return View(device);
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return View();
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetBedsBySector(string sectorId)
        {
            var sector = Data.ModelData.Sectors.Where(s => s.Id == int.Parse(sectorId)).FirstOrDefault();
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

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(DeviceViewModel model)
        {
            try
            {
                var device = new Device
                {
                    Id = ModelData.Devices.Count + 1,
                    Name = model.Name,
                    Humidity = model.Humidity,
                    Temperature = model.Temperature,
                    Enable = true,
                    Active = false,
                    DiaperId = (int)model.DiaperId,
                    Diaper = ModelData.Diapers.Where(d => d.Id == (int)model.DiaperId).FirstOrDefault(),
                    MacId = ModelData.Macs.Where(m => m.Id != 0).ToList().Count + 1,
                    Mac = ModelData.Macs.Where(m => m.Code == model.MacCode).FirstOrDefault(),
                    BedId = (int)model.BedId,
                    Bed = ModelData.Sectors.Where(s => s.Id == (int)model.SectorId).FirstOrDefault().Beds.Where(b => b.Id == (int)model.BedId).FirstOrDefault()
                };

                ModelData.Macs.Where(m => m.Code == model.MacCode).FirstOrDefault().Id = ModelData.Macs.Where(m => m.Id != 0).ToList().Count + 1;

                ModelData.Devices.Add(device);

                return RedirectToAction("Index", "Devices");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return View(model);
        }

        private IEnumerable<SelectListItem> GetDiapers()
        {
            var items = new List<SelectListItem>();

            foreach(var diaper in ModelData.Diapers)
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

            foreach (var sector in ModelData.Sectors)
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

            foreach (var mac in ModelData.Macs.Where(m => m.Id == 0).ToList())
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
            foreach(var device in ModelData.Devices)
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
                    SectorName = ModelData.Sectors.Where(s => s.Id == device.Bed.SectorId).FirstOrDefault().Name,
                    BedId = device.BedId,
                    BedName = device.Bed.Name,
                    MacId = device.Mac.Id,
                    MacCode = device.Mac.Code
                });
            }
            return deviceList;
        }
    }
}