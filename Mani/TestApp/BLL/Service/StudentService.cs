using BLL.Dto;
using BLL.Interface;
using DAL;
using DAL.Interface;
using DAL.Model;
using DAL.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class StudentService : IStudentService
    {
        IStudentRepository studentRepo;
        public StudentService(IStudentRepository studentRepository)
        {
            studentRepo=studentRepository;
        }

        public IEnumerable<StudentDto> GetEmployees()
        {
            IEnumerable<Student> students = studentRepo.GetStudents();
            var studentDtoList = students.Select(x => GetStudent(x));
            return studentDtoList;
        }

        public StudentDto? GetStudent(int id)
        {
            var student = studentRepo.GetStudent(id);
            var studentDto = GetStudent(student);
            return studentDto;
        }

        public int AddStudent(StudentDto? studentDto)
        {
            var student = GetStudent(studentDto);

            var id = studentRepo.AddStudent(student);
            return id;
        }

        public bool UpdateStudent(StudentDto? studentDto)
        {
            var student = GetStudent(studentDto);
            var isUpdated = studentRepo.UpdateStudent(student);
            return isUpdated;
        }

        public bool DeleteStudent(int id)
        {
            var isDeleted = studentRepo.DeleteStudent(id);
            return isDeleted;
        }

        private StudentDto? GetStudent(Student student)
        {
            StudentDto studentDto = new StudentDto()
            {
                Id = student.Id,
                Name = student.Name,
                Department = student.Dept,
                Address = student.Address,
            };
            return studentDto;
        }
        //Use Auto Mapper for MAppings
        private Student? GetStudent(StudentDto student)
        {
            Student studentDto = new Student()
            {
                Id = student.Id,
                Name = student.Name,
                Dept = student.Department,
                Address = student.Address,
            };
            return studentDto;
        }

    }
}
