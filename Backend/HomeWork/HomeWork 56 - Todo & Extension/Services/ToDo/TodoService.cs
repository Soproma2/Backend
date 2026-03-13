using HomeWork_56___Todo___Extension.Common;
using HomeWork_56___Todo___Extension.Data;
using HomeWork_56___Todo___Extension.DTOs.Requests;
using HomeWork_56___Todo___Extension.DTOs.Responses;
using HomeWork_56___Todo___Extension.Enums;
using HomeWork_56___Todo___Extension.Models;

namespace HomeWork_56___Todo___Extension.Services.ToDo
{
    public class TodoService : ITodoService
    {
        private readonly DataContext _context;

        public TodoService(DataContext context)
        {
            _context = context;
        }

        public Result<TodoResponse> Create(CreateTodoReq req, int userId)
        {
            if (string.IsNullOrWhiteSpace(req.Title))
                return Result<TodoResponse>.BadRequest("Title is required");

            if (req.DueDate.HasValue && req.DueDate < DateTime.Now)
                return Result<TodoResponse>.BadRequest("Due date cannot be in the past");

            var todo = new TodoItem
            {
                Title = req.Title,
                Description = req.Description,
                Priority = req.Priority,
                DueDate = req.DueDate,
                UserId = userId
            };

            _context.Todos.Add(todo);
            _context.SaveChanges();

            return Result<TodoResponse>.success("Todo created successfully", ToResponse(todo));
        }

        public Result<TodoResponse> Update(int id, UpdateTodoReq req, int userId)
        {
            if (id <= 0)
                return Result<TodoResponse>.BadRequest("Invalid ID");

            var todo = _context.Todos.Find(id);
            if (todo == null)
                return Result<TodoResponse>.NotFound("Todo not found");

            if (todo.UserId != userId)
                return Result<TodoResponse>.BadRequest("You can only edit your own todos");

            if (req.DueDate.HasValue && req.DueDate < DateTime.Now)
                return Result<TodoResponse>.BadRequest("Due date cannot be in the past");

            todo.Title = req.Title ?? todo.Title;
            todo.Description = req.Description ?? todo.Description;
            todo.Priority = req.Priority ?? todo.Priority;
            todo.DueDate = req.DueDate ?? todo.DueDate;
            todo.IsCompleted = req.IsCompleted ?? todo.IsCompleted;
            todo.UpdatedAt = DateTime.Now;

            _context.SaveChanges();
            return Result<TodoResponse>.success("Todo updated successfully", ToResponse(todo));
        }

        public Result<TodoResponse> Delete(int id, int userId)
        {
            if (id <= 0)
                return Result<TodoResponse>.BadRequest("Invalid ID");

            var todo = _context.Todos.Find(id);
            if (todo == null)
                return Result<TodoResponse>.NotFound("Todo not found");

            if (todo.UserId != userId)
                return Result<TodoResponse>.BadRequest("You can only delete your own todos");

            _context.Todos.Remove(todo);
            _context.SaveChanges();

            return Result<TodoResponse>.success("Todo deleted successfully", null);
        }

        public Result<List<TodoResponse>> GetAll(int userId)
        {
            var todos = _context.Todos
                .Where(t => t.UserId == userId)
                .OrderByDescending(t => t.CreatedAt)
                .Select(t => new TodoResponse
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    IsCompleted = t.IsCompleted,
                    Priority = t.Priority,
                    DueDate = t.DueDate,
                    CreatedAt = t.CreatedAt
                }).ToList();

            if (!todos.Any())
                return Result<List<TodoResponse>>.NotFound("No todos found");

            return Result<List<TodoResponse>>.success(null, todos);
        }

        public Result<TodoResponse> GetById(int id, int userId)
        {
            if (id <= 0)
                return Result<TodoResponse>.BadRequest("Invalid ID");

            var todo = _context.Todos.FirstOrDefault(t => t.Id == id && t.UserId == userId);
            if (todo == null)
                return Result<TodoResponse>.NotFound("Todo not found");

            return Result<TodoResponse>.success(null, ToResponse(todo));
        }

        public Result<List<TodoResponse>> GetByPriority(Priority priority, int userId)
        {
            var todos = _context.Todos
                .Where(t => t.UserId == userId && t.Priority == priority)
                .OrderByDescending(t => t.CreatedAt)
                .Select(t => new TodoResponse
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    IsCompleted = t.IsCompleted,
                    Priority = t.Priority,
                    DueDate = t.DueDate,
                    CreatedAt = t.CreatedAt
                }).ToList();

            if (!todos.Any())
                return Result<List<TodoResponse>>.NotFound("No todos found with this priority");

            return Result<List<TodoResponse>>.success(null, todos);
        }

        public Result<List<TodoResponse>> GetCompleted(int userId)
        {
            var todos = _context.Todos
                .Where(t => t.UserId == userId && t.IsCompleted)
                .OrderByDescending(t => t.CreatedAt)
                .Select(t => new TodoResponse
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    IsCompleted = t.IsCompleted,
                    Priority = t.Priority,
                    DueDate = t.DueDate,
                    CreatedAt = t.CreatedAt
                }).ToList();

            if (!todos.Any())
                return Result<List<TodoResponse>>.NotFound("No completed todos found");

            return Result<List<TodoResponse>>.success(null, todos);
        }

        public Result<List<TodoResponse>> GetPending(int userId)
        {
            var todos = _context.Todos
                .Where(t => t.UserId == userId && !t.IsCompleted)
                .OrderByDescending(t => t.CreatedAt)
                .Select(t => new TodoResponse
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    IsCompleted = t.IsCompleted,
                    Priority = t.Priority,
                    DueDate = t.DueDate,
                    CreatedAt = t.CreatedAt
                }).ToList();

            if (!todos.Any())
                return Result<List<TodoResponse>>.NotFound("No pending todos found");

            return Result<List<TodoResponse>>.success(null, todos);
        }

        public Result<TodoResponse> ToggleComplete(int id, int userId)
        {
            if (id <= 0)
                return Result<TodoResponse>.BadRequest("Invalid ID");

            var todo = _context.Todos.FirstOrDefault(t => t.Id == id && t.UserId == userId);
            if (todo == null)
                return Result<TodoResponse>.NotFound("Todo not found");

            todo.IsCompleted = !todo.IsCompleted;
            todo.UpdatedAt = DateTime.Now;

            _context.SaveChanges();

            var message = todo.IsCompleted ? "Todo marked as completed" : "Todo marked as pending";
            return Result<TodoResponse>.success(message, ToResponse(todo));
        }

        private static TodoResponse ToResponse(TodoItem todo) => new TodoResponse
        {
            Id = todo.Id,
            Title = todo.Title,
            Description = todo.Description,
            IsCompleted = todo.IsCompleted,
            Priority = todo.Priority,
            DueDate = todo.DueDate,
            CreatedAt = todo.CreatedAt
        };
    }
}
