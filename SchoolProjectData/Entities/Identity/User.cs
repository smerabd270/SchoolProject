using EntityFrameworkCore.EncryptColumn.Attribute;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
namespace SchoolProjectData.Entities.Identity
{
    public class User : IdentityUser<int>
    {
        public User()
        {
        }
        public string FullName { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }
      
    }
}
