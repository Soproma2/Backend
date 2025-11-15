using HomeWork32.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork32.Services.PostService
{
    internal interface IPost
    {
        void CreatePost(User user);
        void UpdatePost(User currentUser);
        void DeletePost(User currentUser);
    }
}
