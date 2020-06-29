using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Beetroot.RecruitingBot.Scrapers.Models
{
    public class SingleVacancy
    {
        [JsonProperty("id")] public long Id { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("logo")] public string Logo { get; set; }

        [JsonProperty("designBannerUrl")] public string DesignBannerUrl { get; set; }

        [JsonProperty("designBannerFullUrl")] public string DesignBannerFullUrl { get; set; }

        [JsonProperty("notebookId")] public long NotebookId { get; set; }

        [JsonProperty("companyName")] public string CompanyName { get; set; }

        [JsonProperty("verifiedCompany")] public bool VerifiedCompany { get; set; }

        [JsonProperty("contactPerson")] public string ContactPerson { get; set; }

        [JsonProperty("contactPhone")] public string ContactPhone { get; set; }

        [JsonProperty("contactUrl")] public string SingleVacancyContactUrl { get; set; }

        [JsonProperty("contactURL")] public string ContactUrl { get; set; }

        [JsonProperty("date")] public DateTimeOffset Date { get; set; }

        [JsonProperty("dateTxt")] public string DateTxt { get; set; }

        [JsonProperty("isActive")] public bool IsActive { get; set; }

        [JsonProperty("isLiked")] public bool IsLiked { get; set; }

        [JsonProperty("isAgency")] public bool IsAgency { get; set; }

        [JsonProperty("noCvApply")] public bool NoCvApply { get; set; }

        [JsonProperty("isApply")] public bool IsApply { get; set; }

        [JsonProperty("applyDate")] public DateTimeOffset? ApplyDate { get; set; }

        [JsonProperty("isApplyViewed")] public bool IsApplyViewed { get; set; }

        [JsonProperty("isEnableImage")] public bool IsEnableImage { get; set; }

        [JsonProperty("isShowMiniProf")] public bool IsShowMiniProf { get; set; }

        [JsonProperty("salary")] public long Salary { get; set; }

        [JsonProperty("salaryComment")] public string SalaryComment { get; set; }

        [JsonProperty("hot")] public bool Hot { get; set; }

        [JsonProperty("formApplyCustomUrl")] public string FormApplyCustomUrl { get; set; }

        [JsonProperty("description")] public string Description { get; set; }

        [JsonProperty("branchId")] public long BranchId { get; set; }

        [JsonProperty("branchName")] public string BranchName { get; set; }

        [JsonProperty("cityId")] public long CityId { get; set; }

        [JsonProperty("cityName")] public string CityName { get; set; }

        [JsonProperty("vacancyAddress")] public string VacancyAddress { get; set; }

        [JsonProperty("districtId")] public long DistrictId { get; set; }

        [JsonProperty("districtName")] public string DistrictName { get; set; }

        [JsonProperty("metroId")] public long MetroId { get; set; }

        [JsonProperty("metroName")] public string MetroName { get; set; }

        [JsonProperty("metroBranchId")] public long MetroBranchId { get; set; }

        [JsonProperty("isShowMap")] public bool IsShowMap { get; set; }

        [JsonProperty("latitude")] public long Latitude { get; set; }

        [JsonProperty("longitude")] public long Longitude { get; set; }

        [JsonProperty("publicationType")] public string PublicationType { get; set; }

        [JsonProperty("customDesign")] public CustomDesign CustomDesign { get; set; }

        [JsonProperty("profLevelId")] public long ProfLevelId { get; set; }

        [JsonProperty("scheduleId")] public long ScheduleId { get; set; }

        [JsonProperty("dataSource")] public string DataSource { get; set; }

        [JsonProperty("languages")] public List<Language> Languages { get; set; }

        [JsonProperty("images")] public List<Image> Images { get; set; }

        [JsonProperty("mediaItems")] public List<Image> MediaItems { get; set; }

        [JsonProperty("searchTags")] public List<SearchTag> SearchTags { get; set; }

        [JsonProperty("clusters")] public List<Cluster> Clusters { get; set; }

        [JsonProperty("badges")] public List<Badge> Badges { get; set; }
    }

    public class Badge
    {
        [JsonProperty("id")] public long Id { get; set; }

        [JsonProperty("name")] public string Name { get; set; }
    }

    public class Cluster
    {
        [JsonProperty("id")] public long Id { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("groups")] public List<Badge> Groups { get; set; }
    }

    public class CustomDesign
    {
        [JsonProperty("headerInfo")] public HeaderInfo HeaderInfo { get; set; }

        [JsonProperty("footerInfo")] public FooterInfo FooterInfo { get; set; }

        [JsonProperty("backgroundHtml")] public string BackgroundHtml { get; set; }
    }

    public class FooterInfo
    {
        [JsonProperty("imageUrl")] public string ImageUrl { get; set; }
    }

    public class HeaderInfo
    {
        [JsonProperty("mediaItems")] public List<MediaItem> MediaItems { get; set; }

        [JsonProperty("videoPlayButtonImageUrl")]
        public string VideoPlayButtonImageUrl { get; set; }
    }

    public class MediaItem
    {
        [JsonProperty("url")] public string Url { get; set; }

        [JsonProperty("videoCoverImageUrl")] public string VideoCoverImageUrl { get; set; }

        [JsonProperty("type")] public string Type { get; set; }
    }

    public class Image
    {
        [JsonProperty("url")] public string Url { get; set; }

        [JsonProperty("type")] public string Type { get; set; }

        [JsonProperty("description")] public string Description { get; set; }
    }

    public class Language
    {
        [JsonProperty("levelId")] public long LevelId { get; set; }

        [JsonProperty("languageId")] public long LanguageId { get; set; }

        [JsonProperty("description")] public string Description { get; set; }
    }

    public class SearchTag
    {
        [JsonProperty("id")] public long Id { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("synonymGroupId")] public long SynonymGroupId { get; set; }

        [JsonProperty("rate")] public long Rate { get; set; }

        [JsonProperty("vacancySearchCount")] public long VacancySearchCount { get; set; }
    }
}