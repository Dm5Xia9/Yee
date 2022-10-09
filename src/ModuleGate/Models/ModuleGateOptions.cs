using ModuleGate.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ModuleGate.Models
{
    public class ModuleGateOptions
    {
        public ModuleGateOptions(IRootOptions options)
        {
            if (options == null)
                return;

            var nupkgOptions = options.Get<ModuleGateOptions>("MGOptions");
            if (nupkgOptions == null)
            {
                nupkgOptions = ModuleGateOptions.Defualt();
                options.Set("MGOptions", nupkgOptions);
            }
            ContextPath = nupkgOptions.ContextPath;
        }

        public string ContextPath { get; set; }

        public static ModuleGateOptions Defualt()
        {
            var exeDirectory = new FileInfo(Assembly.GetExecutingAssembly()
                .Location).Directory!.FullName;
            return new ModuleGateOptions(null)
            {
                ContextPath = Path.Combine(exeDirectory, "modules.json"),
            };
        }
    }
}
