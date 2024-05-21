using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogForest.EntityLayer.Concrete
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string? Detail { get; set; }
        public DateTime CommentDate { get; set; }= DateTime.Now;
        public bool Status { get; set; }=false;
    }
}
