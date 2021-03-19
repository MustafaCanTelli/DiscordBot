using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscordBot.Controllers
{
    public class HomeController : Controller
    {
       public static DiscordEmbedBuilder testEmbedController;

        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Index(TestEmbed embed)
        {
            
            
            //testEmbedController = new DiscordEmbedBuilder
            //{
            //    Title = embed.Title,
            //    Description = embed.Description,
            //};

            //foreach (var field in embed.EmbedFields)
            //{

            //}
            //testEmbedController.AddField(embed.EmbedFields.,embed.value,embed.Inline);

            return View();
        }


        public IActionResult Embed()
        {
            return View();
        }
      

        [HttpPost]
        public IActionResult Embed(TestEmbed embed)
        {
            testEmbedController = new DiscordEmbedBuilder
            {
                Title = embed.Title,
                Description = embed.Description
            };

            for (int i = 0; i < embed.EmbedFields.Count; i++)
            {
                testEmbedController.AddField(
                    embed.EmbedFields[i].FieldName,
                    embed.EmbedFields[i].Value,
                    embed.EmbedFields[i].InLine);
            }

            

            return View();
        }
    }
}
