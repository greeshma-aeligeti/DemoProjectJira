using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoJira.DataAccess.Entities
{
    public class Status
    {
     
        public int statusId { get; set; }
        public string Name { get; set; }
        public List<MyTask> Tasks { get; set; }
    }
}
