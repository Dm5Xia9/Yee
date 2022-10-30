using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Yee.EntityFrameworkCore.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Abstractions;

namespace Yee.EntityFrameworkCore.Npgsql
{
    public class NpgsqlOptionsProvider : IDbContextOptionsProvider
    {
        private readonly NpgsqlOptions _options;

        public NpgsqlOptionsProvider(IRootOptions rootOptions)
        {
            _options = rootOptions.Get<NpgsqlOptions>("NpgsqlOptions");

            if(_options == null)
            {
                _options = new NpgsqlOptions();
                rootOptions.Set("NpgsqlOptions", _options);
            }
        }

        public DbContextOptions GetOptions(string schema)
        {
            return new DbContextOptionsBuilder()
                .UseNpgsql(_options.ConnectionString, 
                    p => p
                        .CommandTimeout(_options.Timeout)
                        .MigrationsHistoryTable("__EFMigrationsHistory", schema))
                .Options;
        }
    }
}
