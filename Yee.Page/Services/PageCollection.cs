using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Yee.Services;

namespace Yee.Page.Services
{
    public class PageCollection : List<PageInfo>
    {
        private readonly YeeModuleManager _yeeModuleManager;

        public PageCollection(YeeModuleManager yeeModuleManager)
        {
            _yeeModuleManager = yeeModuleManager;
            foreach (var module in _yeeModuleManager.ToAlignmentTrees())
            {
                var pages = module.Assembly.GetTypes()
                    .Where(p => p.GetInterfaces().Contains(typeof(IComponent)) &&
                    p.GetCustomAttribute<RouteAttribute>() != null);

                foreach(var page in pages)
                {
                    var pgInfo = new PageInfo();

                    pgInfo.Type = page;

                    pgInfo.RouteAttribute = page.GetCustomAttribute<RouteAttribute>();

                    this.Add(pgInfo);
                }
            }
        }
    }

    public class PageInfo
    {
        public Type Type { get; set; }
        public RouteAttribute RouteAttribute { get; set; }
    }
}
