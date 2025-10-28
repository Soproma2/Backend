using HomeWork25.Data;
using HomeWork25.Models;

Baza baza = new Baza();

while (true)
{
    Console.WriteLine("=====Library=====");
    Console.WriteLine("1. Create new book");
    Console.WriteLine("2. Remove book");
    Console.WriteLine("3. Edit book");
    Console.WriteLine("4. Show book");
    Console.WriteLine("5. Get Book by Id: ");
    Console.WriteLine("6. Filter Books By title: ");
    Console.WriteLine("7. Filter Books By Year: ");
    Console.WriteLine("8. Filter Books By Author: ");

    Console.Write("Enter key: ");
    string key = Console.ReadLine();

    if (key == "1")
    {
        Console.Clear();
        Console.Write("Enter title: ");
        string title = Console.ReadLine();

        Console.WriteLine("Enter author: ");
        string author = Console.ReadLine();

        Console.WriteLine("Enter year: ");
        int year = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter page count: ");
        int pageCount = int.Parse(Console.ReadLine());

        Book newBook = new Book()
        {
            Year = year,
            Title = title,
            Author = author,
            PageCount = pageCount
        };

        baza.Books.Add(newBook);
        baza.SaveChanges();
        Console.WriteLine("New book add successfully!");
    }
    else if (key == "2")
    {
        Console.Clear();
        var books = baza.Books.ToList();

        foreach (var item in books)
        {
            Console.WriteLine($"Id: {item.Id}, Title: {item.Title}, Author: {item.Author}");
        }

        Console.Write("Enter book id: ");
        int bookId = int.Parse(Console.ReadLine());

        var book = baza.Books.Find(bookId);

        if (book == null)
        {
            Console.WriteLine("Book not found!");
        }
        else
        {
            baza.Books.Remove(book);
            baza.SaveChanges();
            Console.WriteLine("Book deleted successfully.");
        }
    }
    else if (key == "3")
    {
        Console.Clear();
        var books = baza.Books.ToList();

        foreach (var item in books)
        {
            Console.WriteLine($"Id: {item.Id}, Title: {item.Title}, Author: {item.Author}");
        }

        Console.Write("Enter book id: ");
        int bookId = int.Parse(Console.ReadLine());

        var book = baza.Books.Find(bookId);

        if (book == null)
        {
            Console.WriteLine("Book not found!");
        }
        else
        {

            Console.Write("Enter title: ");
            string title = Console.ReadLine();

            Console.WriteLine("Enter author: ");
            string author = Console.ReadLine();

            Console.WriteLine("Enter year: ");
            int year = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter page count: ");
            int pageCount = int.Parse(Console.ReadLine());

            book.Title = title;
            book.Author = author;
            book.Year = year;
            book.PageCount = pageCount;

            baza.SaveChanges();
            Console.WriteLine("Book edited successfully.");
        }
    }
    else if (key == "4")
    {
        Console.Clear();
        var books = baza.Books.ToList();

        foreach (var item in books)
        {
            Console.WriteLine($"Id: {item.Id}, Title: {item.Title}, Author: {item.Author}");
        }
    }
    else if (key == "5")
    {
        Console.Clear();
        var books = baza.Books.ToList();

        foreach (var item in books)
        {
            Console.WriteLine($"Id: {item.Id}, Title: {item.Title}, Author: {item.Author}");
        }

        Console.Write("Enter book id: ");
        int bookId = int.Parse(Console.ReadLine());

        var book = baza.Books.Find(bookId);

        Console.WriteLine($"Id: {book.Id}, Title: {book.Title}, Author: {book.Author}");
    }
    else if (key == "6")
    {
        Console.WriteLine("Enter book title: ");
        string bookTitle = Console.ReadLine();

        List<Book> books = baza.Books.Where(x => x.Title.Contains(bookTitle)).ToList();

        foreach (var item in books)
        {
            Console.WriteLine($"Id: {item.Id}, Title: {item.Title}, Author: {item.Author}");
        }
    }
    else if (key == "7")
    {
        Console.WriteLine("Enter books Author: ");
        int bookYear = int.Parse(Console.ReadLine());

        List<Book> books = baza.Books.Where(x => x.Year == bookYear).ToList();

        foreach (var item in books)
        {
            Console.WriteLine($"Id: {item.Id}, Title: {item.Title}, Author: {item.Author}");
        }

    }
    else if (key == "8")
    {
        Console.WriteLine("Enter books Author: ");
        string bookAuthor = Console.ReadLine();

        List<Book> books = baza.Books.Where(x => x.Author.Contains(bookAuthor)).ToList();

        foreach (var item in books)
        {
            Console.WriteLine($"Id: {item.Id}, Title: {item.Title}, Author: {item.Author}");
        }
    }
    else
    {
        break;
    }
}
