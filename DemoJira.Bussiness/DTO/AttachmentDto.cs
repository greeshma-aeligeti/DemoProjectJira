using DemoJira.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoJira.Bussiness.DTO
{
    public class AttachmentDto
    {
        public int AttachmentId { get; set; }
        public string FileName { get; set; }
        public string Url { get; set; }
        [ForeignKey(nameof(MyTask))]
        public int TaskId { get; set; }
    }
}
