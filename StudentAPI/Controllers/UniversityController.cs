using Microsoft.AspNetCore.Mvc;
using StudentAPI.Interfaces;
using System.Data.Common;
using StudentAPI.Models;
using Microsoft.Extensions.Logging;

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
        private readonly ILogger<UniversityController> _logger;
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
            var lectures = _lectureService.GetLecturesByDepartmentId(departmentId);

            return Ok(lectures);
        }

        [HttpGet("{studentId}")]
        public async Task<IActionResult> GetLecturesByStudent(int studentId)
        {
            var lectures = await _lectureService.GetLecturesByStudentId(studentId);

            if (lectures == null)
            {
                return NotFound($"Student with ID {studentId} not found.");
            }

            return Ok(lectures);
        }

        [HttpGet("{departmentId}")]
        public async Task<IActionResult> GetDepartmentById(int departmentId)
        {
            try
            {
                var department = await _departmentService.GetDepartmentById(departmentId);

                if (department == null)
                {
                    return NotFound($"Department with ID {departmentId} not found.");
                }

                return Ok(department);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the request.");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartmentWithStudentsAndLectures([FromBody] DepartmentCreationModel model)
        {
            try
            {
                var department = new Departament { DepartmentName = model.DepartmentName };
                var students = model.Students;
                var lectures = model.Lectures;

                var createdDepartmentId = await _departmentService.CreateDepartmentWithStudentsAndLectures(department, students, lectures);

                var createdDepartment = await _departmentService.GetDepartmentById(createdDepartmentId);

                return CreatedAtAction(nameof(GetDepartmentById), new { departmentId = createdDepartmentId }, createdDepartment);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the request.");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost("{departmentId}/addStudents")]
        public async Task<IActionResult> AddStudentsToDepartment(int departmentId, [FromBody] List<Student> students)
        {
            var addedStudentsCount = await _departmentService.AddStudentsToDepartment(departmentId, students);

            return Ok(new { AddedStudentsCount = addedStudentsCount });
        }

        [HttpPost("{studentId}/transfer/{newDepartmentId}")]
        public async Task<IActionResult> TransferStudent(int studentId, int newDepartmentId)
        {
            var isTransferSuccessful = await _departmentService.TransferStudent(studentId, newDepartmentId);

            if (isTransferSuccessful)
            {
                return Ok(new { Message = "Student transferred successfully." });
            }

            return NotFound($"Student with ID {studentId} not found or transfer failed.");
        }

        [HttpPost("{departmentId}/createLecture")]
        public async Task<IActionResult> CreateLectureAndAddToDepartment(int departmentId, [FromBody] CreateLectureModel model)
        {
            var lectureId = await _lectureService.CreateLectureAndAddToDepartment(model.LectureName, departmentId);

            if (lectureId > 0)
            {
                return Ok(new { LectureId = lectureId, Message = "Lecture created and added to department successfully." });
            }

            return BadRequest("Failed to create lecture or add it to department.");
        }

    }
}
