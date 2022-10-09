using Ability.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuelGate.Options.EntityFrameworkCore.Models
{
    public class ModuleOptions : IEntity
    {
        public long Id { get; set; }
        
        //нужно сделать единый id каждого модуля
        public string TypeName { get; set; }

        public string Value { get; set; }
    }
}
