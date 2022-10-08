using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleGate.Middlewares
{
    public class MiddleNotDevelopment : IMiddleComponent
    {
        public string Id => this.GetType().Name;

        public void Next(WebApplication app)
        {
            if (!app.Environment.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
                app.UseHsts();
            }
            else
            {
                //app.UseDeveloperExceptionPage();

            }
        }
    }
}
