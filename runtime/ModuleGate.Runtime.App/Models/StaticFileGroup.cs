using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleGate.Runtime.App.Models
{
    public class StaticFileGroup : IGrouping<string, StaticFile>
    {
        private string _key;
        private List<StaticFile> _staticFiles;

        public StaticFileGroup(string key, List<StaticFile> staticFiles)
        {
            _key = key;
            _staticFiles = staticFiles;
        }

        public string Key => _key;

        public IEnumerator<StaticFile> GetEnumerator()
        {
            return _staticFiles.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _staticFiles.GetEnumerator();
        }
    }
}
