using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.DynamicRouters.Data;
using Yee.DynamicRouters.Models;
using Yee.EntityFrameworkCore;
using Yee.Web;

namespace Yee.DynamicRouters
{
    public class RouteState
    {
        private readonly NavigationManager _navigation;
        private readonly DbContextFactory _factory;
        public RouteState(NavigationManager navigation, DbContextFactory dbContextFactory)
        {
            _navigation = navigation;
            _factory = dbContextFactory;
        }

        public YeeRoute? GetCurrent()
        {
            var dbState = _factory.Create(typeof(DynamicRouterDbContext));
            if (dbState.IsWorked == false)
                return null;

            using var db = dbState.Context as DynamicRouterDbContext;
            var uri = new Uri(_navigation.Uri);

            return db.YeeRoutes.FirstOrDefault(p => p.LocalPath == uri.LocalPath);
        }
    }
}
