using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yee.Web
{
    public class NotFoundBuilder
    {

        private readonly Stack<Func<NavigationManager, Type>> _funcs = new Stack<Func<NavigationManager, Type>>();
        public void Use(Func<NavigationManager, Type> func)
        {
            _funcs.Push(func);
        }

        internal Type BuildCurrentComponent(NavigationManager navigationManager)
        {
            foreach(var item in _funcs)
            {
                var type = item(navigationManager);

                if (type != null)
                    return type;
            }

            return null;
        }
    }


}
