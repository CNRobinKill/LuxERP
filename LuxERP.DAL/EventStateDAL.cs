using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LuxERP.DAL
{
    public class EventStateDAL
    {
        private const string SPAddEventState = "AddEventState";
        private const string SPGetEventState = "GetEventState";
        private const string SPDelEventState = "DelEventState";
        private const string SPChangeUpEventState = "ChangeUpEventState";
        private const string SPChangeDownEventState = "ChangeDownEventState";
        private const string SPUpdateEventStateByStateID = "UpdateEventStateByStateID";
        private const string SPGetEventStateByStateID = "GetEventStateByStateID";
        private const string SPGetMinEventState = "GetMinEventState";

        public static int AddEventState(string stateName, int stateDay, string stateType)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@stateName",stateName),
                new SqlParameter("@stateDay",stateDay),
                new SqlParameter("@stateType",stateType)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPAddEventState, paras);
        }

        public static DataSet GetEventState(string stateType)
        {
            SqlParameter[] paras = { 
                new SqlParameter("@stateType",stateType)
            };
            DataSet ds = null;
            ds = Common.SqlHelper.ExecuteDataSet(SPGetEventState, paras);
            return ds;
        }

        public static int DelEventState(string stateType, int stateID)
        {
            SqlParameter[] paras = { 
                new SqlParameter("@stateType",stateType),
                new SqlParameter("@stateID",stateID)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPDelEventState, paras);
        }

        public static int ChangeUpEventState(int stateID)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@stateID",stateID)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPChangeUpEventState, paras);
        }

        public static int ChangeDownEventState(int stateID)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@stateID",stateID)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPChangeDownEventState, paras);
        }

        public static int UpdateEventStateByStateID(int stateID, string stateName, int stateDay)
        {
            SqlParameter[] paras = { 
                new SqlParameter("@stateID",stateID),
	            new SqlParameter("@stateName",stateName),
                new SqlParameter("@stateDay",stateDay)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPUpdateEventStateByStateID, paras);
        }

        public static DataSet GetEventStateByStateID(int stateID, string stateType)
        {
            SqlParameter[] paras = { 
                new SqlParameter("@stateID",stateID),
                new SqlParameter("@stateType",stateType)
            };
            DataSet ds = null;
            ds = Common.SqlHelper.ExecuteDataSet(SPGetEventStateByStateID, paras);
            return ds;
        }

        public static int GetMinEventState(string stateType)
        {
            SqlParameter[] paras = { 
                new SqlParameter("@stateType",stateType)
            };
            return (int)Common.SqlHelper.ExecuteScalar(SPGetMinEventState, paras);
        }
    }
}
