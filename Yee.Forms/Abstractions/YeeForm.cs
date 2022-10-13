using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yee.Forms.Abstractions
{

    public abstract class YeeForm<TArg>
        where TArg : YeeFormArg
    {
        public virtual string DisplayName { get; set; }
        public virtual string Method { get; set; }
        public virtual Guid Id { get; set; }
        public virtual List<YeeFormArg> Args { get; set; }
    }

    public abstract class YeeFormArg
    {
        public virtual Guid Id { get; set; }
        public virtual string DisplayName { get; set; }
        public virtual bool Required { get; set; }
        public virtual string Key { get; set; }
        public virtual Type Type { get; set; }
    }

    public class YeeFormResult
    {
        public bool Ok { get; set; }
        public List<YeeResultError> Errors { get; set; }
    }

    public class YeeResultError
    {
        public Guid ArgId { get; set; }
        public string DisplayName { get; set; }
    }
}
