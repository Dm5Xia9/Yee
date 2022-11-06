using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yee.Abstractions
{
    public interface IYeeSource<T>
    {
        public string DisplayName { get; }
        public YeeSourceType SourceType { get; }
        public bool Success { get; }
        public T Value { get; }
    }

    public enum YeeSourceType
    {
        None,
        NotFound,
        Database,

    }
}
