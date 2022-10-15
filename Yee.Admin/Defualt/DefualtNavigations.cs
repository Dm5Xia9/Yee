using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Section.Navigation;
using Yee.Section.Prototypes;

namespace Yee.Admin.Defualt
{
    public static class DefualtNavigations
    {
        public readonly static IEnumerable<IMenuItem>
            Value = new List<IMenuItem>()
            {
                new GroupMenuItem
                {
                    Title = "Основное",
                    Link = new ProtoLink() { Value = "/admin/modules" },
                    ChildItems = new List<ActionMenuItem>
                    {
                        new ActionMenuItem
                        {
                            Title = "Модули",
                            Link = new ProtoLink() { Value = "/test2" },
                        },
                        new ActionMenuItem
                        {
                            Title = "Пользователи",
                            Link = new ProtoLink() { Value = "/admin/users" },
                        },
                        new ActionMenuItem
                        {
                            Title = "Роли",
                            Link = new ProtoLink() { Value = "/admin/rules" },
                        },
                        new ActionMenuItem
                        {
                            Title = "Области",
                            Link = new ProtoLink() { Value = "/admin/pages" },
                        },
                    }
                },
                new GroupMenuItem
                {
                    Title = "Конструктор страниц",
                    Link = new ProtoLink() { Value = "/admin/modules" },
                    ChildItems = new List<ActionMenuItem>
                    {
                        new ActionMenuItem
                        {
                            Title = "Страницы",
                            Link = new ProtoLink() { Value = "/admin/modules" },
                        },
                        new ActionMenuItem
                        {
                            Title = "Секции",
                            Link = new ProtoLink() { Value = "/admin/users" },
                        },
                        new ActionMenuItem
                        {
                            Title = "Данные",
                            Link = new ProtoLink() { Value = "/admin/rules" },
                        }
                    }
                }
            };
    }
}
