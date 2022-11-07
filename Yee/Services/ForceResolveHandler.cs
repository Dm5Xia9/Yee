using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Abstractions;
using Yee.Extensions;

namespace Yee.Services
{
    public class ForceResolveHandler : IForceHandler
    {
        private readonly IServiceProvider _serviceProvider;

        public ForceResolveHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void Up(IEnumerable<BaseYeeModule> modules)
        {
            foreach (var module in modules.Where(p => p.Builder.ContainsKey(YeeBuilderTags.Resolve)))
            {
                YeeBuilderHandler.Go(module.Builder, YeeBuilderTags.Resolve, _serviceProvider);
            }
        }
    }
}
