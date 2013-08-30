using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LuxERP.DAL
{
    public class IndexDAL
    {
        private const string SPCountNormalEventLog = "CountNormalEventLog";
        private const string SPCountSetUpShopEventLog = "CountSetUpShopEventLog";
        private const string SPCountShutUpShopEventLog = "CountShutUpShopEventLog";
        private const string SPCountStoreRenovationEventLog = "CountStoreRenovationEventLog";
        private const string SPGetUrgentNormalEventLog = "GetUrgentNormalEventLog";
        private const string SPGetUrgentSetUpShopEventLog = "GetUrgentSetUpShopEventLog";
        private const string SPGetUrgentShutUpShopEventLog = "GetUrgentShutUpShopEventLog";
        private const string SPGetUrgentStoreRenovationEventLog = "GetUrgentStoreRenovationEventLog";

        public static int CountNormalEventLog()
        {
            return (int) Common.SqlHelper.ExecuteScalar(SPCountNormalEventLog, null);
        }

        public static int CountSetUpShopEventLog()
        {
            return (int)Common.SqlHelper.ExecuteScalar(SPCountSetUpShopEventLog, null);
        }

        public static int CountShutUpShopEventLog()
        {
            return (int)Common.SqlHelper.ExecuteScalar(SPCountShutUpShopEventLog, null);
        }

        public static int CountStoreRenovationEventLog()
        {
            return (int)Common.SqlHelper.ExecuteScalar(SPCountStoreRenovationEventLog, null);
        }

        public static DataSet GetUrgentNormalEventLog(string temp, string logBy)
        {
            SqlParameter[] paras = { 
                new SqlParameter("@temp",temp),
                new SqlParameter("@logBy",logBy)
            };
            DataSet ds = null;
            ds = Common.SqlHelper.ExecuteDataSet(SPGetUrgentNormalEventLog, paras);
            return ds;
        }

        public static DataSet GetUrgentSetUpShopEventLog()
        {
            DataSet ds = null;
            ds = Common.SqlHelper.ExecuteDataSet(SPGetUrgentSetUpShopEventLog, null);
            return ds;
        }

        public static DataSet GetUrgentShutUpShopEventLog()
        {
            DataSet ds = null;
            ds = Common.SqlHelper.ExecuteDataSet(SPGetUrgentShutUpShopEventLog, null);
            return ds;
        }

        public static DataSet GetUrgentStoreRenovationEventLog()
        {
            DataSet ds = null;
            ds = Common.SqlHelper.ExecuteDataSet(SPGetUrgentStoreRenovationEventLog, null);
            return ds;
        }
    }
}
