using DemoJira.Bussiness.DTO;
using DemoJira.Bussiness.ServiceInterface;
using Microsoft.AspNetCore.Mvc;

namespace Practice.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RelationController:ControllerBase
    {
        private readonly IRelationService _relationService;
        public RelationController(IRelationService relationService)
        {
            _relationService = relationService;
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<TaskRelationshipDTO>> CreateRelation([FromBody]  TaskRelationshipDTO relationDTO)
        {
            var createdRelation=await _relationService.CreateRelation(relationDTO);
            return Ok(createdRelation);
        }
        [HttpGet]
        [Route("relations")]
        public async Task<ActionResult<IEnumerable<TaskRelationshipDTO>>> GetAllRelations()
        {
            var rels=await _relationService.GetAllRelations();
            return Ok(rels);
        }

        [HttpGet]
        [Route("relByTid/{tid}")]
        public async Task<ActionResult<IEnumerable<TaskRelationshipDTO>>> GetAllRelationsByTid(int tid)
        {
            var rels = await _relationService.GetAllRelationsByTID(tid);
            return Ok(rels);
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetRelByID(int id)
        {
            var rel=await _relationService.GetRelByID(id);
            if(rel==null)
                return Ok(new NotFoundResult());
            return Ok(rel);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRelation(int id)
        {
            await _relationService.DeleteRelation(id);
            return Ok();

        }
        
    }
}
