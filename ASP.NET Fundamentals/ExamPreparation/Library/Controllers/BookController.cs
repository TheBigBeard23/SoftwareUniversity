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
        public async Task<IActionResult> Mine()
        {
            IEnumerable<AllBookViewModel> model = await bookService.GetMyBookAsync(GetUserId());

            return View(model);
        }
        public async Task<IActionResult> AddToCollection(int id)
        {
            BookViewModel book = await bookService.GetBookByIdAsync(id);

            if (book == null)
            {
                return RedirectToAction(nameof(All));
            }

            string userId = GetUserId();

            await bookService.AddBookToCollectionAsync(userId, book);

            return RedirectToAction(nameof(All));

        }

        public async Task<IActionResult> RemoveFromCollection(int id)
        {
            var book = await bookService.GetBookByIdAsync(id);

            if (book == null)
            {
                return RedirectToAction(nameof(Mine));
            }

            var userId = GetUserId();

            await bookService.RemoveFromCollectionAsync(userId, book);

            return RedirectToAction(nameof(Mine));
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = await bookService.GetNewAddBookViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBookViewModel model)
        {
            decimal rating;

            if (!decimal.TryParse(model.Rating, out rating) ||
                rating < 0 ||
                rating > 10)
            {
                ModelState.AddModelError(nameof(model.Rating), "Rating must be a number between 0 and 10");

                return View(model);
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await bookService.AddBookAsync(model);

            return RedirectToAction(nameof(All));

        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (await bookService.DeleteBook(id))
            {
                return RedirectToAction(nameof(All));
            }
            else
            {
                return NotFound("The Book does not exist!");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            BookViewModel? book = await bookService.GetBookByIdAsync(id);

            if (book == null)
            {
                return NotFound("The Book does not exist!");
            }

            AddBookViewModel model = await bookService.GetNewAddBookViewModel();
            model.Title = book.Title;
            model.Description = book.Description;
            model.Author = book.Author;
            model.Url = book.ImageUrl;
            model.Rating = book.Rating.ToString();

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, AddBookViewModel model)
        {
            decimal rating;

            if (!decimal.TryParse(model.Rating, out rating) ||
               rating < 0 ||
               rating > 10)
            {
                ModelState.AddModelError(nameof(model.Rating), "Rating must be a number between 0 and 10");

                return View(model);
            }

            if (!ModelState.IsValid)
            {
                return View(id);
            }

            if (!await bookService.EditBook(id, model))
            {
                return View(id);
            }

            return RedirectToAction(nameof(All));

        }

    }
}

