using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.EntityFrameworkCore;
using Yee.Page;
using Yee.Page.Models;
using Yee.Web;

namespace Yee.Admin.PageEngine.Services
{
    public class RouteState
    {
        private readonly DbContextFactory _factory;
        private readonly ConcurrentDictionary<string, YeeRoute> _cache = new ConcurrentDictionary<string, YeeRoute>();
        public RouteState(DbContextFactory dbContextFactory)
        {
            _factory = dbContextFactory;
        }

        public YeeRoute? GetCurrent(NavigationManager navigation)
        {
            if (_cache.ContainsKey(navigation.Uri))
            {
                if (_cache.TryGetValue(navigation.Uri, out YeeRoute route))
                {
                    return route;
                }
            }

            var dbState = _factory.Create(typeof(PageDbContext));
            if (dbState.IsWorked == false)
                return null;

            using var db = dbState.Context as PageDbContext;
            var uri = new Uri(navigation.Uri);

            var page = db.YeeRoutes
                .Include(p => p.Page).ThenInclude(p => p.YeeComponents)
                .ThenInclude(p => p.Properties)
                .ThenInclude(p => p.YeePropertyValue)
                .Include(p => p.Page).ThenInclude(p => p.YeeComponents)
                .ThenInclude(p => p.Childs).ThenInclude(p => p.Properties).ThenInclude(p => p.YeePropertyValue)
                .FirstOrDefault(p => p.LocalPath == uri.LocalPath);

            _cache.AddOrUpdate(navigation.Uri, page, (p, z) =>
            {
                return z;
            });

            return db.YeeRoutes.FirstOrDefault(p => p.LocalPath == uri.LocalPath);
        }
    }
}
