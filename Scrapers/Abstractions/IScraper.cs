using System.Threading.Tasks;
using Beetroot.RecruitingBot.Scrapers.Models;

namespace Beetroot.RecruitingBot.Scrapers.Abstractions
{
    public interface IScraper
    {
        Task<PublishedVacancies> GetVacanciesAsync();
    }
}