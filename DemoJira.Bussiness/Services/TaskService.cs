using DemoJira.Bussiness.DTO;
using DemoJira.Bussiness.ServiceInterface;
using DemoJira.DataAccess.Entities;
using DemoJira.DataAccess.InterfaceForRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoJira.Bussiness.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository repository;

        public TaskService(ITaskRepository repos)
        {
            this.repository = repos;
        }

        public async Task<TaskDTO> CreateTask(TaskDTO taskDTO)
        {
            var task = new MyTask
            {
                Title = taskDTO.Title,
                desp    =taskDTO.Description,
                CurStatus=taskDTO.CurStatus,
                ProjectId = taskDTO.ProjectId,
                IterationId= taskDTO.IterationId,
                ExpEndDate=taskDTO.EndDate,
                ExpStartDate=taskDTO.StartDate,

                
            };
            await repository.Create(task);
            return taskDTO;
           
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
            return Tasks.Select(t => new TaskDTO
            {
                Id=t.TaskId,
                Title=t.Title,
                Description=t.Description.DespContent,
                StartDate   =t.ExpStartDate,
                EndDate =t.ExpEndDate,
                ProjectId=t.ProjectId,
                IterationId =t.IterationId
            });


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
                Description = Task.Description.DespContent,
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
            existingTask.CurStatus = taskDTO.CurStatus;
            existingTask.ExpStartDate = taskDTO.StartDate;
            existingTask.ExpEndDate= taskDTO.EndDate;

            await repository.UpdateTask(existingTask);
            return taskDTO;




         //   throw new NotImplementedException();
        }
    }
}
