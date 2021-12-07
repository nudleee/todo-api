using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApi.Models
{
    [Table("Todo")]
    public class Todo
    {
        public long TodoId { get; set; }
        public string TodoTitle { get; set; }
        public string? TodoDescription { get; set; }
        public string? DueDate { get; set; }
        public int ColumnId { get; set; }
    }
}
