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
        public string HexId {  get; set; }
        [Required]
        [MaxLength(40)]
        public string Title { get; set; }

     public string Type {  get; set; }
        public string status {  get; set; }


        [ForeignKey(nameof(Project))]
       public int ProjectId {  get; set; }
        public Project Areas {  get; set; }

        [ForeignKey(nameof(Iteration))]
        public int IterationId {  get; set; }
        public Iteration Iterations {  get; set; }

        public string Description {  get; set; }

       public string Priority {  get; set; }
        public DateTime ExpStartDate { get; set; }
        public DateTime ExpEndDate { get; set; }
        public DateTime ActStartDate { get; set; }
        public DateTime ActEndDate { get; set; }

        [ForeignKey(nameof(User))]
        public int MyUserId { get; set; }
        public User MyUser { get; set; }

   
        public ICollection<Comment>? Comments { get; set; }



    }


}
