using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LuxERP.DAL
{
    public class StoresDAL
    {
        private const string SPGetRegionByStoreNo = "GetRegionByStoreNo";
        private const string SPGetStoresByStoreNo = "GetStoresByStoreNo";
        private const string SPAddStores = "AddStores";
        private const string SPGetStores = "GetStores";
        private const string SPUpdateStores = "UpdateStores";
        private const string SPUpdateStoresState = "UpdateStoresState";
        private const string SPDelStores = "DelStores";
        

        public static object GetRegionByStoreNo(string storeNo)
        {
            SqlParameter[] paras = {
	            new SqlParameter("@storeNo",storeNo)
            };
            return Common.SqlHelper.ExecuteScalar(SPGetRegionByStoreNo, paras);
        }

        public static SqlDataReader GetStoresByStoreNo(string storeNo)
        {
            SqlParameter[] paras = {
	            new SqlParameter("@storeNo",storeNo)
            };
            return Common.SqlHelper.ExecuteReader(SPGetStoresByStoreNo, paras);
        }

        public static int AddStores(string storeNo, string storeType, string region,
            string storeName, string city, string storeAddress, string storeTel, string aDSLNo, string contractArea, string opeingDate, string storeState)
        {
            SqlParameter[] paras = {
                                       new SqlParameter("@storeNo",storeNo),
                                       new SqlParameter("@storeType",storeType),
                                       new SqlParameter("@region",region),
                                       new SqlParameter("@storeName",storeName),
                                       new SqlParameter("@city",city),
                                       new SqlParameter("@storeAddress",storeAddress),
                                       new SqlParameter("@storeTel",storeTel),
                                       new SqlParameter("@aDSLNo",aDSLNo),
                                       new SqlParameter("@contractArea",contractArea),
                                       new SqlParameter("@opeingDate",opeingDate),
                                       new SqlParameter("@storeState",storeState)
                                   };
            return Common.SqlHelper.ExecuteNonQuery(SPAddStores, paras);
        }

        public static DataSet GetStores(string storeNo, string storeType, string region, string storeTel, string storeName, string storeState)
        {
            SqlParameter[] paras = {
                                       new SqlParameter("@storeNo",storeNo),
                                       new SqlParameter("@storeType",storeType),
                                       new SqlParameter("@region",region),
                                       new SqlParameter("@storeTel",storeTel),
                                       new SqlParameter("@storeName",storeName),
                                       new SqlParameter("@storeState",storeState)
                                   };
            return Common.SqlHelper.ExecuteDataSet(SPGetStores, paras);
        }

        public static int UpdateStores(string storeNo, string storeType, string region,
            string storeName, string city, string storeAddress, string storeTel, string aDSLNo, string contractArea, string opeingDate, string storeState)
        {
            SqlParameter[] paras = {
                                       new SqlParameter("@storeNo",storeNo),
                                       new SqlParameter("@storeType",storeType),
                                       new SqlParameter("@region",region),
                                       new SqlParameter("@storeName",storeName),
                                       new SqlParameter("@city",city),
                                       new SqlParameter("@storeAddress",storeAddress),
                                       new SqlParameter("@storeTel",storeTel),
                                       new SqlParameter("@aDSLNo",aDSLNo),
                                       new SqlParameter("@contractArea",contractArea),
                                       new SqlParameter("@opeingDate",opeingDate),
                                       new SqlParameter("@storeState",storeState)
                                   };
            return Common.SqlHelper.ExecuteNonQuery(SPUpdateStores, paras);
        }

        public static int UpdateStoresState(string storeNo, string storeState)
        {
            SqlParameter[] paras = {
                                       new SqlParameter("@storeNo",storeNo),
                                       new SqlParameter("@storeState",storeState)
                                   };
            return Common.SqlHelper.ExecuteNonQuery(SPUpdateStoresState, paras);
        }

        public static int DelStores(string storeNo)
        {
            SqlParameter[] paras = {
                                       new SqlParameter("@storeNo",storeNo)
                                   };
            return Common.SqlHelper.ExecuteNonQuery(SPDelStores, paras);
        }

    }
}
