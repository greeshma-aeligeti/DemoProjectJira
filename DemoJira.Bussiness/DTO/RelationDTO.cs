﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoJira.Bussiness.DTO
{
    public class RelationDTO
    {
        public int RelationId { get; set; }
        public string TaskId1 { get; set; }

        public string TaskId2 { get; set;}
        public string relation {  get; set; }
    }
}
