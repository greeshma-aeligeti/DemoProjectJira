using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoJira.Bussiness.DTO
{
    public class UserDTO
    {
        //[Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        //public string UserEmail { get; set; }
       // public ICollection<TaskDTO> Tasks { get; set; }
      // public string password {  get; set; }


    }
}
