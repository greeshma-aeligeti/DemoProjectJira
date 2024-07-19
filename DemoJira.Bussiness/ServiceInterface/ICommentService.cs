using DemoJira.Bussiness.DTO;
using DemoJira.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoJira.Bussiness.ServiceInterface
{
    public interface ICommentService
    {
        Task<Comment> CreateCommentAsync(CommentDTO commentDTO);
        Task DeleteComment(int id);
        Task<CommentDTO> GetCommentAsync(int id);
        Task<IEnumerable<CommentDTO>> GetAllCommentsAsync();

        Task<IEnumerable<CommentDTO>> GetAllCommentsByTID(string tID);

    }
}
