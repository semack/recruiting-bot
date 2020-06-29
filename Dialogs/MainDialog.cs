using Beetroot.RecruitingBot.Scrappers;
using Beetroot.RecruitingBot.Settings;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Extensions.Logging;

namespace Beetroot.RecruitingBot.Dialogs
{
    public class MainDialog : ComponentDialog
    {
        public MainDialog(RabotaUaScrapper scrapper, ILogger<RabotaUaScrapper> logger) 
            : base(nameof(MainDialog))
        {
            var vacancies = scrapper.GetVacanciesAsync().Result;
            foreach (var item in vacancies.FilteredVacancies)
            {

            }
        }
    }
}