namespace TaskBoardApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration.UserSecrets;
    using System.Security.Claims;
    using TaskBoardApp.Services.Contracts;
    using TaskBoardApp.Web.ViewModels.Home;

    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;

        public HomeController(IHomeService homeService)
        {
            this._homeService = homeService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<HomeBoardViewModel> boardViewModels = await _homeService.GetHomeBoardViewModelAsync();

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            int userTaskCount = _homeService.GetUserTasksCountAsync(userId);

            HomeViewModel model = _homeService.GetHomeViewModelAsync(userTaskCount, boardViewModels);

            return View(model);
        }
    }
}