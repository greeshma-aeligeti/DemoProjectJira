using DemoJira.Bussiness.DTO;
using DemoJira.Bussiness.ServiceInterface;
using DemoJira.DataAccess.Entities;
using DemoJira.DataAccess.InterfaceForRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace DemoJira.Bussiness.Services
{ 
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository repository;
        //private readonly HttpClient _httpClient;
        

        public TaskService(ITaskRepository repos)

        {
           // _httpClient = httpClient;
            repository = repos;
        }

        public async Task<MyTask> CreateTask(TaskDTO taskDTO)
        {
            MyTask task = new MyTask
            {
                Title = taskDTO.Title,
                Description = taskDTO.Description,
                status = taskDTO.StatusId,
                Priority = taskDTO.Priority,
                HexId = taskDTO.HexaId,
                ProjectId = taskDTO.ProjectId,
                IterationId = taskDTO.IterationId,
              //  AttachmentUrl ="",  
                ExpEndDate = taskDTO.EndDate,
                ExpStartDate = taskDTO.StartDate,
                ActEndDate = DateTime.Now,
                ActStartDate = DateTime.Now,
                Type = taskDTO.Type,
                MyUserId = taskDTO.UserId,
               // RelatedTasks = taskDTO.RelatedTasks



                
            };
           var response= await repository.CreateTask(task);
            return response;
           
           // throw new NotImplementedException();
        }

        public async Task DeleteTask(int Id)
        {
           
            var task=await repository.GetTaskById(Id);
            await repository.DeleteTask(task);
            //throw new NotImplementedException();
        }

        public async Task<IEnumerable<TaskDTO>> GetAllTasks()
        {

            var Tasks= await repository.GetAllTasks();
            var response=  Tasks.Select(t => new TaskDTO
            {
                Id=t.TaskId,
                Title=t.Title,
                HexaId=t.HexId,
                StatusId=t.status,
                Description=t.Description,
                Priority=t.Priority,
                //AttachmentUrl=t.AttachmentUrl,
                StartDate=t.ExpStartDate,
                UserId=t.MyUserId,
                ActStartDate=t.ActStartDate, ActEndDate=t.ActEndDate,
                Type=t.Type,
               // AssignedToUserId = t.AssignedToUserId,
                EndDate =t.ExpEndDate,
                ProjectId=t.ProjectId,
                IterationId =t.IterationId
            });
           return response;
       /*     var response = await _httpClient.GetFromJsonAsync<IEnumerable<TaskDTO>>("api/tasks");
            return response;*/


            //throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProjectDTO>> GetAllProjects()
        {

            var projects = await repository.GetAllProjs();
            var resp = projects.Select(p => new ProjectDTO
            {
                Id = p.Id,
                Name    =p.Name,
               /* Iterations = p.Iterations.Select(c => new IterationDTO
                {
                    Id = c.Id,
                    Name = c.Name,

                }).ToList()
*/
            });
            return resp;

        }

            public async Task<ProjectDTO> GetProjectById(int Id)
        {
            var Proj= await repository.GetProjectById(Id);
            return new ProjectDTO
            {
                Id = Proj.Id,
                Name = Proj.Name,
               
              //  IterationId=Proj.IterationId,
               /* Iterations = Proj.Iterations.Select(c => new IterationDTO { Id = c.Id,
                    Name = c.Name,
                    //projID=Proj.Id
                    
                }).ToList()*/

            };

          //  throw new NotImplementedException();
        }

        public async Task<TaskDTO> GetTaskById(int Id)
        {
            var Task=await repository.GetTaskById(Id);
            if (Task == null) return null;
            return new TaskDTO
            {

                Id = Task.TaskId,
                Title = Task.Title,
                HexaId=Task.HexId,
                StatusId=Task.status,
                Description = Task.Description,
                Priority=Task.Priority,
               // AttachmentUrl=Task.AttachmentUrl,
                StartDate = Task.ExpStartDate,
                EndDate = Task.ExpEndDate,
                ProjectId = Task.ProjectId,
                UserId=Task.MyUserId,
                Type=Task.Type,
                ActStartDate = Task.ActStartDate,
                ActEndDate = Task.ActEndDate,
             //  AssignedToUserId=Task.AssignedToUserId,
                IterationId = Task.IterationId,
               /* Comments = Task.Comments.Select(c => new CommentDTO
                {
                    CommentId = c.CommentId,
                    Content = c.Content,
                    CreatedAt = c.CreatedAt,
                    UserName = c.User.UserName
                }).ToList(),
*/


            };
           
           // throw new NotImplementedException();
        }

        public async Task<TaskDTO> UpdateTask(int Id, TaskDTO taskDTO)
        {
            var existingTask=await repository.GetTaskById(Id);
            if (existingTask == null) return null;

            //existingTask.TaskId = taskDTO.Id;
            existingTask.Title = taskDTO.Title;
            existingTask.Description = taskDTO.Description;
            existingTask.ProjectId = taskDTO.ProjectId;
            existingTask.IterationId = taskDTO.IterationId;
            existingTask.status = taskDTO.StatusId;
           // existingTask.AttachmentUrl = taskDTO.AttachmentUrl;
            existingTask.Priority = taskDTO.Priority;
            existingTask.ExpStartDate = taskDTO.StartDate;
            existingTask.MyUserId = taskDTO.UserId;
            existingTask.Type = taskDTO.Type;
            existingTask.ActStartDate = taskDTO.ActStartDate;
            existingTask.ActEndDate = taskDTO.ActEndDate;
           // existingTask.AssignedToUserId = taskDTO.AssignedToUserId;
            existingTask.ExpEndDate= taskDTO.EndDate;
            
            await repository.UpdateTask(existingTask);
            return taskDTO;




         //   throw new NotImplementedException();
        }

        public async Task<IEnumerable<IterationDTO>> GetAllIterations()
        {
            var iterations = await repository.GetIterationAll();
            var resp = iterations.Select(p => new IterationDTO
            {
                Id = p.IterationId,
                Name = p.Name,
               projID=p.ProjId
            });
            return resp;
        }

       /* public async Task<string> GetAttachmentUrl(int Id)
        {
            var tasks = await repository.GetAllTasks();
            TaskDTO taskDTO = new TaskDTO();
            string s = "";
            foreach(var t in tasks)
            {
                if(t.TaskId == Id)
                {
                   // taskDTO = t; break; 
                   s=t.AttachmentUrl; break;

                }
            }
            return s;

            //throw new NotImplementedException();
        }*/

       /* public async Task<TaskDTO> AddAttachmentToTask(int taskId, Attachment attachment)
        {
            var taskEntity = await repository.AddAttachmentToTask(taskId, attachment);

            // Map entity to DTO
            var taskDto = MapEntityToDto(taskEntity); // Implement this method

            return taskDto;
            // throw new NotImplementedException();
        }*/

        private TaskDTO MapEntityToDto(MyTask Task1)
        {
            return new TaskDTO
            {
                // Map properties as needed
                Id = Task1.TaskId,
                Title = Task1.Title,
                HexaId = Task1.HexId,
                StatusId = Task1.status,
                Description = Task1.Description,
                Priority = Task1.Priority,
                //AttachmentUrl = Task1.AttachmentUrl,
                StartDate = Task1.ExpStartDate,
                EndDate = Task1.ExpEndDate,
                ProjectId = Task1.ProjectId,
                UserId = Task1.MyUserId,
                Type = Task1.Type,
                ActStartDate = Task1.ActStartDate,
                ActEndDate = Task1.ActEndDate,
                //  AssignedToUserId=Task.AssignedToUserId,
                IterationId = Task1.IterationId,
                // Add other properties
            };
        }

        public Task<string> GetAttachmentUrl(int Id)
        {
            throw new NotImplementedException();
        }

        /* public async Task addRelation(TaskDTO t1, TaskDTO t2)
         {
             var task1=await repository.GetTaskById(t1.Id);
           //  if (task1 == null) { return null; }
             var task2 = await repository.GetTaskById(t2.Id);
             task1.RelatedTasks.Add(task2); 
             await repository.UpdateTask(task1);
            // throw new NotImplementedException();
         }*/
    }
}
