using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LuxERP.DAL
{
    public class StocksDAL
    {

        private const string SPAddStocks = "AddStocks";
        private const string SPAddStocksCommitHistory = "AddStocksCommitHistory";
        private const string SPGetStocks = "GetStocks";
        private const string SPUpdateStocksMutualOutStockDemands = "UpdateStocksMutualOutStockDemands";
        private const string SPUpdateStocksMutualFacilityAllot = "UpdateStocksMutualFacilityAllot";
        private const string SPDelStocksMutualFacilityAllot = "DelStocksMutualFacilityAllot";
        private const string SPGetStocksPaged = "GetStocksPaged";
        private const string SPDelStocksBack = "DelStocksBack";
        private const string SPDelStocks = "DelStocks";
        private const string SPGetStocksInID = "GetStocksInID";
        private const string SPDelStocksToScrapInID = "DelStocksToScrapInID";
        

        public static int AddStocks(
                           string WarehouseStoreNo,
                           string Maching,
                           string Brand,
                           string Model,
                           string SerialNo,
                           string Parameter,
                           string EpcTags,
                           string SapNo,
                           string PurchaseDate,
                           string GuaranteeTime,
                           string RepairsNo,
                           string Supplier,
                           string AddStockDate,
                           string OutStockDate,
                           string Operator,
                           string StockType,
                           string MachingState)
        {
            SqlParameter[] paras = {
                                       
                                       new SqlParameter("@WarehouseStoreNo",WarehouseStoreNo),
                                       new SqlParameter("@Maching",Maching),
                                       new SqlParameter("@Brand",Brand),
                                       new SqlParameter("@Model",Model),
                                       new SqlParameter("@SerialNo",SerialNo),
                                       new SqlParameter("@Parameter",Parameter),
                                       new SqlParameter("@EpcTags",EpcTags),
                                       new SqlParameter("@SapNo",SapNo),
                                       new SqlParameter("@PurchaseDate",PurchaseDate),
                                       new SqlParameter("@GuaranteeTime",GuaranteeTime),
                                       new SqlParameter("@RepairsNo",RepairsNo),
                                       new SqlParameter("@Supplier",Supplier),
                                       new SqlParameter("@AddStockDate",AddStockDate),
                                       new SqlParameter("@OutStockDate",OutStockDate),
                                       new SqlParameter("@Operator",Operator),
                                       new SqlParameter("@StockType",StockType),
                                       new SqlParameter("@MachingState",MachingState)
                                   };
            return Common.SqlHelper.ExecuteNonQuery(SPAddStocks, paras);
        }

        public static int AddStocksCommitHistory(
                           string WarehouseStoreNo,
                           string Maching,
                           string Brand,
                           string Model,
                           string SerialNo,
                           string Parameter,
                           string EpcTags,
                           string SapNo,
                           string PurchaseDate,
                           string GuaranteeTime,
                           string RepairsNo,
                           string Supplier,
                           string AddStockDate,
                           string Operator,
                           string StockType,
                           string MachingState)
        {
            SqlParameter[] paras = {
                                       
                                       new SqlParameter("@WarehouseStoreNo",WarehouseStoreNo),
                                       new SqlParameter("@Maching",Maching),
                                       new SqlParameter("@Brand",Brand),
                                       new SqlParameter("@Model",Model),
                                       new SqlParameter("@SerialNo",SerialNo),
                                       new SqlParameter("@Parameter",Parameter),
                                       new SqlParameter("@EpcTags",EpcTags),
                                       new SqlParameter("@SapNo",SapNo),
                                       new SqlParameter("@PurchaseDate",PurchaseDate),
                                       new SqlParameter("@GuaranteeTime",GuaranteeTime),
                                       new SqlParameter("@RepairsNo",RepairsNo),
                                       new SqlParameter("@Supplier",Supplier),
                                       new SqlParameter("@AddStockDate",AddStockDate),
                                       new SqlParameter("@Operator",Operator),
                                       new SqlParameter("@StockType",StockType),
                                       new SqlParameter("@MachingState",MachingState)
                                   };
            return Common.SqlHelper.ExecuteNonQuery(SPAddStocksCommitHistory, paras);
        }

        public static DataSet GetStocks(
                        string eventNo, 
                        string warehouseStoreNo, 
                        string maching, 
                        string brand, 
                        string model,
                        string parameter, 
                        string supplier, 
                        string addStockDateA, 
                        string addStockDateB,
                        string outStockDateA,
                        string outStockDateB,
                        string stockType,
                        string machingState)
        {
            SqlParameter[] paras = {
                                       new SqlParameter("@eventNo",eventNo),
                                       new SqlParameter("@warehouseStoreNo",warehouseStoreNo),
                                       new SqlParameter("@maching",maching),
                                       new SqlParameter("@brand",brand),
                                       new SqlParameter("@model",model),
                                       new SqlParameter("@parameter",parameter),
                                       new SqlParameter("@supplier",supplier),
                                       new SqlParameter("@addStockDateA",addStockDateA),
                                       new SqlParameter("@addStockDateB",addStockDateB),
                                       new SqlParameter("@outStockDateA",outStockDateA),
                                       new SqlParameter("@outStockDateB",outStockDateB),
                                       new SqlParameter("@stockType",stockType),
                                       new SqlParameter("@machingState",machingState)
                                   };
            return Common.SqlHelper.ExecuteDataSet(SPGetStocks, paras);
        }

        public static int UpdateStocksMutualOutStockDemands(string eventNo, string temp)
        {
            SqlParameter[] paras = {
                                       new SqlParameter("@eventNo",eventNo),
                                       new SqlParameter("@temp",temp)
                                   };
            return Common.SqlHelper.ExecuteNonQuery(SPUpdateStocksMutualOutStockDemands, paras);
        }

        public static int UpdateStocksMutualFacilityAllot(string eventNo, string rowID)
        {
            SqlParameter[] paras = {
                                       new SqlParameter("@eventNo",eventNo),
                                       new SqlParameter("@rowID",rowID)
                                   };
            return Common.SqlHelper.ExecuteNonQuery(SPUpdateStocksMutualFacilityAllot, paras);
        }

        public static int DelStocksMutualFacilityAllot(string eventNo)
        {
            SqlParameter[] paras = {
                                       new SqlParameter("@eventNo",eventNo)
                                   };
            return Common.SqlHelper.ExecuteNonQuery(SPDelStocksMutualFacilityAllot, paras);
        }

        public static DataSet GetStocksPaged(
                        string warehouseStoreNo,
                        string maching,
                        string brand,
                        string model,
                        string parameter,
                        string supplier,
                        string addStockDateA,
                        string addStockDateB,
                        string machingState,
                        int pageSize,
                        int pageIndex)
        {
            SqlParameter[] paras = {                                      
                                       new SqlParameter("@warehouseStoreNo",warehouseStoreNo),
                                       new SqlParameter("@maching",maching),
                                       new SqlParameter("@brand",brand),
                                       new SqlParameter("@model",model),
                                       new SqlParameter("@parameter",parameter),
                                       new SqlParameter("@supplier",supplier),
                                       new SqlParameter("@addStockDateA",addStockDateA),
                                       new SqlParameter("@addStockDateB",addStockDateB),
                                       new SqlParameter("@machingState",machingState),
                                       new SqlParameter("@pageSize",pageSize),
                                       new SqlParameter("@pageIndex",pageIndex)
                                   };
            return Common.SqlHelper.ExecuteDataSet(SPGetStocksPaged, paras);
        }

        public static int DelStocksBack(string eventNo)
        {
            SqlParameter[] paras = {
                                       new SqlParameter("@eventNo",eventNo)
                                   };
            return Common.SqlHelper.ExecuteNonQuery(SPDelStocksBack, paras);
        }

        public static int DelStocks(string id)
        {
            SqlParameter[] paras = {
                                       new SqlParameter("@id",id)
                                   };
            return Common.SqlHelper.ExecuteNonQuery(SPDelStocks, paras);
        }

        public static DataSet GetStocksInID(string idTemp)
        {
            SqlParameter[] paras = {
                                       new SqlParameter("@idTemp",idTemp)
                                   };
            return Common.SqlHelper.ExecuteDataSet(SPGetStocksInID, paras);
        }

        public static int DelStocksToScrapInID(string idTemp, string addScrapStockDate, string Operator, string scrapReason)
        {
            SqlParameter[] paras = {
                                       new SqlParameter("@idTemp",idTemp),
                                       new SqlParameter("@addScrapStockDate",addScrapStockDate),
                                       new SqlParameter("@Operator",Operator),
                                       new SqlParameter("@scrapReason",scrapReason)
                                   };
            return Common.SqlHelper.ExecuteNonQuery(SPDelStocksToScrapInID, paras);
        }
        
    }
}
