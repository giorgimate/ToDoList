using Microsoft.EntityFrameworkCore;
using ToDoList_Backend.Models;

namespace ToDoList_Backend.Context
{
    public class ToDoListDbContext : DbContext
    {
        public ToDoListDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<TaskModel> Tasks { get; set; }

    }
}
