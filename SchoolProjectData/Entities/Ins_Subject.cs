using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProjectData.Entities
{
    public  class Ins_Subject
    {
        [Key]
        public int InsId { get; set; }
        [Key]
        public int SubjectId { get; set; }
        [ForeignKey("InsId")]
        [InverseProperty(("Ins_Subjects"))]
        public Instructor Instructor { get; set; }
        [ForeignKey("SubjectId")]
        [InverseProperty("Ins_Subjects")]
        public Subject Subject { get; set; }
    }
}
