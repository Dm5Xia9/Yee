using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yee.Web.Abstractions
{
    public abstract class UpdatedPage : ComponentBase, IUpdatedPage
    {
        public abstract void Update();

    }
    public interface IUpdatedPage
    {
        public void Update();
    }
}
