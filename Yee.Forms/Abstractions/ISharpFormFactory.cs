using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Forms.SharpForms;

namespace Yee.Forms.Abstractions
{
    public interface ISharpFormFactory
    {
        public SharpForm Create(Type type);
    }
}
