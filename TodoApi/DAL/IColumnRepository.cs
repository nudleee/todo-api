using System;
using System.Collections.Generic;
using TodoApi.Models;

namespace TodoApi.DAL
{
    public interface IColumnRepository : IDisposable
    {
        List<Column> GetColumns();
        Column GetColumnByID(int columnID);
    }
}
