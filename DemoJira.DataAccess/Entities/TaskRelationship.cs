using DemoJira.Shared.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoJira.DataAccess.Entities
{
    public class TaskRelationship
    {

        [Key]
        public int Id { get; set; }
        public int MainTaskId { get; set; }

        [ForeignKey(nameof(MainTaskId))]
        public MyTask MainTask { get; set; }

        public int RelatedTaskId { get; set; }

        [ForeignKey(nameof(RelatedTaskId))]
        public MyTask RelatedTask { get; set; }

        public TaskRelationshipType RelationshipType { get; set; }
    }
}
