using IoPee.Entities;
using System.Collections.Generic;

namespace IoPee.Data
{
    public static class StaticData
    {
        public static List<Diaper> Diapers = new List<Diaper>
        {
            //new Diaper
            //{
            //    Id = 1,
            //    Name = "Pumpers #1",
            //    Brand = "Pumpers",
            //    Humidity = 900,
            //    Temperature = 5
            //},

            //new Diaper
            //{
            //    Id = 2,
            //    Name = "Pumpers #2",
            //    Brand = "Pumpers",
            //    Humidity = 945,
            //    Temperature = 6
            //},

            //new Diaper
            //{
            //    Id = 3,
            //    Name = "Pumpers #3",
            //    Brand = "Pumpers",
            //    Humidity = 885,
            //    Temperature = 9
            //}
        };

        public static List<Sector> Sectors = new List<Sector>
        {
            //new Sector
            //{
            //    Id = 1,
            //    Name = "Enfermaria #1",
            //    Description = "Setor de doenças cardiacas"
            //    Beds = new List<Bed>
            //    {
            //        new Bed
            //        {
            //            Id = 1,
            //            Name = "Leito #1",
            //            SectorId = 1
            //        },

            //        new Bed
            //        {
            //            Id = 2,
            //            Name = "Leito #2",
            //            SectorId = 1
            //        }
            //    }
            //},

            //new Sector
            //{
            //    Id = 2,
            //    Name = "Enfermaria #2",
            //    Description = "Setor de doenças dermatológicas"
            //    Beds = new List<Bed>
            //    {
            //        new Bed
            //        {
            //            Id = 3,
            //            Name = "Leito #3",
            //            SectorId = 2
            //        },

            //        new Bed
            //        {
            //            Id = 4,
            //            Name = "Leito #4",
            //            SectorId = 2
            //        },

            //        new Bed
            //        {
            //            Id = 5,
            //            Name = "Leito #5",
            //            SectorId = 2
            //        }
            //    }
            //},

            //new Sector
            //{
            //    Id = 3,
            //    Name = "Quartos Corredor #1",
            //    Description = "Setor de doenças terminais"
            //    Beds = new List<Bed>
            //    {
            //        new Bed
            //        {
            //            Id = 6,
            //            Name = "Leito #6",
            //            SectorId = 3
            //        }
            //    }
            //}
        };

        // Macs containing Id = 0 are availables
        public static List<Mac> Macs = new List<Mac>
        {
            //new Mac
            //{
            //    Id = 1,
            //    Code = "38-B1-DB-CD-04-29"
            //},

            //new Mac
            //{
            //    Id = 2,
            //    Code = "83-B4-DY-PP-44-22"
            //},

            // new Mac
            //{
            //    Id = 3,
            //    Code = "00-AA-BB-CC-11-22"
            //},

            //new Mac
            //{
            //    Id = 0,
            //    Code = "01-B4-ZZ-GH-44-22"
            //},

            // new Mac
            //{
            //    Id = 0,
            //    Code = "66-HH-UI-CC-66-00"
            //},
        };

        public static List<Device> Devices = new List<Device>
        {
            //new Device
            //{
            //    Id = 1,
            //    Name = "Dispositivo #1",
            //    Humidity = 50,
            //    Temperature = 3,
            //    Enable = true,
            //    Active = false,
            //    DiaperId = 1,
            //    Diaper = StaticData.Diapers.Where(d => d.Id == 1).FirstOrDefault(),
            //    MacId = 1,
            //    Mac = StaticData.Macs.Where(m => m.Id == 1).FirstOrDefault(),
            //    BedId = 1,
            //    Bed = StaticData.Sectors.Where(s => s.Id == 1).FirstOrDefault().Beds.Where(b => b.Id == 1).FirstOrDefault(),
            //    LastChangeTime = DateTime.Now
            //},

            //new Device
            //{
            //    Id = 2,
            //    Name = "Dispositivo #2",
            //    Humidity = 50,
            //    Temperature = 3,
            //    Enable = true,
            //    Active = true,
            //    DiaperId = 2,
            //    Diaper = StaticData.Diapers.Where(d => d.Id == 2).FirstOrDefault(),
            //    MacId = 2,
            //    Mac = StaticData.Macs.Where(m => m.Id == 2).FirstOrDefault(),
            //    BedId = 2,
            //    Bed = StaticData.Sectors.Where(s => s.Id == 1).FirstOrDefault().Beds.Where(b => b.Id == 2).FirstOrDefault(),
            //    LastChangeTime = DateTime.Now
            //},

            //new Device
            //{
            //    Id = 3,
            //    Name = "Dispositivo #3",
            //    Humidity = 50,
            //    Temperature = 3,
            //    Enable = true,
            //    Active = false,
            //    DiaperId = 3,
            //    Diaper = StaticData.Diapers.Where(d => d.Id == 3).FirstOrDefault(),
            //    MacId = 3,
            //    Mac = StaticData.Macs.Where(m => m.Id == 3).FirstOrDefault(),
            //    BedId = 3,
            //    Bed = StaticData.Sectors.Where(s => s.Id == 2).FirstOrDefault().Beds.Where(b => b.Id == 3).FirstOrDefault(),
            //    LastChangeTime = DateTime.Now
            //}
        };
    }
}