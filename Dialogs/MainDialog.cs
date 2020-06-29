using Beetroot.RecruitingBot.Scrapers;
using Beetroot.RecruitingBot.Scrapers.Abstractions;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Extensions.Logging;

namespace Beetroot.RecruitingBot.Dialogs
{
    public class MainDialog : ComponentDialog
    {
        public MainDialog(IScraper scrapper, ILogger<MainDialog> logger) 
            : base(nameof(MainDialog))
        {
            var cities = scrapper.GetCitiesHaveVacanciesAsync().Result;
        }
    }
}