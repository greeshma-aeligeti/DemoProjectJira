using DemoJira.DataAccess.Entities;
using DemoJira.DataAccess.InterfaceForRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoJira.DataAccess.Repositories
{
    public class FileRepos : IFileRepos
    {
        private readonly SiraDBContext _dbContext;
        public FileRepos(SiraDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task DeleteFile(MyFile file)
        {
            if (file != null)
            {
                 _dbContext.Files.Remove(file);
                await _dbContext.SaveChangesAsync();
            }
           // throw new NotImplementedException();
        }

        public async Task<IEnumerable<MyFile>> GetAllFilesByTaskID(string id)
        {
            return await _dbContext.Files.Where(file => file.TaskId == id).ToListAsync();
        }

        public async Task<MyFile> GetFileById(int fileId)
        {
            return await _dbContext.Files.FirstOrDefaultAsync(file => file.Id == fileId);
        }

        public async Task UploadFile(MyFile file)
        {

           var resp= await _dbContext.Files.AddAsync(file);
            await _dbContext.SaveChangesAsync();
        
        }
    }
}
