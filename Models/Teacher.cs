﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementSystem1.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public virtual ICollection<Course> Course { get; set; }

    }
}
