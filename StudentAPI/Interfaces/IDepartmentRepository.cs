﻿using StudentAPI.Models;

namespace StudentAPI.Interfaces
{
    public interface IDepartmentRepository
    {
        public List<Departament> GetDepartments();
        public Task<Departament> GetDepartmentById(int departmentId);
        Task<int> CreateDepartmentWithStudentsAndLectures(Departament department, List<Student> students, List<Lecture> lectures);
        Task<int> AddStudentsToDepartment(int departmentId, List<Student> students);
        public Task<int> AddLecturesToDepartment(int departmentId, List<Lecture> lectures);
        Task<bool> TransferStudent(int studentId, int newDepartmentId);
    }
}
