using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoJira.DataAccess.Entities
{
    public class Iteration
    {
        public int Id { get; set; }
        public int ProjID {  get; set; }
        public string Name { get; set; }
    }
}
