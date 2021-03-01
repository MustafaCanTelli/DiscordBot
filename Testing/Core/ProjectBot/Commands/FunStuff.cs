using DataAccess.Model;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using ProjectBot.Handlers.Dialogue;
using ProjectBot.Handlers.Steps;
using ProjectBot.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBot.Commands
{
    public class FunStuff : BaseCommandModule
    {
        private readonly ICategoryService _ct;
        public FunStuff(ICategoryService ct)
        {
            _ct = ct;
        }

        [Command("AddCategory")]
        public async Task AddCategory(CommandContext ctx)
        {
            var categoryDesciption = new StringStep("Kategori hakkında bilgi girin", null);

            var categoryName = new StringStep("Kategori name ne olucak ?", null);

            var category = new Category();
            category.ServerID = ctx.Guild.Id;
            category.DiscordID = ctx.User.Id;
            categoryName.OnValidResult += (result) => category.CategoryName = result;
            categoryName.OnValidResult += (result) => category.Descriptoin = result;

            var inputDialogueHandler = new Dialogue(ctx.Client, ctx.Channel, ctx.User, categoryName);

            bool succeeded = await inputDialogueHandler.ProccessDialogue().ConfigureAwait(false);

            if (!succeeded) { return; }

            await _ct.AddCategoryAsync(category).ConfigureAwait(false);

            await ctx.Channel.SendMessageAsync($" {category.CategoryName} Başarı ile oluşturuldu!").ConfigureAwait(false);
        }



        [Command("ping")]
        [Description("Returns pong")]        
        public async Task Ping(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("Pong").ConfigureAwait(false);
        }


    }
}
