using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yee.Web.Middlewares
{
    public class EmptyMiddle : IMiddleComponent
    {
        private readonly string _id;

        public EmptyMiddle(string id)
        {
            _id = id;
        }

        public string Id => _id;

        public void Next(WebApplication app)
        {

        }
    }
}
