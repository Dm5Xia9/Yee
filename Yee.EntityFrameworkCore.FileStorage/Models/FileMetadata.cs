using Ability.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yee.EntityFrameworkCore.FileStorage.Models
{
    public class FileMetadata : BaseRecord
    {
        public string FileName { get; set; }
        public long FileContentId { get; set; }
        public FileContent FileContent { get; set; }
    }
}
