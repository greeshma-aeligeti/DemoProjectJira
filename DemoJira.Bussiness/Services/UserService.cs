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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userInterface)
        {
            _userRepository = userInterface;
        }
        public async Task<IEnumerable<UserDTO>> GetAllUsers()
        {

            var Users=await _userRepository.GetAllUsers();
            var response = Users.Select(u => new UserDTO
            {
                UserId = u.Id,
                UserName = u.Name,
           
               // password = u.Password,
            });
            return response;

           // throw new NotImplementedException();
        }

        public async Task<UserDTO> GetUserByID(int id)
        {
            var user=await _userRepository.GetUserById(id);
            if (user == null) return null;
            return new UserDTO
            {
                UserId = user.Id,
                UserName = user.Name,
/*                UserEmail = user.Email,
*/               // password = user.Password
            };
            //throw new NotImplementedException();
        }
    }
}
