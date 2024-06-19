using DemoJira.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoJira.Bussiness.DTO
{
    public class TaskDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(40)]
        public string Title { get; set; }
        public int Description { get; set; }
        [Required]
        public string CurStatus { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        // Add other properties as needed
        public DateTime EndDate { get; set; }

        // Optional: Navigation properties or references to related entities
        public int ProjectId { get; set; }
        public int IterationId { get; set; }
    }
    
}
