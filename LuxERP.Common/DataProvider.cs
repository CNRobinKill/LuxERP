using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LuxERP.DAL.Common
{
    
    public class DataProvider
    {
        //private const string ConStr = "server=.;Database=LUXERP;User ID=sa;Password=Sikong1986;Max Pool Size = 512;Connection Timeout=15;";
        //private const string ConStr = "Data Source=10.15.130.78,51433;Initial Catalog=LUXERP;User ID=sa;Password=portal123;Max Pool Size = 512;Connection Timeout=15;";
        private const string ConStr = "server=.;Database=LUXERP;User ID=sa;Password=1q2w3e4r;Max Pool Size = 512;";
        //private const string ConStr = @"server=RICHARD-PC\FINKLE;Database=LUXERP;User ID=sa;Password=1q2w3e4r";
        //private const string ConStr = @"server=ROBIN-PC;Database=LUXERP;User ID=sa;Password=1q2w3e4r";
        
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConStr);  
        }
    }
}
