using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LuxERP.DAL
{
    public class MultiplyingPowerTypeDAL
    {
        
        private const string SPAddMultiplyingPowerType = "AddMultiplyingPowerType";
        private const string SPGetMultiplyingPowerType = "GetMultiplyingPowerType";
        private const string SPDelMultiplyingPowerType = "DelMultiplyingPowerType";


        public static int AddMultiplyingPowerType(string typeName, string multiplyingPower)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@typeName",typeName),
                new SqlParameter("@multiplyingPower",multiplyingPower)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPAddMultiplyingPowerType, paras);
        }

        public static DataSet GetMultiplyingPowerType()
        {
            DataSet ds = null;
            ds = Common.SqlHelper.ExecuteDataSet(SPGetMultiplyingPowerType, null);
            return ds;
        }

        public static int DelMultiplyingPowerType(string typeName)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@typeName",typeName)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPDelMultiplyingPowerType, paras);
        }

    }
}
