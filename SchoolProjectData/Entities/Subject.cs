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
    public class Subject: LocalizabileEntity
    {
        public Subject()
        {
            DepartmentSubjects = new HashSet<DepartmentSubject>();
            StudentSubjects = new HashSet<StudentSubject>();
            Ins_Subjects=new HashSet<Ins_Subject>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int SubjectId { get; set; }
        public DateTime Period { get; set; }
        [InverseProperty("SubjectS")]
        public virtual ICollection<StudentSubject> StudentSubjects { get; set; }
        [InverseProperty("Subject")]
        public virtual ICollection<DepartmentSubject> DepartmentSubjects { get; set; }
        [InverseProperty("Subject")]

        public virtual ICollection<Ins_Subject> Ins_Subjects { get; set; }

    }
}
