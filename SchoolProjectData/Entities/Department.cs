using SchoolProjectData.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProjectData.Entities
{
    public class Department: LocalizabileEntity
    {
        public Department()
        {
            Students = new HashSet<Student>();
            Departments = new HashSet<DepartmentSubject>();
        }
        [Key]
        public int DID { get; set; }
     
        [InverseProperty("Departments")]
        public ICollection<Student> Students { get; set; }
        public ICollection<DepartmentSubject> Departments { get; set; }

    }
}
