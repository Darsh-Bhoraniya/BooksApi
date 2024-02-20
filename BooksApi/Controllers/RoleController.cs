using BooksApi.BAL;
using BooksApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Controllers
{

    [ApiController]
    [Route("api/[Controller]/[Action]")]
    public class RoleController : Controller
    {
        #region Global Object BalBase
        Role_BALBase Role_BALBase = new Role_BALBase();
        #endregion
        #region Select All
        [HttpGet]
        public IActionResult Getall()
        {
            List<Role_Model> role_Models = Role_BALBase.Getall();
            //Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (role_Models.Count > 0 && role_Models != null)
            {
                //response.Add("Status", true);
                //response.Add("Masseage", "Data Get Succesfully ");
                //response.Add("Data", role_Models);
                return Ok(role_Models);
            }
            return NotFound(role_Models);
        }
        #endregion
        #region Select By Pk
        [HttpGet("{RoleID}")]
        public IActionResult SelectByPK(int RoleID)
        {
            Role_Model role_Models = Role_BALBase.SelectRoleByPK(RoleID);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (role_Models.RoleID != 0)
            {
                response.Add("Status", true);
                response.Add("Masseage", "Data Get Succesfully ");
                response.Add("Data", role_Models);
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
        #endregion
        #region Insert
        [HttpPost]
        public IActionResult Post(Role_Model role_Model)
        {
            bool IsSuccess = Role_BALBase.InsertNewRole(role_Model);
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
        #endregion
        #region Update
        [HttpPut]
        public IActionResult Put(int RoleID, Role_Model role_Model)
        {
            role_Model.RoleID = RoleID;
            bool IsSuccess = Role_BALBase.UpdateRole(RoleID, role_Model);
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
        #endregion
        #region Delete
        [HttpDelete]
        public IActionResult Delete(int RoleID)
        {
            bool IsSuccess = Role_BALBase.DeleteRole(RoleID);
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
        #endregion
    }
}
