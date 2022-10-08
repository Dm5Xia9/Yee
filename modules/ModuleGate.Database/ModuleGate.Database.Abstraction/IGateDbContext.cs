using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleGate.Database.Abstraction
{
    public interface IGateDbContext
    {
        public IGateSet<T> Set<T>() where T : class;
        public void Update<T>(T entity);
        public void Add<T>(T entity);
        public void SaveChanges();
    }
}
