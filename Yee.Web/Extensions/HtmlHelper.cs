using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yee.Web.Extensions
{
    public static class HtmlHelper
    {
        public static HtmlSingleNode CreateStyle(string uri)
        {
            return new HtmlSingleNode
            {
                Name = "link",
                Attributes = new Dictionary<string, string>()
                {
                    {"href", uri},
                    {"rel", "stylesheet"}
                }
            };
        }

        public static HtmlSingleNode CreateScripts(string uri)
        {
            return new HtmlSingleNode
            {
                Name = "script",
                Attributes = new Dictionary<string, string>()
                {
                    {"src", uri}
                },
                Closing = true
            };
        }

        public static string CreateHtmlFromScripts(List<string> urls)
        {
            return string.Join(Environment.NewLine, urls.Select(p => CreateScripts(p).ToString()));
        }
    }

    public class HtmlSingleNode
    {
        public HtmlSingleNode()
        {
            Attributes = new Dictionary<string, string>();
        }

        public bool Closing { get; set; }
        public string Name { get; set; }
        public Dictionary<string, string> Attributes { get; set; }

        public override string ToString()
        {
            if (Closing)
            {
                return $"<{Name} {AttributesToString()}></{Name}>";
            }


            return $"<{Name} {AttributesToString()}/>";
        }

        private string AttributesToString()
        {
            return string.Join(" ", Attributes.Select(p => $"{p.Key}=\"{p.Value}\""));

        }

    }
}
