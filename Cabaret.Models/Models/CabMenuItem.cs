using Ability.Core.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cabaret.Models.Models
{
    public class CabMenuItem : BaseRecord
    {
        public string DisplayName { get; set; }
        public string Description { get; set; }

        public decimal Price { get; set; }
        public string Consist { get; set; }
        public string ImgPath { get; set; }
        public CabMenuCategory CabMenuCategory { get; set; }
    }
}
