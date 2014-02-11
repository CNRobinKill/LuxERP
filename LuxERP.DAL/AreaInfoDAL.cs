using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LuxERP.DAL
{
    /// <summary>
    /// 区域信息
    /// </summary>
    public class AreaInfoDAL
    {
        /// <summary>
        /// 引用存储过程
        /// </summary>
        private const string SPAddAreaInfo = "AddAreaInfo";
        private const string SPGetAreaInfo = "GetAreaInfo";
        private const string SPGetAreaAliss = "GetAreaAliss";
        private const string SPDelAreaInfo = "DelAreaInfo";
        private const string SPUpdateAreaInfo = "UpdateAreaInfo";

        /// <summary>
        /// 添加区域信息
        /// </summary>
        /// <param name="areaName">区域名称</param>
        /// <param name="areaAliss">区域简称</param>
        /// <param name="areaManager">区域经理</param>
        /// <param name="managerPhone">区域经理电话</param>
        /// <param name="managerEmail">区域经理邮箱</param>
        /// <returns>int</returns>
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
        /// <summary>
        /// 获取区域信息
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet GetAreaInfo()
        {
            DataSet ds = null;
            ds = Common.SqlHelper.ExecuteDataSet(SPGetAreaInfo, null);
            return ds;
        }
        /// <summary>
        /// 获取区域简称
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet GetAreaAliss()
        {
            DataSet ds = null;
            ds = Common.SqlHelper.ExecuteDataSet(SPGetAreaAliss, null);
            return ds;
        }
        /// <summary>
        /// 删除区域信息
        /// </summary>
        /// <param name="areaName">区域名称</param>
        /// <returns>int</returns>
        public static int DelAreaInfo(string areaName)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@areaName",areaName)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPDelAreaInfo, paras);
        }
        /// <summary>
        /// 更新区域信息
        /// </summary>
        /// <param name="areaName">区域名称</param>
        /// <param name="areaAliss">区域简称</param>
        /// <param name="areaManager">区域经理</param>
        /// <param name="managerPhone">区域经理电话</param>
        /// <param name="managerEmail">区域经理邮箱</param>
        /// <returns>int</returns>
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
