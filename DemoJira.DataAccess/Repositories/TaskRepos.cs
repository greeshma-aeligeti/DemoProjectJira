using DemoJira.DataAccess.Entities;
using DemoJira.DataAccess.InterfaceForRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoJira.DataAccess.Repositories
{
    public class TaskRepos : ITaskRepository
    {
        private readonly SiraDBContext _dbContext=null;

       public TaskRepos(SiraDBContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task Create(MyTask task)
        {
            _dbContext.Tasks.Add(task);
             await _dbContext.SaveChangesAsync();

            //throw new NotImplementedException();
        }

        public async Task DeleteTask(MyTask task)
        {
            _dbContext.Tasks.Remove(task);
           await _dbContext.SaveChangesAsync();
           // throw new NotImplementedException();
        }

        public async Task<IEnumerable< MyTask>> GetAllTasks()
        {
            return await _dbContext.Tasks.ToListAsync();
           // throw new NotImplementedException();
        }

        public async Task<MyTask> GetTaskById(int id)
        {
            var Task=from t in _dbContext.Tasks
                     where t.TaskId == id
                     select t;
            MyTask t1=new MyTask();
            foreach(var t in _dbContext.Tasks)
            {
                t1 = t;
            }
            return t1;
            //throw new NotImplementedException();
        }

        public async Task UpdateTask(MyTask task)
        {
            var existingTask=_dbContext.Tasks.FirstOrDefault(t => t.TaskId == task.TaskId);
            if(existingTask != null)
            {
                existingTask.TaskId = task.TaskId;
                existingTask.Title = task.Title;
                existingTask.CurStatus = task.CurStatus;
                existingTask.Area = task.Area;
                existingTask.Iteration  = task.Iteration;
                existingTask.ExpStartDate = task.ExpStartDate;
                existingTask.ExpEndDate
                    = task.ExpEndDate;
                existingTask.desp = task.desp;
                existingTask.Description= task.Description;
                existingTask.Priority   = task.Priority;
              await  _dbContext.SaveChangesAsync();
            }
           // throw new NotImplementedException();
        }
    }
}
