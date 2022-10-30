using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.EntityFrameworkCore.Manager;

namespace Yee.EntityFrameworkCore
{
    public class DbContextFactory
    {
        private readonly DbContextState _state;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public DbContextFactory(DbContextState state, IServiceScopeFactory serviceScopeFactory)
        {
            _state = state;
            _serviceScopeFactory = serviceScopeFactory;
        }

        public DbContextStateValue Create(Type type)
        {
            var serviceScope = _serviceScopeFactory.CreateScope();
            if (!_state.ContainsKey(type))
                _state[type] = new DbContextStateInfo();

            try
            {
                var context = (DbContext)serviceScope.ServiceProvider.GetRequiredService(type);

                _state[type].IsWorked = true;

                if (_state[type].Migrated == false)
                {
                    try
                    {
                        var migrations = context.Database.GetPendingMigrations();
                        if (migrations.Any())
                        {
                            context.Database.Migrate();
                        }
                        _state[type].Migrated = true;
                    }
                    catch(Exception ex)
                    {
                        _state[type].Exception = ex;
                        _state[type].Migrated = false;
                    }
                }

                return new DbContextStateValue
                {
                    IsWorked = true,
                    Context = context
                };
            }
            catch (Exception ex)
            {
                _state[type].Exception = ex;
                _state[type].IsWorked = false;
                _state[type].Migrated = false;

                return new DbContextStateValue
                {
                    IsWorked = false,
                    Exception = ex
                };
            }
        }
    }

    public class DbContextStateValue 
    {
        public bool IsWorked { get; set; }
        public Exception Exception { get; set; }
        public DbContext Context { get; set; }
    }
}
