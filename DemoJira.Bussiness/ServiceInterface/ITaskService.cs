using DemoJira.Bussiness.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoJira.Bussiness.ServiceInterface
{
    public interface ITaskService
    {
        Task<TaskDTO> CreateTask(TaskDTO taskDTO);  
        Task<TaskDTO> UpdateTask(int Id,TaskDTO taskDTO);
        Task DeleteTask(int Id);
        Task<TaskDTO> GetTaskById(int Id);
        Task <IEnumerable<TaskDTO>> GetAllTasks();  

    }
}
