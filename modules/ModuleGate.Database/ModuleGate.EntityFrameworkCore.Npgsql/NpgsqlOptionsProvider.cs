using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ModuleGate.EntityFrameworkCore.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleGate.EntityFrameworkCore.Npgsql
{
    public class NpgsqlOptionsProvider : IDbContextOptionsProvider
    {
        private readonly NpgsqlOptions _options;

        public NpgsqlOptionsProvider(NpgsqlOptions options)
        {
            _options = options;
        }

        public DbContextOptions GetOptions()
        {
            return new DbContextOptionsBuilder()
                .UseNpgsql(_options.ConnectionString, 
                    p => p.CommandTimeout(_options.Timeout))
                .Options;
        }
    }
}
