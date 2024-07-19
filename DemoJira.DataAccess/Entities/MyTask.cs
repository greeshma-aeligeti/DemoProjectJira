using DemoJira.Shared.Enums;
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
        public string TaskId { get; set; }
        [Required]
        [MaxLength(40)]
        public string Title { get; set; }

     public TaskType Type {  get; set; }
        //public string status {  get; set; }

        public MyTaskStatus? TaskStatus { get; set; }
        public BugStatus? BugStatus { get; set; }

        public int StoryPoint {  get; set; }

       public int ProjectId {  get; set; }

        [ForeignKey(nameof(ProjectId))]
        public Project Areas {  get; set; }

        public int IterationId {  get; set; }

        [ForeignKey(nameof(IterationId))]
        public Iteration Iterations {  get; set; }

        public string Description {  get; set; }

       public PriorityLevel Priority {  get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime ExpStartDate { get; set; }
        public DateTime ExpEndDate { get; set; }
        public DateTime ActStartDate { get; set; }
        public DateTime ActEndDate { get; set; }

        public int MyUserId { get; set; }

        [ForeignKey(nameof(MyUserId))]
        public User MyUser { get; set; }

        public int ReporterId { get; set; }

        public User Reporter { get; set; }




        public ICollection<MyFile> TaskFiles {  get; set; }
   
        public ICollection<Comment>? Comments { get; set; }
        
        public ICollection<TaskRelationship>? ParentTasks { get; set; }
       
        public ICollection<TaskRelationship>? ChildTasks { get; set; }



    }


}
