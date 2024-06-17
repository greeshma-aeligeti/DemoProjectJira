using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoJira.DataAccess.Entities
{
    public class Description
    {
        public int Id { get; set; }
        public int IterationId {  get; set; }
        public string DespContent { get; set; }

    }
}
