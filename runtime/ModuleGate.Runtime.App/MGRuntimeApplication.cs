using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using ModuleGate.Runtime.App.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleGate.Runtime.App
{
    public class MGRuntimeApplication
    {
        public WebApplication App { get; internal set; }
        public static MGRuntimeApplicationBuilder CreateBuilder(string[] args = null)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var conf = builder.Build();

            return new MGRuntimeApplicationBuilder(args, conf);
        }
    }
}
