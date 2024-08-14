using DemoJira.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoJira.Bussiness.DTO
{
    public class TaskRelationshipDTO: IValidatableObject
    {
        [Key]
        public int Id { get; set; } 
        public string ParentTaskId { get; set; }
        [Required]
        public string ChildTaskId { get; set; }

        [Required(ErrorMessage ="Relation type is required!")]
        public TaskRelationshipType RelationshipType { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //throw new NotImplementedException();
            if (RelationshipType == 0)
            {
                yield return new ValidationResult("Select relationship type", new[] { nameof(RelationshipType) });
            }

        }
    }
}
