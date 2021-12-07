using System.Collections.Generic;
using TodoApi.Controllers;
using TodoApi.DAL;
using TodoApi.Models;
using Xunit;

namespace TodoApiUnitTest
{
    public class ColumnControllerTest
    {
        ColumnController _controller;
        IColumnRepository _columnRepository;
        
        public ColumnControllerTest()
        {           
            _columnRepository = new ColumnRepositoryFake();
            _controller = new ColumnController(_columnRepository);      
        }

        [Fact]
        public void Get_WhenCalled_GetAll()
        {
            var result = _controller.GetColumns();

            var columns =  Assert.IsType<List<Column>>(result.Value);
            Assert.Equal(3, columns.Count);
        }


        [Fact]
        public void Get_WhenCalled_GetColumnById()
        {
            var Id = 2;
            var result = _controller.GetColumnById(Id);

            Assert.Equal(Id, result.Value.ColumnId);
        }
    }
}
