using IoPee.Data;
using IoPee.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace IoPee.Controllers
{
    public class DeviceStatusController : Controller
    {
        // GET: DeviceStatus
        public ActionResult Index()
        {
            var deviceList = new DeviceListViewModel();
            deviceList.Devices = GetDeviceList();
            return View(deviceList);
        }

        private List<DeviceViewModel> GetDeviceList()
        {
            var deviceList = new List<DeviceViewModel>();
            foreach (var device in ModelData.Devices.Where(d => d.Enable))
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
            deviceList.OrderBy(d => !d.Active);
            return deviceList;
        }
    }
}