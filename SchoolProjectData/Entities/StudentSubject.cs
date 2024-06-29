using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProjectData.Entities
{
    public class StudentSubject
    {
        [Key]
       // public int StudSubID { get; set; }
        public int StudID { get; set; }
        [Key]
        public int SubID { get; set; }
        public decimal? Grade { get; set; }
        [ForeignKey("StudID")]
        [InverseProperty("StudentSubjects")]

        public virtual Student Students { get; set; }
        [ForeignKey("SubID")]
        [InverseProperty("StudentSubjects")]
        public virtual Subject SubjectS { get; set; }

    }
}
