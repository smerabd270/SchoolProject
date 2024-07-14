using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoolProjectService.Abstract;

namespace ShoolProjectService.Services
{
    public class EmailsService : IEmailsService
    {
        public Task<string> SendEmail(string email, string Message, string? reason)
        {
            throw new NotImplementedException();
        }
    }
}
