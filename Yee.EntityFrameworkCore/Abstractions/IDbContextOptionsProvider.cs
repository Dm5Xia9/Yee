using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yee.EntityFrameworkCore.Abstractions
{
    public interface IDbContextOptionsProvider
    {
        public DbContextOptions GetOptions(string schema);
    }
}
