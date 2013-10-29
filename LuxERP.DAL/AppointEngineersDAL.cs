using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LuxERP.DAL
{
    public class AppointEngineersDAL
    {
        private const string SPAddAppointEngineers = "AddAppointEngineers";
        private const string SPGetAppointEngineersByEventNo = "GetAppointEngineersByEventNo";
        private const string SPGetEmailFromEngineers = "GetEmailFromEngineers";
        private const string SPUpdateAppointState = "UpdateAppointState";

        public static int AddAppointEngineers(string eventNo, string name, string appointState)
        {
            SqlParameter[] paras = {
                                       new SqlParameter("@eventNo",eventNo),
                                       new SqlParameter("@name",name),                                   
                                       new SqlParameter("@appointState",appointState)
                                   };
            return Common.SqlHelper.ExecuteNonQuery(SPAddAppointEngineers, paras);
        }

        public static DataSet GetAppointEngineersByEventNo(string eventNo)
        {
            SqlParameter[] paras = {
	            new SqlParameter("@eventNo",eventNo)
            };
            return Common.SqlHelper.ExecuteDataSet(SPGetAppointEngineersByEventNo, paras);
        }

        public static SqlDataReader GetEmailFromEngineers(string eventNo)
        {
            SqlParameter[] paras = {
	            new SqlParameter("@eventNo",eventNo)
            };
            return Common.SqlHelper.ExecuteReader(SPGetEmailFromEngineers, paras);

        }

        public static int UpdateAppointState(int id, string sceneTime, string appointState)
        {
            SqlParameter[] paras = {
                                       new SqlParameter("@id",id),
                                       new SqlParameter("@sceneTime",sceneTime),
                                       new SqlParameter("@appointState",appointState)
                                   };
            return Common.SqlHelper.ExecuteNonQuery(SPUpdateAppointState, paras);
        }
    }
}
