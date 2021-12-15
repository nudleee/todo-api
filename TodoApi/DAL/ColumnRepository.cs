using System;
using System.Collections.Generic;
using System.Linq;
using TodoApi.Models;

namespace TodoApi.DAL
{
    class ColumnRepository: IColumnRepository
    {
        private KanbanBoardContext context;

        public ColumnRepository(KanbanBoardContext context)
        {
            this.context = context;
        }

        public List<Column> GetColumns()
        {
            var columns =  context.Columns.ToList();
            var todos =  context.Todos.ToList();

            foreach (var t in todos)
            {
                foreach (var c in columns)
                {
                    if (t.ColumnId == c.ColumnId)
                    {
                        c.Todos.Add(t);
                    }
                }
            }

           
            return columns;
        }
        public  Column GetColumnByID(int columnID)
        {
            var column =  context.Columns.Find(columnID);
            var todos =  context.Todos.ToList();

            foreach (var t in todos)
            {
                if (t.ColumnId == column.ColumnId)
                {
                    column.Todos.Add(t);
                }
            }
           

            return column;

        }

         public List<Todo> UpdateTodos(List<Todo> todos)
        {
            var _todos = context.Todos.Where(todo => todos.Contains(todo)).ToList();
            if (_todos != null)
            {
                _todos.ForEach(todo =>
                {
                   var updatedTodo = todos.Where(t => t.TodoId == todo.TodoId).FirstOrDefault();
                    if (updatedTodo != null)
                        todo.Index = updatedTodo.Index;
                   
                });
                context.SaveChanges();
            }
           
            var todo = todos.ElementAt(0);
            var column = GetColumnByID(todo.ColumnId);
            if(column!= null)
                return column.Todos.ToList();

            return null;
        }

    }
}
