using DemoJira.Bussiness.DTO;
using DemoJira.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoJira.Bussiness.ServiceInterface
{
    public interface IUserService
    {
        Task<UserDTO> GetUserByID(int id);
        Task<IEnumerable<UserDTO>> GetAllUsers();  
    }
}
