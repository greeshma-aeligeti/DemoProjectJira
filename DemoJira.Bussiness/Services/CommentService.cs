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
    public class CommentService : ICommentService
    {
        private readonly ICommentRepos _repository;
        private readonly ITaskRepository _taskRepository;
        //private readonly IUserService _userService;

        public CommentService(ICommentRepos repository,ITaskRepository taskRepository)
        {
            _repository = repository;
            _taskRepository = taskRepository;
        }

        public async Task<Comment> CreateCommentAsync(CommentDTO commentDTO)
        {
            var task = await _taskRepository.GetTaskById(commentDTO.TaskId);
            if(task == null)
            {
                throw new Exception("Task not Found");
            }
            Comment com = new Comment
            {
                Content = commentDTO.Content,
                userId = commentDTO.UserId,
                TaskId = commentDTO.TaskId,
              
            };
            var resp=await _repository.CreateComment(com);
            
            return resp;
           // throw new NotImplementedException();
        }


        public async Task DeleteComment(int id)
        {

            var rep = await _repository.GetComment(id);
            await _repository.DeleteComment(rep);



            //throw new NotImplementedException();
        }

        public async Task<IEnumerable<CommentDTO>> GetAllCommentsAsync()
        {
            var Comments = await _repository.GetAllComments();
            var resp = Comments.Select(c => new CommentDTO
            {
                Content = c.Content,
                UserId=c.userId,
                TaskId=c.TaskId,
                CreatedAt=c.CreatedAt

            });
            return resp;
            //throw new NotImplementedException();
        }

        public async Task<IEnumerable<CommentDTO>> GetAllCommentsByTID(int tID)
        {
            var Comments=await _repository.GetAllCommentsByTaskID(tID);
            var resp=Comments.Select(c=> new CommentDTO
            {
                Content = c.Content,
                UserId = c.userId,
                TaskId = c.TaskId,
                CreatedAt = c.CreatedAt

            });
            return resp;
            //throw new NotImplementedException();
        }

        public async Task<CommentDTO> GetCommentAsync(int id)
        {
            var cmt=await _repository.GetComment(id);
            if (cmt == null) return null;
            return new CommentDTO
            {
                Content = cmt.Content,

                UserId = cmt.userId,
                TaskId = cmt.TaskId,
                CreatedAt = cmt.CreatedAt,
            };

           // throw new NotImplementedException();
        }
    }
}
