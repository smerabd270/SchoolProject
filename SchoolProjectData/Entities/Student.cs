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
    public  class Student: LocalizabileEntity
    {
        public Student()
        {
            StudentSubjects= new HashSet<StudentSubject>();
        }
        [Key]
        public int StuID{ get; set; }
        
        [StringLength(200)]
        public string Address { get; set; }
        [StringLength(200)]
        public string Phone { get; set; }
        public int? DID { get; set; }
        [ForeignKey("DID")]
        [InverseProperty("Students")]
        public virtual Department Department { get; set; }
        [InverseProperty("Students")]
        public virtual ICollection<StudentSubject> StudentSubjects { get;}
    }
}
