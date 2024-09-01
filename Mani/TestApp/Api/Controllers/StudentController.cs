using BLL.Dto;
using BLL.Interface;
using BLL.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/test")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        IStudentService studentService;
        public StudentController(IStudentService studentService) 
        {
            this.studentService = studentService;
        }

        [Route("all")]
        [HttpGet]
        public IEnumerable<StudentDto> GetStudents()
        {
            var students = studentService.GetEmployees();
            return students;
        }

        [Route("{id}")]
        [HttpGet]
        public StudentDto? GetStudent(int id)
        {
            var student = studentService.GetStudent(id);
            return student;
        }

        [Route("add")]
        [HttpPost]
        public int AddStudent([FromBody] StudentDto studentDto)
        {
            var response = studentService.AddStudent(studentDto);
            return response;
        }

        [Route("update")]
        [HttpPut]
        public bool UpdateEmployee([FromBody] StudentDto studentDto)
        {
            var response = studentService.UpdateStudent(studentDto);
            return response;
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public bool DeleteEmployee(int id)
        {
            var response = studentService.DeleteStudent(id);
            return response;
        }
    }
}
