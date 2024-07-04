using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoJira.DataAccess.Entities
{
    public class TasksRelation
    {
        [Key]
        public int RelationId { get; set; }
        
        [ForeignKey(nameof(MyTask))]
        public int TaskId1 { get; set; }


        [ForeignKey(nameof(MyTask))]
        public int TaskId2 { get; set;}
        public string relation {  get; set; }
    }
}
