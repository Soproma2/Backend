using HomeWork_56___Todo___Extension.Common;
using HomeWork_56___Todo___Extension.DTOs.Requests;
using HomeWork_56___Todo___Extension.DTOs.Responses;
using HomeWork_56___Todo___Extension.Enums;

namespace HomeWork_56___Todo___Extension.Services.ToDo
{
    public interface ITodoService
    {
        Result<TodoResponse> Create(CreateTodoReq req, int userId);
        Result<TodoResponse> Update(int id, UpdateTodoReq req, int userId);
        Result<TodoResponse> Delete(int id, int userId);
        Result<List<TodoResponse>> GetAll(int userId);
        Result<TodoResponse> GetById(int id, int userId);
        Result<List<TodoResponse>> GetByPriority(Priority priority, int userId);
        Result<List<TodoResponse>> GetCompleted(int userId);
        Result<List<TodoResponse>> GetPending(int userId);
        Result<TodoResponse> ToggleComplete(int id, int userId);
    }
}
