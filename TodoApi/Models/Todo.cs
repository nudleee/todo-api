using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApi.Models
{
    [Table("Todo")]
    public class Todo
    {
        public long TodoId { get; set; }
        public string TodoTitle { get; set; }
#nullable enable
        public string? TodoDescription { get; set; }
        public string? DueDate { get; set; }
#nullable disable
        public int Index { get; set; }
        public int ColumnId { get; set; }
    }
}
