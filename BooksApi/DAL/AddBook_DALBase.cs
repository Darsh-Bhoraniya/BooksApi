using BooksApi.BAL;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using BooksApi.Model;

namespace BooksApi.DAL
{
    public class AddBook_DALBase : DAL_Helper
    {
        #region AddBook
        public List<AddBook_Model> GetallBook()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Book_Master_SelectAll");
                List<AddBook_Model> Bookmodel = new List<AddBook_Model>();
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (dr.Read())
                    {
                        AddBook_Model book_Model = new AddBook_Model();
                        book_Model.BookID = Convert.ToInt32(dr["BookID"].ToString());
                        book_Model.BookName = dr["BookName"].ToString();
                        book_Model.BookTitle = dr["BookTitle"].ToString();
                        book_Model.BookWiseAuthorID = Convert.ToInt32(dr["BooKWiseAuthorID"].ToString());
                        book_Model.TypeID = Convert.ToInt32(dr["TypeID"].ToString());
                        book_Model.Price = Convert.ToDouble(dr["Price"].ToString());
                        book_Model.INSBN = Convert.ToInt32(dr["INSBN"].ToString());
                        book_Model.PublishedDate = Convert.ToDateTime(dr["PublishedDate"]);
                        book_Model.Created = Convert.ToDateTime(dr["Created"]); ;
                        book_Model.Modified = Convert.ToDateTime(dr["Modified"]); ;
                        Bookmodel.Add(book_Model);
                    }
                    return Bookmodel;
                }

            }
            catch (Exception ex)
            {
                return null;
            }

        }
        #endregion

        #region Insert
        public bool PR_Insert_Books(AddBook_Model AddBook_Model)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Book_Master_Insert");
                sqlDatabase.AddInParameter(dbCommand, "@BookName", SqlDbType.VarChar, AddBook_Model.BookName);
                sqlDatabase.AddInParameter(dbCommand, "@BookTitle", SqlDbType.VarChar, AddBook_Model.BookTitle);
                sqlDatabase.AddInParameter(dbCommand, "@Email", SqlDbType.VarChar, AddBook_Model.);
                if (Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand)))
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
