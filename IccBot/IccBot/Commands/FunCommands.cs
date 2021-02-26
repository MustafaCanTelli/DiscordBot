using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity.Extensions;
using IccBot.Attributes;
using IccBot.Handlers.Dialogue;
using IccBot.Handlers.Dialogue.Steps;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IccBot.Commands
{
    public class FunCommands : BaseCommandModule
    {
        [Command("ping")]
        [Description("Sana Pong Diye Cevap Verir.")]
        [RequireCategories(ChannelCheckMode.Any, "Metin Kanalları")]
        public async Task Ping(CommandContext ct)
        {
            await ct.Channel.SendMessageAsync("Pong").ConfigureAwait(false);
        }

        [Command("Add")]
        [Description("2 Numara ver Toplasın")]
        [RequireRoles(RoleCheckMode.All)]

        public async Task Add(CommandContext ct, [Description("Numara 1")] int n1, [Description("Numara 2")] int n2)
        {
            await ct.Channel
                .SendMessageAsync((n1 + n2).ToString())
                .ConfigureAwait(false);

        }
        [Command("responsemessage")]
        public async Task ResponseMessage(CommandContext ct)
        {
            var interactivity = ct.Client.GetInteractivity();

            var message = await interactivity.WaitForMessageAsync(x => x.Channel == ct.Channel).ConfigureAwait(false);

            await ct.Channel.SendMessageAsync(message.Result.Content);
        }

        [Command("responseReaction")]
        public async Task ResponseReaction(CommandContext ct)
        {
            var interactivity = ct.Client.GetInteractivity();

            var message = await interactivity.WaitForReactionAsync(x => x.Channel == ct.Channel && x.User==ct.User).ConfigureAwait(false);

            await ct.Channel.SendMessageAsync(message.Result.Emoji);
        }
        [Command("dialogue")]
        public async Task Dialogue(CommandContext ctx)
        {
            var inputStep = new TextStep("Enter something interesting!", null, 10);
            var funnyStep = new IntStep("Haha, funny", null, maxValue: 100);

            string input = string.Empty;
            int value = 0;

            inputStep.OnValidResult += (result) =>
            {
                input = result;

                if (result == "something interesting")
                {
                    inputStep.SetNextStep(funnyStep);
                }
            };

            funnyStep.OnValidResult += (result) => value = result;

            var userChannel = await ctx.Member.CreateDmChannelAsync().ConfigureAwait(false);

            var inputDialogueHandler = new DialogueHandler(
                ctx.Client,
                userChannel,
                ctx.User,
                inputStep
            );

            bool succeeded = await inputDialogueHandler.ProcessDialogue().ConfigureAwait(false);

            if (!succeeded) { return; }

            await ctx.Channel.SendMessageAsync(input).ConfigureAwait(false);

            await ctx.Channel.SendMessageAsync(value.ToString()).ConfigureAwait(false);
        }

        [Command("emojidialogue")]
        public async Task EmojiDialogue(CommandContext ctx)
        {
            var yesStep = new TextStep("You chose yes", null);
            var noStep = new IntStep("You chose no", null);

            var emojiStep = new ReactionStep("Yes Or No?", new Dictionary<DiscordEmoji, ReactionStepData>
            {
                { DiscordEmoji.FromName(ctx.Client, ":thumbsup:"), new ReactionStepData { Content = "This means yes", NextStep = yesStep } },
                { DiscordEmoji.FromName(ctx.Client, ":thumbsdown:"), new ReactionStepData { Content = "This means no", NextStep = noStep } }
            });

            var userChannel = await ctx.Member.CreateDmChannelAsync().ConfigureAwait(false);

            var inputDialogueHandler = new DialogueHandler(
                ctx.Client,
                userChannel,
                ctx.User,
                emojiStep
            );

            bool succeeded = await inputDialogueHandler.ProcessDialogue().ConfigureAwait(false);

            if (!succeeded) { return; }
        }

    }
}
