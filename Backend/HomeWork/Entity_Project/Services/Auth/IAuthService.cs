using Entity_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Project.Services.Auth
{
    internal interface IAuthService
    {
        void Register();
        void VerifyEmail();
        void Login();
        void Logout();
    }
}
