using Ability.Core.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.EntityFrameworkCore.Abstractions;
using Yee.EntityFrameworkCore.FileStorage.Models;

namespace Yee.EntityFrameworkCore.FileStorage
{
    public class FileStorageDbContext : AbilityDbContext
    {
        public FileStorageDbContext(IDbContextOptionsProvider provider) : base("FileStorage", provider)
        {
        }

        public DbSet<FileMetadata> FileMetadata { get; set; }
        public DbSet<FileContent> FileContents { get; set; }
        

    }
}
