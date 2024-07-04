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
        Task<TasksRelation> CreateRelation(TasksRelation relation);
        Task<IEnumerable<TasksRelation>> GetAllRelations();

        Task DeleteRelation(TasksRelation relation);
        Task<TasksRelation>GetRelByID(int id);

    }
}
