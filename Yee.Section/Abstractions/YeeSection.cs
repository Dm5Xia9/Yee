using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yee.Section.Abstractions
{
    public class YeeSection : ComponentBase, IYeeSection
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public void ToNav(string link)
        {
            NavigationManager.NavigateTo(link);
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
