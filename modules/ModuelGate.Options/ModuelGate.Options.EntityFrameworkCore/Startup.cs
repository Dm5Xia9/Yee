using Microsoft.Extensions.DependencyInjection;
using ModuelGate.Options.EntityFrameworkCore.Models;
using ModuleGate;
using ModuleGate.Attributes;
using ModuleGate.EntityFrameworkCore.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
[assembly: ModuleGate(Special = ModuleGateSpecialType.OptionsModule)]

namespace ModuelGate.Options.EntityFrameworkCore
{
    public class Startup : ModuleStartup
    {

        public override void Build(IServiceProvider provider)
        {
            var anotationService = provider.GetRequiredService<DatabaseAnotationService>();
            anotationService.AddModel<ModuleOptions>();


            base.Build(provider);
        }
    }
}
