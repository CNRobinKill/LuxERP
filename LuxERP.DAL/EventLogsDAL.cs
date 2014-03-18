using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LuxERP.DAL
{
    /// <summary>
    /// 事件记录
    /// </summary>
    public class EventLogsDAL
    {
        /// <summary>
        /// 引用存储过程
        /// </summary>
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
        private const string SPDeleteEventLogsByEventNo = "DeleteEventLogsByEventNo";
        /// <summary>
        /// 添加事件记录
        /// </summary>
        /// <param name="eventNo">事件编号</param>
        /// <param name="eventTime">事件时间</param>
        /// <param name="storeNo">门店编号</param>
        /// <param name="typeCode">事件编号</param>
        /// <param name="eventDescribe">事件简述</param>
        /// <param name="toResolvedTime">解决时间</param>
        /// <param name="eventState">事件状态</param>
        /// <param name="logBy">事件记录人</param>
        /// <returns>int</returns>
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
        /// <summary>
        /// 根据事件编号获取事件
        /// </summary>
        /// <param name="eventNo">事件编号</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader GetEventLogsByEventNo(string eventNo)
        {
            SqlParameter[] paras = {
	            new SqlParameter("@eventNo",eventNo)
            };
            return Common.SqlHelper.ExecuteReader(SPGetEventLogsByEventNo, paras);
  
        }
        /// <summary>
        /// 获取普通事件
        /// </summary>
        /// <param name="eventTimeA">事件时间区间</param>
        /// <param name="eventTimeB">事件时间区间</param>
        /// <param name="storeNo">门店编号</param>
        /// <param name="typeCode">事件类型</param>
        /// <param name="eventState">时间状态</param>
        /// <returns>DataSet</returns>
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
        /// <summary>
        /// 事件状态更新
        /// </summary>
        /// <param name="eventNo">事件编号</param>
        /// <param name="eventState">事件状态</param>
        /// <returns>int</returns>
        public static int UpdateEventState(string eventNo, string eventState)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@eventNo",eventNo),
                new SqlParameter("@eventState",eventState)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPUpdateEventState, paras);
        }
        /// <summary>
        /// 事件解决时间更新
        /// </summary>
        /// <param name="eventNo">事件编号</param>
        /// <param name="toResolvedTime">解决时间</param>
        /// <returns>int</returns>
        public static int UpdateToResolvedTime(string eventNo, string toResolvedTime)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@eventNo",eventNo),
                new SqlParameter("@toResolvedTime",toResolvedTime)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPUpdateToResolvedTime, paras);
        }
        /// <summary>
        /// 事件解决人\时间更新
        /// </summary>
        /// <param name="eventNo">事件编号</param>
        /// <param name="resolvedBy">解决人</param>
        /// <param name="resolvedTime">解决时间</param>
        /// <returns>int</returns>
        public static int UpdateResolvedByAndTime(string eventNo, string resolvedBy, string resolvedTime)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@eventNo",eventNo),
                new SqlParameter("@resolvedBy",resolvedBy),
                new SqlParameter("@resolvedTime",resolvedTime)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPUpdateResolvedByAndTime, paras);
        }
        /// <summary>
        /// 事件类型/简述更新
        /// </summary>
        /// <param name="eventNo">事件编号</param>
        /// <param name="typeCode">事件类型</param>
        /// <param name="eventDescribe">事件简述</param>
        /// <returns>int</returns>
        public static int UpdateEvent(string eventNo, string typeCode, string eventDescribe)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@eventNo",eventNo),
                new SqlParameter("@typeCode",typeCode),
                new SqlParameter("@eventDescribe",eventDescribe)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPUpdateEvent, paras);
        }
        /// <summary>
        /// 更新跟进人
        /// </summary>
        /// <param name="eventNo">事件编号</param>
        /// <param name="handingBy">解决组织</param>
        /// <returns>int</returns>
        public static int UpdateHandingBy(string eventNo, string handingBy)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@eventNo",eventNo),
                new SqlParameter("@handingBy",handingBy)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPUpdateHandingBy, paras);
        }
        /// <summary>
        /// 根据事件编号获取解决人
        /// </summary>
        /// <param name="eventNo">事件编号</param>
        /// <returns>string</returns>
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
        /// <summary>
        /// 更新关店事件状态
        /// </summary>
        /// <param name="storeNo">店铺编号</param>
        /// <param name="stepDescribe">步骤简述</param>
        /// <param name="stepTime">步骤事件</param>
        /// <param name="stepState">步骤状态</param>
        /// <param name="stepBy">执行人</param>
        /// <returns>int</returns>
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
        /// <summary>
        /// 根据店铺号获取前10事件
        /// </summary>
        /// <param name="storeNo">店铺号</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader GetTopTenEventLogsByStoreNo(string storeNo)
        {
            SqlParameter[] paras = {
	            new SqlParameter("@storeNo",storeNo)
            };
            return Common.SqlHelper.ExecuteReader(SPGetTopTenEventLogsByStoreNo, paras);

        }
        /// <summary>
        /// 查询事件(总量)
        /// </summary>
        /// <param name="eventTimeA">事件时间区间</param>
        /// <param name="eventTimeB">事件时间区间</param>
        /// <param name="storeNo">门店编号</param>
        /// <param name="typeCode">事件类型</param>
        /// <param name="eventState">事件状态</param>
        /// <param name="eventNo">事件编号</param>
        /// <param name="user">执行人</param>
        /// <returns>DataSet</returns>
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
        /// <summary>
        /// 查询事件(分页)
        /// </summary>
        /// <param name="eventTimeA">事件时间区间</param>
        /// <param name="eventTimeB">事件时间区间</param>
        /// <param name="storeNo">门店编号</param>
        /// <param name="typeCode">事件类型</param>
        /// <param name="eventState">事件状态</param>
        /// <param name="eventNo">事件编号</param>
        /// <param name="user">执行人</param>
        /// <param name="pageSize">单页量</param>
        /// <param name="pageIndex">页码</param>
        /// <returns>DataSet</returns>
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
        /// <summary>
        /// 更新上门工单/出库单图片
        /// </summary>
        /// <param name="eventNo">事件编号</param>
        /// <param name="outStockPic">出库单</param>
        /// <param name="scenePic">上门工单</param>
        /// <returns></returns>
        public static int UpdateUpLoadPic(string eventNo, string outStockPic, string scenePic)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@eventNo",eventNo),
                new SqlParameter("@outStockPic",outStockPic),
                new SqlParameter("@scenePic",scenePic),
            };
            return Common.SqlHelper.ExecuteNonQuery(SPUpdateUpLoadPic, paras);
        }
        /// <summary>
        /// 获取图片
        /// </summary>
        /// <param name="eventNo">事件编号</param>
        /// <param name="picNo">图片</param>
        /// <returns>string</returns>
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
        /// <summary>
        /// 获取用户
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet GetUsers()
        {
            DataSet ds = Common.SqlHelper.ExecuteDataSet(SPGetUsers, null);
            return ds;
        }

        public static int DeleteEventLogsByEventNo(string eventNo)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@eventNo",eventNo)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPDeleteEventLogsByEventNo, paras);
        }
    }
}
