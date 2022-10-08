using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleGate
{
    [AttributeUsageAttribute(AttributeTargets.Class, Inherited = true, AllowMultiple = true)]

    public abstract class MarkerAttribute : Attribute
    {
        protected MarkerAttribute(string localUri)
        {
            LocalUri = localUri;
        }

        public string LocalUri { get; set; }

    }
}
