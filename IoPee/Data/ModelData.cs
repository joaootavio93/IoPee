using IoPee.Entities;
using System.Collections.Generic;
using System.Linq;

namespace IoPee.Data
{
    public static class ModelData
    {
        public static List<Diaper> Diapers = new List<Diaper>
        {
            new Diaper
            {
                Id = 1,
                Name = "Pumpers #1",
                Brand = "Pumpers",
                Humidity = 40,
                Temperature = 5
            },

            new Diaper
            {
                Id = 2,
                Name = "Pumpers #2",
                Brand = "Pumpers",
                Humidity = 45,
                Temperature = 6
            },

            new Diaper
            {
                Id = 3,
                Name = "Pumpers #3",
                Brand = "Pumpers",
                Humidity = 33,
                Temperature = 9
            }
        };

        public static List<Sector> Sectors = new List<Sector>
        {
            new Sector
            {
                Id = 1,
                Name = "Enfermaria #1",
                Beds = new List<Bed>
                {
                    new Bed
                    {
                        Id = 1,
                        Name = "Leito #1",
                        SectorId = 1
                    },

                    new Bed
                    {
                        Id = 2,
                        Name = "Leito #2",
                        SectorId = 1
                    }
                }
            },

            new Sector
            {
                Id = 2,
                Name = "Enfermaria #2",
                Beds = new List<Bed>
                {
                    new Bed
                    {
                        Id = 3,
                        Name = "Leito #3",
                        SectorId = 2
                    },

                    new Bed
                    {
                        Id = 4,
                        Name = "Leito #4",
                        SectorId = 2
                    },

                    new Bed
                    {
                        Id = 5,
                        Name = "Leito #5",
                        SectorId = 2
                    }
                }
            },

            new Sector
            {
                Id = 3,
                Name = "Quartos Corredor #1",
                Beds = new List<Bed>
                {
                    new Bed
                    {
                        Id = 6,
                        Name = "Leito #6",
                        SectorId = 3
                    }
                }
            }
        };

        // Macs containing Id = 0 are availables
        public static List<Mac> Macs = new List<Mac>
        {
            new Mac
            {
                Id = 0,
                Code = "38-B1-DB-CD-04-29"
            },

            new Mac
            {
                Id = 0,
                Code = "83-B4-DY-PP-44-22"
            },

             new Mac
            {
                Id = 1,
                Code = "00-AA-BB-CC-11-22"
            }
        };

        public static List<Device> Devices = new List<Device>
        {
            new Device
            {
                Id = 1,
                Name = "Dispositivo #1",
                Humidity = 50,
                Temperature = 3,
                Enable = true,
                Active = false,
                DiaperId = 1,
                Diaper = ModelData.Diapers.Where(d => d.Id == 1).FirstOrDefault(),
                MacId = ModelData.Macs.Count + 1,
                Mac = ModelData.Macs.Where(m => m.Id == 1).FirstOrDefault(),
                BedId = 1,
                Bed = ModelData.Sectors.Where(s => s.Id == 1).FirstOrDefault().Beds.Where(b => b.Id == 1).FirstOrDefault()
            }
        };

    }
}