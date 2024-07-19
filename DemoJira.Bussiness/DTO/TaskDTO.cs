using DemoJira.DataAccess.Entities;
using DemoJira.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoJira.Bussiness.DTO
{
    public class TaskDTO:IValidatableObject
    {
        [Key]
        public string Id  {  get; set; }
        [Required(ErrorMessage = "Title is required")]
        [MaxLength(40)]
        public string Title { get; set; }
        [Required(ErrorMessage = "Type is required")]
        public TaskType Type {  get; set; }
        public string Description { get; set; }
        public DateTime? CreatedAt { get; set; }

        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }
        public DateTime ActStartDate { get; set; }
        public DateTime ActEndDate { get; set; }
        [Required(ErrorMessage = "User is required")]
        public int AssigneeId {  get; set; }
        public int ReporterId { get; set; }

        public int StoryPoint {  get; set; }
        public PriorityLevel Priority {  get; set; }

        [Required(ErrorMessage = "Project is required")]
        public int ProjectId { get; set; }
             [Required(ErrorMessage = "Iteration is required")] 
        public int IterationId { get; set; }
  
      public List<CommentDTO>? Comments { get; set; }

        public MyTaskStatus? TaskStatus { get; set; }
        public BugStatus? BugStatus { get; set; }

        public ICollection<TaskRelationshipDTO>? ParentTasks { get; set; }
        public ICollection<TaskRelationshipDTO>?  ChildTasks { get; set; }


      
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (EndDate < StartDate)
            {
                yield return new ValidationResult(
                    "End Date must be after Start Date",
                    new[] { nameof(EndDate) });
            }

            if(ActEndDate < ActStartDate)
            {
                yield return new ValidationResult(
                    "End Date must be after Start Date",
                    new[] { nameof(ActEndDate) });
            }

            if (AssigneeId == ReporterId)
            {
                yield return new ValidationResult(
                   "Assignee and Reporter cannot be the same.",
                   new[] { nameof(AssigneeId) });

            }
        }

    }

}
