using DemoJira.DataAccess.Entities;
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
        public int Id { get; set; }

        public string HexaId {  get; set; }
        [Required(ErrorMessage = "Title is required")]
        [MaxLength(40)]
        public string Title { get; set; }
        [Required(ErrorMessage = "Type is required")]
        public string Type {  get; set; }
        public string Description { get; set; }
      
        public string StatusId { get; set; }
        
        public DateTime StartDate { get; set; }
        
        // Add other properties as needed
        public DateTime EndDate { get; set; }
        public DateTime ActStartDate { get; set; }
        public DateTime ActEndDate { get; set; }
        [Required(ErrorMessage = "User is required")]
        public int UserId {  get; set; }

        public string Priority {  get; set; }

        // Optional: Navigation properties or references to related entities
        [Required(ErrorMessage = "Project is required")]
        public int ProjectId { get; set; }
        //  public ProjectDTO ProjectU { get; set; }
             [Required(ErrorMessage = "Iteration is required")] 
        public int IterationId { get; set; }
       // public IterationDTO IterationU { get; set; }

        // public DateTime EndDate { get; set; }
      /*  public int AssignedToUserId { get; set; }
        public string AssignedToUserName { get; set; }*/
      public List<CommentDTO>? Comments { get; set; }
 //  public string AttachmentUrl { get; set; }
        public List<TaskDTO>? RelatedTasks { get; set; }
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
        }

    }

}
