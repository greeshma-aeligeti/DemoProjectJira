using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoJira.DataAccess.Entities
{
    public class MyTask
    {
        [Key]
        public int TaskId { get; set; }
        [Required]
        [MaxLength(40)]
        public string Title { get; set; }
        public Status CurStatus { get; set; }
       public int ProjectId {  get; set; }
        public Project Area {  get; set; }

        public int IterationId {  get; set; }
        public Iteration Iteration {  get; set; }

        public string desp {  get; set; }
        public Description Description { get; set; }
        public int Priority {  get; set; }
        public DateOnly ExpStartDate { get; set; }
        public DateOnly ExpEndDate { get; set; }


    }
    
   
}
