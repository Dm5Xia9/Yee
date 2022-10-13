using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yee.Forms.Controllers
{

    [Area("YeeForms")]
    [ApiController]
    public class FormController : Controller
    {
        [Route("forms/{formId}/")]
        [HttpGet]
        public List<string> FormHandlerGet(Guid formId, 
            [FromQuery] Dictionary<string, string>? args)
        {
            if(args == null || args.Any() == false)
            {
                args = HttpContext.Request.Query
                    .ToDictionary(p => p.Key, p => (string)p.Value);
            }

            return new List<string>() { $"сасай {formId} раз" };
        }

        [Route("forms/{formId}/")]
        [HttpPost]
        public List<string> FormHandlerPost(Guid formId)
        {
            return new List<string>() { $"сасай {formId} раз" };
        }
    }
}
