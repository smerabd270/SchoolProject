using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProjectData.Entities
{
    public  class User:IdentityUser
    {
        public string Address { get; set; }
        public string Country { get; set; }

    }
}
