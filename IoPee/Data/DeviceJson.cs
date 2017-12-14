using Newtonsoft.Json;

namespace IoPee.Data
{
    public class DeviceJson
    {
        [JsonProperty("CurrentTime")]
        public string CurrentTime { get; set; }
        [JsonProperty("Humidity")]
        public string Humidity { get; set; }
        [JsonProperty("LastChange")]
        public string LastChange { get; set; }
        [JsonProperty("LastUpdate")]
        public string LastUpdate { get; set; }
        [JsonProperty("MacId")]
        public string MacId { get; set; }
        [JsonProperty("Temperature")]
        public string Temperature { get; set; }
        [JsonProperty("id")]
        public string id { get; set; }
    }
}