using BooksApi.BAL;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using BooksApi.Model;
using System.Net;

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

        #region selectbypk
        public AddBook_Model Book_SelectByPK(int BookID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Book_Master_SelectByPK");
                sqlDatabase.AddInParameter(dbCommand, "@BookID", SqlDbType.Int, BookID);
                AddBook_Model AddBook_Model = new AddBook_Model();
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (dr.Read())
                    {
                        AddBook_Model.BookID = Convert.ToInt32(dr["BookID"].ToString());
                        AddBook_Model.BookName = dr["BookName"].ToString();
                        AddBook_Model.BookTitle = dr["BookTitle"].ToString();
                        AddBook_Model.BookWiseAuthorID = Convert.ToInt32(dr["BooKWiseAuthorID"].ToString());
                        AddBook_Model.TypeID = Convert.ToInt32(dr["TypeID"].ToString());
                        AddBook_Model.Price = Convert.ToDouble(dr["Price"].ToString());
                        AddBook_Model.INSBN = Convert.ToInt32(dr["INSBN"].ToString());
                        AddBook_Model.PublishedDate = Convert.ToDateTime(dr["PublishedDate"]);
                        AddBook_Model.Created = Convert.ToDateTime(dr["Created"]);
                        AddBook_Model.Modified = Convert.ToDateTime(dr["Modified"]);
                    }
                }
                return AddBook_Model;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        #endregion
        #region Delete
        public bool PR_Delete_Books(int BookID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Book_Master_DeleteByPK");
                sqlDatabase.AddInParameter(dbCommand, "@BookID", SqlDbType.Int, BookID);
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
                sqlDatabase.AddInParameter(dbCommand, "@BooKWiseAuthorID", SqlDbType.Int, AddBook_Model.BookWiseAuthorID);
                sqlDatabase.AddInParameter(dbCommand, "@TypeID", SqlDbType.VarChar, AddBook_Model.TypeID);
                sqlDatabase.AddInParameter(dbCommand, "@Price", SqlDbType.Decimal, AddBook_Model.Price);
                sqlDatabase.AddInParameter(dbCommand, "@INSBN", SqlDbType.Int, AddBook_Model.INSBN);
                sqlDatabase.AddInParameter(dbCommand, "@PublishedDate", SqlDbType.DateTime, AddBook_Model.PublishedDate);
                sqlDatabase.AddInParameter(dbCommand, "@Created", SqlDbType.DateTime, AddBook_Model.Created);
                sqlDatabase.AddInParameter(dbCommand, "@Modified", SqlDbType.DateTime, AddBook_Model.Modified);

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
        #endregion
        public bool PR_Update_Books(int BookID, AddBook_Model AddBook_Model)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Book_Master_Update");
                sqlDatabase.AddInParameter(dbCommand, "@BookID", SqlDbType.Int, AddBook_Model.BookID);
                sqlDatabase.AddInParameter(dbCommand, "@BookName", SqlDbType.VarChar, AddBook_Model.BookName);
                sqlDatabase.AddInParameter(dbCommand, "@BookTitle", SqlDbType.VarChar, AddBook_Model.BookTitle);
                sqlDatabase.AddInParameter(dbCommand, "@BooKWiseAuthorID", SqlDbType.Int, AddBook_Model.BookWiseAuthorID);
                sqlDatabase.AddInParameter(dbCommand, "@TypeID", SqlDbType.VarChar, AddBook_Model.TypeID);
                sqlDatabase.AddInParameter(dbCommand, "@Price", SqlDbType.Decimal, AddBook_Model.Price);
                sqlDatabase.AddInParameter(dbCommand, "@INSBN", SqlDbType.Int, AddBook_Model.INSBN);
                sqlDatabase.AddInParameter(dbCommand, "@PublishedDate", SqlDbType.DateTime, AddBook_Model.PublishedDate);
                // Update time we donot to add a parameter created
                //sqlDatabase.AddInParameter(dbCommand, "@Created", SqlDbType.DateTime, AddBook_Model.Created);
                sqlDatabase.AddInParameter(dbCommand, "@Modified", SqlDbType.DateTime, AddBook_Model.Modified);
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
}