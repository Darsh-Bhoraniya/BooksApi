using BooksApi.BAL;
using BooksApi.Model;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace BooksApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[Action]")]
    public class AuthorController : Controller
    {
        Author_BALBase author_BALBase = new Author_BALBase();
        [HttpGet]
        public IActionResult Getall()
        {
            List<Author_Model> author_Models = author_BALBase.Getall();
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (author_Models.Count > 0 && author_Models != null)
            {
                response.Add("Status", true);
                response.Add("Masseage", "Data Get Succesfully ");
                response.Add("Data", author_Models);
                return Ok(response);
            }
            else
            {
                response.Add("Status", false);
                response.Add("Masseage", "Data Not Get Succesfully");
                response.Add("Data", null);
            }
            return NotFound(response);
        }


        [HttpGet("AuthorID")]
        public IActionResult AuthorGetbId(int AuthorID)
        {

            Author_Model author_Model = author_BALBase.SelectAuthorByPK(AuthorID);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (author_Model.AuthorID != 0)
            {
                response.Add("Status", true);
                response.Add("Masseage", "Data Get Succesfully ");
                response.Add("Data", author_Model);
                return Ok(response);
            }
            else
            {
                response.Add("Status", false);
                response.Add("Masseage", "Data Not Get Succesfully");
                response.Add("Data", null);
            }
            return NotFound(response);
        }
        [HttpPost]
        public IActionResult Post(Author_Model author_Model)
        {
            bool IsSuccess = author_BALBase.InsertAuthor(author_Model);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (IsSuccess)
            {
                response.Add("Status", true);
                response.Add("Masseage", "Data Inserted Succesfully ");
                return Ok(response);
            }
            else
            {

                response.Add("status", false);
                response.Add("Message", "Try Again 😊!");
                return NotFound(response);
            }
        }
        [HttpPut]
        public IActionResult Put(Author_Model author_Model ,int AuthorID)
        {

            author_Model.AuthorID = AuthorID;
            bool IsSuccess = author_BALBase.UpdateAuthor(AuthorID, author_Model);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (IsSuccess)
            {
                response.Add("Status", true);
                response.Add("Masseage", "Data Update Succesfully ");
                return Ok(response);
            }
            else
            {

                response.Add("status", false);
                response.Add("Message", "Try Again 😊!");
                return NotFound(response);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int AuthorID)
        {
            bool IsSuccess = author_BALBase.DeleteAuthor(AuthorID);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (IsSuccess)
            {
                response.Add("Status", true);
                response.Add("Masseage", "Data Deleted ");
                return Ok(response);
            }
            else
            {

                response.Add("status", false);
                response.Add("Message", "Data not deletd!");
                return NotFound(response);
            }
        }
    }
}
