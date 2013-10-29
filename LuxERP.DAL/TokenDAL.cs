using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LuxERP.DAL
{
    public class TokenDAL
    {
        private const string SPAddToken = "AddToken";
        private const string SPUpdateToken = "UpdateToken";
        private const string SPGetTokenTotal = "GetTokenTotal";
        private const string SPGetTokenPaged = "GetTokenPaged";



        public static int AddToken(string eventNo)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@eventNo",eventNo)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPAddToken, paras);
        }

        public static int UpdateToken(string eventNo, string timeStart, string timeEnd, string sceneType, string multiplyingPower, string serviceProvider)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@eventNo",eventNo),
                new SqlParameter("@timeStart",timeStart),
                new SqlParameter("@timeEnd",timeEnd),
                new SqlParameter("@sceneType",sceneType),
                new SqlParameter("@multiplyingPower",multiplyingPower),
                new SqlParameter("@serviceProvider",serviceProvider)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPUpdateToken, paras);
        }


        public static DataSet GetTokenTotal(string eventNo, string sceneType, string timeStartA, string timeStartB, string serviceProvider)
        {
            SqlParameter[] paras = {
                                       new SqlParameter("@eventNo",eventNo),
                                       new SqlParameter("@sceneType",sceneType),
                                       new SqlParameter("@timeStartA",timeStartA),
                                       new SqlParameter("@timeStartB",timeStartB),
                                       new SqlParameter("@serviceProvider",serviceProvider)
                                   };
            DataSet ds = null;
            ds = Common.SqlHelper.ExecuteDataSet(SPGetTokenTotal, paras);
            return ds;
        }

        public static DataSet GetTokenPaged(string eventNo, string sceneType, string timeStartA, string timeStartB, string serviceProvider, int pageSize, int pageIndex)
        {
            SqlParameter[] paras = {
                                       new SqlParameter("@eventNo",eventNo),
                                       new SqlParameter("@sceneType",sceneType),
                                       new SqlParameter("@timeStartA",timeStartA),
                                       new SqlParameter("@timeStartB",timeStartB),
                                       new SqlParameter("@serviceProvider",serviceProvider),
                                       new SqlParameter("@pageSize",pageSize),
                                       new SqlParameter("@pageIndex",pageIndex)
                                   };
            DataSet ds = null;
            ds = Common.SqlHelper.ExecuteDataSet(SPGetTokenPaged, paras);
            return ds;
        }

    }
}
