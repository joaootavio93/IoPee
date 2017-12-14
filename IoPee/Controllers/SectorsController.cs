using IoPee.Data;
using IoPee.Entities;
using IoPee.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace IoPee.Controllers
{
    public class SectorsController : Controller
    {
        // GET: Sectors
        public ActionResult Index()
        {
            var sectorList = new SectorListViewModel();
            sectorList.Sectors = GetSectorList();
            return View(sectorList);
        }

        // GET: Register
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(SectorViewModel model)
        {
            try
            {
                var sector = new Sector
                {
                    Id = Util.Sectors.Count + 1,
                    Name = model.Name,
                    Description = model.Description
                };

                Util.Sectors.Add(sector);

                return RedirectToAction("Index", "Sectors");
            }
            catch (Exception e)
            {
                Console.WriteLine("An exception has been thrown: " + e.Message);
            }
            return View(model);
        }

        private List<SectorViewModel> GetSectorList()
        {
            var sectorList = new List<SectorViewModel>();
            foreach (var sector in Util.Sectors)
            {
                sectorList.Add(new SectorViewModel
                {
                    Id = sector.Id,
                    Name = sector.Name,
                    Description = sector.Description
                });
            }
            return sectorList;
        }
    }
}