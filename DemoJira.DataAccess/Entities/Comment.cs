using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoJira.DataAccess.Entities
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }= DateTime.Now;

        [ForeignKey(nameof(MyTask))]
        public int TaskId { get; set; }
        public MyTask Task { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId {  get; set; }
        public User CmntUser { get; set; }


       // [ForeignKey(nameof(User))]
       // public string UserId { get; set; }
       // public User User { get; set; }
    }
}
