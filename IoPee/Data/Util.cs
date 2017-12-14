using IoPee.Entities;
using System;
using System.Collections.Generic;

namespace IoPee.Data
{
    public static class Util
    {
        public readonly static double MaxHumidity = 978.0;
        public static List<Diaper> Diapers = new List<Diaper>();
        public static List<Sector> Sectors = new List<Sector>();
        public static List<Mac> Macs = new List<Mac>()
        {
            //new Mac
            //{
            //    Id = 0,
            //    Code = "teste",
            //    ExternalId = 1
            //}
        };

        public static List<Device> Devices = new List<Device>();

        public static int CalcHumidityPercentage(int humidity)
        {
            return (int)Math.Ceiling(100 * (MaxHumidity - humidity) / MaxHumidity);
        }

        public static int CalcHumidityPercentageNoInvert(int humidity)
        {
            return (int)Math.Ceiling(100 * humidity / MaxHumidity);
        }

        public static int CalcHumidity(int humidityPercent)
        {
            return (int)Math.Ceiling(MaxHumidity - (double)(humidityPercent) / 100 * MaxHumidity);
        }
    }
}