using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LuxERP.DAL
{
    public class AllotStocksDAL
    {
        private const string SPAddAllAllotStocksFromStocks = "AddAllAllotStocksFromStocks";
        private const string SPAddAllotStocksFromStocks = "AddAllotStocksFromStocks";
        private const string SPGetAllotStocks = "GetAllotStocks";
        private const string SPGetCountAllotStocksState = "GetCountAllotStocksState";
        private const string SPGetAllotStocksTotal = "GetAllotStocksTotal";
        private const string SPGetAllotStocksPaged = "GetAllotStocksPaged";

        public static int AddAllAllotStocksFromStocks(string eventNo, string warehouseStoreNoB, string allotStockDate, string Operator, string allotStockState)
        {
            SqlParameter[] paras = {
                                     new SqlParameter("@eventNo",eventNo),
                                     new SqlParameter("@warehouseStoreNoB",warehouseStoreNoB),
                                     new SqlParameter("@allotStockDate",allotStockDate),
                                     new SqlParameter("@operator",Operator),
                                     new SqlParameter("@allotStockState",allotStockState)
             };
            return Common.SqlHelper.ExecuteNonQuery(SPAddAllAllotStocksFromStocks, paras);
        }

        public static int AddAllotStocksFromStocks(string id, string warehouseStoreNoB, string allotStockDate, string Operator, string allotStockState, string scrapReason)
        {
            SqlParameter[] paras = {
                                     new SqlParameter("@id",id),
                                     new SqlParameter("@warehouseStoreNoB",warehouseStoreNoB),
                                     new SqlParameter("@allotStockDate",allotStockDate),
                                     new SqlParameter("@operator",Operator),
                                     new SqlParameter("@allotStockState",allotStockState),
                                     new SqlParameter("@scrapReason",scrapReason)
             };
            return Common.SqlHelper.ExecuteNonQuery(SPAddAllotStocksFromStocks, paras);
        }

        public static DataSet GetAllotStocks(string eventNo)
        {
            SqlParameter[] paras = {
                                     new SqlParameter("@eventNo",eventNo)
            };
            DataSet ds = null;
            ds = Common.SqlHelper.ExecuteDataSet(SPGetAllotStocks, paras);
            return ds;
        }

        public static int GetCountAllotStocksState(string eventNo)
        {
            SqlParameter[] paras = {
                                     new SqlParameter("@eventNo",eventNo)
            };
            return (int)Common.SqlHelper.ExecuteScalar(SPGetCountAllotStocksState, paras);
        }

        public static DataSet GetAllotStocksTotal(
            string eventNo,
            string storeNoA,
            string storeNoB,
            string maching,
            string brand,
            string model,
            string serialNo,
            string parameter,
            string allotStockDateF,
            string allotStockDateT,
            string operators,
            string allotStockState)
        {
            SqlParameter[] paras = {
                                       new SqlParameter("@eventNo",eventNo),
                                       new SqlParameter("@storeNoA",storeNoA),
                                       new SqlParameter("@storeNoB",storeNoB),
                                       new SqlParameter("@maching",maching),
                                       new SqlParameter("@brand",brand),
                                       new SqlParameter("@model",model),
                                       new SqlParameter("@serialNo",serialNo),
                                       new SqlParameter("@parameter",parameter),
                                       new SqlParameter("@allotStockDateA",allotStockDateF),
                                       new SqlParameter("@allotStockDateB",allotStockDateT),
                                       new SqlParameter("@operator",operators),
                                       new SqlParameter("@allotStockState",allotStockState)
                                   };
            DataSet ds = null;
            ds = Common.SqlHelper.ExecuteDataSet(SPGetAllotStocksTotal, paras);
            return ds;
        }

        public static DataSet GetAllotStocksPaged(
            string eventNo,
            string storeNoA,
            string storeNoB,
            string maching,
            string brand,
            string model,
            string serialNo,
            string parameter,
            string allotStockDateF,
            string allotStockDateT,
            string operators,
            string allotStockState,
            int pageSize,
            int pageIndex)
        {
            SqlParameter[] paras = {
                                       new SqlParameter("@eventNo",eventNo),
                                       new SqlParameter("@storeNoA",storeNoA),
                                       new SqlParameter("@storeNoB",storeNoB),
                                       new SqlParameter("@maching",maching),
                                       new SqlParameter("@brand",brand),
                                       new SqlParameter("@model",model),
                                       new SqlParameter("@serialNo",serialNo),
                                       new SqlParameter("@parameter",parameter),
                                       new SqlParameter("@allotStockDateA",allotStockDateF),
                                       new SqlParameter("@allotStockDateB",allotStockDateT),
                                       new SqlParameter("@operator",operators),
                                       new SqlParameter("@allotStockState",allotStockState),
                                       new SqlParameter("@pageSize",pageSize),
                                       new SqlParameter("@pageIndex",pageIndex)
                                   };
            DataSet ds = null;
            ds = Common.SqlHelper.ExecuteDataSet(SPGetAllotStocksPaged, paras);
            return ds;
        }
    }
}
