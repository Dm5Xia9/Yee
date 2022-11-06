using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Abstractions;

namespace Yee.Services
{
    public class SourceService : ISourceService
    {
        private readonly Dictionary<Type, Func<object>> _sources = new Dictionary<Type, Func<object>>();
        public void Set<T>(Func<IYeeSource<T>> source)
        {
            _sources[typeof(T)] = source;
        }

        public IYeeSource<T> Get<T>() where T: class
        {
            if (_sources.ContainsKey(typeof(T)) == false)
                return new DefualtYeeSource<T>();

            return (IYeeSource<T>)_sources[typeof(T)]();
        }

    }

    public class DefualtYeeSource<T> : IYeeSource<T>
        where T : class
    {
        public string DisplayName => null;

        public YeeSourceType SourceType => YeeSourceType.NotFound;

        public bool Success => false;

        public T Value => null;
    }


    public class YeeSource<T> : IYeeSource<T>
        where T : class
    {
        public YeeSource(string displayName, YeeSourceType sourceType, bool success, T value)
        {
            DisplayName = displayName;
            SourceType = sourceType;
            Success = success;
            Value = value;
        }

        public string DisplayName { get; set; }

        public YeeSourceType SourceType { get; set; }

        public bool Success { get; set; }

        public T Value { get; set; }
    }
}
