using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yee.EntityFrameworkCore.FileStorage.Services
{
    public class FileStorageManager
    {
        private readonly DbContextFactory _dbContextFactory;
        private readonly DbContextStateValue _state;
        public FileStorageManager(DbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;

            _state = _dbContextFactory.Create(typeof(FileStorageDbContext));
        }

        public void SetFile(string fileName, byte[] bytes) 
        {
            if (!_state.IsWorked)
                return;

            var ctx = (_state.Context as FileStorageDbContext)!;

            var file = ctx.FileMetadata
                .Include(p => p.FileContent)
                .FirstOrDefault(p => p.FileName == fileName);

            if(file != null)
            {
                file.FileContent.Data = bytes;

                ctx.FileMetadata.Update(file);
                
            }
            else
            {
                ctx.FileMetadata.Add(new Models.FileMetadata
                {
                    FileName = fileName,
                    FileContent = new Models.FileContent
                    {
                        Data = bytes
                    }
                });

            }

            ctx.SaveChanges();
        }

        public byte[]? ReadFile(string fileName)
        {
            if (!_state.IsWorked)
                return null;

            var ctx = (_state.Context as FileStorageDbContext)!;

            var file = ctx.FileMetadata
                .Include(p => p.FileContent)
                .FirstOrDefault(p => p.FileName == fileName);

            if (file == null)
                return null;

            return file.FileContent.Data;
        }
    }
}
