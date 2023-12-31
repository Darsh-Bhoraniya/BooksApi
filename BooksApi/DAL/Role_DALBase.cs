﻿using BooksApi.Model;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.VisualBasic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace BooksApi.DAL
{
    public class Role_DALBase : DAL_Helper
    {
        SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
        public List<Role_Model> GetAllRoles()
        {
            // Getall Roles From the Database
            DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Role_SelectAll");
            List<Role_Model> role_Models = new List<Role_Model>();
            try
            {
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (dr.Read())
                    {
                        Role_Model role = new Role_Model();
                        role.RoleID = Convert.ToInt32(@dr["RoleID"]);
                        role.RoleName = dr["RoleName"].ToString();
                        role_Models.Add(role);
                    }
                    return role_Models;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Role_Model SelectRoleByPk(int RoleID)
        {
            try
            {
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Role_SelectByPK");
                sqlDatabase.AddInParameter(dbCommand, "@RoleID", SqlDbType.Int, RoleID);
                Role_Model role_Model = new Role_Model();
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (dr.Read())
                    {
                        role_Model.RoleID = Convert.ToInt32(@dr["RoleID"]);
                        role_Model.RoleName = Convert.ToString(@dr["RoleName"]);
                    }
                }
                return role_Model;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool InsertNewRole(Role_Model role_Model)
        {
            try
            {
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Role_Insert");
                sqlDatabase.AddInParameter(dbCommand, "RoleName", SqlDbType.VarChar, role_Model.RoleName);
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
       

        public bool UpdateRole(int RoleID, Role_Model role_Model)
        {
            try
            {
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Role_Update");
                sqlDatabase.AddInParameter(dbCommand, "RoleID", SqlDbType.Int, role_Model.RoleID);
                sqlDatabase.AddInParameter(dbCommand, "RoleName", SqlDbType.VarChar, role_Model.RoleName);
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

        public bool DeleteRole(int RoleId)
        {
            try
            {
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Role_Delete");
                sqlDatabase.AddInParameter(dbCommand, "@RoleId", SqlDbType.Int, RoleId);
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
