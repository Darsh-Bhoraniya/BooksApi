using BooksApi.DAL;
using BooksApi.Model;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;

namespace BooksApi.BAL
{
    public class AddBook_BALBase:DAL_Helper
    {
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
    }
}
