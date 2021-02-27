using DAL;
using DAL.Models.Icc;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IccBot.Commands
{


    public class TeamCommands : BaseCommandModule
    {
        private readonly IccDbContext _context;

        public TeamCommands(IccDbContext context)
        {
            _context = context;
        }


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

            var reaciton = await interactivity.WaitForReactionAsync(
                  x => x.Message == joinMessage &&
                 x.User == ct.User &&
                  (x.Emoji == ok || x.Emoji == no)).ConfigureAwait(false);

            if (reaciton.Result.Emoji == ok)
            {
                var xrole = ct.Guild.GetRole(814893130318348298);

                await ct.Member.GrantRoleAsync(xrole).ConfigureAwait(false);
            }
            else if (reaciton.Result.Emoji == no)
            {
                var rRole = ct.Guild.GetRole(814893130318348298);
                await ct.Member.RevokeRoleAsync(rRole);
            }

            await joinMessage.DeleteAsync();


        }

        [Command("AddProduct")]
        public async Task AddProduct(CommandContext ct, string name, string desciption, decimal price)
        {
            var split = desciption.Split('-');
            var total = string.Empty;
            foreach (var x in split)
            {
                total += x + " ";
            }

            await _context.Products.AddAsync(new Product
            {
                Name = name,
                Desciption = total,
                Price = price
            });
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        [Command("product")]
        public async Task Product(CommandContext ct, string name)
        {

            var products = await _context.Products.ToListAsync().ConfigureAwait(false);
            var productListesi = string.Empty;
            var des = string.Empty;
            var price = string.Empty;            
            foreach (var product in products)
            {
                
                productListesi += product.Name + "\n";
                des += product.Desciption + "\n";
                price += product.Price + "\n";
            }
            var joinEmbed = new DiscordEmbedBuilder
            {
                Title = "Ürünler",
                Description = "Categori ismi"
            };
            joinEmbed.AddField("Ürün Listesi", productListesi, true);
            joinEmbed.AddField("Açıklama", des, true);
            joinEmbed.AddField("Fiyat", price, true);
            


            var joinMessage = await ct.Channel.SendMessageAsync(joinEmbed).ConfigureAwait(false);


            //await ct.Channel.SendMessageAsync(product.Desciption).ConfigureAwait(false);
        }

    }
}
