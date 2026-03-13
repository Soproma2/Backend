using HomeWork_64_Asp___Todo.Common;
using HomeWork_64_Asp___Todo.DTOs.Requests;
using HomeWork_64_Asp___Todo.DTOs.Responses;

namespace HomeWork_64_Asp___Todo.Services.Todo
{
    public interface ITodoService
    {
        Result<List<TodoResponseDto>> GetAll();
        Result<TodoResponseDto> GetById(int Id);
        Result<string> Create(CreateTodoReq req);
        Result<string> Update(int Id, UpdateTodoReq req);
        Result<string> Delete(int Id);
        Result<string> ToggleComplete(int Id);

    }
}
