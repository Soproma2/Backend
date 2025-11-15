using HomeWork30.Services.AuthorServices;
using HomeWork30.Services.BookServices;

BookServices bookService = new BookServices();
AuthorServices authorService = new AuthorServices();

while (true)
{
    Console.WriteLine("\n===== Library Management =====");
    Console.WriteLine("1. Register Author");
    Console.WriteLine("2. Show Authors");
    Console.WriteLine("3. Show One Author (with books)");
    Console.WriteLine("4. Add Book");
    Console.WriteLine("5. Show Books");
    Console.WriteLine("6. Exit");
    Console.Write("Choose option: ");

    string choice = Console.ReadLine();
    Console.WriteLine();

    switch (choice)
    {
        case "1":
            authorService.RegisterAuthor();
            break;

        case "2":
            authorService.ShowAuthors();
            break;

        case "3":
            authorService.ShowAuthor();
            break;

        case "4":
            bookService.AddBook();
            break;

        case "5":
            bookService.ShowBooks();
            break;

        case "6":
            Console.WriteLine("Goodbye!");
            return;

        default:
            Console.WriteLine("Invalid option, try again.");
            break;
    }
}