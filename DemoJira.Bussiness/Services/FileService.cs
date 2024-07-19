using DemoJira.Bussiness.DTO;
using DemoJira.Bussiness.ServiceInterface;
using DemoJira.DataAccess.Entities;
using DemoJira.DataAccess.InterfaceForRepo;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoJira.Bussiness.Services
{
    public class FileService : IFileService
    {
        private readonly IFileRepos fileRepos;
        private readonly ITaskRepository taskRepository;
        public FileService(IFileRepos repos, ITaskRepository taskRepository)
        {

            fileRepos = repos;
            this.taskRepository = taskRepository;
        }

        public async Task<FileDTO> GetFileById(int fileId)
        {
            var file = await fileRepos.GetFileById(fileId);
            if (file == null)
            {
                return null;
            }

            // Map to FileDTO or return as needed
            return new FileDTO
            {
                Id = file.Id,
                FileName = file.FileName,
                Content = file.Content, // Consider not returning content here, or handle it securely
                ContentType = file.ContentType,
                Size = file.Size,
                TaskId = file.TaskId,
                UploadTime = file.UploadTime
            };
        }

        public async Task<IEnumerable<FileDTO>> GetFilesWithTaskID(string TaskID)
        {

            var files= await fileRepos.GetAllFilesByTaskID(TaskID);
            List <FileDTO>  res= new List<FileDTO>();
            foreach(var file in files) {
                res.Add(new FileDTO { 
                Id = file.Id,
                FileName = file.FileName,
                Content = file.Content,
                ContentType = file.ContentType,
                Size = file.Size,
                TaskId=file.TaskId,
                UploadTime=file.UploadTime
                
                
                }
                    
                    
                    );

            }
            return res;

            //throw new NotImplementedException();
        }

        public async Task<bool> UploadFile(List<IFormFile> files, string TaskID)
        {
            var workItem = await taskRepository.GetTaskById(TaskID);
            if (workItem == null)
            {
                return false;
            }

            foreach (var file in files)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);

                    var fileUpload = new MyFile
                    {
                        FileName = file.FileName,
                        Content = memoryStream.ToArray(),
                        UploadTime=DateTime.Now,
                        ContentType = file.ContentType,
                        Size = file.Length,
                        TaskId = TaskID
                    };

                    await fileRepos.UploadFile(fileUpload);
                }
            }

            return true;
            //  throw new NotImplementedException();
        }
       
    }
}
