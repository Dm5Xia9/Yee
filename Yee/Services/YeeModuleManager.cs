using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Intrinsics.Arm;
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
                if (buffer.Any(p => p.Assembly == module.Assembly))
                    continue;

                AlignmentTree(module, buffer);
            }

            return buffer;
        }
        private void AlignmentTree(BaseYeeModule module, List<BaseYeeModule> buffer = null)
        {
            if (buffer == null)
                buffer = new List<BaseYeeModule>();

            if (module.Deps != null && module.Deps.Any())
            {
                foreach (var dep in module.Deps)
                {
                    if (buffer.Any(p => p.Assembly == dep.Assembly))
                        continue;

                    AlignmentTree(dep, buffer);
                }
            }
            buffer.Add(module);

        }
    }
}
