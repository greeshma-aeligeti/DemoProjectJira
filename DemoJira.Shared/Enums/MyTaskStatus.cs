using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoJira.Shared.Enums
{
    public enum MyTaskStatus
    {
        New,
        [Description("In Progress")]
        InProgress,
        Resolved,
        Review,
        Closed
        
    }
}
