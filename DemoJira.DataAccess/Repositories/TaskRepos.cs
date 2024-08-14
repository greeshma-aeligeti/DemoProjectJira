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
            var response = await _dbContext.Tasks.AddAsync(task);
            await _dbContext.SaveChangesAsync();
            return response.Entity;

            //throw new NotImplementedException();
        }

        public async Task DeleteTask(MyTask task)
        {
            var rels = await _dbContext.Relations.ToListAsync();

            foreach (TaskRelationship r in rels)
            {
                if (task.TaskId == r.MainTaskId || task.TaskId == r.RelatedTaskId)
                {
                    _dbContext.Relations.Remove(r);
                    await _dbContext.SaveChangesAsync();
                }
            }
            var files = await _dbContext.Files.ToListAsync();
            foreach (MyFile f in files)
            {
                if (f.TaskId == task.TaskId)
                {
                    _dbContext.Files.Remove(f);
                    await _dbContext.SaveChangesAsync();

                }
            }
            
            var task1 = await _dbContext.Tasks
           .Include(t => t.Comments)
           .FirstOrDefaultAsync(t => t.TaskId == task.TaskId);
           /* var comments = await _dbContext.Comments.ToListAsync();
            foreach (Comment c in comments)
            {
                if (c.TaskId == task.TaskId)
                {
                    _dbContext.Comments.Remove(c);
                    await _dbContext.SaveChangesAsync();

                }
            }
*/

            if (task != null)
            {

                if (task1.Comments != null)
                {
                    _dbContext.Comments.RemoveRange(task1.Comments);
                }
                

                _dbContext.Tasks.Remove(task);
                await _dbContext.SaveChangesAsync();
            }



            // throw new NotImplementedException();
        }

        public async Task<IEnumerable<MyTask>> GetAllTasks()
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

            var proj = from p in _dbContext.Areas where p.Id == id select p;
            Project project = new Project();
            foreach (var item in proj)
            {
                project = item;
            }
            return project;

        }

        public async Task<MyTask> GetTaskById(string id)
        {
            var Task = from t in _dbContext.Tasks
                       where t.TaskId == id
                       select t;
            MyTask t1 = new MyTask();
            foreach (var t in Task)
            {
                t1 = t;
            }
            return t1;

            //throw new NotImplementedException();
        }

        public async Task<MyTask> UpdateTask(MyTask task)
        {
            var existingTask = await _dbContext.Tasks.FirstOrDefaultAsync(t => t.TaskId == task.TaskId);
            if (existingTask != null)
            {
                existingTask.TaskId = task.TaskId;
                existingTask.Title = task.Title;
                existingTask.TaskStatus = task.TaskStatus;
                existingTask.BugStatus = task.BugStatus;
                existingTask.ProjectId = task.ProjectId;
                existingTask.IterationId = task.IterationId;
                existingTask.ExpStartDate = task.ExpStartDate;
                existingTask.ExpEndDate
                    = task.ExpEndDate;
                existingTask.StoryPoint = task.StoryPoint;
                existingTask.Type = task.Type;
                existingTask.ActEndDate = task.ActEndDate;
                existingTask.ActStartDate = task.ActStartDate;
                existingTask.MyUserId = task.MyUserId;
                existingTask.ReporterId = task.ReporterId;
                existingTask.Description = task.Description;
                //  existingTask.AssignedToUser = task.AssignedToUser;
                // existingTask.Description= task.Description;
                existingTask.Priority = task.Priority;

            }
            await _dbContext.SaveChangesAsync();
            return existingTask;
            // throw new NotImplementedException();
        }



        public async Task<IEnumerable<Iteration>> GetIterationAll()
        {
            return await _dbContext.Iterations.ToListAsync();
        }



        public async Task AddTaskRelationshipAsync(TaskRelationship relationship)
        {
            var existingRelationship = await _dbContext.Relations
             .FirstOrDefaultAsync(r => r.MainTaskId == relationship.MainTaskId && r.RelatedTaskId == relationship.RelatedTaskId);

            if (existingRelationship != null)
            {
                throw new InvalidOperationException("This relationship already exists.");
            }

            MyTask Main = await GetTaskById(relationship.MainTaskId);
            MyTask Sub = await GetTaskById(relationship.RelatedTaskId);


            // _dbContext.Relations.Add(relationship);
            await _dbContext.SaveChangesAsync();

            if (relationship.RelationshipType.Equals(1))
            {

                Main.ParentTasks.Add(relationship);

            }
            else if (relationship.RelationshipType.Equals(2))
            {
                Main.ChildTasks.Add(relationship);
            }
            await _dbContext.SaveChangesAsync();


            //throw new NotImplementedException();
        }

        public async Task RemoveTaskRelationshipAsync(string parentTaskId, string childTaskId)
        {
            var relationship = await _dbContext.Relations
            .FirstOrDefaultAsync(r => r.MainTaskId.Equals(parentTaskId) && r.RelatedTaskId.Equals(childTaskId));
            MyTask Main = await GetTaskById(parentTaskId);
            MyTask Sub = await GetTaskById(childTaskId);

            if (relationship != null)
            {
                Main.ParentTasks.Remove(relationship);
                Sub.ChildTasks.Remove(relationship);
                _dbContext.Relations.Remove(relationship);
                await _dbContext.SaveChangesAsync();
            }
            //throw new NotImplementedException();
        }

        public async Task<List<TaskRelationship>> GetTaskRelationshipsAsync(string taskId)
        {
            return await _dbContext.Relations
           .Where(r => r.MainTaskId.Equals(taskId) || r.RelatedTaskId.Equals(taskId))
           .ToListAsync();
        }
        public async Task<bool> IsChildOfAsync(string parentTaskId, string childTaskId)
        {
            return await _dbContext.Relations
                .AnyAsync(r => r.MainTaskId.Equals(parentTaskId) && r.RelatedTaskId.Equals(childTaskId));
        }
    }
}
