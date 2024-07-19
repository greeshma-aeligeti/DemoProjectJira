using DemoJira.Bussiness.DTO;
using DemoJira.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoJira.Bussiness.ServiceInterface
{
    public interface ITaskService
    {
        Task<MyTask> CreateTask(TaskDTO taskDTO);
        Task<TaskDTO> UpdateTask(string Id, TaskDTO taskDTO);
        Task DeleteTask(string Id);
        Task<TaskDTO> GetTaskById(string Id);
        Task<IEnumerable<TaskDTO>> GetAllTasks();
       // Task<string> GetAttachmentUrl(int Id);
        Task<ProjectDTO> GetProjectById(int Id);
        Task<IEnumerable<ProjectDTO>> GetAllProjects();
        Task<IEnumerable<IterationDTO>> GetAllIterations();
        Task AddTaskRelationshipAsync(TaskRelationshipDTO relationshipDTO);
        Task RemoveTaskRelationshipAsync(string parentTaskId, string childTaskId);
        Task<List<TaskRelationshipDTO>> GetTaskRelationshipsAsync(string taskId);

    }
}
