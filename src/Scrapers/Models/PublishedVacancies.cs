using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Beetroot.RecruitingBot.Scrapers.Models
{
    public class PublishedVacancies
    {
        [JsonProperty("cityIdsWhereVacanciesPublished")]
        public List<long> CityIdsWhereVacanciesPublished { get; set; }

        [JsonProperty("rubricIdsWhereVacanciesPublished")]
        public List<long> RubricIdsWhereVacanciesPublished { get; set; }

        [JsonProperty("filteredVacancies")] public List<FilteredVacancy> FilteredVacancies { get; set; }

        [JsonProperty("totalVacanciesCount")] public long TotalVacanciesCount { get; set; }
    }

    public class FilteredVacancy
    {
        [JsonProperty("id")] public long Id { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("date")] public DateTimeOffset Date { get; set; }

        [JsonProperty("dateTxt")] public string DateTxt { get; set; }

        [JsonProperty("salary")] public long Salary { get; set; }

        [JsonProperty("cityId")] public long CityId { get; set; }

        [JsonProperty("isHot")] public bool IsHot { get; set; }

        [JsonProperty("description")] public string Description { get; set; }
    }
}