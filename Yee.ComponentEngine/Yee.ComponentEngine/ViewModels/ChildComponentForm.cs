using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yee.ComponentEngine.ViewModels
{
	public class ChildComponentForm
    {
        public string Name { get; set; }
        public List<ChildComponentForm> Children { get; set; } = new();
    }
}
