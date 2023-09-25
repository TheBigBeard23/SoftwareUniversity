using Library.Contracts;
using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class BookController : BaseController
    {
        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }
        public async Task<IActionResult> All()
        {
            IEnumerable<AllBookViewModel> models = await bookService.GetAllBooksAsync();

            return View(models);
        }
        public async Task<ActionResult> Mine()
        {
            IEnumerable<AllBookViewModel> model = await bookService.GetMyBookAsync(GetUserId());

            return View(model);
        }
        public async Task<IActionResult> AddToCollection(int id)
        {

        }
    }
}

