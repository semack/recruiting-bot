using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Beetroot.RecruitingBot.Models
{
    public partial class PublishedVacancies
    {
        [JsonProperty("cityIdsWhereVacanciesPublished")]
        public List<long> CityIdsWhereVacanciesPublished { get; set; }

        [JsonProperty("rubricIdsWhereVacanciesPublished")]
        public List<long> RubricIdsWhereVacanciesPublished { get; set; }

        [JsonProperty("filteredVacancies")]
        public List<FilteredVacancy> FilteredVacancies { get; set; }

        [JsonProperty("totalVacanciesCount")]
        public long TotalVacanciesCount { get; set; }
    }

    public class FilteredVacancy
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("date")]
        public DateTimeOffset Date { get; set; }

        [JsonProperty("dateTxt")]
        public string DateTxt { get; set; }

        [JsonProperty("salary")]
        public long Salary { get; set; }

        [JsonProperty("cityId")]
        public long CityId { get; set; }

        [JsonProperty("isHot")]
        public bool IsHot { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
    
    public partial class PublishedVacancies
    {
        public static PublishedVacancies FromJson(string json) => 
            JsonConvert.DeserializeObject<PublishedVacancies>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this PublishedVacancies self) => 
            JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}