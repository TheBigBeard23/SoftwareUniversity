using TaskBoardApp.Web.ViewModels.Home;

namespace TaskBoardApp.Services.Contracts
{
    public interface IHomeService
    {
        Task<IEnumerable<HomeBoardViewModel>> GetHomeBoardViewModelAsync();

        int GetUserTasksCountAsync(string id);

        HomeViewModel GetHomeViewModelAsync(int userTaskCount, IEnumerable<HomeBoardViewModel> boardsViewModel);
    }
}
