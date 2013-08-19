using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LuxERP.DAL
{
    public class SynthesisDAL
    {
        private const string SPAddSolver = "AddSolver";
        private const string SPGetSolver = "GetSolver";
        private const string SPGetAllSolver = "GetAllSolver";
        private const string SPGetSolverByEventType = "GetSolverByEventType";
        private const string SPGetSolverChangeHandingBy = "GetSolverChangeHandingBy";
        private const string SPGetStockIn = "GetStockIn";
         
        private const string SPUpdateSolver = "UpdateSolver";
        private const string SPDelSolver = "DelSolver";
        private const string SPAddExpressCo = "AddExpressCo";
        private const string SPGetExpressCo = "GetExpressCo";
        private const string SPDelExpressCo = "DelExpressCo";
        private const string SPAddSupplier = "AddSupplier";
        private const string SPGetSupplier = "GetSupplier";
        private const string SPDelSupplier = "DelSupplier";

        public static int AddSolver(string solver)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@solver",solver)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPAddSolver, paras);
        }

        public static DataSet GetSolver()
        {
            DataSet ds = null;
            ds = Common.SqlHelper.ExecuteDataSet(SPGetSolver, null);
            return ds;
        }

        public static DataSet GetAllSolver()
        {
            DataSet ds = null;
            ds = Common.SqlHelper.ExecuteDataSet(SPGetAllSolver, null);
            return ds;
        }

        public static SqlDataReader GetSolverByEventType(string typeCode)
        {
            SqlParameter[] paras = {
	            new SqlParameter("@typeCode",typeCode)
            };
            return Common.SqlHelper.ExecuteReader(SPGetSolverByEventType, paras);

        }

        public static SqlDataReader GetSolverChangeHandingBy(string handingBy,string typeCode)
        {
            SqlParameter[] paras = {
                new SqlParameter("@handingBy",handingBy),
	            new SqlParameter("@typeCode",typeCode)
            };
            return Common.SqlHelper.ExecuteReader(SPGetSolverChangeHandingBy, paras);

        }

        public static SqlDataReader GetStockIn(string stockInSolver)
        {
            SqlParameter[] paras = {
                new SqlParameter("@stockInSolver",stockInSolver)
            };
            return Common.SqlHelper.ExecuteReader(SPGetStockIn, paras);

        }

        public static int DelSolver(string solver)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@solver",solver)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPDelSolver, paras);
        }

        public static int UpdateSolver(string solver, string email, string smtp, string epassword, string note)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@solver",solver),
                new SqlParameter("@email",email),
                new SqlParameter("@smtp",smtp),
                new SqlParameter("@epassword",epassword),
                new SqlParameter("@note",note)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPUpdateSolver, paras);
        }

        public static int AddExpressCo(string expressCo)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@expressCo",expressCo)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPAddExpressCo, paras);
        }

        public static DataSet GetExpressCo()
        {
            DataSet ds = null;
            ds = Common.SqlHelper.ExecuteDataSet(SPGetExpressCo, null);
            return ds;
        }

        public static int DelExpressCo(string expressCo)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@expressCo",expressCo)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPDelExpressCo, paras);
        }

        // supplier
        public static int AddSupplier(string supplier)
        {
            SqlParameter[] paras = { 
                                       new SqlParameter("@supplier",supplier)
                                   };
            return Common.SqlHelper.ExecuteNonQuery(SPAddSupplier, paras);
        }

        public static DataSet GetSupplier()
        {
            return Common.SqlHelper.ExecuteDataSet(SPGetSupplier, null);
        }

        public static int DelSupplier(string supplier)
        {
            SqlParameter[] paras = {
                                       new SqlParameter("@supplier",supplier)
                                   };
            return Common.SqlHelper.ExecuteNonQuery(SPDelSupplier, paras);
        }
    }
}
