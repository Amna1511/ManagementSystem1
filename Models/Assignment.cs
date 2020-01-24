using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementSystem1.Models
{
    public class Assignment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
}
