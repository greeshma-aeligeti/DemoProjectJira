using DemoJira.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoJira.DataAccess.InterfaceForRepo
{
    public interface IRelationRepos
    {
        Task<TaskRelationship> CreateRelation(TaskRelationship relation);
        Task<IEnumerable<TaskRelationship>> GetAllRelations();

        Task DeleteRelation(TaskRelationship relation);
        Task<TaskRelationship>GetRelByID(int id);
        Task<IEnumerable<TaskRelationship>> GetAllRelationsWithTaskID(int TID);

        Task<bool> IsChildOfAsync(int parentTaskId, int childTaskId);
    }
}
