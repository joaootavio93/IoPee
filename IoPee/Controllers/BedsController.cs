using IoPee.Data;
using IoPee.Entities;
using IoPee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace IoPee.Controllers
{
    public class BedsController : Controller
    {
        // GET: Beds
        public ActionResult Index(int sectorId)
        {
            var bedList = GetBedListBySectorId(sectorId);
            return View(bedList);
        }

        public ActionResult Add(int sectorId)
        {
            Register(sectorId);
            var bedList = GetBedListBySectorId(sectorId);
            return View(bedList);
        }

        private bool Register(int sectorId)
        {
            try
            {
                var sector = StaticData.Sectors.Where(s => s.Id == sectorId).FirstOrDefault();
                if (sector.Beds == null)
                    sector.Beds = new List<Bed>();
                int count = 0;
                foreach (var sec in StaticData.Sectors)
                    count += sec.Beds.Count;
                count++;
                sector.Beds.Add(new Bed
                {
                    Id = count,
                    Name = "Leito " + (sector.Beds.Count + 1),
                    SectorId = sector.Id
                });
            }
            catch(Exception e)
            {
                Console.WriteLine("An exception has been thrown: " + e.Message);
                return false;
            }

            return true;
        }

        private BedListViewModel GetBedListBySectorId(int sectorId)
        {
            var bedList = new BedListViewModel();
            var sector = StaticData.Sectors.Where(s => s.Id == sectorId).FirstOrDefault();

            if(sector != null)
            {
                bedList.SectorId = sector.Id;
                bedList.SectorName = sector.Name;
            }

            if(sector != null && sector.Beds != null)
            {
                foreach (var bed in sector.Beds)
                {
                    bedList.Beds.Add(new BedViewModel
                    {
                        Id = bed.Id,
                        Name = bed.Name
                    });
                }
            }        
            return bedList;
        }
    }
}