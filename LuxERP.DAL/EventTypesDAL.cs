using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LuxERP.DAL
{
    /// <summary>
    /// 事件类型
    /// </summary>
    public class EventTypesDAL
    {
        /// <summary>
        /// 引用存储过程
        /// </summary>
        private const string SPAddTypeOne = "AddTypeOne";
        private const string SPGetTypeOne = "GetTypeOne";
        private const string SPDelTypeOne = "DelTypeOne";
        private const string SPAddTypeTwo = "AddTypeTwo";
        private const string SPGetTypeTwo = "GetTypeTwo";
        private const string SPDelTypeTwo = "DelTypeTwo";
        private const string SPAddTypeThree = "AddTypeThree";
        private const string SPGetTypeThree = "GetTypeThree";
        private const string SPDelTypeThree = "DelTypeThree";
        private const string SPAddTypeFour = "AddTypeFour";
        private const string SPGetTypeFour = "GetTypeFour";
        private const string SPDelTypeFour = "DelTypeFour";
        private const string SPAddEventTypes = "AddEventTypes";
        private const string SPGetEventTypes = "GetEventTypes";
        private const string SPDelEventTypes = "DelEventTypes";
        private const string SPGetEventTypesByTypeCode = "GetEventTypesByTypeCode";
        private const string SPGetEventLevelByTypeCode = "GetEventLevelByTypeCode";

        /// <summary>
        /// 添加类型一
        /// </summary>
        /// <param name="typeOne">类型一</param>
        /// <returns>int</returns>
        public static int AddTypeOne(string typeOne)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@typeOne",typeOne)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPAddTypeOne, paras);
        }
        /// <summary>
        /// 获取类型一
        /// </summary>
        /// <param name="typeOne">类型一</param>
        /// <returns>int</returns>
        public static DataSet GetTypeOne()
        {
            DataSet ds = null;
            ds = Common.SqlHelper.ExecuteDataSet(SPGetTypeOne,null);
            return ds;           
        }
        /// <summary>
        /// 删除类型一
        /// </summary>
        /// <param name="typeOne">类型一</param>
        /// <returns>int</returns>
        public static int DelTypeOne(string typeOne)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@typeOne",typeOne)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPDelTypeOne, paras);
        }
        /// <summary>
        /// 添加类型二
        /// </summary>
        /// <param name="typeOne">类型二</param>
        /// <returns>int</returns>
        public static int AddTypeTwo(string typeTwo)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@typeTwo",typeTwo)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPAddTypeTwo, paras);
        }
        /// <summary>
        /// 获取类型二
        /// </summary>
        /// <param name="typeOne">类型二</param>
        /// <returns>int</returns>
        public static DataSet GetTypeTwo()
        {
            DataSet ds = null;
            ds = Common.SqlHelper.ExecuteDataSet(SPGetTypeTwo, null);
            return ds;
        }
        /// <summary>
        /// 删除类型二
        /// </summary>
        /// <param name="typeOne">类型二</param>
        /// <returns>int</returns>
        public static int DelTypeTwo(string typeTwo)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@typeTwo",typeTwo)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPDelTypeTwo, paras);
        }
        /// <summary>
        /// 添加类型三
        /// </summary>
        /// <param name="typeOne">类型三</param>
        /// <returns>int</returns>
        public static int AddTypeThree(string typeThree)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@typeThree",typeThree)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPAddTypeThree, paras);
        }
        /// <summary>
        /// 获取类型三
        /// </summary>
        /// <param name="typeOne">类型三</param>
        /// <returns>int</returns>
        public static DataSet GetTypeThree()
        {
            DataSet ds = null;
            ds = Common.SqlHelper.ExecuteDataSet(SPGetTypeThree, null);
            return ds;
        }
        /// <summary>
        /// 删除类型三
        /// </summary>
        /// <param name="typeOne">类型三</param>
        /// <returns>int</returns>
        public static int DelTypeThree(string typeThree)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@typeThree",typeThree)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPDelTypeThree, paras);
        }
        /// <summary>
        /// 添加类型四
        /// </summary>
        /// <param name="typeOne">类型四</param>
        /// <returns>int</returns>
        public static int AddTypeFour(string typeFour)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@typeFour",typeFour)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPAddTypeFour, paras);
        }
        /// <summary>
        /// 获取类型四
        /// </summary>
        /// <param name="typeOne">类型四</param>
        /// <returns>int</returns>
        public static DataSet GetTypeFour()
        {
            DataSet ds = null;
            ds = Common.SqlHelper.ExecuteDataSet(SPGetTypeFour, null);
            return ds;
        }
        /// <summary>
        /// 删除类型四
        /// </summary>
        /// <param name="typeOne">类型四</param>
        /// <returns>int</returns>
        public static int DelTypeFour(string typeFour)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@typeFour",typeFour)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPDelTypeFour, paras);
        }
        /// <summary>
        /// 添加事件类型
        /// </summary>
        /// <param name="typeCode">类型编码</param>
        /// <param name="typeOne">类型一</param>
        /// <param name="typeTwo">类型二</param>
        /// <param name="typeThree">类型三</param>
        /// <param name="typeFour">类型四</param>
        /// <param name="eventLevel">事件等级</param>
        /// <returns>int</returns>
        public static int AddEventTypes(string typeCode, string typeOne, string typeTwo, string typeThree, string typeFour, string eventLevel)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@typeCode",typeCode),
                new SqlParameter("@typeOne",typeOne),
                new SqlParameter("@typeTwo",typeTwo),
                new SqlParameter("@typeThree",typeThree),
                new SqlParameter("@typeFour",typeFour),
                new SqlParameter("@eventLevel",eventLevel)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPAddEventTypes, paras);
        }
        /// <summary>
        /// 获取时间类型
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet GetEventTypes()
        {
            DataSet ds = null;
            ds = Common.SqlHelper.ExecuteDataSet(SPGetEventTypes, null);
            return ds;
        }
        /// <summary>
        /// 删除事件类型
        /// </summary>
        /// <param name="typeCode">类型编号</param>
        /// <returns>int</returns>
        public static int DelEventTypes(string typeCode)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@typeCode",typeCode)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPDelEventTypes, paras);
        }
        /// <summary>
        /// 根据事件号查询事件类型
        /// </summary>
        /// <param name="typeCode">类型编号</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader GetEventTypesByTypeCode(string typeCode)
        {
            SqlParameter[] paras = {
	            new SqlParameter("@typeCode",typeCode)
            };
            return Common.SqlHelper.ExecuteReader(SPGetEventTypesByTypeCode, paras);

        }
        /// <summary>
        /// 很据类型编号获取事件等级
        /// </summary>
        /// <param name="typeCode">类型编号</param>
        /// <returns>string</returns>
        public static string GetEventLevelByTypeCode(string typeCode)
        {
            SqlParameter[] paras = {
	            new SqlParameter("@typeCode",typeCode)
            };
            return (string)Common.SqlHelper.ExecuteScalar(SPGetEventLevelByTypeCode, paras);

        }
    }
}
