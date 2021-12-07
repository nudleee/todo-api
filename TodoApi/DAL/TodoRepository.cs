using System;
using System.Collections.Generic;
using System.Linq;
using TodoApi.Models;

namespace TodoApi.DAL
{
   class TodoRepository: ITodoRepository
    {
        private KanbanBoardContext context;

        public TodoRepository(KanbanBoardContext context)
        {
            this.context = context;
        }

        public List<Todo> GetTodos()
        {
            return  context.Todos.ToList();
        }
        public Todo GetTodoByID(long todoID)
        {
            return context.Todos.Find(todoID);
        }
        public Todo AddTodo(Todo todo)
        {
            context.Todos.Add(todo);
            context.SaveChanges();
            return todo;
        }
        public Todo EditTodo(Todo todo)
        {
            if (todo == null)
                return null;
            var exist = context.Set<Todo>().Find(todo.TodoId);
            if (exist != null)
            {
                context.Entry(exist).CurrentValues.SetValues(todo);
                context.SaveChanges();
            }
            return exist;
        }

        public Todo RemoveTodo(long todoID)
        {
            Todo todoToRemove = context.Todos.Find(todoID);
            context.Todos.Remove(todoToRemove);
            context.SaveChanges();
            return todoToRemove;
        }
      
    }
}
