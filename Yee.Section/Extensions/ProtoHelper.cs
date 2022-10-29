using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Yee.Section.Abstractions;

namespace Yee.Section.Extensions
{
    public static class ProtoHelper
    {
        public static T CreateDefualt<T>()
        {
            return (T)CreateObjectProto(type: typeof(T));
        }

        public static object CreateObjectProto(PropertyInfo propertyInfo = null, Type type = null)
        {
            if (type == null && propertyInfo == null)
                throw new Exception();


            if (type == null)
                type = propertyInfo.PropertyType;


            if(type.Name == "Nullable`1")
            {
                type = type.GenericTypeArguments[0];
            }

            if (type.IsPrimitive)
            {
                return Activator.CreateInstance(type);
            }
            if (type == typeof(String))
                return null;

            if(type.FullName!.StartsWith("System.Collections.Generic.List`1"))
            {
                return Activator.CreateInstance(type);
            }
            if (type.GetInterfaces().Any(p => p == typeof(IYeeProto)))
            {
                var obj = (IYeeProto)Activator.CreateInstance(type);

                var valueProperty = type.GetProperty("Value")!;

                obj.DisplayName = propertyInfo?
                    .GetCustomAttribute<DisplayNameAttribute>()?.DisplayName
                    ?? propertyInfo?.Name ?? type.Name;

                var valueObj = CreateObjectProto(valueProperty);


                if(valueObj == null)
                {
                    obj.SetDefualtValue();
                }
                else
                {
                    valueProperty.SetValue(obj, valueObj);
                }

                return obj;
            }
            else
            {
                Object obj = null;
                try
                {
                    obj = Activator.CreateInstance(type);

                    if(type == typeof(DateTime))
                        return obj;

                    foreach (var property in type.GetProperties())
                    {
                        var propertyObj = CreateObjectProto(property);


                        property.SetValue(obj, propertyObj);
                    }

                    return obj;
                }
                catch
                {
                    return obj;
                }
            }

        }
    }
}
