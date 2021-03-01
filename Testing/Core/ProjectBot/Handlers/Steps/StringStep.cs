using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity.Extensions;
using ProjectBot.Handlers.Dialogue.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBot.Handlers.Steps
{
    public class StringStep : DialogueStepBase
    {
        private readonly int? _minLength;
        private readonly int? _maxLength;
        private readonly IDialogueStep _nextStep;

        public StringStep(string content, IDialogueStep nextStep, int? minLength = null, int? maxLength = null) : base(content)
        {
            _nextStep = nextStep;
            _minLength = minLength;
            _maxLength = maxLength;
            
        }

        public Action<string> OnValidResult { get; set; } = delegate { };

        public override IDialogueStep NextStep => _nextStep;

        public override async Task<bool> ProcessStep(DiscordClient client, DiscordChannel channel, DiscordUser user)
        {
            var embedBuilder = new DiscordEmbedBuilder
            {
                Title = "Cevap Bekleniyor",
                Description = $"{user.Mention}  {_content}",
                Color = DiscordColor.Green,
            };

            embedBuilder.AddField("Diyaloğu iptal emek istiyormusun ? ", " !iptal komutunu kullan.");

            if (_minLength.HasValue)
            {
                embedBuilder.AddField("Diyalok min karakter ile sınırlandırıldı", $" karakter sayısı : {_minLength.Value}");
            }
            if (_maxLength.HasValue)
            {
                embedBuilder.AddField("Diyalok max karakter ile sınırlandırıldı", $" karakter sayısı : {_minLength.Value}");

            }

            var interactivity = client.GetInteractivity();
            while (true)
            {
                var embed = await channel.SendMessageAsync(embedBuilder).ConfigureAwait(false);

                OnMessageAdded(embed);

                var messageResult = await interactivity.WaitForMessageAsync(x => x.Channel.Id == channel.Id && x.Author.Id == user.Id).ConfigureAwait(false);

                OnMessageAdded(messageResult.Result);

                if (messageResult.Result.Content.Equals("!iptal", StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }

                if(_minLength.HasValue)
                {
                    if (messageResult.Result.Content.Length < _minLength.Value)
                    {
                        await TryAgain(channel, $"Eksik karakter sayısı : {_minLength.Value - messageResult.Result.Content.Length}. Tekrar Dene").ConfigureAwait(false);
                        continue;
                    }
                }
                if (_maxLength.HasValue)
                {
                    if (messageResult.Result.Content.Length > _maxLength.Value)
                    {
                        await TryAgain(channel, $"Fazla karakter sayısı : {messageResult.Result.Content.Length - _maxLength.Value}. Tekrar Dene").ConfigureAwait(false);
                        continue;
                    }
                }

                OnValidResult(messageResult.Result.Content);
                return false;
            }

           
        }

    }
}
