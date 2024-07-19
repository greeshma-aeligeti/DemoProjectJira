using DemoJira.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoJira.DataAccess.InterfaceForRepo
{
    public interface ICommentRepos

    {
        Task<Comment> CreateComment(Comment comment);
        Task DeleteComment(Comment comment);
        Task<Comment> GetComment(int id);
        Task<IEnumerable<Comment>> GetAllComments();
        Task<IEnumerable<Comment>> GetAllCommentsByTaskID(string tID);

    }
}
