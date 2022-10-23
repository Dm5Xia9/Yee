using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Abstractions;
using Yee.Admin.Extensions;
using Yee.Blog.Prototypes;
using Yee.Extensions;
using Yee.Section.Extensions;

namespace Yee.Blog
{
    public class Model : IYeeModule
    {
        public void Build(YeeBuilder builder)
        {
            builder
                .YeeAdminCompose(p =>
                {
                    //p.Navigations.Add(new Section.Navigation.NavMenuItem
                    //{
                    //    Title = "Блог",
                    //    ChildItems = new List<Section.Navigation.NavMenuItem>
                    //    {
                    //        new Section.Navigation.NavMenuItem
                    //        {
                    //            Title = "Записи",
                    //            Link = new Section.Prototypes.ProtoLink
                    //            {
                    //                Value = "/admin/blog-items"
                    //            }
                    //        },
                    //        new Section.Navigation.NavMenuItem
                    //        {
                    //            Title = "Категории",
                    //            Link = new Section.Prototypes.ProtoLink
                    //            {
                    //                Value = "/admin/blog-categories"
                    //            }
                    //        },
                    //        new Section.Navigation.NavMenuItem
                    //        {
                    //            Title = "Теги",
                    //            Link = new Section.Prototypes.ProtoLink
                    //            {
                    //                Value = "/admin/blog-tags"
                    //            }
                    //        }
                    //    }
                    //});
                })
                .YeeSections(p =>
                {
                    //p.ProtoHandlers.Add(typeof(ProtoBlogCategory), )
                })
                .AspConfigureServices(p =>
                {
                    p.AddScoped<BlogDbContext>();
                });
        }
    }
}
