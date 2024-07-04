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
        Task<TasksRelation> CreateRelation(RelationDTO relationDTO);
        Task <IEnumerable<RelationDTO>> GetAllRelations();
        Task DeleteRelation(int id);
        Task<RelationDTO> GetRelByID(int id);
    }
}
