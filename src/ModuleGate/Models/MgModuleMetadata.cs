using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ModuleGate.Models
{
    public class MgModuleMetadata
    {
        public string NugetSource { get; set; }
        public string ModuleName { get; set; }
        public string ModuleVersion { get; set; }
        public string Framework { get; set; }
        public string Source { get; set; }
        public string InternalSource { get; set; }
        public string Xml { get; set; }
        public string InternalXml { get; set; }
        public string[] Other { get; set; }
        public List<string> InternalOther { get; set; }

        [JsonIgnore]
        public Assembly Assembly { get; set; }

        public string StaticWebAssetsPath { get; set; }
    }
}
