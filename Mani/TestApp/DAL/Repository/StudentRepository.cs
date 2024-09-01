using DAL.Interface;
using DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly MyDBContext myDbContext;
        public StudentRepository(MyDBContext myDbContext)
        {
            this.myDbContext = myDbContext;
        }
        public IEnumerable<Student> GetStudents()
        {
            //List<Student> students = this.GetStudentsData();
            var students = myDbContext.Students.ToList();
            return students;
        }

        public Student? GetStudent(int id)
        {
            var student = myDbContext.Students.Where(x => x.Id == id).FirstOrDefault();
            return student;
        }

        public int AddStudent(Student? student)
        {
            myDbContext.Students.Add(student);
            myDbContext.SaveChanges();
            return student.Id;
        }

        public bool UpdateStudent(Student? student)
        {
            myDbContext.Students.Update(student);
            myDbContext.Entry(student).State = EntityState.Modified;
            myDbContext.SaveChanges();
            return true;
        }

        public bool DeleteStudent(int id)
        {
            var student = myDbContext.Students.FirstOrDefault(x => x.Id == id);
            myDbContext.Students.Remove(student);
            myDbContext.SaveChanges();
            return true;
        }

        private List<Student> GetStudentsData()
        {
            List<Student> students = new List<Student>()
            {
            new Student(){ Id=1, Dept="IT", Name="Jai", Address="Trichy" },
            new Student(){ Id=2, Dept="EEE", Name="Ganesh", Address="Coimbatore" }
            };
            students.Add(new Student() { Id = 3, Dept = "Ece", Name = "Prasanna", Address = "Madurai" });
            var student = new Student() { Id = 4, Dept = "CS", Name = "Mani", Address = "Chennai" };
            students.Add(student);

            return students;
        }
    }
}
