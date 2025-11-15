using HomeWork32.Data;
using HomeWork32.Models;
using HomeWork32.Services.UserService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace HomeWork32.Services.PostService
{
    internal class PostService : IPost
    {
        DataContext _db = new DataContext();
         public void CreatePost(User user)
        {
            Console.Write("Enter Post Title: ");
            string title = Console.ReadLine();

            Console.Write("Enter Post Description: ");
            string description = Console.ReadLine();

            Post post = new Post()
            {
                Title = title,
                Description = description,
                UserId = user.Id 
            };

            _db.Posts.Add(post);
            _db.SaveChanges();
            Console.WriteLine("Post Created successfully.");
        }

        public void ShowPosts()
        {
            var posts = _db.Posts.Include(p => p.User).ToList();

            if (posts.Count == 0 || posts == null)
            {
                Console.WriteLine("Posts not found!");
            }

            foreach (var p in posts)
            {
                Console.WriteLine($"Id: {p.Id} - Title: {p.Title} - Description: {p.Description} - CreatedAt: {p.Created} - User: {p.User.Firstname} {p.User.Lastname}");
            }
        }

        public void UpdatePost(User currentUser)
        {
            Console.Write("Enter post Id: ");
            int postId = int.Parse(Console.ReadLine());

            Console.Write("Enter new title (leave empty to keep old): ");
            string nTitle = Console.ReadLine();

            Console.Write("Enter new description (leave empty to keep old): ");
            string nDesc = Console.ReadLine();

            var post = _db.Posts.Find(postId);
            if(post == null)
            {
                Console.WriteLine("Post not found!");
                return;
            }

            if (post.UserId != currentUser.Id)
            {
                Console.WriteLine("You are not allowed to edit this post!");
                return;
            }

            if (!string.IsNullOrEmpty(nTitle))
                post.Title = nTitle;

            if (!string.IsNullOrEmpty(nDesc))
                post.Description = nDesc;

            _db.SaveChanges();
            Console.WriteLine("Post Updated Successfully.");
        }

        public void DeletePost(User currentUser)
        {
            Console.Write("Enter post Id: ");
            int postId = int.Parse(Console.ReadLine());

            var post = _db.Posts.Find(postId);
            if (post == null)
            {
                Console.WriteLine("Post not found!");
                return;
            }

            if (post.UserId != currentUser.Id)
            {
                Console.WriteLine("You are not allowed to delete this post!");
                return;
            }

            _db.Remove(post);
            _db.SaveChanges();
            Console.WriteLine("Post Deleted Successfully.");
        }
    }
}
