using HomeWork30.Data;
using HomeWork30.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork30.Services.AuthorServices
{
    internal class AuthorServices : IAuthor
    {
        DataContext _db = new DataContext();

        public void RegisterAuthor()
        {
            Console.WriteLine("Enter Firstname: ");
            string firstname = Console.ReadLine();

            Console.WriteLine("Enter Lastname: ");
            string lastname = Console.ReadLine();

            Author author = new Author()
            {
                Firstname = firstname,
                Lastname = lastname
            };

            _db.authors.Add(author);
            _db.SaveChanges();
            Console.WriteLine("Author registered successfully.");
        }

        public void ShowAuthor()
        {
            Console.WriteLine("Enter Author Id: ");
            int Id = int.Parse(Console.ReadLine());

            var author = _db.authors
                .Include(b=>b.books)
                .FirstOrDefault(x => x.Id == Id);

            if (author == null)
            {
                Console.WriteLine("Author not found!");
            }

            Console.WriteLine($"\nAuthor: {author.Firstname} {author.Lastname}");
            Console.WriteLine($"\nBooks: ");
            if(author.books == null || author.books.Count == 0)
            {
                Console.WriteLine("Books not found!");
            }

            foreach (var book in author.books)
            {
                Console.WriteLine($"- TiTle: {book.Title} | Description: {book.Description}");
            }
        }

        public void ShowAuthors()
        {
            var authors = _db.authors.ToList();
            foreach(var author in authors)
            {
                Console.WriteLine($"{author.Id} - Author: {author.Firstname} {author.Lastname}");
            }

            if(authors.Count == 0)
            {
                Console.WriteLine("Authors not found!");
            }
        }
    }
}
