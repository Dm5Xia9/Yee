using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Admin.Abstractions;
using Yee.EntityFrameworkCore;
using Yee.Page;
using Yee.Page.Repositories;
using Yee.Section.Base;

namespace Yee.Admin.Navigations
{
    public class PageNavPatch : INavPatch
    {
        private readonly IServiceScopeFactory _scope;
        public PageNavPatch(IServiceScopeFactory scope)
        {
            _scope = scope;

        }

        public void Patch(List<NavMenuItem> navMenuItems)
        {
            using var scope = _scope.CreateScope();
            var pageRepository = scope.ServiceProvider.GetRequiredService<PageRepository>();
            var state = pageRepository.GetState();
            if (state.IsWorked == false)
                return;

            var group = new NavMenuItem()
            {
                Title = "Данные",
                ChildItems = new List<NavMenuItem>()
            };

            try
            {
                var allComponents = pageRepository.GetModelDatas();

                foreach (var component in allComponents)
                {

                    group.ChildItems.Add(new NavMenuItem
                    {
                        Title = $"{component.DisplayName ?? component.Id.ToString()}",
                        Link = $"/admin/proto/{component.Id}"
                    });
                }

                if (group.ChildItems.Any())
                {
                    navMenuItems.Add(group);
                }
            }
            catch
            {

            }

        }
    }
}
