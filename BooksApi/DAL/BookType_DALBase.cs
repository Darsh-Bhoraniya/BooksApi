using BooksApi.Model;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;   
using System.Data;
using System;

namespace BooksApi.DAL
{
    public class BookType_DALBase: DAL_Helper
    {
        SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
        public List<BookType_Model> Getall()
        {
            DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_BooksType_SelectAll");
            List<BookType_Model> BookType_Model = new List<BookType_Model>();
            try
            {
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (dr.Read())
                    {
                        BookType_Model bookType_Model = new BookType_Model();
                        bookType_Model.TypeID = Convert.ToInt32(dr["TypeID"]);
                        bookType_Model.TypeName = dr["TypeName"].ToString();
                        bookType_Model.Created = Convert.ToDateTime(dr["Created"]);
                        bookType_Model.modified = Convert.ToDateTime(dr["Modified"]);
                        BookType_Model.Add(bookType_Model);
                    }
                }
                return BookType_Model;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public BookType_Model SelectTypeByPk(int TypeID)
        {
            try
            {
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_BooksType_SelectByPK");
                sqlDatabase.AddInParameter(dbCommand, "@TypeID", SqlDbType.Int, TypeID);
                BookType_Model bookType_Model = new BookType_Model();
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (dr.Read())
                    {
                        bookType_Model.TypeID = Convert.ToInt32(dr["TypeID"]);
                        bookType_Model.TypeName = dr["TypeName"].ToString();
                        bookType_Model.Created = Convert.ToDateTime(dr["Created"]);
                        bookType_Model.modified = Convert.ToDateTime(dr["Modified"]);
                    }
                }
                return bookType_Model;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool InsertBookType(BookType_Model bookType_Model)
        {
            try
            {
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_BooksType_Insert");
                sqlDatabase.AddInParameter(dbCommand, "@TypeName", SqlDbType.VarChar, bookType_Model.TypeName);
                sqlDatabase.AddInParameter(dbCommand, "@Created", SqlDbType.DateTime, bookType_Model.Created);
                sqlDatabase.AddInParameter(dbCommand, "@modified", SqlDbType.DateTime, bookType_Model.modified);
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
        public bool UpdateBookType(int TypeID, BookType_Model bookType_Model)
        {
            try
            {
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_MST_Author_Update");
                sqlDatabase.AddInParameter(dbCommand, "@TypeID", SqlDbType.Int, bookType_Model.TypeID);
                sqlDatabase.AddInParameter(dbCommand, "@TypeName", SqlDbType.VarChar, bookType_Model.TypeName);
                sqlDatabase.AddInParameter(dbCommand, "@Created", SqlDbType.DateTime, bookType_Model.Created);
                sqlDatabase.AddInParameter(dbCommand, "@modified", SqlDbType.DateTime, bookType_Model.modified);
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

        public bool DeleteBookType(int TypeID)
        {
            try
            {
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_MST_Author_Delete");
                sqlDatabase.AddInParameter(dbCommand, "@TypeID", SqlDbType.Int, TypeID);
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
