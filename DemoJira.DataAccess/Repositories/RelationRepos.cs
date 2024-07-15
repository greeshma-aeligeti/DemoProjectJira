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

    public class RelationRepos : IRelationRepos
    {
        private readonly SiraDBContext _dbContext;
        private readonly ITaskRepository _taskRepository;
        public RelationRepos(SiraDBContext dbContext, ITaskRepository taskRepository)
        {
            _dbContext = dbContext;
            _taskRepository = taskRepository;
        }
        public async Task<bool> IsChildOfAsync(int parentTaskId, int childTaskId)
        {
            return await _dbContext.Relations
                .AnyAsync(r => r.MainTaskId == parentTaskId && r.RelatedTaskId == childTaskId);
        }
        public async Task<TaskRelationship> CreateRelation(TaskRelationship relationship)
        {
            var existingRelationship = await _dbContext.Relations
            .FirstOrDefaultAsync(r => r.MainTaskId == relationship.MainTaskId && r.RelatedTaskId == relationship.RelatedTaskId);

            if (existingRelationship != null)
            {

                throw new InvalidOperationException("This relationship already exists.");
                return null;
            }

            MyTask Main = await _taskRepository.GetTaskById(relationship.MainTaskId);
            MyTask Sub = await _taskRepository.GetTaskById(relationship.RelatedTaskId);


            var resp = _dbContext.Relations.Add(relationship);
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
            return resp.Entity;



           /*= await _dbContext.Relations.AddAsync(relation);
            await _dbContext.SaveChangesAsync();
            return resp.Entity;*/
            //throw new NotImplementedException();
        }

        public async Task DeleteRelation(TaskRelationship relation)
        {
            if (relation != null)
            {

                _dbContext.Relations.Remove(relation);
                await _dbContext.SaveChangesAsync();
            }
            //  throw new NotImplementedException();
        }

        public async Task<IEnumerable<TaskRelationship>> GetAllRelations()
        {
            return await _dbContext.Relations.ToListAsync();
            //throw new NotImplementedException();
        }

        public async Task<TaskRelationship> GetRelByID(int id)
        {
            var rel = from r in _dbContext.Relations
                      where r.Id == id
                      select r;
            TaskRelationship tasksRelation = new TaskRelationship();
            foreach (var r in rel)
            {
                tasksRelation = r;
            }
            return tasksRelation;
            // throw new NotImplementedException();
        }

        public async Task<IEnumerable<TaskRelationship>> GetAllRelationsWithTaskID(int TID)
        {
            var Relations= await _dbContext.Relations.ToListAsync();
            List<TaskRelationship> rels = new List<TaskRelationship>();
            foreach (var rel in Relations)
            {
                if (rel.RelatedTaskId == TID || rel.MainTaskId == TID)
                {
                    rels.Add(rel);
                }


            }
            return  rels;
            //throw new NotImplementedException();
        }
    }
}

