using Newtonsoft.Json;

namespace Beetroot.RecruitingBot.Scrapers.Models
{
    public class SingleCity
    {
        [JsonProperty("centerId")]
        public long CenterId { get; set; }

        [JsonProperty("centerName")]
        public string CenterName { get; set; }

        [JsonProperty("regionName")]
        public object RegionName { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("ru")]
        public string Ru { get; set; }

        [JsonProperty("ua")]
        public string Ua { get; set; }

        [JsonProperty("en")]
        public string En { get; set; }
    }
}