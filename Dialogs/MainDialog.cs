using Beetroot.RecruitingBot.Scrapers;
using Beetroot.RecruitingBot.Scrapers.Abstractions;
using Beetroot.RecruitingBot.Settings;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Extensions.Logging;

namespace Beetroot.RecruitingBot.Dialogs
{
    public class MainDialog : ComponentDialog
    {
        public MainDialog(IScraper scrapper, ILogger<RabotaUaScraper> logger) 
            : base(nameof(MainDialog))
        {
            var vacancies = scrapper.GetVacanciesAsync().Result;
            foreach (var item in vacancies.FilteredVacancies)
            {

            }
        }
    }
}