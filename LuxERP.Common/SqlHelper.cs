using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace LuxERP.DAL.Common
{    
  
    public class SqlHelper
    {        
        public static DataSet ExecuteDataSet(string spName,SqlParameter[] paras)
        {
            DataSet ds = new DataSet();
            //1.购买配件
            using (SqlConnection con = DataProvider.GetConnection())
            {
                using (SqlCommand com = new SqlCommand())
                {
                    SqlDataAdapter ad = new SqlDataAdapter();
                    
                    //2.组装配件
                    com.Connection = con;
                    ad.SelectCommand = com;
                    //3.初始化配件(指令文本，指令类型，参数输入）
                    com.CommandText = spName;
                    com.CommandType = CommandType.StoredProcedure;
                    com.CommandTimeout = 300;
                    //如果有参数，还需要加入参数
                    if (paras != null)
                    {
                        com.Parameters.AddRange(paras);
                    }
                    //4.进行数据访问操作
                    con.Open();
                    ad.Fill(ds);
                    con.Close();                    
                }
            }
            
            return ds;
        }

        
        public static SqlDataReader ExecuteReader(string spName, SqlParameter[] paras)
        {
                    
            //1.购买配件
            
                SqlConnection con = DataProvider.GetConnection();
                SqlCommand com = new SqlCommand();
                //2.组装配件
                com.Connection = con;
                //3.初始化配件
                com.CommandText = spName;
                com.CommandType = CommandType.StoredProcedure;
                com.CommandTimeout = 300;
                //如果有参数，还需要加入参数
                if (paras != null)
                {
                    com.Parameters.AddRange(paras);
                }
                //4.进行数据访问操作
                con.Open();
                SqlDataReader reader = com.ExecuteReader(CommandBehavior.CloseConnection);
                
                
                return reader;                                              
                       
        }

       
        public static object ExecuteScalar(string spName, SqlParameter[] paras)
        {
            object objectValue;
            //1.购买配件
            using (SqlConnection con = DataProvider.GetConnection())
            {
                using (SqlCommand com = new SqlCommand())
                {
                    //2.组装配件
                    com.Connection = con;
                    //3.初始化配件
                    com.CommandText = spName;
                    com.CommandType = CommandType.StoredProcedure;
                    //如果有参数，还需要加入参数
                    if (paras != null)
                    {
                        com.Parameters.AddRange(paras);
                    }
                    //4.进行数据访问操作
                    con.Open();
                    objectValue = com.ExecuteScalar();
                    con.Close();                    
                }
            }
            return objectValue;            
        }

        
        public static int ExecuteNonQuery(string spName, SqlParameter[] paras)
        {
            int rowsAffected;
            //1.购买配件
            using (SqlConnection con = DataProvider.GetConnection())
            {
                using (SqlCommand com = new SqlCommand())
                {
                    //2.组装配件
                    com.Connection = con;
                    //3.初始化配件
                    com.CommandText = spName;
                    com.CommandType = CommandType.StoredProcedure;
                    if (paras != null)
                    {
                        com.Parameters.AddRange(paras);
                    }
                    //4.进行数据访问操作
                    con.Open();
                    rowsAffected = com.ExecuteNonQuery();
                    con.Close();                    
                }
            }
            return rowsAffected;
        }
    }
}
