using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LuxERP.DAL
{
    public class FacilityDAL
    {
        private const string SPAddMaching = "AddMaching";
        private const string SPGetMaching = "GetMaching";
        private const string SPDelMaching = "DelMaching";

        private const string SPAddBrand = "AddBrand";
        private const string SPGetBrand = "GetBrand";
        private const string SPDelBrand = "DelBrand";

        private const string SPAddModel = "AddModel";
        private const string SPGetModel = "GetModel";
        private const string SPDelModel = "DelModel";

        private const string SPAddParameter = "AddParameter";
        private const string SPGetParameter = "GetParameter";
        private const string SPDelParameter = "DelParameter";

        private const string SPAddSupplier = "AddSupplier";
        private const string SPGetSupplier = "GetSupplier";
        private const string SPDelSupplier = "DelSupplier";

        // maching
        public static int AddMaching(string maching)
        {
            SqlParameter[] paras = { 
                                       new SqlParameter("@maching",maching)
                                   };
            return Common.SqlHelper.ExecuteNonQuery(SPAddMaching, paras);
        }

        public static DataSet GetMaching()
        {
            return Common.SqlHelper.ExecuteDataSet(SPGetMaching, null);
        }

        public static int DelMaching(string maching)
        {
            SqlParameter[] paras = {
                                       new SqlParameter("@maching",maching)
                                   };
            return Common.SqlHelper.ExecuteNonQuery(SPDelMaching, paras);
        }

        // brand
        public static int AddBrand(string brand)
        {
            SqlParameter[] paras = { 
                                       new SqlParameter("@brand",brand)
                                   };
            return Common.SqlHelper.ExecuteNonQuery(SPAddBrand, paras);
        }

        public static DataSet GetBrand()
        {
            return Common.SqlHelper.ExecuteDataSet(SPGetBrand, null);
        }

        public static int DelBrand(string brand)
        {
            SqlParameter[] paras = {
                                       new SqlParameter("@brand",brand)
                                   };
            return Common.SqlHelper.ExecuteNonQuery(SPDelBrand, paras);
        }

        // model
        public static int AddModel(string model)
        {
            SqlParameter[] paras = { 
                                       new SqlParameter("@model",model)
                                   };
            return Common.SqlHelper.ExecuteNonQuery(SPAddModel, paras);
        }

        public static DataSet GetModel()
        {
            return Common.SqlHelper.ExecuteDataSet(SPGetModel, null);
        }

        public static int DelModel(string model)
        {
            SqlParameter[] paras = {
                                       new SqlParameter("@model",model)
                                   };
            return Common.SqlHelper.ExecuteNonQuery(SPDelModel, paras);
        }

        // parameter
        public static int AddParameter(string parameter)
        {
            SqlParameter[] paras = { 
                                       new SqlParameter("@parameter",parameter)
                                   };
            return Common.SqlHelper.ExecuteNonQuery(SPAddParameter, paras);
        }

        public static DataSet GetParameter()
        {
            return Common.SqlHelper.ExecuteDataSet(SPGetParameter, null);
        }

        public static int DelParameter(string parameter)
        {
            SqlParameter[] paras = {
                                       new SqlParameter("@parameter",parameter)
                                   };
            return Common.SqlHelper.ExecuteNonQuery(SPDelParameter, paras);
        }

        // supplier
        public static int AddSupplier(string supplier)
        {
            SqlParameter[] paras = { 
                                       new SqlParameter("@supplier",supplier)
                                   };
            return Common.SqlHelper.ExecuteNonQuery(SPAddSupplier, paras);
        }

        public static DataSet GetSupplier()
        {
            return Common.SqlHelper.ExecuteDataSet(SPGetSupplier, null);
        }

        public static int DelSupplier(string supplier)
        {
            SqlParameter[] paras = {
                                       new SqlParameter("@supplier",supplier)
                                   };
            return Common.SqlHelper.ExecuteNonQuery(SPDelSupplier, paras);
        }




        private const string SPAddFacility = "AddFacility";
        private const string SPGetMachingFromFacility = "GetMachingFromFacility";
        private const string SPGetBrandFromFacility = "GetBrandFromFacility";
        private const string SPGetModelFromFacility = "GetModelFromFacility";
        private const string SPGetParameterFromFacility = "GetParameterFromFacility";
        private const string SPDelFacility = "DelFacility";


        public static int AddFacility(string maching, string brand, string model, string parameter)
        {
            SqlParameter[] paras = { 
                                        new SqlParameter("@maching",maching),
                                        new SqlParameter("@brand",brand),
                                        new SqlParameter("@model",model),
                                        new SqlParameter("@parameter",parameter)
                                   };
            return Common.SqlHelper.ExecuteNonQuery(SPAddFacility, paras);
        }

        public static DataSet GetMachingFromFacility()
        {
            return Common.SqlHelper.ExecuteDataSet(SPGetMachingFromFacility, null);
        }

        public static DataSet GetBrandFromFacility(string maching)
        {
            SqlParameter[] paras = {
                                        new SqlParameter("@maching",maching)
                                   };
            return Common.SqlHelper.ExecuteDataSet(SPGetBrandFromFacility, paras);
        }

        public static DataSet GetModelFromFacility(string maching, string brand)
        {
            SqlParameter[] paras = {
                                        new SqlParameter("@maching",maching),
                                        new SqlParameter("@brand",brand)
                                   };
            return Common.SqlHelper.ExecuteDataSet(SPGetModelFromFacility, paras);
        }

        public static DataSet GetParameterFromFacility(string maching, string brand, string model)
        {
            SqlParameter[] paras = {
                                        new SqlParameter("@maching",maching),
                                        new SqlParameter("@brand",brand),
                                        new SqlParameter("@model",model)
                                   };
            return Common.SqlHelper.ExecuteDataSet(SPGetParameterFromFacility, paras);
        }

        public static int DelFacility(string maching, string brand, string model, string parameter)
        {
            SqlParameter[] paras = {
                                        new SqlParameter("@maching",maching),
                                        new SqlParameter("@brand",brand),
                                        new SqlParameter("@model",model),
                                        new SqlParameter("@parameter",parameter)
                                   };
            return Common.SqlHelper.ExecuteNonQuery(SPDelFacility, paras);
        }
    }
}
