using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LuxERP.DAL
{
    /// <summary>
    /// 事件步骤
    /// </summary>
    public class EventStepsDAL
    {
        /// <summary>
        /// 引用存储过程
        /// </summary>
        private const string SPAddEventSteps = "AddEventSteps";
        private const string SPGetEventStepsByEventNo = "GetEventStepsByEventNo";
        private const string SPUpdateEventSteps = "UpdateEventSteps";
        private const string SPDeleteEventStepsByEventNo = "DeleteEventStepsByEventNo";

        /// <summary>
        /// 添加事件步骤
        /// </summary>
        /// <param name="eventNo">事件编号</param>
        /// <param name="stepDescribe">步骤内容</param>
        /// <param name="stepTime">步骤时间</param>
        /// <param name="stepState">步骤状态</param>
        /// <param name="stepBy">执行人</param>
        /// <returns>int</returns>
        public static int AddEventSteps(string eventNo, string stepDescribe, string stepTime, string stepState, string stepBy)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@eventNo",eventNo),
                new SqlParameter("@stepDescribe",stepDescribe),
                new SqlParameter("@stepTime",stepTime),
                new SqlParameter("@stepState",stepState),
                new SqlParameter("@stepBy",stepBy)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPAddEventSteps, paras);
        }
        /// <summary>
        /// 根据事件编号查询事件步骤
        /// </summary>
        /// <param name="eventNo">事件编号</param>
        /// <returns>DataSet</returns>
        public static DataSet GetEventStepsByEventNo(string eventNo)
        {
            SqlParameter[] paras = { 
                new SqlParameter("@eventNo",eventNo)
            };
            DataSet ds = null;
            ds = Common.SqlHelper.ExecuteDataSet(SPGetEventStepsByEventNo, paras);
            return ds;
        }
        /// <summary>
        /// 更新事件步骤
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="stepDescribe">步骤内容</param>
        /// <param name="stepState">步骤状态</param>
        /// <returns>int</returns>
        public static int UpdateEventSteps(int id ,string stepDescribe, string stepState)
        {
            SqlParameter[] paras = { 
                new SqlParameter("@id",id),
                new SqlParameter("@stepDescribe",stepDescribe),
                new SqlParameter("@stepState",stepState)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPUpdateEventSteps, paras);
        }

        public static int DeleteEventStepsByEventNo(string eventNo)
        {
            SqlParameter[] paras = { 
                new SqlParameter("@eventNo",eventNo)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPDeleteEventStepsByEventNo, paras);
        }
    }
}
