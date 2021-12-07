using System;
using System.Collections.Generic;
using System.Linq;
using TodoApi.DAL;
using TodoApi.Models;

namespace TodoApiUnitTest
{
    class TodoRepositoryFake : ITodoRepository
    {

        private List<Todo> todos = new List<Todo>()
        {
            new Todo(){TodoId = 1, TodoTitle = "Fake1", ColumnId = 1 },
            new Todo(){TodoId = 2, TodoTitle = "Fake2", ColumnId = 2 },
            new Todo(){TodoId = 3, TodoTitle = "Fake3", ColumnId = 2 },
            new Todo(){TodoId = 4, TodoTitle = "Fake4", ColumnId = 4 }
        };


        public List<Todo> GetTodos()
        {
            return todos;
        }

        public Todo GetTodoByID(long todoID)
        {
            Todo _todo = todos.FirstOrDefault(t => t.TodoId == todoID);
            return _todo;
        }

        public Todo AddTodo(Todo todo)
        {
            todos.Add(todo);
            return todo;
        }

        public Todo EditTodo(Todo todo)
        {
            if (todo == null)
                return null;
            Todo _todo = todos.FirstOrDefault(t => t.TodoId == todo.TodoId);
            if(todo != null)
            {
                _todo = todo;
            }

            return _todo;
        }


        public Todo RemoveTodo(long todoID)
        {
            Todo _todo = todos.FirstOrDefault(t => t.TodoId == todoID);
            todos.Remove(_todo);
            return _todo;
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    foreach (var t in todos)
                    {
                        todos.Remove(t);
                    }
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
