using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProjectData.Entities
{
    public class Subject
    {
        public Subject()
        {
            Departments = new HashSet<Department>();
            StudentSubjects = new HashSet<StudentSubject>();
        }

        [Key]
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public DateTime Period { get; set; }
        public virtual ICollection<StudentSubject> StudentSubjects { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
    }
}
