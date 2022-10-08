using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleGate.EntityFrameworkCore.Options
{
    public class DatabaseAnotation : List<Type>
    {

        public List<Action<ModelBuilder>> ModelCreatingActions { get; set; }
            = new List<Action<ModelBuilder>>();

    }
}
