using DataAccess.Model;
using DiscordBot.Handlers.Dialogue;
using DiscordBot.Handlers.Dialogue.Steps;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscordBot.Commands
{
    public class CategoryCommands : BaseCommandModule
    {
        private readonly ICategoryService _categoryService;

        public CategoryCommands(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [Command("AddCategory")]
        public async Task AddCategory(CommandContext ctx)
        {
            await ctx.Message.DeleteAsync();

            var categoyDescriptonStep = new TextStep("Lütfen Kategori Açıklaması Yazın", null);

            var categoryNameStep = new TextStep("Lütfen Kategori Adını Yazın.", categoyDescriptonStep);

            var category = new Category();           
            category.ServerID = ctx.Guild.Id;
            category.DiscordID = ctx.User.Id;

            categoryNameStep.OnValidResult += (result) => category.CategoryName = result;
            categoyDescriptonStep.OnValidResult += (result) => category.Descriptoin = result;

            var inputDialogueHandler = new DialogueHandler(
                ctx.Client,
                ctx.Channel,
                ctx.User,
                categoryNameStep
            );
            bool succeeded = await inputDialogueHandler.ProcessDialogue().ConfigureAwait(false);

            if (!succeeded) { return; }

            await _categoryService.AddCategory(category).ConfigureAwait(false);

            await ctx.Channel.SendMessageAsync($"{category.CategoryName} Kategorisi Oluşturuldu...").ConfigureAwait(false);
        }
    }
}
