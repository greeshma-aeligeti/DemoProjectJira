using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoJira.DataAccess.Entities
{
    public class Iteration
    {
        public int IterationId { get; set; }

     
        public string Name { get; set; }

        //[DeleteBehavior(DeleteBehavior.NoAction)]
        [ForeignKey(nameof(Project))]
        public int ProjId {  get; set; }
        public Project ProjectEntity { get; set; }

    }
}
