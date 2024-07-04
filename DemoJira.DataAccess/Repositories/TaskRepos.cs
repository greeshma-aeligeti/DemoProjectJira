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
            var rels = await _dbContext.Relations.ToListAsync();

            foreach(TasksRelation r in rels)
            {
                if(task.TaskId==r.TaskId1 || task.TaskId == r.TaskId2)
                {
                     _dbContext.Relations.Remove(r);
                    await _dbContext.SaveChangesAsync();
                }
            }

            var task1 = await _dbContext.Tasks
           .Include(t => t.Comments)
           .FirstOrDefaultAsync(t => t.TaskId == task.TaskId);
            if (task != null)
            {
                _dbContext.Comments.RemoveRange(task1.Comments);
               
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
        public async Task<IEnumerable<Project>> GetAllProjs()
        {
            return await _dbContext.Areas.ToListAsync();
            // throw new NotImplementedException();
        }

        public async Task<Project> GetProjectById(int id)
        {

            var proj=from p in _dbContext.Areas where p.Id == id select p;
            Project project = new Project();
            foreach(var item in proj)
            {
                project = item;
            }
            return project;

        }

        public async Task<MyTask> GetTaskById(int id)
        {
            var Task=from t in _dbContext.Tasks
                     where t.TaskId == id
                     select t;
            MyTask t1=new MyTask();
            foreach(var t in Task)
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
                existingTask.ProjectId = task.ProjectId;
                existingTask.IterationId  = task.IterationId;
                existingTask.ExpStartDate = task.ExpStartDate;
                existingTask.ExpEndDate
                    = task.ExpEndDate;
                existingTask.Type = task.Type;
                existingTask.ActEndDate = task.ActEndDate;
                existingTask.ActStartDate = task.ActStartDate;
                existingTask.MyUserId = task.MyUserId;
                existingTask.Description = task.Description;
              //  existingTask.AssignedToUser = task.AssignedToUser;
               // existingTask.Description= task.Description;
                existingTask.Priority   = task.Priority;
             
            }
            await _dbContext.SaveChangesAsync();
            return existingTask;
           // throw new NotImplementedException();
        }

     

        public async Task<IEnumerable<Iteration>> GetIterationAll()
        {
            return await _dbContext.Iterations.ToListAsync();
        }

        public Task<MyTask> AddAttachmentToTask(int taskId, Attachment attachment)
        {
            throw new NotImplementedException();
        }
    }
}
