using DemoJira.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoJira.Bussiness.DTO
{
    public class TaskRelationshipDTO
    {
        [Key]
        public int Id { get; set; } 
        public string ParentTaskId { get; set; }
        public string ChildTaskId { get; set; }


        public TaskRelationshipType RelationshipType { get; set; }
    }
}
