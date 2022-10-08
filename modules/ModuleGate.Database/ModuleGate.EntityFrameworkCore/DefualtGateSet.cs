using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ModuleGate.Database.Abstraction;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ModuleGate.EntityFrameworkCore
{
    public class DefualtGateSet<T> : IGateSet<T>
        where T : class
    {
        private readonly DbSet<T> _gateSet;

        public DefualtGateSet(DbSet<T> gateSet)
        {
            _gateSet = gateSet;
        }  

        public Type ElementType => (_gateSet as IQueryable).ElementType;

        public Expression Expression => (_gateSet as IQueryable).Expression;

        public IQueryProvider Provider => (_gateSet as IQueryable).Provider;

        public IEnumerator<T> GetEnumerator()
        {
            return (_gateSet as IQueryable<T>).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (_gateSet as IQueryable<T>).GetEnumerator();
        }
    }
}
