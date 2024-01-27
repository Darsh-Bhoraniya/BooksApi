using BooksApi.Model;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace BooksApi.DAL
{
    public class Login_DAL : DAL_Helper {
        SqlDatabase sqlDatabase = new SqlDatabase(ConnString);

        public int login(string UserName, string Password)
        {
            try
            {
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Login");

                sqlDatabase.AddInParameter(dbCommand, "@UserName", SqlDbType.VarChar, UserName);
                sqlDatabase.AddInParameter(dbCommand, "@Password", SqlDbType.VarChar, Password);
                int UserID=-1;
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (dr.Read())
                    {
                        UserID = Convert.ToInt32(dr["UserID"]);
                    }
                    return UserID;
                }

            }
            catch (Exception ex)
            {
                return -1;
            }

        }
    }
}
