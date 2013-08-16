using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LuxERP.DAL
{
    public class OutStocksDAL
    {
        private const string SPAddAllOutStocksFromStocks = "AddAllOutStocksFromStocks";
        private const string SPAddOutStocksFromStocks = "AddOutStocksFromStocks";
        private const string SPGetOutStocks = "GetOutStocks";
        private const string SPGetCountOutStocksState = "GetCountOutStocksState";
        private const string SPGetOutStocksTotal = "GetOutStocksTotal";
        private const string SPGetOutStocksPaged = "GetOutStocksPaged";

        public static int AddAllOutStocksFromStocks(string eventNo, string storeNo, string outStockDate, string Operator, string outStocksState)
        {
            SqlParameter[] paras = {
                                     new SqlParameter("@eventNo",eventNo),
                                     new SqlParameter("@storeNo",storeNo),
                                     new SqlParameter("@outStockDate",outStockDate),
                                     new SqlParameter("@operator",Operator),
                                     new SqlParameter("@outStocksState",outStocksState)
             };
            return Common.SqlHelper.ExecuteNonQuery(SPAddAllOutStocksFromStocks, paras);
        }

        public static int AddOutStocksFromStocks(string id, string storeNo, string outStockDate, string Operator, string outStocksState, string scrapReason)
        {
            SqlParameter[] paras = {
                                     new SqlParameter("@id",id),
                                     new SqlParameter("@storeNo",storeNo),
                                     new SqlParameter("@outStockDate",outStockDate),
                                     new SqlParameter("@operator",Operator),
                                     new SqlParameter("@outStocksState",outStocksState),
                                     new SqlParameter("@scrapReason",scrapReason)
             };
            return Common.SqlHelper.ExecuteNonQuery(SPAddOutStocksFromStocks, paras);
        }

        public static DataSet GetOutStocks(string eventNo)
        {
            SqlParameter[] paras = {
                                     new SqlParameter("@eventNo",eventNo)
            };
            DataSet ds = null;
            ds = Common.SqlHelper.ExecuteDataSet(SPGetOutStocks, paras);
            return ds;
        }

        public static int GetCountOutStocksState(string eventNo)
        {
            SqlParameter[] paras = {
                                     new SqlParameter("@eventNo",eventNo)
            };
            return (int)Common.SqlHelper.ExecuteScalar(SPGetCountOutStocksState, paras);
        }

        public static DataSet GetOutStocksTotal(string eventNo, string storeNo, string maching, string brand, string model, string parameter, string supplier, string outstockF, string outstockT, string outStocksState)
        {
            SqlParameter[] paras = {
                                       new SqlParameter("@eventNo",eventNo),
                                       new SqlParameter("@storeNo",storeNo),
                                       new SqlParameter("@maching",maching),
                                       new SqlParameter("@brand",brand),
                                       new SqlParameter("@model",model),
                                       new SqlParameter("@parameter",parameter),
                                       new SqlParameter("@supplier",supplier),
                                       new SqlParameter("@outStockDateA",outstockF),
                                       new SqlParameter("@outStockDateB",outstockT),
                                       new SqlParameter("@outStocksState",outStocksState)
                                   };
            DataSet ds = null;
            ds = Common.SqlHelper.ExecuteDataSet(SPGetOutStocksTotal, paras);
            return ds;
        }

        public static DataSet GetOutStocksPaged(
            string eventNo,
            string storeNo,
            string maching,
            string brand,
            string model,
            string parameter,
            string supplier,
            string outstockF,
            string outstockT,
            string outStocksState,
            int pageSize,
            int pageIndex)
        {
            SqlParameter[] paras = {
                                       new SqlParameter("@eventNo",eventNo),
                                       new SqlParameter("@storeNo",storeNo),
                                       new SqlParameter("@maching",maching),
                                       new SqlParameter("@brand",brand),
                                       new SqlParameter("@model",model),
                                       new SqlParameter("@parameter",parameter),
                                       new SqlParameter("@supplier",supplier),
                                       new SqlParameter("@outStockDateA",outstockF),
                                       new SqlParameter("@outStockDateB",outstockT),
                                       new SqlParameter("@outStocksState",outStocksState),
                                       new SqlParameter("@pageSize",pageSize),
                                       new SqlParameter("@pageIndex",pageIndex)
                                   };
            DataSet ds = null;
            ds = Common.SqlHelper.ExecuteDataSet(SPGetOutStocksPaged, paras);
            return ds;
        }
    }
}
