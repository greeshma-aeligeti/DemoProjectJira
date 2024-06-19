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
        private readonly SiraDBContext _dbContext;

       public TaskRepos(SiraDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<MyTask> CreateTask(MyTask task)
        {
          var response=  await _dbContext.Tasks.AddAsync(task);
             await _dbContext.SaveChangesAsync();
            return response.Entity;

            //throw new NotImplementedException();
        }

        public async Task DeleteTask(MyTask task)
        {
            if (task != null)
            {
                _dbContext.Tasks.Remove(task);
                await _dbContext.SaveChangesAsync();
            }
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

        public async Task<MyTask> UpdateTask(MyTask task)
        {
            var existingTask=await _dbContext.Tasks.FirstOrDefaultAsync(t => t.TaskId == task.TaskId);
            if(existingTask != null)
            {
                existingTask.TaskId = task.TaskId;
                existingTask.Title = task.Title;
                existingTask.status = task.status   ;
                existingTask.Area = task.Area;
                existingTask.Iteration  = task.Iteration;
                existingTask.ExpStartDate = task.ExpStartDate;
                existingTask.ExpEndDate
                    = task.ExpEndDate;
                existingTask.desp = task.desp;
                existingTask.Description= task.Description;
                existingTask.Priority   = task.Priority;
             
            }
            await _dbContext.SaveChangesAsync();
            return existingTask;
           // throw new NotImplementedException();
        }
    }
}
