using DemoJira.Bussiness.DTO;
using DemoJira.Bussiness.ServiceInterface;
using Microsoft.AspNetCore.Mvc;

namespace Practice.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController:ControllerBase
    {

        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }
    
        [HttpPost]
        public async Task<ActionResult<CommentDTO>> CreateComment([FromBody] CommentDTO commentDTO)
        {
            var com=await _commentService.CreateCommentAsync(commentDTO);
            return Ok(com);
        }
        [HttpGet]
        [Route("comments")]
        public async Task<ActionResult<IEnumerable<CommentDTO>>> GetAllCommentsAsync()
        {
            var comments=await _commentService.GetAllCommentsAsync(); ;
            return Ok(comments);
        }

        [HttpGet]
        [Route("task/{id}")]
        public async Task<ActionResult<IEnumerable<CommentDTO>>> GetAllCommentsByTID(string id)
        {
            var comments = await _commentService.GetAllCommentsByTID(id); 
            return Ok(comments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommentByID(int id)
        {
            var cmm=await _commentService.GetCommentAsync(id);
            if(cmm==null)
                return NotFound();
            return Ok(cmm);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
          await _commentService.DeleteComment(id);
            return Ok();
        }

       
    }
}
