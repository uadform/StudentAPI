﻿using StudentAPI.Interfaces;
using StudentAPI.Models;

namespace StudentAPI.Services
{
    public class LectureService : ILectureService
    {
        private readonly ILectureRepository _lectureRepository;
        public LectureService(ILectureRepository lectureRepository)
        {
            _lectureRepository = lectureRepository;
        }
        public List<Lecture> GetLectures()
        {
            return _lectureRepository.GetLectures().ToList();
        }
        public List<Lecture> GetLecturesByDepartmentId(int departmentId)
        {
            return _lectureRepository.GetLecturesByDepartmentId(departmentId).ToList();
        }
        public async Task<List<Lecture>> GetLecturesByStudentId(int studentId)
        {
            // Implement logic to retrieve lectures by student using Dapper
            var lectures = await _lectureRepository.GetLecturesByStudentId(studentId);
            return lectures;
        }
    }
}
