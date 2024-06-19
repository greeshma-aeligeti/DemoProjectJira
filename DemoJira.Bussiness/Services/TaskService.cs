using DemoJira.Bussiness.DTO;
using DemoJira.Bussiness.ServiceInterface;
using DemoJira.DataAccess.Entities;
using DemoJira.DataAccess.InterfaceForRepo;
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
        private readonly HttpClient _httpClient;
        

        public TaskService(ITaskRepository repos,HttpClient httpClient)

        {
            _httpClient = httpClient;
            repository = repos;
        }

        public async Task<MyTask> CreateTask(TaskDTO taskDTO)
        {
            MyTask task = new MyTask
            {
                Title = taskDTO.Title,
                desp    =taskDTO.Description,
              status = taskDTO.CurStatus,
                ProjectId = taskDTO.ProjectId,
                IterationId= taskDTO.IterationId,
                ExpEndDate=taskDTO.EndDate,
                ExpStartDate=taskDTO.StartDate,

                
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
                CurStatus=t.status,
                Description=t.desp,
                StartDate=t.ExpStartDate,
                EndDate =t.ExpEndDate,
                ProjectId=t.ProjectId,
                IterationId =t.IterationId
            });
           return response;
       /*     var response = await _httpClient.GetFromJsonAsync<IEnumerable<TaskDTO>>("api/tasks");
            return response;*/


            //throw new NotImplementedException();
        }

        public async Task<TaskDTO> GetTaskById(int Id)
        {
            var Task=await repository.GetTaskById(Id);
            if (Task == null) return null;
            return new TaskDTO
            {

                Id = Task.TaskId,
                Title = Task.Title,
                CurStatus=Task.status,
                Description = Task.desp,
                StartDate = Task.ExpStartDate,
                EndDate = Task.ExpEndDate,
                ProjectId = Task.ProjectId,
                IterationId = Task.IterationId


            };
           
           // throw new NotImplementedException();
        }

        public async Task<TaskDTO> UpdateTask(int Id, TaskDTO taskDTO)
        {
            var existingTask=await repository.GetTaskById(Id);
            if (existingTask == null) return null;

            existingTask.Title = taskDTO.Title;
            existingTask.desp = taskDTO.Description;
            existingTask.ProjectId = taskDTO.ProjectId;
            existingTask.IterationId = taskDTO.IterationId;
            existingTask.status = taskDTO.CurStatus;
            existingTask.ExpStartDate = taskDTO.StartDate;
            existingTask.ExpEndDate= taskDTO.EndDate;

            await repository.UpdateTask(existingTask);
            return taskDTO;




         //   throw new NotImplementedException();
        }
    }
}
