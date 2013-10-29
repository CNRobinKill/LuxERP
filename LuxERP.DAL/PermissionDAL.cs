using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LuxERP.DAL
{
    public class PermissionDAL
    {
        private const string SPGetOnePermission = "GetOnePermission";
        private const string SPGetPermission = "GetPermission";
        private const string SPUpdatePermissionByUserName = "UpdatePermissionByUserName";


        public static string GetOnePermission(string userName, string temp)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@userName",userName),
                new SqlParameter("@temp",temp)
            };
            return Common.SqlHelper.ExecuteScalar(SPGetOnePermission, paras).ToString();
        }

        public static SqlDataReader GetPermission(string userName)
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@userName",userName)
            };
            return Common.SqlHelper.ExecuteReader(SPGetPermission, paras);
        }

        public static int UpdatePermissionByUserName(
                string userName,
                int index,
	            int updateSolution,
	            int eventQuery,
	            int createEvent,
	            int reportFormsEvent,
	            int addStock,
	            int stockQuery,
	            int outStockQuery,
	            int allotStockQuery,
	            int addStockQuery,
	            int alterStore,
	            int eventTypes,
	            int facilityManage,
	            int peopleManage,
	            int synthesisManage,
	            int eventState,
	            int initialStores,
	            int initialStocks,
                int scrapStocks,
                int sceneToken,
                int sceneInformation,
                int sceneServiceProvider,
                int areaInformation
            )
        {
            SqlParameter[] paras = { 
	            new SqlParameter("@userName",userName),
                new SqlParameter("@index",index),
	            new SqlParameter("@updateSolution",updateSolution),
	            new SqlParameter("@eventQuery",eventQuery),
	            new SqlParameter("@createEvent",createEvent),
	            new SqlParameter("@reportFormsEvent",reportFormsEvent),
	            new SqlParameter("@addStock",addStock),
	            new SqlParameter("@stockQuery",stockQuery),
	            new SqlParameter("@outStockQuery",outStockQuery),
	            new SqlParameter("@allotStockQuery",allotStockQuery),
	            new SqlParameter("@addStockQuery",addStockQuery),
	            new SqlParameter("@alterStore",alterStore),
	            new SqlParameter("@eventTypes",eventTypes),
	            new SqlParameter("@facilityManage",facilityManage),
	            new SqlParameter("@peopleManage",peopleManage),
	            new SqlParameter("@synthesisManage",synthesisManage),
	            new SqlParameter("@eventState",eventState),
	            new SqlParameter("@initialStores",initialStores),
	            new SqlParameter("@initialStocks",initialStocks),
                new SqlParameter("@scrapStocks",scrapStocks),
                new SqlParameter("@sceneToken",sceneToken),
	            new SqlParameter("@sceneInformation",sceneInformation),
	            new SqlParameter("@sceneServiceProvider",sceneServiceProvider),
                new SqlParameter("@areaInformation",areaInformation)
            };
            return Common.SqlHelper.ExecuteNonQuery(SPUpdatePermissionByUserName, paras);
        }
        
    }
}
