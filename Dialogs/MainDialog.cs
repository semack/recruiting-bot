using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Beetroot.RecruitingBot.Scrapers.Abstractions;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Choices;
using Microsoft.Bot.Schema;
using Microsoft.Extensions.Logging;

namespace Beetroot.RecruitingBot.Dialogs
{
    public class MainDialog : ComponentDialog
    {
        private readonly IScraper _scrapper;

        public MainDialog(IScraper scrapper, ILogger<MainDialog> logger)
            : base(nameof(MainDialog))
        {
            _scrapper = scrapper;
            Dialogs.Add(new ConfirmPrompt(nameof(ConfirmPrompt)));
            Dialogs.Add(new ChoicePrompt(nameof(ChoicePrompt)));
            Dialogs.Add(new AttachmentPrompt(nameof(AttachmentPrompt)));
            var waterfallSteps = new WaterfallStep[]
            {
                AgreeForPurposesAsync,
                SelectCityAsync,
                SelectVacancyAsync,
                ShowVacancyAsync
            };
            AddDialog(new WaterfallDialog(nameof(WaterfallDialog), waterfallSteps));
            InitialDialogId = nameof(WaterfallDialog);
        }

        private async Task<DialogTurnResult> AgreeForPurposesAsync(WaterfallStepContext stepContext,
            CancellationToken cancellationToken)
        {
            var messageText = stepContext.Options?.ToString() ??
                              "We are recruiting! Do you want to review our vacancies?";
            var promptMessage = MessageFactory.Text(messageText, messageText, InputHints.ExpectingInput);
            var options = new PromptOptions
            {
                Prompt = promptMessage,
                RetryPrompt =
                    MessageFactory.Text("Sorry, I did not understand. Do u want me to continue this conversation?"),
                Style = ListStyle.SuggestedAction
            };
            return await stepContext.PromptAsync(nameof(ConfirmPrompt), options, cancellationToken);
        }

        private async Task<DialogTurnResult> SelectCityAsync(WaterfallStepContext stepContext,
            CancellationToken cancellationToken)
        {
            if (!(bool) stepContext.Result)
                return await stepContext.EndDialogAsync(cancellationToken: cancellationToken);

            var messageText = stepContext.Options?.ToString() ??
                              "Please choose  our office location are you looking for:";
            var promptMessage = MessageFactory.Text(messageText, messageText, InputHints.ExpectingInput);
            var options = new PromptOptions
            {
                Prompt = promptMessage,
                RetryPrompt =
                    MessageFactory.Text("Sorry, I did not understand. Do you want me to continue this conversation?"),
                Choices = (await _scrapper.GetCitiesHaveVacanciesAsync())
                    .Select(x => new Choice(x.Id.ToString())
                        {
                            Action = new CardAction(type: "messageBack",
                                title: x.En,
                                text:x.En,
                                displayText: x.En)
                        }

                    )
                    .ToList(),
                Style = ListStyle.Auto
            };
            return await stepContext.PromptAsync(nameof(ChoicePrompt), options, cancellationToken);
        }

        private async Task<DialogTurnResult> SelectVacancyAsync(WaterfallStepContext stepContext,
            CancellationToken cancellationToken)
        {
            var cityId = (stepContext.Result as FoundChoice)?.Value;
            var messageText = stepContext.Options?.ToString() ??
                              "Please choose vacancy you interested in:";
            var promptMessage = MessageFactory.Text(messageText, messageText, InputHints.AcceptingInput);
            var options = new PromptOptions
            {
                Prompt = promptMessage,
                RetryPrompt =
                    MessageFactory.Text("Sorry, I did not understand. Do you want me to continue this conversation?"),
                Choices = (await _scrapper.GetVacanciesAsync(cityId))
                    .FilteredVacancies
                    .Select(x => new Choice(x.Id.ToString())
                        {
                            Action = new CardAction(type: "messageBack",
                                title: x.Name,
                                displayText: x.Name, 
                                text: x.Name)
                        }
                    )
                    .ToList(),
                Style = ListStyle.HeroCard
            };
            return await stepContext.PromptAsync(nameof(ChoicePrompt), options, cancellationToken);
        }

        private async Task<DialogTurnResult> ShowVacancyAsync(WaterfallStepContext stepContext,
            CancellationToken cancellationToken)
        {
            var vacancyId = (stepContext.Result as FoundChoice)?.Value;
            var vacancy = await _scrapper.GetSingleVacancyAsync(vacancyId);
            return await stepContext.EndDialogAsync(cancellationToken: cancellationToken);
        }
    }
}