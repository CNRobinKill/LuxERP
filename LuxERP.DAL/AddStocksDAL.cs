using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LuxERP.DAL
{
    public class AddStocksDAL
    {
        private const string SPGetAddStocks = "GetAddStocks";
        private const string SPGetAddStocksPaged = "GetAddStocksPaged";

        public static DataSet GetAddStocks(
                        string warehouseNo,
                        string maching,
                        string brand,
                        string model,
                        string parameter,
                        string supplier,
                        string addStockDateA,
                        string addStockDateB
            )
        {
            SqlParameter[] paras = {
                                       new SqlParameter("@warehouseNo",warehouseNo),
                                       new SqlParameter("@maching",maching),
                                       new SqlParameter("@brand",brand),
                                       new SqlParameter("@model",model),
                                       new SqlParameter("@parameter",parameter),
                                       new SqlParameter("@supplier",supplier),
                                       new SqlParameter("@addStockDateA",addStockDateA),
                                       new SqlParameter("@addStockDateB",addStockDateB)
                                   };
            return Common.SqlHelper.ExecuteDataSet(SPGetAddStocks, paras);
        }

        public static DataSet GetAddStocksPaged(
                        string warehouseNo,
                        string maching,
                        string brand,
                        string model,
                        string parameter,
                        string supplier,
                        string addStockDateA,
                        string addStockDateB,
                        int pageSize,
                        int pageIndex)
        {
            SqlParameter[] paras = {                                      
                                       new SqlParameter("@warehouseNo",warehouseNo),
                                       new SqlParameter("@maching",maching),
                                       new SqlParameter("@brand",brand),
                                       new SqlParameter("@model",model),
                                       new SqlParameter("@parameter",parameter),
                                       new SqlParameter("@supplier",supplier),
                                       new SqlParameter("@addStockDateA",addStockDateA),
                                       new SqlParameter("@addStockDateB",addStockDateB),
                                       new SqlParameter("@pageSize",pageSize),
                                       new SqlParameter("@pageIndex",pageIndex)
                                   };
            return Common.SqlHelper.ExecuteDataSet(SPGetAddStocksPaged, paras);
        }
    }
}
