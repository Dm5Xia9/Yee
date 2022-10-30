using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yee.EntityFrameworkCore.Manager
{
    public class DbContextState : Dictionary<Type, DbContextStateInfo>
    {
        public DbContextStateInfo GetState<T>()
        {
            return this[typeof(T)];
        }

        public void SetState<T>(DbContextStateInfo value)
        {
            if (this.ContainsKey(typeof(T)))
            {
                this[typeof(T)] = value;
            }
            else
            {
                this.Add(typeof(T), value);
            }
        }
    }

    public class DbContextStateInfo
    {
        public bool IsWorked { get; set; }
        public bool Migrated { get; set; }
        public Exception Exception { get; set; }
        public bool ReadyForWork => IsWorked == true && Migrated == true;
    }
}
