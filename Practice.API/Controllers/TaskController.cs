using DemoJira.Bussiness.DTO;
using DemoJira.Bussiness.ServiceInterface;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace Practice.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
       // private readonly IMapper _mapper;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
          //  _mapper = mapper;
        }

        [HttpGet]
        [Route("tasks")]
        public async Task<ActionResult<IEnumerable<TaskDTO>>> GetAllTasks()
        {
            var tasks = await _taskService.GetAllTasks();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var task = await _taskService.GetTaskById(id);
            if(task== null)
            {
                return NotFound();

            }
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<TaskDTO>> CreateTask([FromBody] TaskDTO taskDTO)
        {
           
         
            
                var createdTask = await _taskService.CreateTask(taskDTO);
               
               return Ok(createdTask);
                
              // return CreatedAtAction(nameof(CreateTask), new { id = createdTask.Id }, createdTask);
            
            

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id,[FromBody]TaskDTO taskDTO)
        {
          
            var updateTask = await _taskService.UpdateTask(id, taskDTO);
            if (updateTask == null) return NotFound();

            return Ok(updateTask);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTask(int id)
        {
            await _taskService.DeleteTask(id);
            return NoContent();
        }
    }
}
