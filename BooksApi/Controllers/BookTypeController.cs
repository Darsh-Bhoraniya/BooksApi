using BooksApi.BAL;
using BooksApi.Model;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BooksApi.Controllers
{

    [ApiController]
    [Route("api/[Controller]/[Action]")]
    public class BookTypeController : Controller
    {
        BooksType_BALBase booksType_BALBase = new BooksType_BALBase();
        [HttpGet]
        public IActionResult Getall()
        {
            List<BookType_Model> bookType_Models = booksType_BALBase.Getall();
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (bookType_Models.Count > 0 && bookType_Models != null)
            {
                response.Add("Status", true);
                response.Add("Masseage", "Data Get Succesfully ");
                response.Add("Data", bookType_Models);
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


        [HttpGet("{TypeID}")]
        public IActionResult BooksTypesGetbyId(int TypeID)
        {

            BookType_Model bookType_Model = booksType_BALBase.SelectRoleByPK(TypeID);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (bookType_Model.TypeID != 0)
            {
                response.Add("Status", true);
                response.Add("Masseage", "Data Get Succesfully ");
                response.Add("Data", bookType_Model);
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
        public IActionResult Post(BookType_Model bookType_Model)
        {
            bool IsSuccess = booksType_BALBase.InsertNewRole(bookType_Model);
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
        public IActionResult Put(BookType_Model bookType_Model, int TypeID)
        {

            bookType_Model.TypeID = TypeID;
            bool IsSuccess = booksType_BALBase.UpdateRole(TypeID, bookType_Model);
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
        public IActionResult Delete(int TypeID)
        {
            bool IsSuccess = booksType_BALBase.DeleteRole(TypeID);
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
