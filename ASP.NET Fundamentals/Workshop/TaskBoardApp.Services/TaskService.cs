namespace TaskBoardApp.Services
{
    using Data;
    using Services.Contracts;
    using Web.ViewModels.Task;
    public class TaskService : ITaskService
    {
        private readonly TaskBoardDbContext _dbContext;

        public TaskService(TaskBoardDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task AddAsync(string ownerId, TaskFormModel viewModel)
        {
            Data.Models.Task task = new Data.Models.Task()
            {
                Title = viewModel.Title,
                Description = viewModel.Description,
                BoardId = viewModel.BoardId,
                CreatedOn = DateTime.UtcNow,
                OwnerId = ownerId
            };

            await this._dbContext.Tasks.AddAsync(task);
            await this._dbContext.SaveChangesAsync();
        }
    }
}
