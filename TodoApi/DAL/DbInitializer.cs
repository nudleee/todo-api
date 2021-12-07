using System.Linq;
using TodoApi.Models;

namespace TodoApi.DAL
{
    public class DbInitializer
    {
        internal static void Initialize(KanbanBoardContext context)
        {
            context.Database.EnsureCreated();

            if (context.Columns.Any())
            {
                return;
            }

            var columns = new Column[]
            {
                new Column { ColumnTitle ="To do" },
                new Column { ColumnTitle = "In progress" },
                new Column { ColumnTitle = "Testing" },
                new Column { ColumnTitle = "Done" }
            };

           
         


            context.Columns.AddRange(columns);
            context.SaveChanges();

        }
    }
}
