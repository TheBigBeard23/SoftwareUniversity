using TaskBoardApp.Data;
using TaskBoardApp.Services.Contracts;
using TaskBoardApp.Web.ViewModels.Board;
using TaskBoardApp.Web.ViewModels.Home;

namespace TaskBoardApp.Services
{
    public class HomeService : IHomeService
    {
        private readonly IBoardService _boardService;
        private readonly TaskBoardDbContext _dbContext;
        public HomeService(IBoardService boardService, TaskBoardDbContext dbContext)
        {
            this._boardService = boardService;
            this._dbContext = dbContext;
        }
        public async Task<IEnumerable<HomeBoardViewModel>> GetHomeBoardViewModelAsync()
        {
            IEnumerable<BoardAllViewModel> boards = await _boardService.AllAsync();

            IEnumerable<HomeBoardViewModel> boardsViewModel = boards
                                                               .Select(b => new HomeBoardViewModel
                                                               {
                                                                   BoardName = b.Name,
                                                                   TasksCount = b.Tasks.Count()
                                                               });


            return boardsViewModel;


        }

        public HomeViewModel GetHomeViewModelAsync(int userTaskCount, IEnumerable<HomeBoardViewModel> boards)
        {
            HomeViewModel model = new HomeViewModel()
            {
                AllTasksCount = _dbContext.Tasks.Count(),
                BoardsTasksCount = boards,
                UserTaskCount = userTaskCount
            };

            return model;
        }

        public int GetUserTasksCountAsync(string id)
        {
            int userTaskCount = _dbContext.Tasks.Where(t => t.OwnerId == id).Count();
            return userTaskCount;
        }
    }
}
