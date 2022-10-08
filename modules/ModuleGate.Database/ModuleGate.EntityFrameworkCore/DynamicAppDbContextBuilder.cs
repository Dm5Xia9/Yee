using Microsoft.Extensions.Options;
using ModuleGate.EntityFrameworkCore.Abstractions;
using ModuleGate.EntityFrameworkCore.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleGate.EntityFrameworkCore
{
    public class DynamicAppDbContextBuilder
    {
        private readonly IDbContextOptionsProvider _dbContextOptionsProvider;
        private readonly IOptions<EntityFrameworkDatabaseOptions> _options;
        private readonly DatabaseAnotation _types;
        public DynamicAppDbContextBuilder(IDbContextOptionsProvider dbContextOptionsProvider, 
            IOptions<EntityFrameworkDatabaseOptions> options,
            DatabaseAnotation types)
        {
            if(dbContextOptionsProvider == null)
            {
                throw new ArgumentNullException(nameof(dbContextOptionsProvider));
            }

            _dbContextOptionsProvider = dbContextOptionsProvider;
            _options = options;
            _types = types;
        }

        public DynamicAppDbContext Create()
        {
            return new DynamicAppDbContext(_dbContextOptionsProvider.GetOptions(), _options, _types);
        }
    }
}
