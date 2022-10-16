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
                new ActionMenuItem
                {
                    Title = "Доска",
                    Link = new ProtoLink() { Value = "/admin" },
                },
                new GroupMenuItem
                {
                    Title = "Основное",
                    ChildItems = new List<ActionMenuItem>
                    {
                        new ActionMenuItem
                        {
                            Title = "Настройки",
                            Link = new ProtoLink() { Value = "/admin/options" },
                        },
                        new ActionMenuItem
                        {
                            Title = "Модули",
                            Link = new ProtoLink() { Value = "/admin/modules" },
                        },
                        new ActionMenuItem
                        {
                            Title = "Пользователи",
                            Link = new ProtoLink() { Value = "/admin/users" },
                        },
                        new ActionMenuItem
                        {
                            Title = "Роли",
                            Link = new ProtoLink() { Value = "/admin/roles" },
                        },
                        new ActionMenuItem
                        {
                            Title = "Области",
                            Link = new ProtoLink() { Value = "/admin/pages" },
                        },
                        new ActionMenuItem
                        {
                            Title = "Страницы",
                            Link = new ProtoLink() { Value = "/admin/pages" },
                        },
                        new ActionMenuItem
                        {
                            Title = "Формы",
                            Link = new ProtoLink() { Value = "/admin/pages" },
                        },
                    }
                },
                new GroupMenuItem
                {
                    Title = "Конструктор страниц",
                    ChildItems = new List<ActionMenuItem>
                    {
                        new ActionMenuItem
                        {
                            Title = "Страницы",
                            Link = new ProtoLink() { Value = "/admin/modules1" },
                        },
                        new ActionMenuItem
                        {
                            Title = "Секции",
                            Link = new ProtoLink() { Value = "/admin/users1" },
                        },
                        new ActionMenuItem
                        {
                            Title = "Данные",
                            Link = new ProtoLink() { Value = "/admin/rules1" },
                        }
                    }
                }
            };
    }
}
