using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace LuxERP.DAL
{
    public class OutStockDemandsDAL
    {
        private const string SPAddOutStockDemands = "AddOutStockDemands";
        private const string SPGetOutStockDemandsByEventNo = "GetOutStockDemandsByEventNo";
        private const string SPDelOutStockDemands = "DelOutStockDemands";
        private const string SPGetNoMatchingByEventNo = "GetNoMatchingByEventNo";
        private const string SPUptateOutStockDemands = "UptateOutStockDemands";

        public static int AddOutStockDemands(string eventNo, string maching, string brand, string model, string parameter)
        {
            SqlParameter[] paras = {
                                     new SqlParameter("@eventNo",eventNo),
                                     new SqlParameter("@maching",maching),
                                     new SqlParameter("@brand",brand),
                                     new SqlParameter("@model",model),
                                     new SqlParameter("@parameter",parameter)
             };
            return Common.SqlHelper.ExecuteNonQuery(SPAddOutStockDemands, paras);
       }

        public static DataSet GetOutStockDemandsByEventNo(string eventNo)
       {
           SqlParameter[] paras = {
                                     new SqlParameter("@eventNo",eventNo)
            };
            DataSet ds = null;
            ds = Common.SqlHelper.ExecuteDataSet(SPGetOutStockDemandsByEventNo, paras);
            return ds;
       }

        public static int DelOutStockDemands(string demandNo)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@demandNo",demandNo)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPDelOutStockDemands, paras);
        }

        public static DataSet GetNoMatchingByEventNo(string eventNo)
        {
            SqlParameter[] paras = {
                                     new SqlParameter("@eventNo",eventNo)
            };
            DataSet ds = null;
            ds = Common.SqlHelper.ExecuteDataSet(SPGetNoMatchingByEventNo, paras);
            return ds;
        }

        public static int UptateOutStockDemands(int id, string eventNo, int demandNo)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@id",id),
                new SqlParameter("@eventNo",eventNo),
                new SqlParameter("@demandNo",demandNo)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPUptateOutStockDemands, paras);
        }
    }
}
