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
    public class Instructor: LocalizabileEntity
    {
        public Instructor()
        {
            Ins_Subjects=new HashSet<Ins_Subject>();
            Instructors = new HashSet<Instructor>();
        }
        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InsId { get; set; }
        public string Address { get; set; }
        public string Postion { get; set; }
        public int? SupervisorId { get; set; }
        public decimal Salary { get; set; }
        public int DID { get; set; }
        [ForeignKey("DID")]
        [InverseProperty("Instructors")]
        public Department? Department { get; set; }

        [InverseProperty("Instructor")]
        public Department DepartmentManager { get; set; }
        [ForeignKey(nameof(SupervisorId))]
        [InverseProperty(nameof(Instructors))]

        public Instructor? Supervisor { get; set; }
        [InverseProperty(nameof(Supervisor))]
        public virtual ICollection <Instructor> Instructors { get; set; }
        [InverseProperty("Instructor")]
        public virtual ICollection <Ins_Subject> Ins_Subjects { get;}


    }
}
