
namespace TaskBoardApp.Services
{

    using Microsoft.EntityFrameworkCore;

    using TaskBoardApp.Data;
    using TaskBoardApp.Services.Contracts;

    using TaskBoardApp.Web.ViewModels.Board;
    using TaskBoardApp.Web.ViewModels.Task;
    public class BoardService : IBoardService
    {
        private readonly TaskBoardDbContext _dbContext;

        public BoardService(TaskBoardDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<IEnumerable<BoardAllViewModel>> AllAsync()
        {
            IEnumerable<BoardAllViewModel> allBoards = await this._dbContext
                .Board
                .Select(b => new BoardAllViewModel()
                {
                    Name = b.Name,
                    Tasks = b.Tasks
                            .Select(t => new TaskViewModel()
                            {
                                Id = t.Id.ToString(),
                                Title = t.Title,
                                Description = t.Description,
                                Owner = t.Owner.UserName
                            })
                            .ToArray()
                })
                .ToArrayAsync();

            return allBoards;
        }
    }
}
