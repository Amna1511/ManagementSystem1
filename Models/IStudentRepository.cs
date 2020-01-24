using System.Collections.Generic;

namespace ManagementSystem1.Models
{
   public interface IStudentRepository
    {
       
        IEnumerable<Student> GetAllStudent();
        Student GetStudent(int Id);
        Student Add(Student Student);
        //void Update(Student StudentChanges);
        //void Delete(int id);
    }
}

