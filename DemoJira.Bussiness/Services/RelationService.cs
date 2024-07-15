using DemoJira.Bussiness.DTO;
using DemoJira.Bussiness.ServiceInterface;
using DemoJira.DataAccess.Entities;
using DemoJira.DataAccess.InterfaceForRepo;
using DemoJira.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoJira.Bussiness.Services
{
    public class RelationService:IRelationService
    {
        private readonly IRelationRepos _repository;
        private readonly ITaskService _taskRepository;
        public RelationService(IRelationRepos repository,ITaskService taskRepository)
        {
            _repository = repository;
            _taskRepository = taskRepository;
        }

        public async Task<TaskRelationship> CreateRelation(TaskRelationshipDTO relationshipDTO)
        {
            if (relationshipDTO.RelationshipType == TaskRelationshipType.Parent && await _repository.IsChildOfAsync(relationshipDTO.ChildTaskId, relationshipDTO.ParentTaskId))
            {
                throw new InvalidOperationException("A child task cannot be a parent of its own parent.");
            }


            var relationship = new TaskRelationship
            {
                Id = relationshipDTO.Id,
                MainTaskId = relationshipDTO.ParentTaskId,
                RelatedTaskId = relationshipDTO.ChildTaskId,
                RelationshipType = relationshipDTO.RelationshipType
            };


            var resp=await _repository.CreateRelation(relationship);
            return resp;
            // throw new NotImplementedException();
        }

        public async Task DeleteRelation(int id)
        {
            var resp=await _repository.GetRelByID(id);
            await _repository.DeleteRelation(resp);
         //   throw new NotImplementedException();
        }

        public async Task<IEnumerable<TaskRelationshipDTO>> GetAllRelations()
        {
            var relations=await _repository.GetAllRelations();
            var resp = relations.Select(r => new TaskRelationshipDTO
            {
                ParentTaskId = r.MainTaskId,
                ChildTaskId = r.RelatedTaskId,
                RelationshipType = r.RelationshipType
            });
            return resp;
            //throw new NotImplementedException();
        }

        public async Task<IEnumerable<TaskRelationshipDTO>> GetAllRelationsByTID(int Tid)
        {
            var relations = await _repository.GetAllRelationsWithTaskID(Tid);
            var resp = relations.Select(r => new TaskRelationshipDTO
            {
                Id=r.Id,
                ParentTaskId = r.MainTaskId,
                ChildTaskId = r.RelatedTaskId,
                RelationshipType = r.RelationshipType
            });
            return resp;
        }

        public async Task<TaskRelationshipDTO> GetRelByID(int id)
        {
            var rel=await _repository.GetRelByID(id);
            if (rel == null) return null;
            return new TaskRelationshipDTO
            {
                ParentTaskId = rel.MainTaskId,
                ChildTaskId = rel.RelatedTaskId,
                RelationshipType = rel.RelationshipType
            };
           // throw new NotImplementedException();
        }
    }
}
