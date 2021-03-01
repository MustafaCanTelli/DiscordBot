using DSharpPlus;
using DSharpPlus.Entities;
using ProjectBot.Handlers.Dialogue.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBot.Handlers.Dialogue
{
    public class Dialogue
    {
        private readonly DiscordClient _client;
        private readonly DiscordChannel _channel;
        private readonly DiscordUser _user;
        private IDialogueStep _currentStep;

        public Dialogue(DiscordClient client,DiscordChannel channel,DiscordUser user,IDialogueStep step)
        {
            _client = client;
            _channel = channel;
            _user = user;
            _currentStep = step;
        }

        private readonly List<DiscordMessage> messages = new List<DiscordMessage>();

        public async Task<bool> ProccessDialogue()
        {
            while (_currentStep !=null )
            {
                _currentStep.OnMessageAdded += (message) => messages.Add(message);

                bool cancled = await _currentStep.ProcessStep(_client, _channel, _user).ConfigureAwait(false);

                if (cancled)
                {
                    await DeleteMessages().ConfigureAwait(false);

                    var cancelEmbed = new DiscordEmbedBuilder
                    {
                        Title = "İşlem İptal Edildi",
                        Description = _user.Mention,
                        Color = DiscordColor.Red
                    };

                    await _channel.SendMessageAsync(cancelEmbed).ConfigureAwait(false);

                    return false;
                }

                _currentStep = _currentStep.NextStep;
            }
            await DeleteMessages().ConfigureAwait(false);

            return true;
        }

        private async Task DeleteMessages()
        {
            if (_channel.IsPrivate) { return; }

            foreach (var message in messages)
            {
                await message.DeleteAsync().ConfigureAwait(false);
            }
            
        }
    }
}
