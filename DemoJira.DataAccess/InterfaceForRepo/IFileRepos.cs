using DemoJira.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoJira.DataAccess.InterfaceForRepo
{
    public interface IFileRepos
    {
        Task UploadFile(MyFile file);
        Task<IEnumerable<MyFile>> GetAllFilesByTaskID(int id);
        Task<MyFile> GetFileById(int fileId);

    }
}
