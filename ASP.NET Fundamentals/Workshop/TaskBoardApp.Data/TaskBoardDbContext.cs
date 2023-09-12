namespace TaskBoardApp.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;
    using TaskBoardApp.Data.Models;
    using Task = TaskBoardApp.Data.Models.Task;
    public class TaskBoardDbContext : IdentityDbContext<IdentityUser>
    {
        public TaskBoardDbContext(DbContextOptions<TaskBoardDbContext> options)
            : base(options)
        {

        }

        public DbSet<Task> Tasks { get; set; } = null!;
        public DbSet<Board> Board { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(TaskBoardDbContext)));
        }
    }
}