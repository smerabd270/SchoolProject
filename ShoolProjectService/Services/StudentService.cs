﻿using SchoolProjectData.Entities;
using SchoolProjectInfrastrcure.Abstract;
using ShoolProjectService.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoolProjectService.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<List<Student>> GetStudentsListAsync()
        {
            return await _studentRepository.GetStudentsListAsync();
        }
        public async Task<Student> GetStudentByIdAsync(int Id)
        {
            return await _studentRepository.GetStudentByIdAsync(Id);
        }
        public async Task<string> AddStudentASync(Student student)
        {
            return await _studentRepository.AddStudentASync(student);

        }
    }
}
