using TaskBoardApp.Web.ViewModels.Board;
using TaskBoardApp.Web.ViewModels.Task;

namespace TaskBoardApp.Services.Contracts
{
    public interface IBoardService
    {
        Task<IEnumerable<BoardAllViewModel>> AllAsync();

        Task<IEnumerable<BoardSelectViewModel>> AllForSelectAsync();

        Task<bool> ExistsByIdAsync(int id);
    }
}
