using DemoJira.DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoJira.Bussiness.DTO
{
    public class FileDTO
    {
        [Key]
        public int Id { get; set; }

        public byte[] Content { get; set; }
        public string ContentType { get; set; }
        public string FileName { get; set; }
        public long Size { get; set; }
        public DateTime UploadTime { get; set; }

        public string TaskId { get; set; }

        [ForeignKey(nameof(TaskId))]
        public MyTask AttachedToTask { get; set; }
    }
}
