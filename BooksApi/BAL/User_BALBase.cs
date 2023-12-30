using BooksApi.DAL;
using BooksApi.Model;

namespace BooksApi.BAL
{
    public class User_BALBase: DAL_Helper
    {
        User_DALBase User_DALBase = new User_DALBase();

        #region select all
        public List<User_Model> GetAllUser()
        {
            try
            {
                List<User_Model> user_Models = User_DALBase.GetallUser();
                return user_Models;

            }
            catch (Exception ex)
            {
                return null;

            }
        }
        #endregion
        #region insert

        public bool RegisterNewUser(User_Model User_Model)

        {
            try
            {

                if (User_DALBase.RegisterNewUser(User_Model))
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

        #endregion
        #region insert

        public bool Update_User(int BookID, User_Model User_Model)

        {
            try
            {

                if (User_DALBase.Update_User(BookID, User_Model))
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

        #endregion

        #region insert

        public bool Delete_User(int BookID)

        {
            try
            {

                if (User_DALBase.Delete_User(BookID))
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

        #endregion
    }
}
