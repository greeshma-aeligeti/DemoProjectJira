using DemoJira.DataAccess.Entities;
using DemoJira.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DemoJira.Bussiness.DTO
{
     class NotWhitespaceAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is string str)
            {
                return !string.IsNullOrWhiteSpace(str);
            }
            return true; // if value is not a string, consider it valid
        }

        public override string FormatErrorMessage(string name)
        {
            return $"{name} cannot be just whitespace.";
        }
    }
    public class TaskDTO:IValidatableObject
    {
        [Key]
        public string Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [MaxLength(40)]
        [NotWhitespace(ErrorMessage = "Title cannot be just whitespace.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Type is required")]
        public TaskType Type { get; set; }

        public string? Description { get; set; }
        public DateTime? CreatedAt { get; set; }

        [Required(ErrorMessage = "Start Date is required")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End Date is required")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Actual Start Date is required")]
        public DateTime ActStartDate { get; set; }

        [Required(ErrorMessage = "Actual End Date is required")]
        public DateTime ActEndDate { get; set; }

        [Required(ErrorMessage = "User is required")]
        public int AssigneeId { get; set; }

        [Required(ErrorMessage = "Reporter is required")]
        public int ReporterId { get; set; }

        [Required(ErrorMessage = "Story Point is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Story Point must be a positive number")]
        public int StoryPoint { get; set; }

        public PriorityLevel Priority { get; set; }

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


            if (string.IsNullOrWhiteSpace(Title))
            {
                yield return new ValidationResult("Title is required", new[] { nameof(Title) });
            }
            if (StoryPoint <= 0)
            {
                yield return new ValidationResult("Story Point must be a positive number", new[] { nameof(StoryPoint) });
            }
            if (Type < 0) // assuming default enum value is 0
            {
                yield return new ValidationResult("Type is required", new[] { nameof(Type) });
            }
            if (StartDate == EndDate)
            {
                yield return new ValidationResult("End Date must be after Start Date ", new[] { nameof(EndDate) });

            }
            if (StartDate == default)
            {
                yield return new ValidationResult("Start Date is required", new[] { nameof(StartDate) });
            }
            if (EndDate == default)
            {
                yield return new ValidationResult("End Date is required", new[] { nameof(EndDate) });
            }
           
            if (AssigneeId == 0)
            {
                yield return new ValidationResult("Assignee is required", new[] { nameof(AssigneeId) });
            }
            if (ReporterId == 0)
            {
                yield return new ValidationResult("Reporter is required", new[] { nameof(ReporterId) });
            }
            if (ProjectId == 0)
            {
                yield return new ValidationResult("Project is required", new[] { nameof(ProjectId) });
            }
            if (IterationId == 0)
            {
                yield return new ValidationResult("Iteration is required", new[] { nameof(IterationId) });
            }
        }

    }

}
