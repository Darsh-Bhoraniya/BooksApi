﻿using BooksApi.BAL;
using BooksApi.DAL;
using BooksApi.Model;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace BooksApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[Action]")]
    public class UserController : Controller
    {
        #region Globalobject Of BAL
        User_BALBase User_BALBase = new User_BALBase();
        #endregion

        #region Getall
        [HttpGet]
        public IActionResult Getall()
        {

            List<User_Model> User_Model = User_BALBase.GetAllUser();
            Dictionary<string, dynamic> respon = new Dictionary<string, dynamic>();
            if (User_Model.Count > 0 && User_Model != null)
            {
     /*           respon.Add("status", true);
                respon.Add("Message", "Users found");
                respon.Add("data", User_Model);*/
                return Ok(User_Model);
            }
            else
            {
                respon.Add("status", false);
                respon.Add("Message", "Users not found");
                respon.Add("data", null);
            }
            return NotFound(respon);
        }
        #endregion

        #region Getbyid

        [HttpGet("{UserID}")]
        public IActionResult GetById(int UserID)
        {
            User_Model User_Model = User_BALBase.User_SelectByPK(UserID);
            Dictionary<string, dynamic> respon = new Dictionary<string, dynamic>();
            if (User_Model.UserID != 0)
            {
              /*  respon.Add("status", true);
                respon.Add("Message", "Data found");
                respon.Add("data", User_Model);*/
                return Ok(User_Model);
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

        #region Delete
        [HttpDelete]
        public IActionResult Delete(int UserID)
        {
            bool IsSuccess = User_BALBase.Delete_User(UserID);
            Dictionary<string, dynamic> respon = new Dictionary<string, dynamic>();
            if (IsSuccess)
            {
                respon.Add("status", true);
                respon.Add("Message", "User Deleted Succesfuly");
                return Ok(respon);
            }
            else
            {
                respon.Add("status", false);
                respon.Add("Message", "User not Deleted");
                return NotFound(respon);
            }
        }
        #endregion


        #region Insert
        [HttpPost]
        public IActionResult Post([FromBody] User_Model User_Model)
        {
            bool IsSuccess = User_BALBase.RegisterNewUser(User_Model);
            Dictionary<string, dynamic> respon = new Dictionary<string, dynamic>();
            if (IsSuccess)
            {
                respon.Add("status", true);
                respon.Add("Message", "Register Succesfuly");
                return Ok(respon);
            }
            else
            {
                respon.Add("status", false);
                respon.Add("Message", "Try Again 😊!");
                return NotFound(respon);
            }
        }
        #endregion
        #region Update
        [HttpPut]
        public IActionResult Update([FromBody] User_Model User_Model)
        {
            //User_Model.UserID = UserID;
            bool IsSuccess = User_BALBase.Update_User(User_Model);
            Dictionary<string, dynamic> respon = new Dictionary<string, dynamic>();
            if (IsSuccess)
            {
                respon.Add("status", true);
                respon.Add("Message", "Updated Succesfuly");
                return Ok(respon);
            }
            else
            {
                respon.Add("status", false);
                respon.Add("Message", "Data Not Updated");
                return NotFound(respon);
            }
        }
        #endregion
        [HttpPost]
        public IActionResult Login([FromBody] Login_Model login_Model)
        {
            Login_BAL login_BAL = new Login_BAL();

            return Ok(login_BAL.login(login_Model.UserName,login_Model.Password));
        }
    }
}
