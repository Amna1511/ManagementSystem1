using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManagementSystem1.Models;

namespace ManagementSystem1.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)

        { }
            public DbSet<Student> Students { get; set; }
            public DbSet<Teacher> Teachers { get; set; }
            public DbSet<Course> Courses { get; set; }
            public DbSet<Assignment> Assignments { get; set; }
            public DbSet<StudentCourseModel> StudentCourseModel { get; set; }
            public DbSet<User> User { get; set; }
       

    }
}
