using Microsoft.AspNetCore.Mvc;
using StudentAPI.Interfaces;
using System.Data.Common;
using StudentAPI.Models;

namespace StudentAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UniversityController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly ILectureService _lectureService;
        private readonly IDepartmentService _departmentService;
        private readonly IDepartmentLectureService _departmentLectureService;
        public UniversityController(IStudentService studentService, ILectureService lectureService, IDepartmentService departmentService, IDepartmentLectureService departmentLectureService)
        {
            _studentService = studentService;
            _lectureService = lectureService;
            _departmentService = departmentService;
            _departmentLectureService = departmentLectureService;
        }

        [HttpGet] 
        public async Task <IActionResult> GetStudents()
        {
            var students = _studentService.GetStudents();
            return Ok(students);
        }
        [HttpGet]
        public async Task<IActionResult> GetLectures()
        {
            var lectures = _lectureService.GetLectures();
            return Ok(lectures);
        }
        [HttpGet]
        public async Task<IActionResult> GetDepartment()
        {
            var department = _departmentService.GetDepartments();
            return Ok(department);
        }
        [HttpGet]
        public async Task<IActionResult> GetDepartmentLecture()
        {
            var departmentLectures = _departmentLectureService.GetDepartmentLecture();
            return Ok(departmentLectures);
        }
        [HttpGet("{departmentId}")]
        public async Task<IActionResult> GetStudentsByDepartment(int departmentId)
        {
            var department = await _departmentService.GetDepartmentById(departmentId);

            if (department == null)
            {
                return NotFound($"Department with ID {departmentId} not found.");
            }

            // Use the service method to get students by department
            var students = _studentService.GetStudentsByDepartmentId(departmentId);

            return Ok(students);
        }

        [HttpGet("{departmentId}")]
        public async Task<IActionResult> GetLecturesByDepartment(int departmentId)
        {
            var department = await _departmentService.GetDepartmentById(departmentId);

            if (department == null)
            {
                return NotFound($"Department with ID {departmentId} not found.");
            }

            // Use the service method to get lectures by department
            var lectures = _lectureService.GetLecturesByDepartmentId(departmentId);

            return Ok(lectures);
        }

        [HttpGet("{studentId}")]
        public async Task<IActionResult> GetLecturesByStudent(int studentId)
        {
            // Use the service method to get lectures by student
            // Corrected: Use the lecture service method instead of the incorrect student service method
            var lectures = await _lectureService.GetLecturesByStudentId(studentId);

            if (lectures == null)
            {
                return NotFound($"Student with ID {studentId} not found.");
            }

            return Ok(lectures);
        }






    }
}
