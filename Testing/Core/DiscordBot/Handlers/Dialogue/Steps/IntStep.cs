using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;
using System;
using System.Threading.Tasks;

namespace DiscordBot.Handlers.Dialogue.Steps
{
    public class IntStep : DialogueStepBase
    {
        private readonly int? _minValue;
        private readonly int? _maxValue;

        private IDialogueStep _nextStep;

        public IntStep(string content,IDialogueStep nextStep,int? minValue = null,int? maxValue = null) : base(content)
        {
            _nextStep = nextStep;
            _minValue = minValue;
            _maxValue = maxValue;
        }

        public Action<int> OnValidResult { get; set; } = delegate { };

        public override IDialogueStep NextStep => _nextStep;

        public void SetNextStep(IDialogueStep nextStep)
        {
            _nextStep = nextStep;
        }

        public override async Task<bool> ProcessStep(DiscordClient client, DiscordChannel channel, DiscordUser user)
        {
            var embedBuilder = new DiscordEmbedBuilder
            {
                Title = _content,
                Description = $"{user.Mention}Cevap Bekleniyor...",
            };

            embedBuilder.AddField("İptal etmek için.. ", "!iptal yazabilirsin.");

            if (_minValue.HasValue)
            {
                embedBuilder.AddField("Min Value:", $"{_minValue.Value}");
            }
            if (_maxValue.HasValue)
            {
                embedBuilder.AddField("Max Value:", $"{_maxValue.Value}");
            }

            var interactivity = client.GetInteractivity();

            while (true)
            {
                var embed = await channel.SendMessageAsync(embed: embedBuilder).ConfigureAwait(false);

                OnMessageAdded(embed);

                var messageResult = await interactivity.WaitForMessageAsync(
                    x => x.ChannelId == channel.Id && x.Author.Id == user.Id).ConfigureAwait(false);

                OnMessageAdded(messageResult.Result);

                if (messageResult.Result.Content.Equals("!iptal", StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }

                if (!int.TryParse(messageResult.Result.Content, out int inputValue))
                {
                    await TryAgain(channel, $"Rakam girmen gerekiyor..").ConfigureAwait(false);
                    continue;
                }

                if (_minValue.HasValue)
                {
                    if (inputValue < _minValue.Value)
                    {
                        await TryAgain(channel, $"Girilen değer : {inputValue}, Min değerden küçük : {_minValue}").ConfigureAwait(false);
                        continue;
                    }
                }
                if (_maxValue.HasValue)
                {
                    if (inputValue > _maxValue.Value)
                    {
                        await TryAgain(channel, $"Girilen değer : {inputValue}, Max değerden büyük : {_maxValue}").ConfigureAwait(false);
                        continue;
                    }
                }

                OnValidResult(inputValue);

                return false;
            }
        }
    }
}
