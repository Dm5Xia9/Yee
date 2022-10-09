using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleGate.Services
{
    public class ModuleGateService
    {
        private readonly string _rootPath;
        private readonly string _slPaht;

        public ModuleGateService(string rootPath, string slPaht)
        {
            _rootPath = rootPath;
            _slPaht = slPaht;
        }

        public List<string> GetAllModules()
        {
            var all = Directory
                    .GetFiles(_slPaht, "*.dll", SearchOption.AllDirectories)
                    .Where(p => p.Contains("bin\\Debug\\net6.0"))
                    .ToList();

            var fileNameAndCreated = all
                .GroupBy(p => Path.GetFileName(p), 
                p => new { Create = new FileInfo(p).CreationTimeUtc, p });

            var resultList = new List<string>();

            foreach(var group in fileNameAndCreated)
            {
                resultList.Add(group.OrderBy(p => p.Create).First().p);
            }

            return resultList
                .Where(p => Path.GetFileName(p).Contains("ModuleGate") ||
                Path.GetFileName(p).Contains("ModuelGate"))
                .ToList();
        }

        public ModuleGateStorage GetStorage(string name)
        {
            return null;
            //return new ModuleGateStorage(Path.Combine(_rootPath, name));

        }


    }
}
