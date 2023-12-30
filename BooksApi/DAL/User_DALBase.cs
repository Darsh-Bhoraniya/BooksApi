using BooksApi.Model;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;

namespace BooksApi.DAL
{
    public class User_DALBase:DAL_Helper
    {
        #region Global object of Db
        SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
        #endregion

        #region Get all users
        public List<User_Model> GetallUser()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_User_SelectAll");
                List<User_Model> Bookmodel = new List<User_Model>();
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (dr.Read())
                    {
                        User_Model User_Model = new User_Model();
                        User_Model.UserID = Convert.ToInt32(dr["UserID"].ToString());
                        User_Model.UserName = dr["UserName"].ToString();
                        User_Model.Email = dr["Email"].ToString();
                        User_Model.Password = (dr["Password"].ToString());
                        User_Model.RoleID = Convert.ToInt32(dr["RoleID"].ToString());
                        User_Model.Created = Convert.ToDateTime(dr["Created"]); ;
                        User_Model.Modified = Convert.ToDateTime(dr["Modified"]); ;
                        Bookmodel.Add(User_Model);
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

        #region Delete
        public bool Delete_User(int UserID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_User_Delete");
                sqlDatabase.AddInParameter(dbCommand, "@UserID", SqlDbType.Int, UserID);
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

        #region Insert/ Register Users
        public bool RegisterNewUser(User_Model User_Model)
        {
            try
            {
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_User_Insert");
                sqlDatabase.AddInParameter(dbCommand, "@UserName", SqlDbType.VarChar, User_Model.UserName);
                sqlDatabase.AddInParameter(dbCommand, "@Email", SqlDbType.VarChar, User_Model.Email);
                sqlDatabase.AddInParameter(dbCommand, "@PhoneNumber", SqlDbType.VarChar, User_Model.PhoneNumber);
                sqlDatabase.AddInParameter(dbCommand, "@Password", SqlDbType.VarChar, User_Model.Password);
                sqlDatabase.AddInParameter(dbCommand, "@RoleID", SqlDbType.Int, User_Model.RoleID);
                sqlDatabase.AddInParameter(dbCommand, "@Created", SqlDbType.DateTime, User_Model.Created);
                sqlDatabase.AddInParameter(dbCommand, "@Modified", SqlDbType.DateTime, User_Model.Modified);

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
        #region Update User 
        public bool Update_User(int UserID, User_Model User_Model)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Book_Master_Update");
                sqlDatabase.AddInParameter(dbCommand, "@UserID", SqlDbType.Int, User_Model.UserID);
                sqlDatabase.AddInParameter(dbCommand, "@UserName", SqlDbType.VarChar, User_Model.UserName);
                sqlDatabase.AddInParameter(dbCommand, "@Email", SqlDbType.VarChar, User_Model.Email);
                sqlDatabase.AddInParameter(dbCommand, "@PhoneNumber", SqlDbType.VarChar, User_Model.PhoneNumber);
                sqlDatabase.AddInParameter(dbCommand, "@Password", SqlDbType.VarChar, User_Model.Password);
                sqlDatabase.AddInParameter(dbCommand, "@PhoneNumber", SqlDbType.VarChar, User_Model.PhoneNumber);
                sqlDatabase.AddInParameter(dbCommand, "@RoleID", SqlDbType.Int, User_Model.RoleID);
                //sqlDatabase.AddInParameter(dbCommand, "@Created", SqlDbType.DateTime, User_Model.Created);
                sqlDatabase.AddInParameter(dbCommand, "@Modified", SqlDbType.DateTime, User_Model.Modified);
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
    }
}
