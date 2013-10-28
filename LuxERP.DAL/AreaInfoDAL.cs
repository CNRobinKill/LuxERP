using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LuxERP.DAL
{
    public class AreaInfoDAL
    {
        private const string SPAddAreaInfo = "AddAreaInfo";
        private const string SPGetAreaInfo = "GetAreaInfo";
        private const string SPGetAreaAliss = "GetAreaAliss";
        private const string SPDelAreaInfo = "DelAreaInfo";
        private const string SPUpdateAreaInfo = "UpdateAreaInfo";


        public static int AddAreaInfo(string areaName, string areaAliss, string areaManager, string managerPhone, string managerEmail)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@areaName",areaName),
                new SqlParameter("@areaAliss",areaAliss),
                new SqlParameter("@areaManager",areaManager),
                new SqlParameter("@managerPhone",managerPhone),
                new SqlParameter("@managerEmail",managerEmail)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPAddAreaInfo, paras);
        }

        public static DataSet GetAreaInfo()
        {
            DataSet ds = null;
            ds = Common.SqlHelper.ExecuteDataSet(SPGetAreaInfo, null);
            return ds;
        }

        public static DataSet GetAreaAliss()
        {
            DataSet ds = null;
            ds = Common.SqlHelper.ExecuteDataSet(SPGetAreaAliss, null);
            return ds;
        }

        public static int DelAreaInfo(string areaName)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@areaName",areaName)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPDelAreaInfo, paras);
        }

        public static int UpdateAreaInfo(string areaName, string areaAliss, string areaManager, string managerPhone, string managerEmail)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@areaName",areaName),
                new SqlParameter("@areaAliss",areaAliss),
                new SqlParameter("@areaManager",areaManager),
                new SqlParameter("@managerPhone",managerPhone),
                new SqlParameter("@managerEmail",managerEmail)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPUpdateAreaInfo, paras);
        }

    }
}
