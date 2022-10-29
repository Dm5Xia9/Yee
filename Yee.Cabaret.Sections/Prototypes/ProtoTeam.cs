﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Section.Abstractions;
using Yee.Section.Base;

namespace Yee.Cabaret.Sections.Prototypes
{
    public class ProtoTeam : BaseYeeProto<List<Employee>>
    {
    }

    public class Employee
    {
        public ProtoString Name { get; set; }
        public ProtoString Post { get; set; }
        public ProtoImg Img { get; set; }
    }
}
