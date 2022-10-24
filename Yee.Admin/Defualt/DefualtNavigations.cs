using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Section.Base;

namespace Yee.Admin.Defualt
{
    public static class DefualtNavigations
    {
        public readonly static IEnumerable<NavMenuItem>
            Value = new List<NavMenuItem>()
            {
                new NavMenuItem
                {
                    Title = "Доска",
                    Link = "/admin",
                },
                new NavMenuItem
                {
                    Title = "Основное",
                    ChildItems = new List<NavMenuItem>
                    {
                        new NavMenuItem
                        {
                            Title = "Настройки",
                            Link = "/admin/options",
                        },
                        new NavMenuItem
                        {
                            Title = "Модули",
                            Link = "/admin/modules",
                        },
                        new NavMenuItem
                        {
                            Title = "Пользователи",
                            Link = "/admin/users",
                        },
                        new NavMenuItem
                        {
                            Title = "Роли",
                            Link = "/admin/roles",
                        },
                        new NavMenuItem
                        {
                            Title = "Машрутизация",
                            Link = "/admin/routers",
                        },
                        new NavMenuItem
                        {
                            Title = "Страницы",
                            Link = "/admin/pages",
                        },
                        new NavMenuItem
                        {
                            Title = "Формы",
                            Link = "/admin/pages",
                        },
                        new NavMenuItem
                        {
                            Title = "Файлы",
                            Link = "/admin/files",
                        },
                    }
                },
                new NavMenuItem
                {
                    Title = "Конструктор страниц",
                    ChildItems = new List<NavMenuItem>
                    {
                        new NavMenuItem
                        {
                            Title = "Создать страницу",
                            Link = "/admin/pages/create",
                        },
                        new NavMenuItem
                        {
                            Title = "Страницы",
                            Link = "/admin/pages",
                        },
                        new NavMenuItem
                        {
                            Title = "Секции",
                            Link = "/admin/sections",
                        },
                        new NavMenuItem
                        {
                            Title = "Прототипы",
                            Link = "/admin/protos",
                        },
                        new NavMenuItem
                        {
                            Title = "Данные",
                            Link = "/admin/rules1",
                        }
                    }
                }
            };
    }
}
