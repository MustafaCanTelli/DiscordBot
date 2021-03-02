using DataAccess.Model;
using DiscordBot.Handlers.Dialogue;
using DiscordBot.Handlers.Dialogue.Steps;
using DiscordBot.Handlers.Dialogue.Steps.DataBaseSteps;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscordBot.Commands
{
    public class ProductCommands : BaseCommandModule
    {
        private readonly IProductService _productService;

        private readonly ICategoryService _categoryService;
        IDialogueStep categoryId { get; }


        public ProductCommands(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }


        [Command("AddProduct")]
        public async Task AddProduct(CommandContext ctx)
        {
           await ctx.Message.DeleteAsync();

            var productCategory = new CategoryStep("Ürün Hangi Kategoride Olacak", null, _categoryService, null);
            var productStok = new IntStep("Ürün Stok Miktarı Ne Olacak", productCategory);
            var productPrice = new IntStep("Ürün Fiyatı Ne Olacak?", productStok);
            var productName = new TextStep("Ürün Adın Ne Olacak?", productPrice, null,20);


            Product product = new Product();
            product.DiscordID = ctx.User.Id;
            product.ServerID = ctx.Guild.Id;

            


            productName.OnValidResult += (result) => product.ProductName = result;
            productPrice.OnValidResult += (result) => product.UnitPrice = result;
            productStok.OnValidResult += (result) => product.UnitsInStock = result;
            productCategory.OnValidResult += (result) => product.CategoryId = result;

            //product.Category = productCategory.ProcessStep(ctx.Client, ctx.Channel,ctx.User);

            var inputDialogueHandler = new DialogueHandler(
                ctx.Client,
                ctx.Channel,
                ctx.User,
                productName
            );

            bool succeeded = await inputDialogueHandler.ProcessDialogue().ConfigureAwait(false);

            if (!succeeded) { return; }

            var categories = _categoryService.ActiveCategories();
            product.CategoryId = categories.Count;

            await _productService.AddProduct(product).ConfigureAwait(false);

            await ctx.Channel.SendMessageAsync($"{product.ProductName} Ürünü Oluşturuldu...").ConfigureAwait(false);






        }

        
        
    }

}
