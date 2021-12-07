using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.DAL
{
    public class KanbanBoardContext:DbContext
    {
        public KanbanBoardContext(DbContextOptions<KanbanBoardContext> options)
            : base(options) { }

        public DbSet<Column> Columns { get; set; }
        public DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Column>().ToTable("Column");  
            modelBuilder.Entity<Todo>().ToTable("Todo");  
        }
    }
}
