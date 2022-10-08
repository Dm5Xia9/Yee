using Ability.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ModuleGate.Database.Abstraction;
using ModuleGate.EntityFrameworkCore.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleGate.EntityFrameworkCore
{
    public class DynamicAppDbContext : AbilityDbContext, IGateDbContext
    {
        private readonly IOptions<EntityFrameworkDatabaseOptions> _options;
        private readonly DatabaseAnotation _types;

        public DynamicAppDbContext(DbContextOptions options, 
            IOptions<EntityFrameworkDatabaseOptions> efOptions,
            DatabaseAnotation types) : base(options)
        {
            _options = efOptions;
            _types = types;
        }

        void IGateDbContext.SaveChanges()
        {
            SaveChanges();
        }

        IGateSet<T> IGateDbContext.Set<T>()
            where T: class
        {
            return new DefualtGateSet<T>(this.Set<T>());
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            foreach (var type in _types)
            {
                builder.Entity(type);
            }

            foreach (var action in _types.ModelCreatingActions)
            {
                action(builder);
            }
        }

        void IGateDbContext.Update<T>(T entity)
        {
            this.Update(entity);
        }

        void IGateDbContext.Add<T>(T entity)
        {
            this.Add(entity);
        }
    }
}
