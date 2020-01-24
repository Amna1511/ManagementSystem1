using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementSystem1.Models
{
    public class MockStudentRepository : IStudentRepository
    {
        private List<Student> _Students;
        public MockStudentRepository()
        {

            if (_Students == null)
            {
                InitializeStudent();
            }
        }
        private void InitializeStudent()
        {
            _Students = new List<Student>
            {       new Student{Id=1, Fname="Babaer", Lname= "Amin", DOB= "1988/08/12"/*, Course= "Programming"*/},
                    new Student{Id=2, Fname="Tahir", Lname= "Zaheer", DOB= "1945/03/11"/*, Course= "Programming"*/},
                    new Student{Id=3, Fname="Sahira", Lname= "Amir", DOB= "1988/02/22"/*, Course= "Programming"*/}
            };
        }
        Student IStudentRepository.Add(Student Student)
        {
            throw new NotImplementedException();
        }

        //Student IStudentRepository.Delete(int id)
        //{
        //    throw new NotImplementedException();
        //}

        IEnumerable<Student> IStudentRepository.GetAllStudent()
        {
            return _Students;
        }

        Student IStudentRepository.GetStudent(int S_Id)
        {
            return _Students.FirstOrDefault(p => p.Id == S_Id);
        }

        //Student IStudentRepository.Update(Student StudentChanges)
        //{
        //    throw new NotImplementedException();
        //}

        //public Student GetStudent(int Id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
