namespace TaskBoardApp.Services
{
    using Data;
    using Microsoft.EntityFrameworkCore;
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

        public async Task<TaskDetailsViewModel> GetByIdAsync(string id)
        {
            TaskDetailsViewModel viewModel = await this._dbContext
                .Tasks
                .Select(t => new TaskDetailsViewModel
                {
                    Id = t.Id.ToString(),
                    Title = t.Title,
                    Board = t.Board.Name,
                    Description = t.Description,
                    Owner = t.Owner.UserName,
                    CreatedOn = t.CreatedOn.ToString("f")
                })
                .FirstAsync(t => t.Id == id);

            return viewModel;
        }
    }
}
