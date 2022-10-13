using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Ability.Core.Models
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class RequireNonZeroAttribute : RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null) return false;

            if (value is Guid)
            {
                var g = (Guid)value;
                if (g.Equals(Guid.Empty))
                    return false;
            }
            else if (value is IConvertible)
            {
                if (Convert.ToInt64(value) == 0)
                    return false;
            }

            return base.IsValid(value);
        }
    }
}