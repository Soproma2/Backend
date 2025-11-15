using HomeWork32.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork32.Services.UserService
{
    internal interface IUser
    {
        void Register();
        User Login(); 
    }
}
