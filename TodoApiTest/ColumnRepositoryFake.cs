using System;
using System.Collections.Generic;
using TodoApi.DAL;
using TodoApi.Models;

namespace TodoApiUnitTest
{
    class ColumnRepositoryFake : IColumnRepository
    {

        private List<Column> columns = new List<Column>()
        {
            new Column() { ColumnId = 1, ColumnTitle = "Fake1", Todos = null},

            new Column() { ColumnId = 2, ColumnTitle = "Fake2", Todos = new List<Todo>(){
                    new Todo() {TodoId = 1, TodoTitle = "Todo1", ColumnId = 2},
                    new Todo() {TodoId = 2, TodoTitle = "Todo2", ColumnId = 2}}
                },
                new Column() { ColumnId = 3, ColumnTitle = "Fake3", Todos = new List<Todo>(){
                    new Todo() {TodoId = 1, TodoTitle = "Todo1", ColumnId = 2 }}
                },
         };

        public List<Column> GetColumns()
        {
            return columns;
        }

        public Column GetColumnByID(int columnID)
        {
            return columns.Find(c => c.ColumnId == columnID);
        }
                     
    }
}
