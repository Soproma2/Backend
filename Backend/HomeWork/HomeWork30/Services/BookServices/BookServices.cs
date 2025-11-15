using HomeWork30.Data;
using HomeWork30.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork30.Services.BookServices
{
    internal class BookServices : IBook
    {
        DataContext _db = new DataContext();
        public void AddBook()
        {
            Console.WriteLine("Enter Book Title: ");
            string title = Console.ReadLine();

            Console.WriteLine("Enter Description: ");
            string desc = Console.ReadLine();

            Console.WriteLine("Enter Author Id: ");
            int authorID = int.Parse(Console.ReadLine());

            var author = _db.authors.FirstOrDefault(a => a.Id == authorID);

            if (author == null)
            {
                Console.WriteLine("Author not found!");
                return;
            }

            Book book = new Book()
            {
                Title = title,
                Description = desc,
                Author = author
            };

            _db.books.Add(book);
            _db.SaveChanges();
            Console.WriteLine("Book added successfully.");
        }

        public void ShowBooks()
        {
            var books = _db.books
                .Include(b => b.Author)
                .ToList();

            foreach( var book in books)
            {
                Console.WriteLine($"- Title: {book.Title} | Description: {book.Description} | Author: {book.Author.Firstname} {book.Author.Lastname}");
            }

            if(books.Count == 0)
            {
                Console.WriteLine("Books not found!");
            }
        }
    }
}
