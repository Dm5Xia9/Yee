using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yee.Forms.Abstractions
{
    public interface IFormProvider<TForm, TArg>
        where TForm: YeeForm<TArg>
        where TArg: YeeFormArg
    {
        public List<TForm> GetAll();
        public TForm GetById(Guid id);
        public TForm GetByIdAndMethod(Guid id, string method);
        public List<YeeFormResult> GetFormResultsByFormId(Guid id);
        public YeeResultError SaveFormResult(Guid formId, YeeFormResult result);
    }
}
