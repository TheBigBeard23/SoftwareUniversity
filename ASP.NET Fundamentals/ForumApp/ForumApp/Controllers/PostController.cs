using Microsoft.AspNetCore.Mvc;
using ForumApp.Models.Post;
using Forum.Services.Interfaces;

namespace Forum.App.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService postService;
        public PostController(IPostService postService)
        {
            this.postService = postService;
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var allPosts = await this.postService.ListAllAsync();

            return View(allPosts);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(PostFormModel model)
        {
            await this.postService.AddPostAsync(model);

            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var post = await this.postService.GetByIdAsync(id);

                return View(post);
            }
            catch (Exception)
            {
                return RedirectToAction("All", "Post");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, PostFormModel model)
        {
            await this.postService.EditByIdAsync(id, model);

            return RedirectToAction("All");

        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await this.postService.DeleteByIdAsync(id);
            }
            catch (Exception)
            {
                return RedirectToAction("All", "Post");
            }

            return RedirectToAction("All");
        }


    }
}
