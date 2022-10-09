using Ability.Core.Data;
using Ability.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Ability.Core.Internal
{
    internal class ReflectionTools
    {
        public static void FindRealContextGenericArgumentsTypes<TContext>(ref Type userType, ref Type roleType) where TContext : DbContext
        {
            var cur = typeof(TContext);
            while (cur != null && cur != typeof(object))
            {
                if (cur.GetTypeInfo().IsGenericType)
                {
                    var args = cur.GetGenericArguments().ToArray();
                    if (args.Length == 2)
                    {
                        if (typeof(AbilityUser).IsAssignableFrom(args[0]) && typeof(AbilityRole).IsAssignableFrom(args[1]))
                        {
                            userType = args[0];
                            roleType = args[1];
                            break;
                        }
                    }
                }
                cur = cur.GetTypeInfo().BaseType;
            }
        }

        public static void CallGenericStaticMethodForDbContextType<TContext>(Type parentClassType, string methodName, object[] parametersList, Type userManagerType = null)
            where TContext : DbContext
        {
            MethodInfo generic;
            Type userType = null, roleType = null;
            ReflectionTools.FindRealContextGenericArgumentsTypes<TContext>(ref userType, ref roleType);

            if (userType == null)
                throw new ArgumentException("Invalid DbСontext type. Looking for DbContext<TUser, TRole>");

            var mtdGeneric = parentClassType.GetTypeInfo().GetMethod(methodName, BindingFlags.Static | BindingFlags.NonPublic);
            if (mtdGeneric == null)
                throw new ArgumentException($"Invalid private static method name {methodName}");

            var argsCount = mtdGeneric.GetGenericArguments().Length;
            if (argsCount != 3 && argsCount != 4)
                throw new ArgumentException($"{methodName} should have 3 or 4 generic arguments\r\nMethodName<TContext, TUser, TRole>(...)\r\nMethodName<TContext, TUser, TRole, TUserManager>(...)");

            if (argsCount == 4 && userManagerType == null)
            {
                userManagerType = typeof(AbilityUserManager<>);
                userManagerType = userManagerType.MakeGenericType(userType);
            }

            if (argsCount == 3)
                generic = mtdGeneric.MakeGenericMethod(typeof(TContext), userType, roleType);
            else
                generic = mtdGeneric.MakeGenericMethod(typeof(TContext), userType, roleType, userManagerType);

            generic.Invoke(null, parametersList);
        }
    }
}
