using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Beetroot.RecruitingBot.Bots
{
    public class RecruiterBot<T> : DialogBot<T>
        where T : Dialog
    {
        public RecruiterBot(ConversationState conversationState, UserState userState, T dialog,
            ILogger<DialogBot<T>> logger)
            : base(conversationState, userState, dialog, logger)
        {
        }

        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded,
            ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            foreach (var member in membersAdded)
                // Greet anyone that was not the target (recipient) of this message.
                // To learn more about Adaptive Cards, see https://aka.ms/msbot-adaptivecards for more details.
                if (member.Id != turnContext.Activity.Recipient.Id)
                {
                    var welcomeCard = CreateAdaptiveCardAttachment();
                    var response = MessageFactory.Attachment(welcomeCard, ssml: "Welcome to Bot Framework!");
                    await turnContext.SendActivityAsync(response, cancellationToken);
                    await Dialog.RunAsync(turnContext, ConversationState.CreateProperty<DialogState>("DialogState"),
                        cancellationToken);
                }
        }

        // Load attachment from embedded resource.
        private Attachment CreateAdaptiveCardAttachment()
        {
            var cardResourcePath = GetType().Assembly.GetManifestResourceNames()
                .First(name => name.EndsWith("welcomeCard.json"));

            using var stream = GetType().Assembly.GetManifestResourceStream(cardResourcePath);
            using var reader = new StreamReader(stream);
            var adaptiveCard = reader.ReadToEnd();
            return new Attachment
            {
                ContentType = "application/vnd.microsoft.card.adaptive",
                Content = JsonConvert.DeserializeObject(adaptiveCard)
            };
        }
    }
}