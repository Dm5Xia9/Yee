using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleGate.Runtime.App.Abstractions
{
    public class HtmlSingleNode
    {
        public HtmlSingleNode()
        {
            Attributes = new Dictionary<string, string>();
        }

        public string Name { get; set; }
        public Dictionary<string, string> Attributes { get; set; }

        public override string ToString()
        {
            return $"<{Name} {AttributesToString()}/>";
        }

        private string AttributesToString()
        {
            return string.Join(" ", Attributes.Select(p => $"{p.Key}=\"{p.Value}\""));

        }

    }
}
