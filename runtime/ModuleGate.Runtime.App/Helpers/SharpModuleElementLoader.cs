using ModuleGate.Runtime.App.Abstractions;
using ModuleGate.Runtime.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ModuleGate.Runtime.App.Helpers
{
    public static class SharpModuleElementLoader
    {
        public static ModulePatch LoadPatch(Assembly assembly)
        {
            var patch = new ModulePatch();
            var metadatas = GetMetadataTypesFromAssembly(assembly);

            patch.AppComponentTypes = metadatas.Select(p => new AppComponentType()
            {
                Meta = p.AppComponent,
                Type = p.Type
            }).ToList();

            patch.RootStaticFiles = new StaticFileGroup(null, metadatas
                .SelectMany(p => p.MarkerAttributes)
                .Select(p => new StaticFile
                {
                    Source = assembly,
                    FileType = GetStaticFileTypeFromAttribute(p),
                    Uri = p.LocalUri
                }).ToList());

            return patch;
        }

        public static List<Type> GetComponentTypesFromAssembly(Assembly assembly)
        {
            return assembly.GetTypes()
                .Where(p => p.CustomAttributes.Any(p => p.AttributeType == typeof(AppComponentAttribute)))
                .ToList();
        }

        public static List<TypeMetadata> GetMetadataTypesFromAssembly(Assembly assembly)
        {
            var compoentTypes = GetComponentTypesFromAssembly(assembly);

            return compoentTypes.Select(p => new TypeMetadata(p)).ToList();
        }

        public static ModuleStartup LoadStartup(Assembly assembly)
        {
            var startupType = assembly.GetTypes()
                .FirstOrDefault(p => p.BaseType == typeof(ModuleStartup));

            if (startupType == null)
                return null;

            var constructor = startupType.GetConstructors().FirstOrDefault();

            if (constructor == null)
                return null;


            return (ModuleStartup)constructor.Invoke(Array.Empty<object>());
        }

        private static StaticFileType GetStaticFileTypeFromAttribute(MarkerAttribute marker)
        {
            if (marker is ScriptAttribute)
                return StaticFileType.Scrips;
            else if (marker is StyleAttribute)
                return StaticFileType.Style;

            throw null;
        }

        public class TypeMetadata
        {
            public TypeMetadata(Type type)
            {
                Type = type;

                AppComponent = (AppComponentAttribute)
                    Attribute.GetCustomAttribute(type, typeof(AppComponentAttribute))!;

                MarkerAttributes = 
                   Attribute.GetCustomAttributes(type, typeof(MarkerAttribute))?
                   .Cast<MarkerAttribute>().ToList() ?? new List<MarkerAttribute>();
            }

            public Type Type { get; set; }

            public AppComponentAttribute AppComponent { get; set; }
            public List<MarkerAttribute> MarkerAttributes { get; set; }
        }


    }
}
