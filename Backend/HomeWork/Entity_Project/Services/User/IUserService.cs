using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Project.Services.User
{
    internal interface IUserService
    {
        void ViewProfile(Models.User user);
        void AddBalance(Models.User user);
        void UpdateProfile(Models.User user);
    }
}
