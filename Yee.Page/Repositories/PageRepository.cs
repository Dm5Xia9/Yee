using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.EntityFrameworkCore;
using Yee.Page.Models;
using static System.Collections.Specialized.BitVector32;
using System.Xml.Linq;

namespace Yee.Page.Repositories
{
    public class PageRepository
    {
        private readonly DbContextFactory _dbContextFactory;
        private readonly DbContextStateValue _state;
        public PageRepository(DbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
            _state = _dbContextFactory.Create(typeof(PageDbContext));

        }


        public DbContextStateValue GetState()
            => _state;
        public YeePage GetPage(Guid id)
        {
            if (_state.IsWorked == false)
                return null;

            var context = ((Yee.Page.PageDbContext)_state.Context);


            return context.YeePages
                    .Include(p => p.YeeComponents)
                    .ThenInclude(p => p.Properties)
                    .ThenInclude(p => p.YeePropertyValue)
                    .Include(p => p.YeeComponents)
                    .ThenInclude(p => p.Childs).ThenInclude(p => p.Properties).ThenInclude(p => p.YeePropertyValue)
                    .FirstOrDefault(p => p.Id == id);
        }

        public List<YeePropertyValue> GetModelDatas()
        {
            if (_state.IsWorked == false)
                return null;

            var context = ((Yee.Page.PageDbContext)_state.Context);


            return context
                    .YeePropertyValues
                    .Include(p => p.YeeProperties)
                    .Where(p => p.IsModelData)
                    .ToList();
        }


        public YeePage CopyPage(Guid id, string displayName)
        {
            if (_state.IsWorked == false)
                return null;

            var context = ((Yee.Page.PageDbContext)_state.Context);


            var targetPage = GetPage(id);
            if (targetPage == null)
                return null;

            var page = new YeePage
            {
                DisplayName = displayName,
                RouterLink = new YeeCSharpLink
                {

                },
                StyleLink = targetPage.StyleLink,
                YeeComponents = targetPage.YeeComponents,
                BodyClass = targetPage.BodyClass,
                BodyId = targetPage.BodyId
            };
            context.YeePages.Add(page);
            context.SaveChanges();

            return page;
        }

        public YeePage CreatePage(string name)
        {
            if (_state.IsWorked == false)
                return null;

            var context = ((Yee.Page.PageDbContext)_state.Context);


            var page = new YeePage
            {
                DisplayName = name,
                RouterLink = new YeeCSharpLink
                {

                },
                StyleLink = new YeeCSharpLink
                {

                },
                YeeComponents = new List<YeeComponentValues>
                {

                }
            };

            context.YeePages.Add(page);
            context.SaveChanges();

            return page;
        }

        public void PageUpdate(YeePage yeePage)
        {
            if (_state.IsWorked == false)
                return;

            var context = ((Yee.Page.PageDbContext)_state.Context);

            context.YeePages.Update(yeePage);
            context.SaveChanges();
        }

    }
}
