using Ability.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ModuleGate.EntityFrameworkCore.Extensions
{
    internal static class AbilityExtensions
    {
        public static void ProcessAbilityAnnotationAttributes(this ModelBuilder builder, DbContext context)
        {
            var properties = context.GetType().GetTypeInfo().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
            foreach (var cur in properties)
            {
                var ptype = cur.PropertyType.GetTypeInfo();
                if (ptype.IsGenericType && ptype.GetGenericTypeDefinition().Equals(typeof(DbSet<>)))
                {
                    var entityType = ptype.GetGenericArguments().Single();
                    var columns = entityType.GetTypeInfo().GetProperties(BindingFlags.Public | BindingFlags.Instance);
                    ManyToManyJoinTableAttribute.CheckAttribute(builder, entityType, columns);
                    UniqueAttribute.CheckAttribute(builder, entityType, columns);
                }
            }
        }
    }
}
