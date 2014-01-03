using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LuxERP.DAL
{
    public class EventLogsDAL
    {
        private const string SPAddEventLogs = "AddEventLogs";
        private const string SPGetEventLogsByEventNo = "GetEventLogsByEventNo";
        private const string SPGetEventLogsInNormalEvent = "GetEventLogsInNormalEvent";
        private const string SPGetPic = "GetPic";
        private const string SPUpdateEventState = "UpdateEventState";
        private const string SPUpdateToResolvedTime = "UpdateToResolvedTime";
        private const string SPUpdateResolvedByAndTime = "UpdateResolvedByAndTime";
        private const string SPUpdateEvent = "UpdateEvent";
        private const string SPUpdateHandingBy = "UpdateHandingBy";
        private const string SPGetHandingByByEventNo = "GetHandingByByEventNo";
        private const string SPUpdateEventStateByShutUpShop = "UpdateEventStateByShutUpShop";
        private const string SPGetTopTenEventLogsByStoreNo = "GetTopTenEventLogsByStoreNo";
        private const string SPGetAllotStocksTotal = "GetEventLogsTotal";
        private const string SPGetAllotStocksPaged = "GetEventLogsPaged";
        private const string SPUpdateUpLoadPic = "UpdateUpLoadPic";
        private const string SPGetUsers = "GetUsers";
        

        public static int AddEventLogs(string eventNo, string eventTime, string storeNo, string typeCode, string eventDescribe, string toResolvedTime, string eventState, string logBy)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@eventNo",eventNo),
                new SqlParameter("@eventTime",eventTime),
                new SqlParameter("@storeNo",storeNo),
                new SqlParameter("@typeCode",typeCode),
                new SqlParameter("@eventDescribe",eventDescribe),
                new SqlParameter("@toResolvedTime",toResolvedTime),
                new SqlParameter("@eventState",eventState),
                new SqlParameter("@logBy",logBy)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPAddEventLogs, paras);
        }

        public static SqlDataReader GetEventLogsByEventNo(string eventNo)
        {
            SqlParameter[] paras = {
	            new SqlParameter("@eventNo",eventNo)
            };
            return Common.SqlHelper.ExecuteReader(SPGetEventLogsByEventNo, paras);
  
        }

        public static DataSet GetEventLogsInNormalEvent(string eventTimeA, string eventTimeB, string storeNo, string typeCode, string eventState)
        {
            SqlParameter[] paras = {
	            new SqlParameter("@eventTimeA",eventTimeA),
                new SqlParameter("@eventTimeB",eventTimeB),
                new SqlParameter("@storeNo",storeNo),
                new SqlParameter("@typeCode",typeCode),
                new SqlParameter("@eventState",eventState)
            };
            DataSet ds = null;
            ds = Common.SqlHelper.ExecuteDataSet(SPGetEventLogsInNormalEvent, paras);
            return ds;
        }

        public static int UpdateEventState(string eventNo, string eventState)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@eventNo",eventNo),
                new SqlParameter("@eventState",eventState)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPUpdateEventState, paras);
        }

        public static int UpdateToResolvedTime(string eventNo, string toResolvedTime)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@eventNo",eventNo),
                new SqlParameter("@toResolvedTime",toResolvedTime)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPUpdateToResolvedTime, paras);
        }

        public static int UpdateResolvedByAndTime(string eventNo, string resolvedBy, string resolvedTime)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@eventNo",eventNo),
                new SqlParameter("@resolvedBy",resolvedBy),
                new SqlParameter("@resolvedTime",resolvedTime)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPUpdateResolvedByAndTime, paras);
        }

        public static int UpdateEvent(string eventNo, string typeCode, string eventDescribe)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@eventNo",eventNo),
                new SqlParameter("@typeCode",typeCode),
                new SqlParameter("@eventDescribe",eventDescribe)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPUpdateEvent, paras);
        }

        public static int UpdateHandingBy(string eventNo, string handingBy)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@eventNo",eventNo),
                new SqlParameter("@handingBy",handingBy)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPUpdateHandingBy, paras);
        }

        public static string GetHandingByByEventNo(string eventNo)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@eventNo",eventNo)
            };
            try
            {
                return (string)Common.SqlHelper.ExecuteScalar(SPGetHandingByByEventNo, paras);
            }
            catch
            {
                return "";
            }
        }

        public static int UpdateEventStateByShutUpShop(string storeNo, string stepDescribe, string stepTime, string stepState, string stepBy)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@storeNo",storeNo),
                new SqlParameter("@stepDescribe",stepDescribe),
                new SqlParameter("@stepTime",stepTime),
                new SqlParameter("@stepState",stepState),
                new SqlParameter("@stepBy",stepBy)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPUpdateEventStateByShutUpShop, paras);
        }

        public static SqlDataReader GetTopTenEventLogsByStoreNo(string storeNo)
        {
            SqlParameter[] paras = {
	            new SqlParameter("@storeNo",storeNo)
            };
            return Common.SqlHelper.ExecuteReader(SPGetTopTenEventLogsByStoreNo, paras);

        }

        public static DataSet GetEventLogsTotal(string eventTimeA, string eventTimeB, string storeNo, string typeCode, string eventState, string eventNo, string user)
        {
            SqlParameter[] paras = {
	            new SqlParameter("@eventTimeA",eventTimeA),
                new SqlParameter("@eventTimeB",eventTimeB),
                new SqlParameter("@storeNo",storeNo),
                new SqlParameter("@typeCode",typeCode),
                new SqlParameter("@eventState",eventState),
                new SqlParameter("@eventNo",eventNo),
                new SqlParameter("@user",user)
            };
            DataSet ds = null;
            ds = Common.SqlHelper.ExecuteDataSet(SPGetAllotStocksTotal, paras);
            return ds;
        }

        public static DataSet GetEventLogsPaged(string eventTimeA, string eventTimeB, string storeNo, string typeCode, string eventState, string eventNo, string user, int pageSize, int pageIndex)
        {
            SqlParameter[] paras = {
	            new SqlParameter("@eventTimeA",eventTimeA),
                new SqlParameter("@eventTimeB",eventTimeB),
                new SqlParameter("@storeNo",storeNo),
                new SqlParameter("@typeCode",typeCode),
                new SqlParameter("@eventState",eventState),
                new SqlParameter("@eventNo",eventNo),
                new SqlParameter("@user",user),
                new SqlParameter("@pageSize",pageSize),
                new SqlParameter("@pageIndex",pageIndex)
            };
            DataSet ds = null;
            ds = Common.SqlHelper.ExecuteDataSet(SPGetAllotStocksPaged, paras);
            return ds;
        }

        public static int UpdateUpLoadPic(string eventNo, string outStockPic, string scenePic)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@eventNo",eventNo),
                new SqlParameter("@outStockPic",outStockPic),
                new SqlParameter("@scenePic",scenePic),
            };
            return Common.SqlHelper.ExecuteNonQuery(SPUpdateUpLoadPic, paras);
        }

        public static string GetPic(string eventNo, string picNo)
        {
            SqlParameter[] paras = {
	            new SqlParameter("@eventNo",eventNo),
                new SqlParameter("@picNo",picNo)
            };
            try
            {
                return (string) Common.SqlHelper.ExecuteScalar(SPGetPic, paras);;
            }
            catch
            {
                return "";
            }

        }

        public static DataSet GetUsers()
        {
            DataSet ds = Common.SqlHelper.ExecuteDataSet(SPGetUsers, null);
            return ds;
        }
    }
}
