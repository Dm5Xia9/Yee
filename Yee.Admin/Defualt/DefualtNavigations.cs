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
        public readonly static IEnumerable<NavMenuItem>
            Value = new List<NavMenuItem>()
            {
                new NavMenuItem
                {
                    Title = "Доска",
                    Link = new ProtoLink() { Value = "/admin" },
                },
                new NavMenuItem
                {
                    Title = "Основное",
                    ChildItems = new List<NavMenuItem>
                    {
                        new NavMenuItem
                        {
                            Title = "Настройки",
                            Link = new ProtoLink() { Value = "/admin/options" },
                        },
                        new NavMenuItem
                        {
                            Title = "Модули",
                            Link = new ProtoLink() { Value = "/admin/modules" },
                        },
                        new NavMenuItem
                        {
                            Title = "Пользователи",
                            Link = new ProtoLink() { Value = "/admin/users" },
                        },
                        new NavMenuItem
                        {
                            Title = "Роли",
                            Link = new ProtoLink() { Value = "/admin/roles" },
                        },
                        new NavMenuItem
                        {
                            Title = "Области",
                            Link = new ProtoLink() { Value = "/admin/pages" },
                        },
                        new NavMenuItem
                        {
                            Title = "Страницы",
                            Link = new ProtoLink() { Value = "/admin/pages" },
                        },
                        new NavMenuItem
                        {
                            Title = "Формы",
                            Link = new ProtoLink() { Value = "/admin/pages" },
                        },
                        new NavMenuItem
                        {
                            Title = "Файлы",
                            Link = new ProtoLink() { Value = "/admin/files" },
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
                            Link = new ProtoLink() { Value = "/admin/pages/create" },
                        },
                        new NavMenuItem
                        {
                            Title = "Страницы",
                            Link = new ProtoLink() { Value = "/admin/pages" },
                        },
                        new NavMenuItem
                        {
                            Title = "Секции",
                            Link = new ProtoLink() { Value = "/admin/sections" },
                        },
                        new NavMenuItem
                        {
                            Title = "Прототипы",
                            Link = new ProtoLink() { Value = "/admin/protos" },
                        },
                        new NavMenuItem
                        {
                            Title = "Данные",
                            Link = new ProtoLink() { Value = "/admin/rules1" },
                        }
                    }
                }
            };
    }
}
