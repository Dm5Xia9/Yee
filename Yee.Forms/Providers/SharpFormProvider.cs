using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Forms.Abstractions;
using Yee.Forms.SharpForms;

namespace Yee.Forms.Providers
{
    public class SharpFormProvider : IFormProvider<SharpForm, SharpFormArg>
    {
        public List<SharpForm> GetAll()
        {
            throw new NotImplementedException();
        }

        public SharpForm GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public SharpForm GetByIdAndMethod(Guid id, string method)
        {
            throw new NotImplementedException();
        }

        public List<YeeFormResult> GetFormResultsByFormId(Guid id)
        {
            throw new NotImplementedException();
        }

        public YeeResultError SaveFormResult(Guid formId, YeeFormResult result)
        {
            throw new NotImplementedException();
        }
    }
}
