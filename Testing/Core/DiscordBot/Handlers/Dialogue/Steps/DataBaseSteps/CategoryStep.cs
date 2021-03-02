using DataAccess.Model;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity.Extensions;
using Service.IService;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscordBot.Handlers.Dialogue.Steps.DataBaseSteps
{
    public class CategoryStep : DialogueStepBase
    {
        private readonly int? _minLength;
        private readonly int? _maxLength;
        private IDialogueStep _nextStep;
        private readonly ICategoryService _categoryService;       
      


        public CategoryStep(string content, IDialogueStep nextStep, ICategoryService categoryService, int? minLength = null, int? maxLength = null) : base(content)
        {
            _nextStep = nextStep;
            _minLength = minLength;
            _maxLength = maxLength;
            _categoryService = categoryService;
           
        }

        public override IDialogueStep NextStep => _nextStep;


        public Action<int> OnValidResult { get; set; } = delegate { };

        public override async Task<bool> ProcessStep(DiscordClient client, DiscordChannel channel, DiscordUser user)
        {


            var embedBuilder = new DiscordEmbedBuilder
            {
                Title = _content,
                Description = $"{user.Mention}Cevap Bekleniyor...",
            };
           
            var categories = _categoryService.ActiveCategories();

            var listCategory = string.Empty;
            foreach (var item in categories)
            {
                listCategory += item.CategoryName + "\n";

            }
            

            embedBuilder.AddField("Kategoriler", listCategory);

            embedBuilder.AddField("İptal Etmek için..", "!iptal yazmana yeterli.");

            if (_minLength.HasValue)
            {
                embedBuilder.AddField("Min karakter sayısı :", $"{_minLength.Value} ");
            }
            if (_maxLength.HasValue)
            {
                embedBuilder.AddField("Max karekter sayısı:", $"{_maxLength.Value} ");
            }

            var interactivity = client.GetInteractivity();

            while (true)
            {
                var embed = await channel.SendMessageAsync(embedBuilder).ConfigureAwait(false);

                OnMessageAdded(embed);

                var messageResult = await interactivity.WaitForMessageAsync(
                    x => x.ChannelId == channel.Id && x.Author.Id == user.Id).ConfigureAwait(false);

                OnMessageAdded(messageResult.Result);

                if (messageResult.Result.Content.Equals("!iptal", StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }

                if (_minLength.HasValue)
                {
                    if (messageResult.Result.Content.Length < _minLength.Value)
                    {
                        await TryAgain(channel, $"Girilen karakter sayısı {_minLength.Value - messageResult.Result.Content.Length} Min uzunluktan az").ConfigureAwait(false);
                        continue;
                    }
                }
                if (_maxLength.HasValue)
                {
                    if (messageResult.Result.Content.Length > _maxLength.Value)
                    {
                        await TryAgain(channel, $"Girilen karakter sayısı {messageResult.Result.Content.Length - _maxLength.Value} Max uzunlıktan fazla").ConfigureAwait(false);
                        continue;
                    }
                }

                var categoryName = messageResult.Result.Content;

                Category category = _categoryService.GetByName(categoryName);

                OnValidResult(category.CategoryId);
                return false;
            }
        }
    }
}
