using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LuxERP.DAL
{
    public class PeopleDAL
    {
        private const string SPAddPeople = "AddPeople";
        private const string SPGetPeople = "GetPeople";
        private const string SPDelPeople = "DelPeople";
        private const string SPGetNameByPosition = "GetNameByPosition";

        public static int AddPeople(string position, string name, string sex, string phone, string email)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@position",position),
                new SqlParameter("@name",name),
                new SqlParameter("@sex",sex),
                new SqlParameter("@phone",phone),
                new SqlParameter("@email",email)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPAddPeople, paras);
        }

        public static DataSet GetPeople()
        {
            DataSet ds = null;
            ds = Common.SqlHelper.ExecuteDataSet(SPGetPeople, null);
            return ds;
        }

        public static int DelPeople(string name)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@name",name)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPDelPeople, paras);
        }

        public static DataSet GetNameByPosition(string position)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@position",position)
            };
            DataSet ds = null;
            ds = Common.SqlHelper.ExecuteDataSet(SPGetNameByPosition, paras);
            return ds;
        }
    }
}
