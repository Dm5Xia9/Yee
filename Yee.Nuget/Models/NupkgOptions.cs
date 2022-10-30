using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Yee.Abstractions;

namespace Yee.Nuget.Models
{
    public class NupkgOptions
    {
        public NupkgOptions(IRootOptions options)
        {
            if (options == null)
                return;

            var nupkgOptions = options.Get<NupkgOptions>("NupkgOptions");
            if (nupkgOptions == null)
            {
                nupkgOptions = NupkgOptions.Defualt();
                options.Set("NupkgOptions", nupkgOptions);
            }
            Sources = nupkgOptions.Sources;
            StoragePath = nupkgOptions.StoragePath;
        }

        public List<string> Sources { get; set; }
        public string StoragePath { get; set; }

        public static NupkgOptions Defualt()
        {
            var exeDirectory = new FileInfo(Assembly.GetExecutingAssembly()
                .Location).Directory!.FullName;
            return new NupkgOptions(null)
            {
                StoragePath = Path.Combine(exeDirectory, "storage"),
                Sources = new List<string>
                {
                    "https://api.nuget.org/v3/index.json",
                    "http://49.12.227.30:555/v3/index.json"
                }
            };
        }
    }
}
