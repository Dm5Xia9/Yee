using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Forms.Abstractions;

namespace Yee.Forms.SharpForms
{
    public class SharpFormCollection : IEnumerable<SharpForm>
    {
        private readonly ISharpFormFactory _sharpFormFactory;
        private readonly List<SharpForm> _list = new List<SharpForm>();

        public SharpFormCollection(ISharpFormFactory sharpFormFactory)
        {
            _sharpFormFactory = sharpFormFactory;
        }

        public void Add<T>()
        {
            _list.Add(_sharpFormFactory.Create(typeof(T)));
        }

        public IEnumerator<SharpForm> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    }
}
