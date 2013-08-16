using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LuxERP.DAL
{
    public class EventTypesDAL
    {
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

        public static int AddTypeOne(string typeOne)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@typeOne",typeOne)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPAddTypeOne, paras);
        }

        public static DataSet GetTypeOne()
        {
            DataSet ds = null;
            ds = Common.SqlHelper.ExecuteDataSet(SPGetTypeOne,null);
            return ds;           
        }

        public static int DelTypeOne(string typeOne)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@typeOne",typeOne)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPDelTypeOne, paras);
        }

        public static int AddTypeTwo(string typeTwo)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@typeTwo",typeTwo)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPAddTypeTwo, paras);
        }

        public static DataSet GetTypeTwo()
        {
            DataSet ds = null;
            ds = Common.SqlHelper.ExecuteDataSet(SPGetTypeTwo, null);
            return ds;
        }

        public static int DelTypeTwo(string typeTwo)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@typeTwo",typeTwo)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPDelTypeTwo, paras);
        }

        public static int AddTypeThree(string typeThree)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@typeThree",typeThree)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPAddTypeThree, paras);
        }

        public static DataSet GetTypeThree()
        {
            DataSet ds = null;
            ds = Common.SqlHelper.ExecuteDataSet(SPGetTypeThree, null);
            return ds;
        }

        public static int DelTypeThree(string typeThree)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@typeThree",typeThree)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPDelTypeThree, paras);
        }

        public static int AddTypeFour(string typeFour)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@typeFour",typeFour)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPAddTypeFour, paras);
        }

        public static DataSet GetTypeFour()
        {
            DataSet ds = null;
            ds = Common.SqlHelper.ExecuteDataSet(SPGetTypeFour, null);
            return ds;
        }

        public static int DelTypeFour(string typeFour)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@typeFour",typeFour)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPDelTypeFour, paras);
        }

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

        public static DataSet GetEventTypes()
        {
            DataSet ds = null;
            ds = Common.SqlHelper.ExecuteDataSet(SPGetEventTypes, null);
            return ds;
        }

        public static int DelEventTypes(string typeCode)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@typeCode",typeCode)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPDelEventTypes, paras);
        }

        public static SqlDataReader GetEventTypesByTypeCode(string typeCode)
        {
            SqlParameter[] paras = {
	            new SqlParameter("@typeCode",typeCode)
            };
            return Common.SqlHelper.ExecuteReader(SPGetEventTypesByTypeCode, paras);

        }

        public static string GetEventLevelByTypeCode(string typeCode)
        {
            SqlParameter[] paras = {
	            new SqlParameter("@typeCode",typeCode)
            };
            return (string)Common.SqlHelper.ExecuteScalar(SPGetEventLevelByTypeCode, paras);

        }
    }
}
