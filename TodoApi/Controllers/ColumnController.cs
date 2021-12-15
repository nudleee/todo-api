using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TodoApi.DAL;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/columns")]
    [ApiController]
    public class ColumnController : ControllerBase
    {
        private readonly IColumnRepository columntRepository;
        public ColumnController(IColumnRepository columnRepository)
        {
            this.columntRepository = columnRepository;
        }


        // GET api/columns
        [HttpGet]
        public ActionResult<List<Column>> GetColumns()
        {
            var res = columntRepository.GetColumns();
            if (res == null)
            {
                return NotFound();
            }

            return res;
        }

        //GET api/columns/{id}
        [HttpGet("{id:int}")]
        public ActionResult<Column> GetColumnById(int id)
        {

            var res =  columntRepository.GetColumnByID(id);

            if (res == null)
            {
                return NotFound();
            }

            return res;
        }

        [HttpPut("todos")]
        public ActionResult<List<Todo>> UpdateTodos( [FromBody]List<Todo> todos)
        {
            var res = columntRepository.UpdateTodos(todos);
            if(res == null)
            {
                return NotFound();
            }

            return res;
                
        }


    }
}
