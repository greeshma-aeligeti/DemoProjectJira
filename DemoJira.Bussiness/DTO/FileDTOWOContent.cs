using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoJira.Bussiness.DTO
{
    public class FileDTOWOContent
    {
        public int Id { get; set; }

        public string ContentType { get; set; }
        public string FileName { get; set; }
        public long Size { get; set; }
        public DateTime UploadTime { get; set; }

        public string TaskId { get; set; }
    }
}
