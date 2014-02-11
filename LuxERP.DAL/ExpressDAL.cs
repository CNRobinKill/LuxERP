using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LuxERP.DAL
{
    /// <summary>
    /// 快递
    /// </summary>
    public class ExpressDAL
    {
        /// <summary>
        /// 引用存储过程
        /// </summary>
        private const string SPAddExpress = "AddExpress";
        private const string SPGetExpressByEventNo = "GetExpressByEventNo";
        private const string SPUpdateExpressState = "UpdateExpressState";
        /// <summary>
        /// 添加快递
        /// </summary>
        /// <param name="eventNo">事件编号</param>
        /// <param name="expressCo">快递公司</param>
        /// <param name="expressNo">快递编号</param>
        /// <param name="getOrSend">寄/收送</param>
        /// <param name="expressState">快递状态</param>
        /// <returns>int</returns>
        public static int AddExpress(string eventNo,string expressCo,string expressNo,int getOrSend,int expressState)
        {
            SqlParameter[] paras = {
                                       new SqlParameter("@eventNo",eventNo),
                                       new SqlParameter("@expressCo",expressCo),
                                       new SqlParameter("@expressNo",expressNo),
                                       new SqlParameter("@getOrSend",getOrSend),
                                       new SqlParameter("@expressState",expressState)
                                   };
            return Common.SqlHelper.ExecuteNonQuery(SPAddExpress, paras);
        }

        public static DataSet GetExpressByEventNo(string eventNo, int getOrSend)
        {
            SqlParameter[] paras = {
	            new SqlParameter("@eventNo",eventNo),
                new SqlParameter("@getOrSend",getOrSend)
            };
            return Common.SqlHelper.ExecuteDataSet(SPGetExpressByEventNo, paras);
        }

        public static int UpdateExpressState(int id, int expressState)
        {
            SqlParameter[] paras = {
                                       new SqlParameter("@id",id),
                                       new SqlParameter("@expressState",expressState)
                                   };
            return Common.SqlHelper.ExecuteNonQuery(SPUpdateExpressState, paras);
        }
    }
}
