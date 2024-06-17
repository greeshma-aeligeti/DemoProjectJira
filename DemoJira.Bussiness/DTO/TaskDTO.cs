using DemoJira.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoJira.Bussiness.DTO
{
    public class TaskDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Status CurStatus { get; set; }

        public DateOnly StartDate { get; set; }
        // Add other properties as needed
        public DateOnly EndDate { get; set; }

        // Optional: Navigation properties or references to related entities
        public int ProjectId { get; set; }
        public int IterationId { get; set; }
    }
    
}
