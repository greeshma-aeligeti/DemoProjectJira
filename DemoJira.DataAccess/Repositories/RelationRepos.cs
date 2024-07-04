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
        public RelationRepos(SiraDBContext dbContext)
        {
            _dbContext = dbContext;
        }
            public async Task<TasksRelation> CreateRelation(TasksRelation relation)
        {
            var resp = await _dbContext.Relations.AddAsync(relation);
            await _dbContext.SaveChangesAsync();
            return resp.Entity;
            //throw new NotImplementedException();
        }

        public async Task DeleteRelation(TasksRelation relation)
        {
            if(relation!=null) { 
            
                _dbContext.Relations.Remove(relation);  
                await _dbContext.SaveChangesAsync();
            }
          //  throw new NotImplementedException();
        }

        public async Task<IEnumerable<TasksRelation>> GetAllRelations()
        {
            return await _dbContext.Relations.ToListAsync();
            //throw new NotImplementedException();
        }

        public async Task<TasksRelation> GetRelByID(int id)
        {
            var rel=from r in _dbContext.Relations
                    where r.RelationId == id
                    select r;
            TasksRelation tasksRelation = new TasksRelation();
            foreach(var r in rel)
            {
                tasksRelation = r;
            }
            return tasksRelation;
           // throw new NotImplementedException();
        }
    }
}

