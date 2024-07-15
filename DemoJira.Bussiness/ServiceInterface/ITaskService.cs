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
        Task<TaskDTO> UpdateTask(int Id, TaskDTO taskDTO);
        Task DeleteTask(int Id);
        Task<TaskDTO> GetTaskById(int Id);
        Task<IEnumerable<TaskDTO>> GetAllTasks();
       // Task<string> GetAttachmentUrl(int Id);
        Task<ProjectDTO> GetProjectById(int Id);
        Task<IEnumerable<ProjectDTO>> GetAllProjects();
        Task<IEnumerable<IterationDTO>> GetAllIterations();
        Task AddTaskRelationshipAsync(TaskRelationshipDTO relationshipDTO);
        Task RemoveTaskRelationshipAsync(int parentTaskId, int childTaskId);
        Task<List<TaskRelationshipDTO>> GetTaskRelationshipsAsync(int taskId);
        
        }      
}
