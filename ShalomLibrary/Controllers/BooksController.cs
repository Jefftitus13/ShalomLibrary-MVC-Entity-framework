using Microsoft.AspNetCore.Mvc;

namespace ShalomLibrary.Controllers
{
    public class BooksController : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
    }
}
