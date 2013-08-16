using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LuxERP.DAL
{
    public class SceneStateDAL
    {
        private const string SPAddSceneState = "AddSceneState";
        private const string SPGetSceneStateByEventNo = "GetSceneStateByEventNo";
        private const string SPUpdateSceneState = "UpdateSceneState";
        private const string SPAddHistoryServiceFromStocks = "AddHistoryServiceFromStocks";
        private const string SPGetHistoryServiceByEventNo = "GetHistoryServiceByEventNo";
        

        public static int AddSceneState(string eventNo,string sceneState)
        {
            SqlParameter[] paras = {
                                       new SqlParameter("@eventNo",eventNo),
                                       new SqlParameter("@sceneState",sceneState)
                                   };
            return Common.SqlHelper.ExecuteNonQuery(SPAddSceneState, paras);
        }

        public static string GetSceneStateByEventNo(string eventNo)
        {
            SqlParameter[] paras = {
	            new SqlParameter("@eventNo",eventNo)
            };
            return (string)Common.SqlHelper.ExecuteScalar(SPGetSceneStateByEventNo, paras);
        }

        public static int UpdateSceneState(string eventNo,string sceneState)
        {
            SqlParameter[] paras = {
                                       new SqlParameter("@eventNo",eventNo),
                                       new SqlParameter("@sceneState",sceneState)
                                   };
            return Common.SqlHelper.ExecuteNonQuery(SPUpdateSceneState, paras);
        }

        public static int AddHistoryServiceFromStocks(string eventNo, string serviceDate)
        {
            SqlParameter[] paras = {
                                       new SqlParameter("@eventNo",eventNo),
                                       new SqlParameter("@serviceDate",serviceDate)
                                   };
            return Common.SqlHelper.ExecuteNonQuery(SPAddHistoryServiceFromStocks, paras);
        }

        public static DataSet GetHistoryServiceByEventNo(string eventNo)
        {
            SqlParameter[] paras = {
                                     new SqlParameter("@eventNo",eventNo)
            };
            DataSet ds = null;
            ds = Common.SqlHelper.ExecuteDataSet(SPGetHistoryServiceByEventNo, paras);
            return ds;
        }
    }
}
