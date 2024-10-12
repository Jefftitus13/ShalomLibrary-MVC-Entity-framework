using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShalomLibrary.Data;
using ShalomLibrary.Models;
using ShalomLibrary.Models.Domain;

namespace ShalomLibrary.Controllers
{
    public class BooksController : Controller
    {
        private readonly ShalomLibraryDbContext shalomLibraryDbContext;

        public BooksController(ShalomLibraryDbContext shalomLibraryDbContext)
        {
            this.shalomLibraryDbContext = shalomLibraryDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var Books = await shalomLibraryDbContext.Books.ToListAsync();
            return View(Books);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddBooksViewModel addBookRequest)
        {
            var books = new Books()
            {
                Id = Guid.NewGuid(),
                BookTitle = addBookRequest.BookTitle,
                Author = addBookRequest.Author,
                Genre = addBookRequest.Genre,
                Description = addBookRequest.Description,
                YearPublished = addBookRequest.YearPublished,
                CopiesAvailable = addBookRequest.CopiesAvailable,
                Price = addBookRequest.Price,
            };
            
            await shalomLibraryDbContext.Books.AddAsync(books);
            await shalomLibraryDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var books = await shalomLibraryDbContext.Books.FirstOrDefaultAsync(a => a.Id == id);

            if (books == null)
            {
                var viewModel = new UpdateBookViewModel()
                {
                    Id = books.Id,
                    BookTitle = books.BookTitle,
                    Author = books.Author,
                    Genre = books.Genre,
                    Description = books.Description,
                    YearPublished = books.YearPublished,
                    CopiesAvailable = books.CopiesAvailable,
                    Price = books.Price,
                };
                return View(viewModel);
            }

            return RedirectToAction("Index");
        }
    }
}
