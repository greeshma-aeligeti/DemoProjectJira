using DemoJira.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoJira.DataAccess.InterfaceForRepo
{
    public interface ITaskRepository
    {
        Task<MyTask> CreateTask(MyTask task);
        Task<IEnumerable< MyTask>> GetAllTasks();
        Task<MyTask> GetTaskById(string id);
        Task<MyTask> UpdateTask(MyTask task);
        Task DeleteTask(MyTask task);
        Task <Project> GetProjectById(int id);
        Task<IEnumerable<Project>> GetAllProjs();
        Task<IEnumerable<Iteration>> GetIterationAll();
        Task AddTaskRelationshipAsync(TaskRelationship relationship);
        Task RemoveTaskRelationshipAsync(string parentTaskId, string childTaskId);
        Task<List<TaskRelationship>> GetTaskRelationshipsAsync(string taskId);
        Task<bool> IsChildOfAsync(string parentTaskId, string childTaskId);
        /// Task<MyTask> AddAttachmentToTask(int taskId, Attachment attachment);

    }
}
