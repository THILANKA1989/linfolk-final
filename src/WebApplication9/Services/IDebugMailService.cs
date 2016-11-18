using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication9.Services
{
    public class IDebugMailService : IMailService
    {
        public bool SendMail(string to, string from, string body, string subject)
        {
            System.Diagnostics.Debug.WriteLine($"Sending Mail To: {to}, Subject:{subject} ,From: {from}, Body: {body}");
            return true;
        }

    }
}
