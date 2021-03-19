using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscordBot.Controllers
{
    public class TestEmbed
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public List<EmbedField> EmbedFields { get; set; }


    }
}
