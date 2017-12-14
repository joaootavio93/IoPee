using Newtonsoft.Json;
using System.Collections.Generic;

namespace IoPee.Data
{
    public class DeviceListJson
    {
        [JsonProperty("devices")]
        public List<DeviceJson> devices { get; set; }
    }
}