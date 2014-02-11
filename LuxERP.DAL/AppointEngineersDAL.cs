using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LuxERP.DAL
{
    /// <summary>
    /// 上门工程师
    /// </summary>
    public class AppointEngineersDAL
    {
        /// <summary>
        /// 引用存储过程
        /// </summary>
        private const string SPAddAppointEngineers = "AddAppointEngineers";
        private const string SPGetAppointEngineersByEventNo = "GetAppointEngineersByEventNo";
        private const string SPGetEmailFromEngineers = "GetEmailFromEngineers";
        private const string SPUpdateAppointState = "UpdateAppointState";

        /// <summary>
        /// 添加预上门工程师
        /// </summary>
        /// <param name="eventNo">事件编号</param>
        /// <param name="name">名称</param>
        /// <param name="appointState">预约状态</param>
        /// <returns>int</returns>
        public static int AddAppointEngineers(string eventNo, string name, string appointState)
        {
            SqlParameter[] paras = {
                                       new SqlParameter("@eventNo",eventNo),
                                       new SqlParameter("@name",name),                                   
                                       new SqlParameter("@appointState",appointState)
                                   };
            return Common.SqlHelper.ExecuteNonQuery(SPAddAppointEngineers, paras);
        }
        /// <summary>
        /// 获取预上门工程师
        /// </summary>
        /// <param name="eventNo">事件编号</param>
        /// <returns>DataSet</returns>
        public static DataSet GetAppointEngineersByEventNo(string eventNo)
        {
            SqlParameter[] paras = {
	            new SqlParameter("@eventNo",eventNo)
            };
            return Common.SqlHelper.ExecuteDataSet(SPGetAppointEngineersByEventNo, paras);
        }
        /// <summary>
        /// 获取上门工程师邮箱
        /// </summary>
        /// <param name="eventNo">事件编号</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader GetEmailFromEngineers(string eventNo)
        {
            SqlParameter[] paras = {
	            new SqlParameter("@eventNo",eventNo)
            };
            return Common.SqlHelper.ExecuteReader(SPGetEmailFromEngineers, paras);

        }
        /// <summary>
        /// 更新上门状态
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="sceneTime">上门时间</param>
        /// <param name="appointState">上门状态</param>
        /// <returns>int</returns>
        public static int UpdateAppointState(int id, string sceneTime, string appointState)
        {
            SqlParameter[] paras = {
                                       new SqlParameter("@id",id),
                                       new SqlParameter("@sceneTime",sceneTime),
                                       new SqlParameter("@appointState",appointState)
                                   };
            return Common.SqlHelper.ExecuteNonQuery(SPUpdateAppointState, paras);
        }
    }
}
