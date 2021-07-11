using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ToDoList.Database
{
    public class ToDoListDbContext : DbContext
    {
        public DbSet<WorkTask> WorkTasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlite($"Filename={Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "todolistdb.sqlite")}");
        }
    }
}
