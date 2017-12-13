using IoPee.Data;
using IoPee.Entities;
using IoPee.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace IoPee.Controllers
{
    public class DiapersController : Controller
    {
        // GET: Devices
        public ActionResult Index()
        {
            var diaperList = new DiaperListViewModel();
            diaperList.Diapers = GetDiaperList();
            return View(diaperList);
        }

        // GET: Register
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(DiaperViewModel model)
        {
            try
            {
                var diaper = new Diaper
                {
                    Id = StaticData.Diapers.Count + 1,
                    Name = model.Name,
                    Brand = model.Brand,
                    Humidity = model.Humidity,
                    Temperature = model.Temperature,
                };

                StaticData.Diapers.Add(diaper);

                return RedirectToAction("Index", "Diapers");
            }
            catch (Exception e)
            {
                Console.WriteLine("An exception has been thrown: " + e.Message);
            }
            return View(model);
        }

        private List<DiaperViewModel> GetDiaperList()
        {
            var diaperList = new List<DiaperViewModel>();
            foreach (var device in StaticData.Diapers)
            {
                diaperList.Add(new DiaperViewModel
                {
                    Id = device.Id,
                    Name = device.Name,
                    Brand = device.Brand,
                    Humidity = device.Humidity,
                    Temperature = device.Temperature                    
                });
            }
            return diaperList;
        }
    }
}