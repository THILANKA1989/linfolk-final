using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication9.Services
{
    public interface IMailService
    {
        bool SendMail(string to,string from, string body, string subject);
    }
}
