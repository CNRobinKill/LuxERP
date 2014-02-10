using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LuxERP.DAL
{
    /// <summary>
    /// 调拨库存
    /// </summary>
    public class AllotStocksDAL
    {
        /// <summary>
        /// 引用存储过程
        /// </summary>
        private const string SPAddAllAllotStocksFromStocks = "AddAllAllotStocksFromStocks";
        private const string SPAddAllotStocksFromStocks = "AddAllotStocksFromStocks";
        private const string SPGetAllotStocks = "GetAllotStocks";
        private const string SPGetCountAllotStocksState = "GetCountAllotStocksState";
        private const string SPGetAllotStocksTotal = "GetAllotStocksTotal";
        private const string SPGetAllotStocksPaged = "GetAllotStocksPaged";
        /// <summary>
        /// 调拨历史
        /// </summary>
        /// <param name="eventNo">事件编号</param>
        /// <param name="warehouseStoreNoB">目标仓库</param>
        /// <param name="allotStockDate">调拨时间</param>
        /// <param name="Operator">操作人</param>
        /// <param name="allotStockState">调拨状态</param>
        /// <returns>int</returns>
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
        /// <summary>
        /// 添加调拨历史
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="warehouseStoreNoB">目标仓库</param>
        /// <param name="allotStockDate">调拨时间</param>
        /// <param name="Operator">操作人</param>
        /// <param name="allotStockState">调拨状态</param>
        /// <param name="scrapReason">调拨原因</param>
        /// <returns>int</returns>
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
        /// <summary>
        ///获取调拨历史
        /// </summary>
        /// <param name="eventNo">事件编号</param>
        /// <returns>DataSet</returns>
        public static DataSet GetAllotStocks(string eventNo)
        {
            SqlParameter[] paras = {
                                     new SqlParameter("@eventNo",eventNo)
            };
            DataSet ds = null;
            ds = Common.SqlHelper.ExecuteDataSet(SPGetAllotStocks, paras);
            return ds;
        }
        /// <summary>
        /// 获取调拨设备
        /// </summary>
        /// <param name="eventNo"></param>
        /// <returns></returns>
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
