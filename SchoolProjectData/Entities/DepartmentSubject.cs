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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DepSubID { get; set; }
        public int DID { get; set; }
        public int SubID { get; set; }
        [ForeignKey("DID")]
        [InverseProperty("DepartmentSubjects")]
        public virtual Department? Department { get; set; }
        [ForeignKey("SubID")]
        [InverseProperty("DepartmentSubjects")]

        public virtual Subject? Subject { get; set; }

    }
}
