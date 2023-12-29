using BooksApi.BAL;
using BooksApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AddBooksController : Controller
    {

        #region Getall
        [HttpGet]
        public IActionResult Getall()
        {
            AddBook_BALBase AddBook_BALBas= new AddBook_BALBase();
            List<AddBook_Model> book_Models = AddBook_BALBas.GetAllBoooks();
            Dictionary<string, dynamic> respon = new Dictionary<string, dynamic>();
            if (book_Models.Count > 0 && book_Models != null)
            {
                respon.Add("status", true);
                respon.Add("Message", "Data found");
                respon.Add("data", book_Models);
                return Ok(respon);
            }
            else
            {
                respon.Add("status", false);
                respon.Add("Message", "Data not found");
                respon.Add("data", null);
            }
            return NotFound(respon);
        }
        #endregion
    }
}
