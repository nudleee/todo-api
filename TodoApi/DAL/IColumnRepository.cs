using System.Collections.Generic;
using TodoApi.Models;

namespace TodoApi.DAL
{
    public interface IColumnRepository
    {
        List<Column> GetColumns();
        Column GetColumnByID(int columnID);
    }
}
