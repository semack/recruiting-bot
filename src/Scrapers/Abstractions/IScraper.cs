using System.Collections.Generic;
using System.Threading.Tasks;
using Beetroot.RecruitingBot.Scrapers.Models;

namespace Beetroot.RecruitingBot.Scrapers.Abstractions
{
    public interface IScraper
    {
        Task<PublishedVacancies> GetVacanciesAsync(string cityId = null);
        Task<SingleVacancy> GetSingleVacancyAsync(string vacancyId);
        Task<List<SingleCity>> GetCitiesHaveVacanciesAsync();
    }
}