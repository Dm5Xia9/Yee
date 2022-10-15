using AntDesign;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yee.Admin.Helpers
{
    public static class ColorHelper
    {
        private static Dictionary<string, PresetColor> _namesFromColors = new Dictionary<string, PresetColor>();


        public static PresetColor GetColorFromName(string name)
        {
            if (_namesFromColors.ContainsKey(name))
            {
                return _namesFromColors[name];
            }


            var vals = Enum.GetValues(typeof(PresetColor));
            var values = vals
                .OfType<PresetColor>().Where(p => !_namesFromColors.Values.Contains(p));
            Random random = new Random();
            PresetColor randomcolor = (PresetColor)vals.GetValue(random.Next(values.Count()));

            _namesFromColors.Add(name, randomcolor);
            return randomcolor;
        }
    }
}
