using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuelGate.Options
{
    public class FlexOptionsFactory
    {
        private readonly IFlexOptionsProvider _flexOptionsProvider;
        public FlexOptionsFactory(IEnumerable<IFlexOptionsProvider> flexOptionsProviders)
        {
            var notDefualt = flexOptionsProviders
                    .SingleOrDefault(p => p.GetType() != typeof(DefualtProvider));

            if (notDefualt == null)
                _flexOptionsProvider = flexOptionsProviders
                    .Single(p => p.GetType() == typeof(DefualtProvider));
            else
            {
                _flexOptionsProvider = notDefualt;
            }
        }

        public IFlexOptions<T> Create<T>()
        {
            return new FlexOptions<T>(_flexOptionsProvider.GetOptions<T>());
        }
    }
}
