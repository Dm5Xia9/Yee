using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Section.Prototypes;

namespace Yee.Section.Abstractions
{
    public class YeeSection : ComponentBase, IYeeSection
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public void ToNav(ProtoLink link)
        {
            NavigationManager.NavigateTo(link.Value);
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }
    }

    public interface IYeeSection
    {


    }
}
