using DemoJira.Bussiness.DTO;
using DemoJira.Bussiness.ServiceInterface;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using DemoJira.Bussiness.Services;

namespace Practice.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly ICommentService _commentService;
        private readonly IIdGeneratorService _idGeneratorService;

        // private readonly IMapper _mapper;
        public TaskController(ITaskService taskService,ICommentService commentService,IIdGeneratorService idGeneratorService)
        {
            _taskService = taskService;
            _idGeneratorService = idGeneratorService;

            _commentService = commentService;
          //  _mapper = mapper;
        }

        [HttpGet]
        [Route("tasks")]
        public async Task<ActionResult<IEnumerable<TaskDTO>>> GetAllTasks()
        {
            var tasks = await _taskService.GetAllTasks();
            return Ok(tasks);
        }
        [HttpGet]
        [Route("proj")]
        public async Task<ActionResult<IEnumerable<ProjectDTO>>> GetAllProjects()
        {
            var tasks = await _taskService.GetAllProjects();
            return Ok(tasks);
        }

        [HttpGet]
        [Route("itr/all")]
        public async Task <ActionResult<IEnumerable<IterationDTO>>> GetAllIterations()
        {
            var iterations = await _taskService.GetAllIterations();
            return Ok(iterations);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            // Log the received ID
            Console.WriteLine($"Received ID: {id}");

            var task = await _taskService.GetTaskById(id);
            if(task== null)
            {
                return NotFound();

            }
            // Log the received ID
            Console.WriteLine($"Received ID: {task}");

            return Ok(task);
        }


     

        [HttpGet("proj/{id}")]

        public async Task<IActionResult> GetProjByID(int id)
        {
            // Log the received ID
            Console.WriteLine($"Received ID: {id}");

            var task = await _taskService.GetProjectById(id);
            if (task == null)
            {
                return NotFound();

            }
            // Log the received ID
            Console.WriteLine($"Received ID: {task}");

            return Ok(task);
        }

        [HttpPost]
        [Route("CreateTask")]
        public async Task<ActionResult<TaskDTO>> CreateTask([FromBody] TaskDTO taskDTO)
        {
            taskDTO.HexaId = await _idGeneratorService.GenerateNextIdAsync(taskDTO.Type.ToString());



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
        [Route("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
           /* var cmts = await _commentService.GetAllCommentsAsync();
            foreach (var c in cmts)
            {
                if (c.TaskId == id)
                {
                    await _commentService.DeleteComment(c.CommentId);
                }
            }*/ 

            await _taskService.DeleteTask(id);
           
            return NoContent();
        }


        [HttpPost("{taskId}/upload")]
        public async Task<IActionResult> UploadFile(int taskId, IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            var filePath = Path.Combine(uploadPath, file.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Optionally, save the file path to your database associated with the task
            var attachmentUrl = Path.Combine("uploads", file.FileName);
            var task=await _taskService.GetTaskById(taskId);
            await _taskService.UpdateTask(taskId,task );

            return Ok(new { AttachmentUrl = attachmentUrl });
        
    }
        [HttpGet("{taskId}/download")]
        public IActionResult DownloadFile(int taskId)
        {
        // Get the attachment URL from the database (pseudo-code)
        var attachmentUrl = _taskService.GetAttachmentUrl(taskId).ToString();
            if (string.IsNullOrEmpty(attachmentUrl))
                return NotFound();

            var filePath = Path.Combine("wwwroot", attachmentUrl);
            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            var fileName = Path.GetFileName(filePath);

            return File(fileBytes, "application/octet-stream", fileName);
        }

    }
}
