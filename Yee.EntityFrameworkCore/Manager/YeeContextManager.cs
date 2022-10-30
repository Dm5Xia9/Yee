using Ability.Core.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using Yee.Abstractions;
using Yee.Services;

namespace Yee.EntityFrameworkCore.Manager
{
    public class YeeContextManager
    {
        private readonly YeeModuleManager _yeeModuleManager;
        private readonly List<ModuleContextNode> _modules;
        public YeeContextManager(YeeModuleManager yeeModuleManager)
        {
            _yeeModuleManager = yeeModuleManager;
            _modules = new List<ModuleContextNode>();
            SearchDbContext(_yeeModuleManager.Modules, _modules);
        }

        public List<ModuleContextNode> EntityNodes => _modules;
        public List<ModuleContextNode> NormalizeNodes => AlignmentTrees(_modules);
        private void SearchDbContext(IEnumerable<BaseYeeModule> modules, 
            List<ModuleContextNode> nodes)
        {

            foreach (var module in modules)
            {
                var dbContext = module.Assembly
                    .GetTypes().FirstOrDefault(p => p
                    .GetInterfaces().Contains(typeof(IYeeDbContext)) 
                    && p.IsAbstract == false);

                if (dbContext == null)
                {
                    if(module.Deps != null)
                    {
                        SearchDbContext(module.Deps, nodes);
                    }
                    continue;
                }

                var node = new ModuleContextNode();
                node.Module = module;
                node.Entities = dbContext.GetProperties()
                    .Where(p => p.PropertyType == typeof(DbSet<>))
                    .Select(p => p.PropertyType.GenericTypeArguments[0])
                    .ToList();
                node.ContextType = dbContext;
                node.Deps = new List<ModuleContextNode>();
                nodes.Add(node);
                SearchDbContext(module.Deps, node.Deps);

            }
        }



        public static List<ModuleContextNode> AlignmentTrees(IEnumerable<ModuleContextNode> modules)
        {
            List<ModuleContextNode> buffer = new List<ModuleContextNode>();

            foreach (var module in modules)
            {
                buffer.AddRange(AlignmentTree(module));
            }

            return buffer;
        }
        public static List<ModuleContextNode> AlignmentTree(ModuleContextNode module, List<ModuleContextNode> buffer = null)
        {
            if (buffer == null)
                buffer = new List<ModuleContextNode>();

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

    public class ModuleContextNode
    {
        public BaseYeeModule Module { get; set; }
        public Type ContextType { get; set; }
        public List<Type> Entities { get; set; }

        public List<ModuleContextNode> Deps { get; set; }
    }

    public interface IYeeDbContext
    {
        
    }
}
