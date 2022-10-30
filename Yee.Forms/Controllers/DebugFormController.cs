using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Forms.SharpForms;

namespace Yee.Forms.Controllers
{
    [Area("YeeForms")]
    [ApiController]
    public class DebugFormController : Controller
    {
        private readonly SharpFormCollection _sharpFormCollection;
        private readonly IHostEnvironment _hostEnvironment;
        public DebugFormController(SharpFormCollection sharpFormCollection, 
            IHostEnvironment hostEnvironment)
        {
            _sharpFormCollection = sharpFormCollection;
            _hostEnvironment = hostEnvironment;
        }

        [Route("debug-forms/{formName}/")]
        [HttpGet]
        public DebugFormResult FormHandlerGet(string formName,
            [FromQuery] Dictionary<string, string>? args)
        {
            if (formName == null || _hostEnvironment.IsDevelopment() == false)
            {
                HttpContext.Response.StatusCode = 404;
                return DebugFormResult.FromError();
            }

            var form = _sharpFormCollection
                .FirstOrDefault(p => p.Method == HttpConst.GET && p.DebugName == formName);

            if (form == null)
            {
                HttpContext.Response.StatusCode = 404;
                return DebugFormResult.FromError();
            }

            if (args == null || args.Any() == false)
            {
                args = HttpContext.Request.Query
                    .ToDictionary(p => p.Key, p => (string)p.Value);
            }

            var result = new DebugFormResult();
            result.Properties = new Dictionary<string, string>();
            result.Excess = new Dictionary<string, string>();
            result.Id = form.Id;
            foreach (var arg in args)
            {
                var formArg = form.Args
                    .FirstOrDefault(p => p.Key == arg.Key);

                if (formArg != null)
                {
                    result.Properties.Add(formArg.Key, arg.Value);
                }
                else
                {
                    result.Excess.Add(arg.Key, arg.Value);
                }
            }

            var notFilled = form.Args
                .Where(p => p.Required && !result.Properties.ContainsKey(p.Key));

            if (notFilled.Any())
            {
                result.Error = true;
                result.NotFilled = notFilled
                    .ToDictionary(p => p.Key, p => p.Type.Name);
            }

            return result;

        }
    }

    public class DebugFormResult
    {
        public Guid Id { get; set; }
        public Dictionary<string, string> Properties { get; set; }
        public Dictionary<string, string> Excess { get; set; }
        public bool Error { get; set; }
        public Dictionary<string, string> NotFilled { get; set; }
        public static DebugFormResult FromError()
        {
            return new DebugFormResult
            {
                Error = true
            };
        }
    }
}
