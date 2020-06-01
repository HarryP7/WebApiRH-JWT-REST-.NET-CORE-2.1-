using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiRH.Models.Services
{
    public interface IEmailSender
    {
        void Send(string message, string to);
    }
}
