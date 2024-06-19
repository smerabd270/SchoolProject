using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProjectData.Entities
{
    public class DepartmentSubject
    {
        [Key]
        public int DepSubID { get; set; }
        public int DID { get; set; }
        public int SubID { get; set; }
        [ForeignKey("DID")]
        public virtual Department Departments { get; set; }
        [ForeignKey("SubID")]
        public virtual Subject SubjectS { get; set; }

    }
}
