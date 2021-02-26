using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IccBot.Commands
{

    
    public class TeamCommands : BaseCommandModule
    {
        [Command("join")]
        [Cooldown(1, 10, CooldownBucketType.Channel)]
        public async Task Join(CommandContext ct)
        {
            var joinEmbed = new DiscordEmbedBuilder
            {
                Title = "Katılmak istermisin?",
                ImageUrl = ct.Client.CurrentUser.AvatarUrl,
                Description = "Dalanı yerim gel"
            };
           var joinMessage = await ct.Channel.SendMessageAsync(joinEmbed).ConfigureAwait(false);

            var ok = DiscordEmoji.FromName(ct.Client, ":+1:");
            var no = DiscordEmoji.FromName(ct.Client, ":-1:");

            await joinMessage.CreateReactionAsync(ok).ConfigureAwait(false);
            await joinMessage.CreateReactionAsync(no).ConfigureAwait(false);

            var interactivity = ct.Client.GetInteractivity();

          var reaciton =  await interactivity.WaitForReactionAsync(
                x => x.Message == joinMessage &&
               x.User == ct.User &&
                (x.Emoji == ok || x.Emoji == no)).ConfigureAwait(false);

            if (reaciton.Result.Emoji == ok)
            {
                var xrole = ct.Guild.GetRole(814893130318348298);   
                
                await ct.Member.GrantRoleAsync(xrole).ConfigureAwait(false);
            }
            else if (reaciton.Result.Emoji==no)
            {
                var rRole = ct.Guild.GetRole(814893130318348298);
                await ct.Member.RevokeRoleAsync(rRole);
            }

            await joinMessage.DeleteAsync();
            

        }

    }
}
