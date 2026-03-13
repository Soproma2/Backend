using Azure;
using HomeWork_64_Asp___Todo.Common;
using HomeWork_64_Asp___Todo.Data;
using HomeWork_64_Asp___Todo.DTOs.Requests;
using HomeWork_64_Asp___Todo.DTOs.Responses;
using HomeWork_64_Asp___Todo.Enums;
using HomeWork_64_Asp___Todo.Models;

namespace HomeWork_64_Asp___Todo.Services.Todo
{
    public class TodoService : ITodoService
    {
        private readonly AppDbContext _db;

        public TodoService(AppDbContext db) => _db = db;


        public Result<string> Create(CreateTodoReq req)
        {
            var todo = new TodoItem()
            {
                Title = req.Title,
                Description = req.Description,
                DueDate = req.DueDate,
            };

            _db.Todos.Add(todo);
            _db.SaveChanges();
            return Result<string>.success("Todo Added Successfully.", req.Title);
        }

        public Result<string> Delete(int Id)
        {
            var todo = _db.Todos.Find(Id);
            if (todo == null)
                return Result<string>.NotFound("Todo not found");
            _db.Todos.Remove(todo);
            _db.SaveChanges();
            return Result<string>.success("Todo Deleted Successfully", null);
        }

        public Result<List<TodoResponseDto>> GetAll()
        {
            var todos = _db.Todos.Select(t=> new TodoResponseDto()
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                IsCompleted = t.IsCompleted,
                Priority = t.Priority,
                CreatedAt = t.CreatedAt,
                UpdatedAt = t.UpdatedAt,
                DueDate = t.DueDate
            }).ToList();

            if (todos.Any())
                Result<List<TodoResponseDto>>.NotFound("Todos not Found");

            return Result<List<TodoResponseDto>>.success(null, todos);

        }

        public Result<TodoResponseDto> GetById(int Id)
        {
            var todo = _db.Todos.Find(Id);

            if(todo == null)
                Result<TodoResponseDto>.NotFound("Todo not Found");

            var response = new TodoResponseDto()
            {
                Id = todo.Id,
                Title = todo.Title,
                Description = todo.Description,
                IsCompleted = todo.IsCompleted,
                Priority = todo.Priority,
                CreatedAt = todo.CreatedAt,
                UpdatedAt = todo.UpdatedAt,
                DueDate = todo.DueDate
            };


            return Result<TodoResponseDto>.success(null, response);
        }

        public Result<string> ToggleComplete(int Id)
        {
            var todo = _db.Todos.Find(Id);

            if (todo == null)
                Result<string>.NotFound("Todo not Found");

            todo.IsCompleted = !todo.IsCompleted;
            todo.UpdatedAt = DateTime.Now;

            _db.SaveChanges();

            return Result<string>.success(null, null);
        }

        public Result<string> Update(int Id, UpdateTodoReq req)
        {
            var todo = _db.Todos.Find(Id);

            if (todo == null)
                Result<TodoResponseDto>.NotFound("Todo not Found");

            todo.Title = req.Title ?? todo.Title;
            todo.Description = req.Description ?? todo.Description;
            todo.IsCompleted = req.IsCompleted ?? todo.IsCompleted;
            todo.Priority = req.Priority ?? todo.Priority;
            todo.UpdatedAt = DateTime.Now;
            todo.DueDate = req.DueDate ?? todo.DueDate;
            _db.SaveChanges();

            return Result<string>.success("Todo Updated Successfully.", null);
        }
    }
}
