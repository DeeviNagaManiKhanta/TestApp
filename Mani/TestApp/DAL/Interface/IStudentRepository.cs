using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetStudents();
        Student? GetStudent(int id);
        int AddStudent(Student? student);

        bool UpdateStudent(Student? student);
        bool DeleteStudent(int id);
    }
}
