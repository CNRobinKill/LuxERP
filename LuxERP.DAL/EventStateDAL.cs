using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LuxERP.DAL
{
    /// <summary>
    /// 事件状态
    /// </summary>
    public class EventStateDAL
    {
        /// <summary>
        /// 引用存储过程
        /// </summary>
        private const string SPAddEventState = "AddEventState";
        private const string SPGetEventState = "GetEventState";
        private const string SPDelEventState = "DelEventState";
        private const string SPChangeUpEventState = "ChangeUpEventState";
        private const string SPChangeDownEventState = "ChangeDownEventState";
        private const string SPUpdateEventStateByStateID = "UpdateEventStateByStateID";
        private const string SPGetEventStateByStateID = "GetEventStateByStateID";
        private const string SPGetMinEventState = "GetMinEventState";

        /// <summary>
        /// 添加事件状态
        /// </summary>
        /// <param name="stateName">状态名称</param>
        /// <param name="stateDay">距离事件天数</param>
        /// <param name="stateType">状态编号</param>
        /// <returns>int</returns>
        public static int AddEventState(string stateName, int stateDay, string stateType)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@stateName",stateName),
                new SqlParameter("@stateDay",stateDay),
                new SqlParameter("@stateType",stateType)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPAddEventState, paras);
        }
        /// <summary>
        /// 获取事件状态
        /// </summary>
        /// <param name="stateType">状态编号</param>
        /// <returns>DataSet</returns>
        public static DataSet GetEventState(string stateType)
        {
            SqlParameter[] paras = { 
                new SqlParameter("@stateType",stateType)
            };
            DataSet ds = null;
            ds = Common.SqlHelper.ExecuteDataSet(SPGetEventState, paras);
            return ds;
        }
        /// <summary>
        /// 删除事件状态
        /// </summary>
        /// <param name="stateType">状态编号</param>
        /// <param name="stateID">状态ID</param>
        /// <returns>int</returns>
        public static int DelEventState(string stateType, int stateID)
        {
            SqlParameter[] paras = { 
                new SqlParameter("@stateType",stateType),
                new SqlParameter("@stateID",stateID)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPDelEventState, paras);
        }
        /// <summary>
        /// 事件状态步骤上移
        /// </summary>
        /// <param name="stateID">状态ID</param>
        /// <returns></returns>
        public static int ChangeUpEventState(int stateID)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@stateID",stateID)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPChangeUpEventState, paras);
        }
        /// <summary>
        /// 事件状态步骤下移
        /// </summary>
        /// <param name="stateID">状态ID</param>
        /// <returns></returns>
        public static int ChangeDownEventState(int stateID)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@stateID",stateID)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPChangeDownEventState, paras);
        }
        /// <summary>
        /// 根据事件状态ID更新事件状态
        /// </summary>
        /// <param name="stateID">事件状态ID</param>
        /// <param name="stateName">状态名称</param>
        /// <param name="stateDay">距离天数</param>
        /// <returns>int</returns>
        public static int UpdateEventStateByStateID(int stateID, string stateName, int stateDay)
        {
            SqlParameter[] paras = { 
                new SqlParameter("@stateID",stateID),
	            new SqlParameter("@stateName",stateName),
                new SqlParameter("@stateDay",stateDay)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPUpdateEventStateByStateID, paras);
        }
        /// <summary>
        /// 根据事件状态ID查询事件状态
        /// </summary>
        /// <param name="stateID">事件状态ID</param>
        /// <param name="stateType">事件编号</param>
        /// <returns></returns>
        public static DataSet GetEventStateByStateID(int stateID, string stateType)
        {
            SqlParameter[] paras = { 
                new SqlParameter("@stateID",stateID),
                new SqlParameter("@stateType",stateType)
            };
            DataSet ds = null;
            ds = Common.SqlHelper.ExecuteDataSet(SPGetEventStateByStateID, paras);
            return ds;
        }
        /// <summary>
        /// 获取最小事件状态
        /// </summary>
        /// <param name="stateType">事件编号</param>
        /// <returns>int</returns>
        public static int GetMinEventState(string stateType)
        {
            SqlParameter[] paras = { 
                new SqlParameter("@stateType",stateType)
            };
            return (int)Common.SqlHelper.ExecuteScalar(SPGetMinEventState, paras);
        }
    }
}
