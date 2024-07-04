using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoJira.DataAccess.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Iteration> Iterations { get; set; }

    }
}
