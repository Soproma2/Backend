using HomeWork24.Data;
using HomeWork24.Models;
using Microsoft.EntityFrameworkCore;
        
var baza = new Baza();


baza.Database.EnsureCreated();

while (true){
    Console.WriteLine("\n--- TODO Application ---");
    Console.WriteLine("1. Add Todo");
    Console.WriteLine("2. List All Todos");
    Console.WriteLine("3. Mark Todo as Completed");
    Console.WriteLine("4. Delete Todo");
    Console.WriteLine("5. Filter Todos");
    Console.WriteLine("0. Exit");
    
    Console.Write("\nSelect an option: ");
    var choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.Write("Enter todo title: ");
            var title = Console.ReadLine();
            baza.Todos.Add(new Todo { Title = title, IsCompeted = false });
            baza.SaveChanges();
            Console.WriteLine("Todo added successfully!");
            break;

        case "2":
            var todos = baza.Todos.ToList();
            if (!todos.Any())
            {
                Console.WriteLine("No todos found!");
                break;
            }
            foreach (var todo in todos)
            {
                Console.WriteLine($"[{(todo.IsCompeted ? "X" : " ")}] {todo.Id}. {todo.Title} (Created: {todo.CreatedAt})");
            }
            break;

        case "3":
            Console.Write("Enter todo ID to mark as completed: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var todo = baza.Todos.Find(id);
                if (todo != null)
                {
                    todo.IsCompeted = true;
                    baza.SaveChanges();
                    Console.WriteLine("Todo marked as completed!");
                }
                else
                {
                    Console.WriteLine("Todo not found!");
                }
            }
            break;

        case "4":
            Console.Write("Enter todo ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int deleteId))
            {
                var todoToDelete = baza.Todos.Find(deleteId);
                if (todoToDelete != null)
                {
                    baza.Todos.Remove(todoToDelete);
                    baza.SaveChanges();
                    Console.WriteLine("Todo deleted successfully!");
                }
                else
                {
                    Console.WriteLine("Todo not found!");
                }
            }
            break;

        case "5":
            Console.WriteLine("Filter options:");
            Console.WriteLine("1. Show completed todos");
            Console.WriteLine("2. Show incomplete todos");
            Console.WriteLine("3. Show todos by date");
            var filterChoice = Console.ReadLine();

            IQueryable<Todo> query = baza.Todos;
            switch (filterChoice)
            {
                case "1":
                    query = query.Where(t => t.IsCompeted);
                    break;
                case "2":
                    query = query.Where(t => !t.IsCompeted);
                    break;
                case "3":
                    Console.Write("Enter date (yyyy-MM-dd): ");
                    if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
                    {
                        query = query.Where(t => t.CreatedAt.Date == date.Date);
                    }
                    break;
            }

            var filteredTodos = query.ToList();
            foreach (var todo in filteredTodos)
            {
                Console.WriteLine($"[{(todo.IsCompeted ? "X" : " ")}] {todo.Id}. {todo.Title} (Created: {todo.CreatedAt})");
            }
            break;

        case "0":
            return;

        default:
            Console.WriteLine("Invalid option!");
            break;
    }
}