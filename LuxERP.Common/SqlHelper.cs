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
            //1.�������
            using (SqlConnection con = DataProvider.GetConnection())
            {
                using (SqlCommand com = new SqlCommand())
                {
                    SqlDataAdapter ad = new SqlDataAdapter();
                    
                    //2.��װ���
                    com.Connection = con;
                    ad.SelectCommand = com;
                    //3.��ʼ�����(ָ���ı���ָ�����ͣ��������룩
                    com.CommandText = spName;
                    com.CommandType = CommandType.StoredProcedure;
                    com.CommandTimeout = 300;
                    //����в���������Ҫ�������
                    if (paras != null)
                    {
                        com.Parameters.AddRange(paras);
                    }
                    //4.�������ݷ��ʲ���
                    con.Open();
                    ad.Fill(ds);
                    con.Close();                    
                }
            }
            
            return ds;
        }

        
        public static SqlDataReader ExecuteReader(string spName, SqlParameter[] paras)
        {
                    
            //1.�������
            
                SqlConnection con = DataProvider.GetConnection();
                SqlCommand com = new SqlCommand();
                //2.��װ���
                com.Connection = con;
                //3.��ʼ�����
                com.CommandText = spName;
                com.CommandType = CommandType.StoredProcedure;
                com.CommandTimeout = 300;
                //����в���������Ҫ�������
                if (paras != null)
                {
                    com.Parameters.AddRange(paras);
                }
                //4.�������ݷ��ʲ���
                con.Open();
                SqlDataReader reader = com.ExecuteReader(CommandBehavior.CloseConnection);
                
                
                return reader;                                              
                       
        }

       
        public static object ExecuteScalar(string spName, SqlParameter[] paras)
        {
            object objectValue;
            //1.�������
            using (SqlConnection con = DataProvider.GetConnection())
            {
                using (SqlCommand com = new SqlCommand())
                {
                    //2.��װ���
                    com.Connection = con;
                    //3.��ʼ�����
                    com.CommandText = spName;
                    com.CommandType = CommandType.StoredProcedure;
                    //����в���������Ҫ�������
                    if (paras != null)
                    {
                        com.Parameters.AddRange(paras);
                    }
                    //4.�������ݷ��ʲ���
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
            //1.�������
            using (SqlConnection con = DataProvider.GetConnection())
            {
                using (SqlCommand com = new SqlCommand())
                {
                    //2.��װ���
                    com.Connection = con;
                    //3.��ʼ�����
                    com.CommandText = spName;
                    com.CommandType = CommandType.StoredProcedure;
                    if (paras != null)
                    {
                        com.Parameters.AddRange(paras);
                    }
                    //4.�������ݷ��ʲ���
                    con.Open();
                    rowsAffected = com.ExecuteNonQuery();
                    con.Close();                    
                }
            }
            return rowsAffected;
        }
    }
}
