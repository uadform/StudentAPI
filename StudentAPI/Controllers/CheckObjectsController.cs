using Microsoft.AspNetCore.Mvc;
using StudentAPI.Interfaces;

namespace StudentAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CheckObjectsController : ControllerBase
    {
            private readonly IStudentService _studentService;
            private readonly ILectureService _lectureService;
            private readonly IDepartmentService _departmentService;
            private readonly IDepartmentLectureService _departmentLectureService;
            public CheckObjectsController(IStudentService studentService, ILectureService lectureService, IDepartmentService departmentService, IDepartmentLectureService departmentLectureService)
            {
                _studentService = studentService;
                _lectureService = lectureService;
                _departmentService = departmentService;
                _departmentLectureService = departmentLectureService;
            }

            [HttpGet]
            public async Task<IActionResult> GetStudents()
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
        }
    
}
