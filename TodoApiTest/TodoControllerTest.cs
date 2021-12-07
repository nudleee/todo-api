using TodoApi.Controllers;
using TodoApi.DAL;
using TodoApi.Models;
using Xunit;

namespace TodoApiUnitTest
{
    public class TodoControllerTest
    {
        TodoController _controller;
        ITodoRepository _todoRepository;

        public TodoControllerTest()
        {
            _todoRepository = new TodoRepositoryFake();
            _controller = new TodoController(_todoRepository);
        }
        [Fact]
        public void Get_ExistingTodo_Passed()
        {
            var Id = 1;
            var result = _todoRepository.GetTodoByID(Id);

            Assert.NotNull(result);
        }

        [Fact]
        public void Get_NotExistingTodo_Failed()
        {
            var Id = 10000;
            var result = _todoRepository.GetTodoByID(Id);

            Assert.Null(result);
        }

        [Fact] 
        public void Put_EditTodoTitle_ReturnsEditedTodo()
        {
            var newTodo = new Todo() { TodoId = 1, TodoTitle = "Updated1", ColumnId = 1 };
            var result = _todoRepository.EditTodo(newTodo);

            Assert.Equal(newTodo.TodoTitle, result.TodoTitle);
        }

        [Fact]
        public void Put_EditTodoColumnId_ReturnsEditedTodo()
        {
            var newTodo = new Todo() { TodoId = 1, TodoTitle = "Updated1", ColumnId = 3 };
            var result = _todoRepository.EditTodo(newTodo);

            Assert.Equal(newTodo.ColumnId, result.ColumnId);
        }

        [Fact]
        public void Delete_DeleteTodo_ReturnsDeletedTodo()
        {
            var Id = 2;
            var result = _todoRepository.RemoveTodo(Id);
            var afterDelete = _todoRepository.GetTodos();

            Assert.Equal(Id, result.TodoId);
            Assert.NotEqual( 4, afterDelete.Count);
            var diff = 4 - afterDelete.Count;
            Assert.Equal(1, diff);
        }



    }
}
