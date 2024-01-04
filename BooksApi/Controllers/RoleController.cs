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
            Dictionary<string,dynamic> response = new Dictionary<string,dynamic>();
            if (role_Models.Count >0 && role_Models!=null)
            {
                response.Add("Status",true);
                response.Add("Masseage","Data Get Succesfully ");
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
    }
}
