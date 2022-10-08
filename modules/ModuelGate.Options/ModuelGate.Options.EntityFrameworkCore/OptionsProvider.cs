using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ModuelGate.Options.EntityFrameworkCore.Models;
using ModuleGate.Abstractions;
using ModuleGate.Database.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ModuelGate.Options.EntityFrameworkCore
{
    public class OptionsProvider : IOptionsProvider
    {
        private readonly IGateDbContext _dbContext;

        public OptionsProvider(IGateDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IConfiguration GetModuleConfiguration(Assembly assembly)
        {
            var assemblyName = assembly.GetName().Name;
            var options = _dbContext.Set<ModuleOptions>()
                .FirstOrDefault(p => p.AssemblyName == assemblyName);

            ConfigurationManager configuration = new ConfigurationManager();
            if(options != null && options.Value != null)
            {
                configuration.AddJsonStream(GenerateStreamFromString(options.Value));
            }

            return configuration;
        }

        public Stream GenerateStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}
