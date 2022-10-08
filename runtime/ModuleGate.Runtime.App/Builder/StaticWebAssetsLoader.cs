using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ModuleGate.Runtime.App.Builder
{
    public static class ModuleGateStaticWebAssetsLoader
    {
        public static void UseStaticWebAssetsFromAssemblies(
            this IWebHostEnvironment environment, 
            IConfiguration configuration,
            params Assembly[] assemblies)
        {
            StaticWebAssetsLoader.UseStaticWebAssets(environment, configuration);
            foreach (var assembly in assemblies)
            {
                var webAssetsPath = WebAssetsPathFromAssembly(assembly);

                //var manifests = ResolveManifest(environment, configuration);
                ConfigurationManager configurationManager = new ConfigurationManager();
                configurationManager.Add<SmallSource>(p => p.SetWebAssetsPath(webAssetsPath));

                StaticWebAssetsLoader.UseStaticWebAssets(environment, configurationManager);
            }

        }

        private static string WebAssetsPathFromAssembly(Assembly assembly)
        {
            var basePath = string.IsNullOrEmpty(assembly.Location) ? AppContext.BaseDirectory : Path.GetDirectoryName(assembly.Location);
            return Path.Combine(basePath!, $"{assembly.GetName().Name}.staticwebassets.runtime.json");
        }

        private class SmallSource : IConfigurationSource
        {
            private string _webAssetsPath;

            internal void SetWebAssetsPath(string webAssetsPath)
            {
                _webAssetsPath = webAssetsPath;

            }
            public IConfigurationProvider Build(IConfigurationBuilder builder)
            {
                return new SmallSourceProvider(_webAssetsPath);
            }
        }

        private class SmallSourceProvider : IConfigurationProvider
        {
            private string _webAssetsPath;

            public SmallSourceProvider(string webAssetsPath)
            {
                _webAssetsPath = webAssetsPath;
            }

            public IEnumerable<string> GetChildKeys(IEnumerable<string> earlierKeys, string parentPath)
            {
                throw new NotImplementedException();
            }

            public IChangeToken GetReloadToken()
            {
                return NullChangeToken.Singleton;
            }

            public void Load()
            {
                //throw new NotImplementedException();
            }

            public void Set(string key, string value)
            {
                throw new NotImplementedException();
            }

            public bool TryGet(string key, out string value)
            {
                if (WebHostDefaults.StaticWebAssetsKey == key)
                {
                    value = _webAssetsPath;
                    return true;
                }
                value = null;
                return false;


            }
        }
  
    }
}
