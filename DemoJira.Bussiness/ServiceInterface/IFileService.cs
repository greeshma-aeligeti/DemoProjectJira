using DemoJira.Bussiness.DTO;
using DemoJira.DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoJira.Bussiness.ServiceInterface
{
    public interface IFileService
    {
        Task<bool> UploadFile(List<IFormFile> files, string TaskID);
        Task<IEnumerable<FileDTO>> GetFilesWithTaskID(string TaskID);
        Task<FileDTO> GetFileById(int fileId);
    }
}

