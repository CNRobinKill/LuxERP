using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LuxERP.DAL
{
    public class SystemUserDAL
    {
        private const string SPAddSystemUser = "AddSystemUser";
        private const string SPGetSystemUser = "GetSystemUser";
        private const string SPDelSystemUser = "DelSystemUser";
        private const string SPUpdateSystemUserByUserName = "UpdateSystemUserByUserName";
        private const string SPUpdateUserStateByUserName = "UpdateUserStateByUserName";
        private const string SPGetCheckSystemUserPassword = "GetCheckSystemUserPassword";
        private const string SPUpdateLogOnByUserName = "UpdateLogOnByUserName";
        private const string SPGetUserIP = "GetUserIP";

        public static int AddSystemUser(string userName, string password, string createTime)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@userName",userName),
                new SqlParameter("@password",password),
                new SqlParameter("@createTime",createTime)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPAddSystemUser, paras);
        }

        public static DataSet GetSystemUser()
        {
            DataSet ds = null;
            ds = Common.SqlHelper.ExecuteDataSet(SPGetSystemUser, null);
            return ds;
        }

        public static int DelSystemUser(string userName)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@userName",userName)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPDelSystemUser, paras);
        }

        public static int UpdateSystemUserByUserName(string userName, string password)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@userName",userName),
                new SqlParameter("@password",password)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPUpdateSystemUserByUserName, paras);
        }

        public static int UpdateUserStateByUserName(string userName, int userState)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@userName",userName),
                new SqlParameter("@userState",userState)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPUpdateUserStateByUserName, paras);
        }

        public static int GetCheckSystemUserPassword(string userName, string password)
        {
            SqlParameter[] paras = { 
                new SqlParameter("@userName",userName),
                new SqlParameter("@password",password)
            };

            return (int)Common.SqlHelper.ExecuteScalar(SPGetCheckSystemUserPassword, paras);
        }

        public static int UpdateLogOnByUserName(string userName, string userIP)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@userName",userName),
                new SqlParameter("@userIP",userIP)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPUpdateLogOnByUserName, paras);
        }

        public static string GetUserIP(string userName, string userIP)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@userName",userName),
                new SqlParameter("@userIP",userIP)
            };
            try
            {
                
                string GuserIP = Common.SqlHelper.ExecuteScalar(SPGetUserIP, paras).ToString();
                if (GuserIP == null || GuserIP == "")
                { return ""; }
                else
                { return GuserIP; }
            }
            catch
            {
                return "";
            }
        }
    }
}
