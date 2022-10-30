using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Yee.Forms.Abstractions
{
    public interface ISharpFormLinksRepository
    {
        public Dictionary<Type, SharpFormLink> GetAllForms();
        public void AddOrUpdate(SharpFormLink form);
    }

    public class SharpFormLink
    {
        public virtual Guid Id { get; set; }
        public virtual Type Type { get; set; }
        public virtual Dictionary<PropertyInfo, Guid> Properties { get; set; }
    }
}
