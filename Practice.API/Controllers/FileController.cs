using DemoJira.Bussiness.DTO;
using DemoJira.Bussiness.ServiceInterface;
using Microsoft.AspNetCore.Mvc;

namespace Practice.API.Controllers
{
    [Route("api/File")]

    [ApiController]
    public class FileController:ControllerBase
    {
       // private static IWebHostEnvironment _webHostEnvironment;
        private readonly IFileService fileService;
        public FileController( IFileService file)
        {
           // _webHostEnvironment = webHostEnvironment;
            fileService = file;

        }

        [HttpGet("getByID/{id}")]
        public async Task<IActionResult> GetFilesByTaskID(int id)
        {
            var resp=await fileService.GetFilesWithTaskID(id);
            return Ok(resp);
        }

        [HttpGet("download/{fileId}")]
        public async Task<IActionResult> DownloadFile(int fileId)
        {
            var file = await fileService.GetFileById(fileId);
            if (file == null)
            {
                return NotFound();
            }

            var fileBytes = file.Content; // Assuming Content is byte[] in FileDTO
            var contentType = file.ContentType;
            var fileName = file.FileName;

            return File(fileBytes, contentType, fileName);
        }



        [HttpPost("fileupload")]
        public async Task<IActionResult> PostFiles([FromForm] List<IFormFile> files, [FromForm] string TaskID)
        {
            if (files == null || files.Count == 0)
            {
                return BadRequest("No files uploaded.");
            }
            int ID=int.Parse(TaskID);

            var result = await fileService.UploadFile(files, ID);
            if (result)
            {
                return Ok();
            }
            else
            {
                return NotFound("WorkItem not found.");
            }
        }

    }
}
