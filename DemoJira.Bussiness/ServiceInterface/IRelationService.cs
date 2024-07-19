using DemoJira.Bussiness.DTO;
using DemoJira.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoJira.Bussiness.ServiceInterface
{
    public interface IRelationService
    {
        Task<TaskRelationship> CreateRelation(TaskRelationshipDTO relationDTO);
        Task <IEnumerable<TaskRelationshipDTO>> GetAllRelations();
        Task DeleteRelation(int id);
        Task<IEnumerable<TaskRelationshipDTO>> GetAllRelationsByTID(string Tid);

        Task<TaskRelationshipDTO> GetRelByID(int id);
    }
}
