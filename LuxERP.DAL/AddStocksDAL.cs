using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LuxERP.DAL
{
    /// <summary>
    /// 添加库存
    /// </summary>
    public class AddStocksDAL
    {
        /// <summary>
        /// 引用存储过程
        /// </summary>
        private const string SPGetAddStocks = "GetAddStocks";
        private const string SPGetAddStocksPaged = "GetAddStocksPaged";
        /// <summary>
        /// 获取库存添加历史
        /// </summary>
        /// <param name="warehouseNo">仓库编号</param>
        /// <param name="maching">机器名称</param>
        /// <param name="brand">品牌</param>
        /// <param name="model">型号</param>
        /// <param name="parameter">参数</param>
        /// <param name="supplier">供应商</param>
        /// <param name="addStockDateA">时间区间</param>
        /// <param name="addStockDateB">时间区间</param>
        /// <returns>dataset数据</returns>
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
        /// <summary>
        /// 获取库存添加历史(翻页)
        /// </summary>
        /// <param name="warehouseNo">仓库编号</param>
        /// <param name="maching">机器名称</param>
        /// <param name="brand">品牌</param>
        /// <param name="model">型号</param>
        /// <param name="parameter">参数</param>
        /// <param name="supplier">供应商</param>
        /// <param name="addStockDateA">时间区间</param>
        /// <param name="addStockDateB">时间区间</param>
        /// <param name="pageSize">单页显示量</param>
        /// <param name="pageIndex">页码</param>
        /// <returns>dataset</returns>
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
