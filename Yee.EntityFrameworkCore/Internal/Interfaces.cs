using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ability.Core.Internal
{
    public interface IDatabaseServiceScopeOwnerConfiguration
    {
        void SetOwningServiceScope(IServiceScope scope);
        void AddBlackServiceType(Type type);
    }

    public interface IIdentityDbContexFactory : IDbContextFactory<DbContext>
    {

    }
}
