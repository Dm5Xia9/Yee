﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleGate.EntityFrameworkCore.Npgsql
{
    public class NpgsqlOptions
    {
        public string ConnectionString { get; set; }
        public int Timeout { get; set; } = 800;
    }
}
