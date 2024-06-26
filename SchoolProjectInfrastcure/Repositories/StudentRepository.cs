using Microsoft.EntityFrameworkCore;
using SchoolProjectData.Entities;
using SchoolProjectInfrastrcure.Abstract;
using SchoolProjectInfrastrcure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProjectInfrastrcure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public StudentRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<List<Student>> GetStudentsListAsync()
        {
            return await _applicationDbContext.students.Include(x => x.Department)
                .ToListAsync();
        }
        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _applicationDbContext.students
                .Include(x => x.Department).AsNoTracking()
                .FirstOrDefaultAsync(x => x.StuID == id);
        }
        public async Task<string> AddStudentASync(Student student)
        {
            var exsitStudent = await _applicationDbContext.students.Where(x => x.NameEn == student.NameEn).FirstOrDefaultAsync();
            if (exsitStudent != null)

                return "exsit";
            else
            {
             await   _applicationDbContext.students.AddAsync(student);
               await _applicationDbContext.SaveChangesAsync();
                return "success";
            }


        }
        public async Task<bool>IsNameExit(string name)
        {
            return await _applicationDbContext.students.AnyAsync(x => x.NameEn == name);
        }
        public async Task<string> UpdateStudentAsync(Student student)
        {
            try
            {
                _applicationDbContext.students.Update(student);
                await _applicationDbContext.SaveChangesAsync();
                return ("Sccuess");
            }
            catch (Exception ex)
            {
                return (ex.Message);
            }
             
        }
        public async Task<string> DeleteStudentAsync(int Id)
        {
            try
            {
              var student= await  _applicationDbContext.students.Where(x=>x.StuID== Id).FirstAsync();
                 _applicationDbContext.students.Remove(student);
                await _applicationDbContext.SaveChangesAsync();
                return ("Sccuess");
            }
            catch (Exception ex)
            {
                return (ex.Message);
            }

        }
        public IQueryable<Student> GetAllStudentsQueryable()
        {
            return _applicationDbContext.students.Include (x=>x.Department).AsQueryable();
        }
    }
}
