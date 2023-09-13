namespace TaskBoardApp.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using TaskBoardApp.Extensions;
    using TaskBoardApp.Services.Contracts;
    using TaskBoardApp.Web.ViewModels.Task;

    [Authorize]
    public class TaskController : Controller
    {
        private readonly IBoardService _boardService;
        private readonly ITaskService _taskService;

        public TaskController(IBoardService boardService, ITaskService taskService)
        {
            this._boardService = boardService;
            this._taskService = taskService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            TaskFormModel viewModel = new TaskFormModel()
            {
                AllBoards = await this._boardService.AllForSelectAsync()
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskFormModel model)
        {
            model.AllBoards = await this._boardService.AllForSelectAsync();

            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            bool boardExists = await this._boardService.ExistsByIdAsync(model.BoardId);

            if (!boardExists)
            {
                ModelState.AddModelError(nameof(model.BoardId), "Selected board does not exist!");
                return View(model);
            }

            string currentUserId = this.User.GetId();

            await this._taskService.AddAsync(currentUserId, model);

            return this.RedirectToAction("All", "Board");
        }
    }
}
