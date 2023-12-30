using BooksApi.DAL;
using BooksApi.Model;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;

namespace BooksApi.BAL
{
    public class AddBook_BALBase:DAL_Helper
    {
        AddBook_DALBase AddBook_DALBase = new AddBook_DALBase();

        #region select all
        public List<AddBook_Model> GetAllBoooks()
        {
            try
            {
                AddBook_DALBase AddBook_DALBase = new AddBook_DALBase();
                List<AddBook_Model> book_Models = AddBook_DALBase.GetallBook();
                return book_Models;

            }
            catch (Exception ex)
            {
                return null;

            }
        }
        #endregion
        #region insert

        public bool PR_Insert_Books(AddBook_Model addBook_Model)

        {
            try
            {

                if (AddBook_DALBase.PR_Insert_Books(addBook_Model))
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

        public bool PR_Update_Books(int BookID,AddBook_Model addBook_Model)

        {
            try
            {

                if (AddBook_DALBase.PR_Update_Books(BookID,addBook_Model))
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

        public bool PR_Delete_Books(int BookID)

        {
            try
            {

                if (AddBook_DALBase.PR_Delete_Books(BookID))
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

