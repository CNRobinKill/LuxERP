using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LuxERP.DAL
{
    public class SceneServiceProviderDAL
    {

        private const string SPAddSceneServiceProvider = "AddSceneServiceProvider";
        private const string SPGetSceneServiceProvider = "GetSceneServiceProvider";
        private const string SPGetServiceProvider = "GetServiceProvider";
        private const string SPDelSceneServiceProvider = "DelSceneServiceProvider";
        private const string SPUpdateSceneServiceProvider = "UpdateSceneServiceProvider";
        private const string SPUpdateAddToken = "UpdateAddToken";
        


        public static int AddSceneServiceProvider(string serviceProvider, string phone, string serviceArea, string remainToken)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@serviceProvider",serviceProvider),
                new SqlParameter("@phone",phone),
                new SqlParameter("@serviceArea",serviceArea),
                new SqlParameter("@remainToken",remainToken)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPAddSceneServiceProvider, paras);
        }

        public static DataSet GetSceneServiceProvider()
        {
            DataSet ds = null;
            ds = Common.SqlHelper.ExecuteDataSet(SPGetSceneServiceProvider, null);
            return ds;
        }

        public static DataSet GetServiceProvider()
        {
            DataSet ds = null;
            ds = Common.SqlHelper.ExecuteDataSet(SPGetServiceProvider, null);
            return ds;
        }

        public static int DelSceneServiceProvider(string serviceProvider)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("serviceProvider",serviceProvider)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPDelSceneServiceProvider, paras);
        }

        public static int UpdateSceneServiceProvider(string serviceProvider, string phone, string serviceArea)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@serviceProvider",serviceProvider),
                new SqlParameter("@phone",phone),
                new SqlParameter("@serviceArea",serviceArea)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPUpdateSceneServiceProvider, paras);
        }

        public static int UpdateAddToken(string serviceProvider, string token)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@serviceProvider",serviceProvider),
                new SqlParameter("@token",token)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPUpdateAddToken, paras);
        }

    }
}
