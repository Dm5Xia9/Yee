using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yee.Web.Middlewares
{
    public class MiddleBlazor : IMiddleComponent
    {
        private readonly string _page;

        public MiddleBlazor(string page)
        {
            _page = page;
        }

        public string Id => this.GetType().Name;

        public void Next(WebApplication app)
        {
            app.MapBlazorHub();
            app.MapFallbackToPage(_page);
        }
    }
}
