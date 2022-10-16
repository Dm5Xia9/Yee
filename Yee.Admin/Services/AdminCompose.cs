﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Section.Navigation;

namespace Yee.Admin.Services
{
    public class AdminCompose
    {
        public AdminCompose()
        {
            Navigations = new List<NavMenuItem>();
        }

        public List<NavMenuItem> Navigations { get; init; }


    }
}
