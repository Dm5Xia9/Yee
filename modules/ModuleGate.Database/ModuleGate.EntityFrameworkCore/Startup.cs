using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModuleGate.Attributes;
using ModuleGate.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
[assembly: ModuleGate]

namespace ModuleGate.EntityFrameworkCore
{
    public class EFStartup : ModuleStartup
    {

    }
}
