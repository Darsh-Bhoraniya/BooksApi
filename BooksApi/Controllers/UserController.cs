using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
