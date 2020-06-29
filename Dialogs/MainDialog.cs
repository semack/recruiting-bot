using System.Threading;
using System.Threading.Tasks;
using Beetroot.RecruitingBot.Scrapers.Abstractions;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;
using Microsoft.Extensions.Logging;

namespace Beetroot.RecruitingBot.Dialogs
{
    public class MainDialog : ComponentDialog
    {
        public MainDialog(IScraper scrapper, ILogger<MainDialog> logger) 
            : base(nameof(MainDialog))
        {
            var cities = scrapper.GetCitiesHaveVacanciesAsync().Result;
            Dialogs.Add(new TextPrompt(nameof(TextPrompt)));
            
            var waterfallSteps = new WaterfallStep[]
            {
                IntroStepAsync,
            };
            AddDialog(new WaterfallDialog(nameof(WaterfallDialog), waterfallSteps));
            InitialDialogId = nameof(WaterfallDialog);
        }

        private async Task<DialogTurnResult> IntroStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            var messageText = stepContext.Options?.ToString() ?? "What can I help you with today?\nSay something like \"Book a flight from Paris to Berlin on March 22, 2020\"";
            var promptMessage = MessageFactory.Text(messageText, messageText, InputHints.ExpectingInput);
            return await stepContext.PromptAsync(nameof(TextPrompt), new PromptOptions { Prompt = promptMessage }, cancellationToken);
        }
    }
}