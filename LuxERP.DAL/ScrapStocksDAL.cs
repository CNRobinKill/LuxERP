using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LuxERP.DAL
{
    public class ScrapStocksDAL
    {
        private const string SPGetScrapStocksTotal = "GetScrapStocksTotal";
        private const string SPGetScrapStocksPaged = "GetScrapStocksPaged";

        public static DataSet GetScrapStocksTotal(string warehouseNo, string maching, string brand, string model, string parameter, string supplier, string addScrapStockDateA, string addScrapStockDateB)
        {
            SqlParameter[] paras = {
                                       new SqlParameter("@warehouseNo",warehouseNo),
                                       new SqlParameter("@maching",maching),
                                       new SqlParameter("@brand",brand),
                                       new SqlParameter("@model",model),
                                       new SqlParameter("@parameter",parameter),
                                       new SqlParameter("@supplier",supplier),
                                       new SqlParameter("@addScrapStockDateA",addScrapStockDateA),
                                       new SqlParameter("@addScrapStockDateB",addScrapStockDateB)
                                   };
            DataSet ds = null;
            ds = Common.SqlHelper.ExecuteDataSet(SPGetScrapStocksTotal, paras);
            return ds;
        }

        public static DataSet GetScrapStocksPaged(string warehouseNo, string maching, string brand, string model, string parameter, string supplier, string addScrapStockDateA, string addScrapStockDateB, int pageSize, int pageIndex)
        {
            SqlParameter[] paras = {
                                       new SqlParameter("@warehouseNo",warehouseNo),
                                       new SqlParameter("@maching",maching),
                                       new SqlParameter("@brand",brand),
                                       new SqlParameter("@model",model),
                                       new SqlParameter("@parameter",parameter),
                                       new SqlParameter("@supplier",supplier),
                                       new SqlParameter("@addScrapStockDateA",addScrapStockDateA),
                                       new SqlParameter("@addScrapStockDateB",addScrapStockDateB),
                                       new SqlParameter("@pageSize",pageSize),
                                       new SqlParameter("@pageIndex",pageIndex)
                                   };
            DataSet ds = null;
            ds = Common.SqlHelper.ExecuteDataSet(SPGetScrapStocksPaged, paras);
            return ds;
        }
    }
}
