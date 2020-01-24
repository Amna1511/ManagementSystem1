using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementSystem1.Models
{
    public class SqlStudentRepository : IStudentRepository
    {
        private readonly AppDbContext context;
        public SqlStudentRepository (AppDbContext context)
        {
            this.context = context;
        }
        public Student Add(Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();
            return student;
        }

        public IEnumerable<Student> GetAllStudent()
        {
            return context.Students;
        }

        public Student GetStudent(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
