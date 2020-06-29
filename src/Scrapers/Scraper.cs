using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Beetroot.RecruitingBot.Scrapers.Abstractions;
using Beetroot.RecruitingBot.Scrapers.Converters;
using Beetroot.RecruitingBot.Scrapers.Models;
using Beetroot.RecruitingBot.Scrapers.Settings;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Rest.TransientFaultHandling;
using Newtonsoft.Json;

namespace Beetroot.RecruitingBot.Scrapers
{
    public class Scraper : IScraper
    {
        private const string VacanciesUrl = "{0}/companies/{1}/published-vacancies";
        private const string SingleVacancyUrl = "{0}/vacancy?id={1}";
        private const string AllCitiesUrl = "{0}/dictionary/city";
        private readonly HttpClient _client;
        private readonly ILogger<Scraper> _logger;
        private readonly ScraperSettings _settings;

        public Scraper(HttpClient client, IOptions<ScraperSettings> options,
            ILogger<Scraper> logger)
        {
            _client = client;
            _settings = options?.Value;
            _logger = logger;
        }

        public async Task<PublishedVacancies> GetVacanciesAsync(string cityId = null)
        {
            var url = string.Format(VacanciesUrl, _settings.Host, _settings.CompanyId);
            if (cityId != null)
                url += $"?cityId={cityId}";
            var result = await GetDeserializedAsync<PublishedVacancies>(url);
            return result;
        }

        public async Task<List<SingleCity>> GetCitiesHaveVacanciesAsync()
        {
            var result = new List<SingleCity>();
            var url = string.Format(AllCitiesUrl, _settings.Host);
            var vacancies = await GetVacanciesAsync();
            if (vacancies.CityIdsWhereVacanciesPublished.Any())
            {
                var allCities = await GetDeserializedAsync<List<SingleCity>>(url);
                result = allCities
                    .Where(x => vacancies.CityIdsWhereVacanciesPublished.Any(z => z == x.Id))
                    .ToList();
            }

            return result;
        }

        public async Task<SingleVacancy> GetSingleVacancyAsync(string vacancyId)
        {
            var url = string.Format(SingleVacancyUrl, _settings.Host, vacancyId);
            var result = await GetDeserializedAsync<SingleVacancy>(url);
            return result;
        }

        private async Task<T> GetDeserializedAsync<T>(string url)
        {
            var request = new HttpRequestMessage();
            request.Headers.Add("Accept", "application/json");

            var response = await _client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                throw new HttpRequestWithStatusException($"Status code: {response.StatusCode}");

            var json = await response.Content.ReadAsStringAsync();
            _logger.LogTrace(json);
            var result = JsonConvert.DeserializeObject<T>(json, Converter.Settings);

            return await Task.FromResult(result);
        }
    }
}