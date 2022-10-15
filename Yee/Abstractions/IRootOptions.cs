using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Loader;
using System.Text;
using System.Threading.Tasks;
using Yee.Options;

namespace Yee.Abstractions
{
    public interface IRootOptions
    {
        public IEnumerable<RootOption<JObject>> GetAll();
        public void Set<T>(string key, T value);
        public T? Get<T>(string key);

        public RootOption<T> GetDetail<T>(string key);

    }

    public class RootOption<T>
    {
        public string OptionsKey { get; set; }
        public string AssemblyName { get; set; }
        public string TypeName { get; set; }
        public T? Value { get; set; }

        public Type GetCurrentType()
        {
            var assembly = AssemblyLoadContext.All
                    .SelectMany(p => p.Assemblies)
                    .FirstOrDefault(p => p.GetName().Name == AssemblyName);

            if (assembly == null)
                throw null;


            return assembly.GetType(TypeName);
        }
        public override string ToString()
        {
            var moduleName = "";

            try
            {
                var name = GetCurrentType()!.Assembly.GetName();
                moduleName = $"{name.Name}:{name.Version}";
            }
            catch(Exception ex)
            {
                moduleName = TypeName;
            }

            return $"{OptionsKey} из {moduleName}";
        }
    }
}
