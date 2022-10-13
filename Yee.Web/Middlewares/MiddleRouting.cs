using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yee.Web.Middlewares
{
    public class MiddleRouting : IMiddleComponent
    {
        public string Id => this.GetType().Name;

        public void Next(WebApplication app)
        {
            app.UseRouting();
        }
    }
}
