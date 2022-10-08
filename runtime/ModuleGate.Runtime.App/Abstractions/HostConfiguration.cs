using ModuleGate.Runtime.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleGate.Runtime.App.Abstractions
{
    public class HostConfiguration
    {
        public HostConfiguration()
        {
            Scripts = new List<HtmlSingleNode>();
            Styles = new List<HtmlSingleNode>();
        }

        public List<HtmlSingleNode> Scripts { get; set; }
        public List<HtmlSingleNode> Styles { get; set; }

        public void AddScript(string uri)
        {
            Scripts.Add(new HtmlSingleNode
            {
                Name = "script",
                Attributes = new Dictionary<string, string>()
                {
                    {"src", uri}
                }
            });
        }

        public void AddStyle(string uri)
        {
            Styles.Add(new HtmlSingleNode
            {
                Name = "link",
                Attributes = new Dictionary<string, string>()
                {
                    {"href", uri},
                    {"rel", "stylesheet"}
                }
            });
        }


        //public static HostConfiguration FromStaticFileGroups(List<StaticFileGroup> statics)
        //{
        //    var staticFiles = statics.SelectMany(p => p).ToList();
        //    var conf = new HostConfiguration();

        //    foreach(var staticFile in staticFiles)
        //    {
        //        switch (staticFile.FileType)
        //        {
        //            case StaticFileType.Scrips:
        //                conf.AddScript(staticFile.Uri);
        //                break;
        //            case StaticFileType.Style:
        //                conf.AddStyle(staticFile.Uri);
        //                break;
        //        }
        //    }

        //    return conf;
        //}

        public static HostConfiguration FromStaticFileGroup(StaticFileGroup statics)
        {
            var staticFiles = statics;
            var conf = new HostConfiguration();

            foreach (var staticFile in staticFiles)
            {
                switch (staticFile.FileType)
                {
                    case StaticFileType.Scrips:
                        conf.AddScript(staticFile.Uri);
                        break;
                    case StaticFileType.Style:
                        conf.AddStyle(staticFile.Uri);
                        break;
                }
            }

            return conf;
        }
    }


}
