using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using TodoApi.DAL;
using TodoApi.Models;

namespace TodoApi.Controllers
{

    [Route("api/todos")]
    [ApiController]
    public class TodoController : ControllerBase
    {

        private readonly ITodoRepository todoRepository;

        public TodoController(ITodoRepository todoRepository)
        {
            this.todoRepository = todoRepository;
        }

        // GET api/todos
        [HttpGet] 
        public ActionResult<List<Todo>> GetAll()
        {
            var res = todoRepository.GetTodos();
            return res;
        }
        
        // GET api/todos/{id}
        [HttpGet("{id:long}")]
        public ActionResult<Todo> GetTodoById(long id)
        {
            var res = todoRepository.GetTodoByID(id);
            return res;
        }

        // POST api/todos
        [HttpPost]
        public ActionResult<Todo> Insert(Todo todo)
        {
            var res = todoRepository.AddTodo(todo);
            return res;

        }

        // PUT api/todos
        [HttpPut]
        public ActionResult<Todo> Update(Todo todo)
        {
            var res = todoRepository.EditTodo(todo);
            if(res == null)
            {
                return NotFound();
            }

            return res;
        }

        // DELETE api/todos/{id}
        [HttpDelete("{id:long}")]
        public ActionResult<Todo> Delete(long id)
        {
            var res = todoRepository.RemoveTodo(id);
            if(res == null)
            {
                return NotFound();
            }

            return res;
        }

    }
}
