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
        public Role_Model SelectRoleByPK(int RoleID)
        {
            try
            {
                Role_Model role_Model = Role_DALBase.SelectRoleByPk(RoleID);
                return role_Model;

            }
            catch (Exception ex)
            {
                return null;

            }
        }
        public bool InsertNewRole(Role_Model role_Model)
        {
            try
            {
                if (Role_DALBase.InsertNewRole(role_Model))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateRole(int RoleID, Role_Model role_Model)
        {
            try
            {
                if (Role_DALBase.UpdateRole(RoleID, role_Model))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }catch(Exception ex)
            {
                return false;
            }
        }

        public bool DeleteRole(int RoleID)
        {
            try
            {
                if (Role_DALBase.DeleteRole(RoleID))
                {
                    return true;   
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}