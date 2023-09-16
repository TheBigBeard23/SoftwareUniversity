namespace TaskBoardApp.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Security.Claims;
    using TaskBoardApp.Extensions;
    using TaskBoardApp.Services.Contracts;
    using TaskBoardApp.Web.ViewModels.Board;
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

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            try
            {
                TaskDetailsViewModel model =
                    await this._taskService.GetTaskDetailsByIdAsync(id);

                return this.View(model);
            }
            catch (Exception)
            {
                return this.RedirectToAction("All", "Board");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            try
            {

                TaskOwnerViewModel task = await _taskService.GetTaskById(id);

                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (userId != task.OwnerId)
                {
                    throw new UnauthorizedAccessException();
                }

                TaskFormModel viewModel = await _taskService.GetTaskEditByIdAsync(id);

                return View(viewModel);

            }
            catch (Exception)
            {
                return this.RedirectToAction("All", "Board");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, TaskFormModel taskModel)
        {
            try
            {
                TaskOwnerViewModel task = await _taskService.GetTaskById(id);

                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (userId != task.OwnerId)
                {
                    throw new UnauthorizedAccessException();
                }

                ICollection<BoardAllViewModel> boards = (ICollection<BoardAllViewModel>)await _boardService.AllAsync();

                if (!boards.Any(b => b.Id == taskModel.BoardId.ToString()))
                {
                    ModelState.AddModelError(nameof(taskModel.BoardId), "Board does not exist.");
                }

                if (!ModelState.IsValid)
                {
                    taskModel.AllBoards = (IEnumerable<BoardSelectViewModel>?)boards;
                    return View(taskModel);
                }

                await _taskService.EditTask(id, taskModel.Title, taskModel.Description, taskModel.BoardId);
                return RedirectToAction("All", "Board");

            }
            catch (Exception)
            {
                return this.RedirectToAction("Edit", "Task", id);
            }
        }

    }
}
