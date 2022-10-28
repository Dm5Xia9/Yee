using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Yee.Extensions;
using Yee.Services;
using Yee.Web.Extensions;
using Yee.Web.Models;

namespace Yee.Web.Services
{
    public class YeeViewManager
    {
        private readonly YeeModuleManager _yeeModuleManager;
        private readonly List<WebAppBuilder> _appBuilders;
        

        public YeeViewManager(YeeModuleManager yeeModuleManager)
        {
            _yeeModuleManager = yeeModuleManager;
            _appBuilders = new List<WebAppBuilder>();
            foreach (var module in _yeeModuleManager.ToAlignmentTrees())
            {
                var buffer = new WebAppBuilder();
                buffer.Assembly = module.Assembly;
                if(YeeBuilderHandler.Go(module.Builder, YeeBuilderExtensions.TagWebApp, buffer))
                    _appBuilders.Add(buffer);
            }
        }


        internal Type GetCurrentNotFoundComponent(NavigationManager navigationManager)
        {
            foreach (var item in _appBuilders)
            {
                var type = item.NotFoundBuilder.BuildCurrentComponent(navigationManager);

                if (type != null)
                    return type;
            }

            return null;
        }

        public string CreateBaseUri(Assembly assembly)
        {
            return $"_content/{assembly.GetName().Name}";
        }

        public List<string> GetAllStyles() 
        {
            return _appBuilders.SelectMany(p => p.StaticFiles
                .Where(z => z.StaticFileType == StaticFileType.Style)
                .Select(z => $"_content/{p.Assembly.GetName().Name}/{z.Uri}")).ToList();
        }

        public List<string> GetAllScripts()
        {
            return _appBuilders.SelectMany(p => p.StaticFiles
                .Where(z => z.StaticFileType == StaticFileType.Sctipt)
                .Select(z => z.AsStandard == false ? $"_content/{p.Assembly.GetName().Name}{z.Uri}": z.Uri)).ToList();
        }

        public List<Type> GetRoutingComponents()
        {
            return _appBuilders.SelectMany(p => p.Routers)
                .ToList();
        }

        public List<Type> GetLayouts()
        {
            return _appBuilders.SelectMany(p => p.Layouts)
                .ToList();
        }

        public List<Type> GetHeaders()
        {
            return _appBuilders.SelectMany(p => p.HeadComponents)
                .ToList();
        }

        public List<Type> GetPossibleHeaders()
        {
            return _appBuilders.SelectMany(p => p.PossibleHeadComponent)
                .ToList();
        }

        public List<Type> GetFooters()
        {
            return _appBuilders.SelectMany(p => p.FooterComponents)
                .ToList();
        }

        public List<Type> GetRootComponents()
        {
            return _appBuilders.SelectMany(p => p.RootComponents)
               .ToList();
        }

        public List<Assembly> GetAssemblies()
        {
            return _appBuilders.Select(p => p.Assembly).ToList();
        }
    }
}
