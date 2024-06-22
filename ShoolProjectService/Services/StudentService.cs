using SchoolProjectData.Entities;
using SchoolProjectInfrastrcure.Abstract;
using SchoolProjectInfrastrcure.Data;
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
        public async Task<bool> IsNameExit(string name)
        {
            return await _studentRepository.IsNameExit(name);
        }
        public async Task<string> UpdateStudentAsync(Student student)
        {
            return await _studentRepository.UpdateStudentAsync(student);
        }
        public async Task<string> DeleteStudentAsync(int Id)
        {
            return await _studentRepository.DeleteStudentAsync(Id);
        }
        public IQueryable<Student> GetAllStudentsQueryable(string[] order, string serach)
        {
            var students = _studentRepository.GetAllStudentsQueryable();
            if (!string.IsNullOrEmpty(serach))
                students = students.Where(x => x.Name.Contains(serach) || x.Address.Contains(serach));
            return students;
        }
    }

}

