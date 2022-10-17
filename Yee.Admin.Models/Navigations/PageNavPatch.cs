﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Admin.Abstractions;
using Yee.EntityFrameworkCore;
using Yee.Page;
using Yee.Page.Repositories;
using Yee.Section.Navigation;

namespace Yee.Admin.Models.Navigations
{
    public class PageNavPatch : INavPatch
    {
        private readonly PageRepository _pageRepository;
        public PageNavPatch(PageRepository pageRepository)
        {
            _pageRepository = pageRepository;

        }
        public void Patch(List<NavMenuItem> navMenuItems)
        {
            var state = _pageRepository.GetState();
            if (state.IsWorked == false)
                return;

            var group = new NavMenuItem()
            {
                Title = "Модели данных",
                ChildItems = new List<NavMenuItem>()
            };

            try
            {
                var allComponents = _pageRepository.GetModelDatas();
                foreach (var component in allComponents)
                {

                    group.ChildItems.Add(new NavMenuItem
                    {
                        Title = $"{component.DisplayName ?? component.Id.ToString()}",
                        Link = new Section.Prototypes.ProtoLink { Value = $"/admin/proto/{component.Id}" }
                    });
                }

                navMenuItems.Add(group);
            }
            catch
            {

            }

        }
    }
}
