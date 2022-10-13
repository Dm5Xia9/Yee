using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Yee.Abstractions;
using Yee.Extensions;

namespace Yee.Services
{
    public class YeeModuleManager
    {
        public YeeModuleManager(IEnumerable<BaseYeeModule> modules)
        {
            Modules = modules;
        }

        public IEnumerable<BaseYeeModule> Modules { get; private set; }

        public void HandlersFromId<T>(string id, T buffer)
        {
            var ff = ToAlignmentTrees();
            foreach (var module in ToAlignmentTrees().Where(p => p.Builder.ContainsKey(id)))
            {
                YeeBuilderHandler.Go(module.Builder, id, buffer);
            }
        }

        public IEnumerable<BaseYeeModule> ToAlignmentTrees()
        {
            return AlignmentTrees(Modules);
        }

        private List<BaseYeeModule> AlignmentTrees(IEnumerable<BaseYeeModule> modules)
        {
            List<BaseYeeModule> buffer = new List<BaseYeeModule>();

            foreach (var module in modules)
            {
                buffer.AddRange(AlignmentTree(module));
            }

            return buffer;
        }
        private List<BaseYeeModule> AlignmentTree(BaseYeeModule module, List<BaseYeeModule> buffer = null)
        {
            if (buffer == null)
                buffer = new List<BaseYeeModule>();

            if (module.Deps != null && module.Deps.Any())
            {
                foreach (var dep in module.Deps)
                {
                    buffer.AddRange(AlignmentTree(dep));
                }
            }
            buffer.Add(module);
            return buffer;

        }
    }
}
