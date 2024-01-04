using BooksApi.DAL;
using BooksApi.Model;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;

namespace BooksApi.BAL
{
    public class Book_BALBase
    {
        Book_DALBase AddBook_DALBase = new Book_DALBase();

        #region select all
        public List<Book_Model> GetAllBoooks()
        {
            try
            {
                Book_DALBase AddBook_DALBase = new Book_DALBase();
                List<Book_Model> book_Models = AddBook_DALBase.GetallBook();
                return book_Models;

            }
            catch (Exception ex)
            {
                return null;

            }
        }
        #endregion

        #region selectbypk
        public Book_Model Books_SelectByPK(int BookID)
        {
            try
            {
                Book_DALBase AddBook_DALBase = new Book_DALBase();
                Book_Model AddBook_Model = AddBook_DALBase.Book_SelectByPK(BookID);
                return AddBook_Model;

            }
            catch (Exception ex)
            {
                return null;

            }
        }
        #endregion

        #region insert

        public bool PR_Insert_Books(Book_Model addBook_Model)

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

        #region Update

        public bool PR_Update_Books(int BookID,Book_Model addBook_Model)

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

        #region Delete

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

