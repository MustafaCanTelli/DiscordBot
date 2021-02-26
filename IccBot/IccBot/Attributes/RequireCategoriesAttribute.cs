using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IccBot.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple =false)]
    public class RequireCategoriesAttribute : CheckBaseAttribute
    {
        public IReadOnlyList<string> CategoryNames { get; }
        public ChannelCheckMode CheckMode { get; }
        public RequireCategoriesAttribute(ChannelCheckMode checkMode, params string[] channelNames)
        {
            CheckMode = checkMode;
            CategoryNames = new ReadOnlyCollection<string>(channelNames);
        }
        public override Task<bool> ExecuteCheckAsync(CommandContext ct, bool help)
        {
            if (ct.Guild == null && ct.Member == null)
            {
                return Task.FromResult(false);
            }
            bool contains = CategoryNames.Contains(ct.Channel.Parent.Name, StringComparer.OrdinalIgnoreCase);
            return CheckMode switch
            {
                ChannelCheckMode.Any => Task.FromResult(contains),
                ChannelCheckMode.None => Task.FromResult(!contains),
                _ => Task.FromResult(false),
            };
            throw new NotImplementedException();
        }
    }
}
