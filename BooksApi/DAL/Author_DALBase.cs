using BooksApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql.Configuration;
using System.Data;
using System.Data.Common;

namespace BooksApi.DAL
{
    public class Author_DALBase : DAL_Helper
    {
        SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
        public List<Author_Model> Getall()
            {
            DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_MST_Author_SelectAll");
            List<Author_Model> Author_Model = new List<Author_Model>();
            try
            {
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (dr.Read())
                    {
                        Author_Model author_Model = new Author_Model();
                        author_Model.AuthorID = Convert.ToInt32(dr["AuthorID"]);
                        author_Model.AuthorName = dr["AuthorName"].ToString();
                        author_Model.AuthorEmail = dr["AuthorEmail"].ToString();
                        author_Model.ContactNo = dr["ContactNo"].ToString();
                        author_Model.Created = Convert.ToDateTime(dr["Created"]);
                        author_Model.Modified = Convert.ToDateTime(dr["Modified"]);
                        Author_Model.Add(author_Model);
                      }
                }
                return Author_Model;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public Author_Model SelectAuthorByPk(int AuthorID)
        {
            try
            {
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_MST_Author_SelectByPK");
                sqlDatabase.AddInParameter(dbCommand, "@AuthorID", SqlDbType.Int, AuthorID);
                Author_Model author_Model= new Author_Model();
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (dr.Read())
                    {
                        author_Model.AuthorID = Convert.ToInt32(dr["AuthorID"]);
                        author_Model.AuthorName = dr["AuthorName"].ToString();
                        author_Model.AuthorEmail = dr["AuthorEmail"].ToString();
                        author_Model.ContactNo = dr["ContactNo"].ToString();
                        //author_Model.Created = Convert.ToDateTime(dr["Created"]);
                        author_Model.Modified = Convert.ToDateTime(dr["Modified"]);
                    }
                }
                return author_Model ;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool InsertAuthor(Author_Model author_Model)
        {
            try
            {
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_MST_Author_Insert");
                sqlDatabase.AddInParameter(dbCommand, "@AuthorName", SqlDbType.VarChar, author_Model.AuthorName);
                sqlDatabase.AddInParameter(dbCommand, "@AuthorEmail", SqlDbType.VarChar, author_Model.AuthorEmail);
                sqlDatabase.AddInParameter(dbCommand, "@ContactNo", SqlDbType.VarChar, author_Model.ContactNo);
                //sqlDatabase.AddInParameter(dbCommand, "@Created", SqlDbType.DateTime, author_Model.Created);
                //sqlDatabase.AddInParameter(dbCommand, "@Modified", SqlDbType.DateTime, author_Model.Modified);
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
        public bool UpdateAuthor(Author_Model author_Model)
        {
            try
            {
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_MST_Author_Update");
                sqlDatabase.AddInParameter(dbCommand, "@AuthorID", SqlDbType.Int, author_Model.AuthorID);
                sqlDatabase.AddInParameter(dbCommand, "@AuthorName", SqlDbType.VarChar, author_Model.AuthorName);
                sqlDatabase.AddInParameter(dbCommand, "@AuthorEmail", SqlDbType.VarChar, author_Model.AuthorEmail);
                //sqlDatabase.AddInParameter(dbCommand, "@ContactNo", SqlDbType.VarChar, author_Model.ContactNo);
                //sqlDatabase.AddInParameter(dbCommand, "@Modified", SqlDbType.DateTime, author_Model.Modified);
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

        public bool DeleteAuthor(int AuthorID)
        {
            try
            {
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_MST_Author_Delete");
                sqlDatabase.AddInParameter(dbCommand, "@AuthorID", SqlDbType.Int, AuthorID);
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
