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
        Task Create(MyTask task);
        Task<IEnumerable< MyTask>> GetAllTasks();
        Task<MyTask> GetTaskById(int id);
        Task UpdateTask(MyTask task);
        Task DeleteTask(MyTask task);
    }
}
