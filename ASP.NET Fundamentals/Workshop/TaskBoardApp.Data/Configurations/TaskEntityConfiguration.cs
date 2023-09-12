namespace TaskBoardApp.Data.Configurations
{

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Task = TaskBoardApp.Data.Models.Task;
    public class TaskEntityConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder
                .HasOne(t => t.Board)
                .WithMany(b => b.Tasks)
                .HasForeignKey(t => t.BoardId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasData(GenerateTasks());
        }

        private ICollection<Task> GenerateTasks()
        {
            ICollection<Task> tasks = new HashSet<Task>()
            {
                new Task()
                {
                    Title = "Improve CSS styles",
                    Description = "Implement better styling for all public pages",
                    CreatedOn = DateTime.UtcNow.AddDays(-200),
                    OwnerId = "01e0c6e2-6e72-42dd-9e24-e17d308cf4ed",
                    BoardId = 1
                },
                new Task()
                {
                    Title = "Android Client App",
                    Description = "Create Android client app for the TaskBoard RESTful API",
                    CreatedOn = DateTime.UtcNow.AddMonths(-5),
                    OwnerId = "e6ea5cef-68af-4b86-be06-97802e5c4c44",
                    BoardId = 1
                },
                new Task()
                {
                    Title = "Desktop Client App",
                    Description = "Create Desktop client app for the TaskBoard RESTful API",
                    CreatedOn = DateTime.UtcNow.AddMonths(-1),
                    OwnerId = "e6ea5cef-68af-4b86-be06-97802e5c4c44",
                    BoardId = 2
                },
                 new Task()
                {
                    Title = "Create Tasks",
                    Description = "Implement [Create Task] page for adding tasks",
                    CreatedOn = DateTime.UtcNow.AddYears(-1),
                    OwnerId = "01e0c6e2-6e72-42dd-9e24-e17d308cf4ed",
                    BoardId = 3
                }
            };

            return tasks;
        }
    }

}
