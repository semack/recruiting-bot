using System.Threading.Tasks;
using Beetroot.RecruitingBot.Models;

namespace Beetroot.RecruitingBot.Scrappers.Abstractions
{
    public interface IScraper
    {
        Task<PublishedVacancies> GetVacanciesAsync();
    }
}