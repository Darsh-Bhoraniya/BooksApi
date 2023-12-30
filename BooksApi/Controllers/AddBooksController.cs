using BooksApi.BAL;
using BooksApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AddBooksController : Controller
    {
        #region Globalobject Of BAL
        AddBook_BALBase AddBook_BALBas = new AddBook_BALBase();
        #endregion

        #region Getall
        [HttpGet]
        public IActionResult Getall()
        {

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


        #region Insert
        [HttpPost]
        public IActionResult Post([FormForm] AddBook_Model addBook_Model)
        {
            bool IsSuccess = AddBook_BALBas.PR_Insert_Books(addBook_Model);
            Dictionary<string, dynamic> respon = new Dictionary<string, dynamic>();
            if (IsSuccess)
            {
                respon.Add("status", true);
                respon.Add("Message", "Data inserted Succesfuly");
                return Ok(respon);
            }
            else
            {
                respon.Add("status", false);
                respon.Add("Message", "Data not inserted");
                return NotFound(respon);
            }
        }
        #endregion
        #region Update
        [HttpPut]
        public IActionResult Update(int BookID,[FormForm] AddBook_Model addBook_Model)
        {
            addBook_Model.BookID=BookID;
            bool IsSuccess = AddBook_BALBas.PR_Update_Books(BookID, addBook_Model);
            Dictionary<string, dynamic> respon = new Dictionary<string, dynamic>();
            if (IsSuccess)
            {
                respon.Add("status", true);
                respon.Add("Message", "Data Updated Succesfuly");
                return Ok(respon);
            }
            else
            {
                respon.Add("status", false);
                respon.Add("Message", "Data not Updated");
                return NotFound(respon);
            }
        }
        #endregion
    }
}
