using System;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Beetroot.RecruitingBot.Models;
using Beetroot.RecruitingBot.Settings;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Beetroot.RecruitingBot.Scrappers
{
    public class RabotaUaScrapper
    {
        private readonly HttpClient _client;
        private readonly RabotaUaApiSettings _settings;
        private readonly ILogger<RabotaUaScrapper> _logger;

        public RabotaUaScrapper(HttpClient client, IOptions<RabotaUaApiSettings> options,
            ILogger<RabotaUaScrapper> logger)
        {
            _client = client;
            _settings = options?.Value;
            _logger = logger;
        }

        public async Task<PublishedVacancies> GetVacanciesAsync()
        {
            var request = new HttpRequestMessage();
            request.Headers.Add("Accept", "application/json");
            _settings.VacanciesUri = "https://api.rabota.ua/companies/2010137/published-vacancies";
            var response = await _client.GetAsync(_settings.VacanciesUri);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                _logger.LogTrace(json);
                var result = PublishedVacancies.FromJson(json);
                return await Task.FromResult(result);
            }
            else
            {
                throw  new NetworkInformationException();
            }
        }
    }
}