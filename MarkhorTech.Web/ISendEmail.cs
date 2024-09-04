using MarkhorTech.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MarkhorTech.Web
{
    public interface ISendEmail
    {
        Task SendEmailAsync(ContactViewModel contactViewModel, string URL, string Subject, string Email); 
    }
}