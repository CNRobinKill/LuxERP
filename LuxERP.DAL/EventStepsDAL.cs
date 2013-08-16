using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LuxERP.DAL
{
    public class EventStepsDAL
    {
        private const string SPAddEventSteps = "AddEventSteps";
        private const string SPGetEventStepsByEventNo = "GetEventStepsByEventNo";
        private const string SPUpdateEventSteps = "UpdateEventSteps";

        public static int AddEventSteps(string eventNo, string stepDescribe, string stepTime, string stepState, string stepBy)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@eventNo",eventNo),
                new SqlParameter("@stepDescribe",stepDescribe),
                new SqlParameter("@stepTime",stepTime),
                new SqlParameter("@stepState",stepState),
                new SqlParameter("@stepBy",stepBy)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPAddEventSteps, paras);
        }

        public static DataSet GetEventStepsByEventNo(string eventNo)
        {
            SqlParameter[] paras = { 
                new SqlParameter("@eventNo",eventNo)
            };
            DataSet ds = null;
            ds = Common.SqlHelper.ExecuteDataSet(SPGetEventStepsByEventNo, paras);
            return ds;
        }

        public static int UpdateEventSteps(int id ,string stepDescribe, string stepState)
        {
            SqlParameter[] paras = { 
                new SqlParameter("@id",id),
                new SqlParameter("@stepDescribe",stepDescribe),
                new SqlParameter("@stepState",stepState)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPUpdateEventSteps, paras);
        }
    }
}
