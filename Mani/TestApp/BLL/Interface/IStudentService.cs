using BLL.Dto;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IStudentService
    {
        IEnumerable<StudentDto> GetEmployees();

        StudentDto? GetStudent(int id);
        int AddStudent(StudentDto? studentDto);
        bool UpdateStudent(StudentDto? student);

        bool DeleteStudent(int id);
    }
}
