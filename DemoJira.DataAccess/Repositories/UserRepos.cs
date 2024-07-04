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
    public class UserRepos : IUserRepository
    {
        private readonly SiraDBContext _dbContext;
        public UserRepos(SiraDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        /*
                public async Task<IEnumerable<User>> GetAllUsers()
                {

                  //  return await _dbContext.Users.ToListAsync();
                    throw new NotImplementedException();
                }
        */
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _dbContext.NewUsers.ToListAsync();
            //throw new NotImplementedException();
        }

        public async Task<User> GetUserById(int id)
        {

            var user = from u in _dbContext.NewUsers
                       where u.Id == id
                       select u;
            User U1 = new User();
            foreach (var u in user)
            {
                U1 = u;


            }
            return U1;
        }

        /*  public async Task<User> GetUserById(string id)
          {
              var user=from u in _dbContext.Users
                       where u.UserId==id
                       select u;  
              User U1=new User();
              foreach(var u in user)
              {
                  U1 = u;


              }
              return U1;
              //throw new NotImplementedException();
          }*/
    }
}
