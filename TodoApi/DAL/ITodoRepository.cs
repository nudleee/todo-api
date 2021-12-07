using System.Collections.Generic;
using TodoApi.Models;

namespace TodoApi.DAL
{
    public interface ITodoRepository
    {
        List<Todo> GetTodos();
        Todo GetTodoByID(long todoID);
        Todo AddTodo(Todo todo);
        Todo EditTodo(Todo todo);
        Todo RemoveTodo(long todoID);
    }
}
