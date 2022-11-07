using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Abstractions;

namespace Yee.Extensions
{
    public static class ModuleHelper
    {

        public static IEnumerable<BaseYeeModule> FindNewModules(IEnumerable<BaseYeeModule> current, 
            IEnumerable<BaseYeeModule> news)
        {
            foreach(var newModule in news)
            {
                if (current.Any(p => p.Assembly == newModule.Assembly))
                    continue;

                yield return newModule;
            }
        }

    }
}
