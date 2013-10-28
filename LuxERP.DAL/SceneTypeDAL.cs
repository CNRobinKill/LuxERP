using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LuxERP.DAL
{
    public class SceneTypeDAL
    {

        private const string SPAddSceneType = "AddSceneType";
        private const string SPGetSceneType = "GetSceneType";
        private const string SPGetTypeName = "GetTypeName";
        private const string SPDelSceneType = "DelSceneType";


        public static int AddSceneType(string typeName, string baseToken, string computingMethod)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@typeName",typeName),
                new SqlParameter("@baseToken",baseToken),
                new SqlParameter("@computingMethod",computingMethod)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPAddSceneType, paras);
        }

        public static DataSet GetSceneType()
        {
            DataSet ds = null;
            ds = Common.SqlHelper.ExecuteDataSet(SPGetSceneType, null);
            return ds;
        }

        public static DataSet GetTypeName()
        {
            DataSet ds = null;
            ds = Common.SqlHelper.ExecuteDataSet(SPGetTypeName, null);
            return ds;
        }

        public static int DelSceneType(string typeName)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@typeName",typeName)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPDelSceneType, paras);
        }

    }

}
