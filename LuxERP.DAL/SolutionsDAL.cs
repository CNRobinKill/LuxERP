using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// add references
using System.Data;
using System.Data.SqlClient;

namespace LuxERP.DAL
{
    public class SolutionsDAL
    {
        private const string spGetSolutionByID = "sp_GetSolutionByID";
        private const string spUpdateSolution = "sp_UpdateSolution";
        private const string spAddSolution = "sp_AddSolution";
        private const string spDelSolution = "sp_DelSolution";

        public static string GetSolutionByID(string TypeCode)
        {
            SqlParameter[] paras = { 
                                       new SqlParameter("@TypeCode", TypeCode) 
                                   };
            object obj = Common.SqlHelper.ExecuteScalar(spGetSolutionByID, paras);
            if (obj == System.DBNull.Value || (string)obj == "")
            {
                return "请添加内容！！！";
            }

            return (string)obj;
        }

        public static int UpdateSolution(string TypeCode, string Content)
        {
            SqlParameter[] paras = { 
                                     new SqlParameter("@TypeCode",TypeCode),
                                     new SqlParameter("@Content",Content)
                                   };
            return Common.SqlHelper.ExecuteNonQuery(spUpdateSolution, paras);
        }

        public static int AddSolution(string TypeCode)
        {
            SqlParameter[] paras = {
                                     new SqlParameter("@TypeCode",TypeCode)
                                   };
            return Common.SqlHelper.ExecuteNonQuery(spAddSolution, paras);
        }

        public static int DelSolution(string TypeCode)
        {
            SqlParameter[] paras = {
                                     new SqlParameter("@TypeCode",TypeCode)
                                   };
            return Common.SqlHelper.ExecuteNonQuery(spDelSolution, paras);
        }
    }
}
