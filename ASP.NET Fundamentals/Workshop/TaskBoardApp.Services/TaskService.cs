namespace TaskBoardApp.Services
{
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Services.Contracts;
    using TaskBoardApp.Web.ViewModels.Board;
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

        public async Task DeleteTask(string id)
        {
            var task = await this._dbContext
                                        .Tasks
                                        .FirstOrDefaultAsync(t => t.Id.ToString() == id);

            if (task != null)
            {
                _dbContext.Remove(task);
                await _dbContext.SaveChangesAsync();

            }
        }

        public async Task EditTask(string id, string title, string description, int boardId)
        {
            var task = await this._dbContext.Tasks.FindAsync(new Guid(id));

            task.Title = title;
            task.Description = description;
            task.BoardId = boardId;

            await this._dbContext.SaveChangesAsync();
        }

        public async Task<TaskOwnerViewModel> GetTaskById(string id)
        {
            TaskOwnerViewModel task = await _dbContext.Tasks
                .Where(t => t.Id.ToString() == id)
                .Select(t => new TaskOwnerViewModel
                {
                    Owner = t.Owner.UserName,
                    OwnerId = t.Owner.Id
                })
                .FirstAsync();

            return task;
        }

        public async Task<TaskDetailsViewModel> GetTaskDetailsByIdAsync(string id)
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
        public async Task<TaskFormModel> GetTaskEditByIdAsync(string id)
        {
            TaskFormModel viewModel = await this._dbContext
                .Tasks
                .Where(t => t.Id.ToString() == id)
                .Select(t => new TaskFormModel
                {
                    Title = t.Title,
                    Description = t.Description,
                    BoardId = t.BoardId,
                    AllBoards = _dbContext
                                          .Board
                                          .Select(b => new BoardSelectViewModel
                                          {
                                              Id = b.Id,
                                              Name = b.Name
                                          })
                                          .AsEnumerable()

                })
                .FirstAsync();

            return viewModel;
        }
    }
}
