using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Abstractions;

namespace Yee.Services
{
    public class FileStorageCollection: List<IFileStorage>, IFileStorageCollection
    {

    }
}
