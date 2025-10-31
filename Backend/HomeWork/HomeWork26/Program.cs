using HomeWork26.Data;
using HomeWork26.Models;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

Baza baza = new Baza();

while (true)
{
    Console.WriteLine("\n--- TODO Application ---");

    Console.WriteLine("1. Add Todo");
    Console.WriteLine("2. View Todos");
    Console.WriteLine("3. Mark Todo as Completed");
    Console.WriteLine("4. Delete Todo");
    Console.WriteLine("5. Filter Todos");
    Console.WriteLine("6. Exit");

    Console.Write("\nSelect an option: ");
    var choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.Write("Enter Todo Title: ");
            string title = Console.ReadLine();

            baza.ToDos.Add(new ToDo
            {
                Title = title,
            });
            baza.SaveChanges();
            Console.WriteLine("Todo added successfully!");
            break; 
        case "2":
            try
            {
                var todos = baza.ToDos.ToList();
                if (!todos.Any())
                {
                    throw new Exception("No todos found!");
                }
                foreach (var todo in todos)
                {
                    Console.WriteLine($"[{(todo.IsCompleted ? "X" : " ")}]: {todo.Id}. {todo.Title} - (Created: {todo.CreatedAt}) ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            break; 
        case "3":
            try
            {
                Console.Write("Enter todo ID to mark as completed: ");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    var todo = baza.ToDos.Find(id);
                    if (todo != null)
                    {
                        todo.IsCompleted = true;
                        baza.SaveChanges();
                        Console.WriteLine("Todo marked as completed!");
                    }
                    else
                    {
                        throw new Exception("Todo not found!");
                    }
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            break;
        case "4":
            try
            {
                Console.Write("Enter todo ID to delete: ");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    var deleteToDo = baza.ToDos.Find(id);
                    if (deleteToDo != null)
                    {
                        baza.ToDos.Remove(deleteToDo);
                        baza.SaveChanges();
                        Console.WriteLine("Todo deleted successfully!");
                    }
                    else
                    {
                        throw new Exception("Todo not found!");
                    }
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            break;
        case "5":
            try
            {
                Console.WriteLine("Filter Todos:");
                Console.WriteLine("1. Completed Todos");
                Console.WriteLine("2. Not Completed Todos");
                Console.Write("Choose filter option: ");
                var filterChoice = Console.ReadLine();

                List<ToDo> filteredToDos;
                if(filterChoice == "1")
                {
                    filteredToDos = baza.ToDos.Where(t => t.IsCompleted == true).ToList();
                }else if(filterChoice == "2")
                {
                    filteredToDos = baza.ToDos.Where(t => t.IsCompleted == false).ToList();
                }
                else
                {
                    throw new Exception("Invalid option!");
                }

                if (!filteredToDos.Any())
                {
                    throw new Exception("No todos found for this filter!");
                }

                Console.WriteLine("\n--- Filtered Todos ---");
                foreach (var todo in filteredToDos)
                {
                    Console.WriteLine($"[{(todo.IsCompleted ? "X" : " ")}] {todo.Id}. {todo.Title} - (Created: {todo.CreatedAt})");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            break;
        case "6": return;
    }
}