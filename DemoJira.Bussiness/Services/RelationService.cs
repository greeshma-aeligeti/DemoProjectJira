using DemoJira.Bussiness.DTO;
using DemoJira.Bussiness.ServiceInterface;
using DemoJira.DataAccess.Entities;
using DemoJira.DataAccess.InterfaceForRepo;
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

        public async Task<TasksRelation> CreateRelation(RelationDTO relationDTO)
        {
            TasksRelation relationTask = new TasksRelation
            {
                TaskId1 = relationDTO.TaskId1,
                TaskId2 = relationDTO.TaskId2,
                
                relation = relationDTO.relation

            };
            var t1=await _taskRepository.GetTaskById(relationTask.TaskId1);
            var t2=await _taskRepository.GetTaskById(relationTask.TaskId2);
           // await _taskRepository.addRelation(t1, t2);
            var response = await _repository.CreateRelation(relationTask);
            return response;
           // throw new NotImplementedException();
        }

        public async Task DeleteRelation(int id)
        {
            var resp=await _repository.GetRelByID(id);
            await _repository.DeleteRelation(resp);
         //   throw new NotImplementedException();
        }

        public async Task<IEnumerable<RelationDTO>> GetAllRelations()
        {
            var relations=await _repository.GetAllRelations();
            var resp = relations.Select(r => new RelationDTO
            {
                TaskId1 = r.TaskId1,
                TaskId2 = r.TaskId2,
                relation = r.relation
            });
            return resp;
            //throw new NotImplementedException();
        }

        public async Task<RelationDTO> GetRelByID(int id)
        {
            var rel=await _repository.GetRelByID(id);
            if (rel == null) return null;
            return new RelationDTO
            {
                TaskId1 = rel.TaskId1,
                TaskId2 = rel.TaskId2,
                relation = rel.relation
            };
           // throw new NotImplementedException();
        }
    }
}
