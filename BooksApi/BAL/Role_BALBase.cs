using BooksApi.DAL;
using BooksApi.Model;

namespace BooksApi.BAL
{
    public class Role_BALBase
    {
        Role_DALBase Role_DALBase = new Role_DALBase();
        public List<Role_Model> Getall()
        {
            try
            {
                List<Role_Model> newrole = Role_DALBase.GetAllRoles();
                return newrole;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}