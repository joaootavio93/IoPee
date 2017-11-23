using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace IoPee.Models
{
    public class DeviceViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Humidade(%)")]
        public int Humidity { get; set; }

        [Required]
        [Display(Name = "Temperatura")]
        public int Temperature { get; set; }

        public bool Enable { get; set; }

        public bool Active { get; set; }

        [Required]
        [Display(Name = "Fralda")]
        public int? DiaperId { get; set; }

        public string DiaperName { get; set; }

        public IEnumerable<SelectListItem> Diapers { get; set; }

        [Required]
        [Display(Name = "Setor/Ala")]
        public int? SectorId { get; set; }

        public string SectorName { get; set; }

        public IEnumerable<SelectListItem> Sectors { get; set; }

        [Required]
        [Display(Name = "Leito")]
        public int? BedId { get; set; }

        public string BedName { get; set; }

        public IEnumerable<SelectListItem> Beds = new List<SelectListItem>();

        public int MacId { get; set; }

        [Required]
        [Display(Name = "MAC")]
        public string MacCode { get; set; }

        public IEnumerable<SelectListItem> Macs = new List<SelectListItem>();

        public DateTime LastChangeTime { get; set; }

        public string LastChangeTimeFormat { get; set; }

        public int CurrentHumidity { get; set; }

        public int CurrentTemperature{ get; set; }
    }

    public class DeviceListViewModel
    {
        public List<DeviceViewModel> Devices = new List<DeviceViewModel>();
    }
}