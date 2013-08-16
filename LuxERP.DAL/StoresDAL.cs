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

        public static int AddStores(string storeNo, string topStore, string storeType, string region, string rating,
            string storeName, string city, string storeAddress, string storeTel, string contractArea, string opeingDate, string storeState)
        {
            SqlParameter[] paras = {
                                       new SqlParameter("@storeNo",storeNo),
                                       new SqlParameter("@topStore",topStore),
                                       new SqlParameter("@storeType",storeType),
                                       new SqlParameter("@region",region),
                                       new SqlParameter("@rating",rating),
                                       new SqlParameter("@storeName",storeName),
                                       new SqlParameter("@city",city),
                                       new SqlParameter("@storeAddress",storeAddress),
                                       new SqlParameter("@storeTel",storeTel),
                                       new SqlParameter("@contractArea",contractArea),
                                       new SqlParameter("@opeingDate",opeingDate),
                                       new SqlParameter("@storeState",storeState)
                                   };
            return Common.SqlHelper.ExecuteNonQuery(SPAddStores, paras);
        }

        public static DataSet GetStores(string storeNo, string topStore, string storeType, string region, string rating,
            string opeingDateF, string opeingDateT, string storeState)
        {
            SqlParameter[] paras = {
                                       new SqlParameter("@storeNo",storeNo),
                                       new SqlParameter("@topStore",topStore),
                                       new SqlParameter("@storeType",storeType),
                                       new SqlParameter("@region",region),
                                       new SqlParameter("@rating",rating),
                                       new SqlParameter("@opeingDateF",opeingDateF),
                                       new SqlParameter("@opeingDateT",opeingDateT),
                                       new SqlParameter("@storeState",storeState)
                                   };
            return Common.SqlHelper.ExecuteDataSet(SPGetStores, paras);
        }

        public static int UpdateStores(string storeNo, string topStore, string storeType, string region, string rating,
            string storeName, string city, string storeAddress, string storeTel, string contractArea, string opeingDate, string storeState)
        {
            SqlParameter[] paras = {
                                       new SqlParameter("@storeNo",storeNo),
                                       new SqlParameter("@topStore",topStore),
                                       new SqlParameter("@storeType",storeType),
                                       new SqlParameter("@region",region),
                                       new SqlParameter("@rating",rating),
                                       new SqlParameter("@storeName",storeName),
                                       new SqlParameter("@city",city),
                                       new SqlParameter("@storeAddress",storeAddress),
                                       new SqlParameter("@storeTel",storeTel),
                                       new SqlParameter("@contractArea",contractArea),
                                       new SqlParameter("@opeingDate",opeingDate),
                                       new SqlParameter("@storeState",storeState)
                                   };
            return Common.SqlHelper.ExecuteNonQuery(SPUpdateStores, paras);
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
