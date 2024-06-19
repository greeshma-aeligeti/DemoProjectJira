using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        public string status {  get; set; }
       
        [ForeignKey(nameof(Project))]
       public int ProjectId {  get; set; }
        public Project Area {  get; set; }
        [ForeignKey(nameof(Iteration))]
        public int IterationId {  get; set; }
        public Iteration Iteration {  get; set; }

        [ForeignKey(nameof(Description))]
        public int desp {  get; set; }
        public Description Description { get; set; }
        public int Priority {  get; set; }
        public DateTime ExpStartDate { get; set; }
        public DateTime ExpEndDate { get; set; }


    }
    
   
}
