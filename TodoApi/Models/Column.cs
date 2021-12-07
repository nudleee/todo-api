using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TodoApi.Models
{
    [Table("Column")]
    public class Column
    {
        [Key]
        public int ColumnId { get; set; }
        public string ColumnTitle { get; set; }
        public ICollection<Todo> Todos { get; set; }
    }
}
