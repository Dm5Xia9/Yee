using Ability.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yee.EntityFrameworkCore.FileStorage.Models
{
    public class FileContent : BaseRecord
    {
        public byte[] Data { get; set; }
    }
}
