using DemoJira.Bussiness.DTO;
using DemoJira.Bussiness.ServiceInterface;
using Microsoft.AspNetCore.Mvc;

namespace Practice.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            this._taskService = taskService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
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
        public async Task<IActionResult> CreateTask(TaskDTO taskDTO)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createTask=_taskService.CreateTask(taskDTO);
            return CreatedAtAction(nameof(GetTaskById), new { id = createTask.Id }, createTask);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id,TaskDTO taskDTO)
        {
            if(id!=taskDTO.Id)
                return BadRequest();
            var updateTask = await _taskService.UpdateTask(id, taskDTO);
            if (updateTask == null) return NotFound();

            return Ok(updateTask);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            await _taskService.DeleteTask(id);
            return NoContent();
        }
    }
}
