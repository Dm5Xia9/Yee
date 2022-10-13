using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

namespace Ability.Core.Models
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ManyToManyJoinTableAttribute : Attribute
    {
        public static void CheckAttribute(ModelBuilder builder, Type entityType, PropertyInfo[] columns)
        {
            var many2many = entityType.GetCustomAttribute<ManyToManyJoinTableAttribute>();
            if (many2many != null)
            {
                var idColumns = columns.Where(x => x.Name.EndsWith("Id"));
                var relColumns = columns.Where(x => idColumns.Any(y => y.Name == x.Name + "Id"));

                //TODO: Do it smarter way!

                //if (idColumns.Count() != 2 || relColumns.Count() != 2)
                //    throw new FormatException("Many-to-many relationship table classs should contains 4 properties, for example:\r\nTag, TagId, Blog, BlogId.\r\nAlso it's case sensitive check, correct format is: 'SomeRelName, SomeRelNameId'.");

                var idNames = idColumns.Select(x => x.Name).ToArray();
                builder.Entity(entityType)
                    .HasKey(idNames);
            }
        }
    }
}