using DemoJira.DataAccess.Entities;
using DemoJira.DataAccess.InterfaceForRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoJira.DataAccess.Repositories
{
    public class CommentRepos : ICommentRepos
    {
        private readonly SiraDBContext _dbContext;
        public CommentRepos(SiraDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Comment> CreateComment(Comment comment)
        {
            var resp = await _dbContext.Comments.AddAsync(comment);
            await _dbContext.SaveChangesAsync();
            return resp.Entity;

//            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Comment>> GetAllComments()
        {
            return await _dbContext.Comments.ToListAsync();
           
        }

        public async Task DeleteComment(Comment comment)
        {
            //throw new NotImplementedException();
            if(comment != null) { 
            
                _dbContext.Comments.Remove(comment);    
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Comment> GetComment(int id)
        {

            var cmt=from c in _dbContext.Comments
                    where c.CommentId == id
                    select c;
            Comment comment=new Comment();
            foreach(var c in  cmt)
            {
                comment = c;
            }
            return comment;
            //throw new NotImplementedException();
        }

        public async Task<IEnumerable<Comment>> GetAllCommentsByTaskID(int tID)
        {
            List<Comment> allComments=new List<Comment>();
            allComments=await _dbContext.Comments.ToListAsync();
            List<Comment> Taskcomments=new List<Comment>();
            foreach(var c in allComments)
            {
                if (c.TaskId == tID)
                {
                    Taskcomments.Add(c);
                }
            }
            return Taskcomments;
          //  throw new NotImplementedException();
        }
    }
}
