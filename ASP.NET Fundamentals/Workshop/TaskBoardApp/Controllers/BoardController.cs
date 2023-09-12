
namespace TaskBoardApp.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TaskBoardApp.Services.Contracts;
    using TaskBoardApp.Web.ViewModels.Board;

    [Authorize]
    public class BoardController : Controller
    {
        private readonly IBoardService _boardService;

        public BoardController(IBoardService boardService)
        {
            this._boardService = boardService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            IEnumerable<BoardAllViewModel> allBoards =
                await this._boardService.AllAsync(); 

            return View(allBoards);
        }
    }
}
