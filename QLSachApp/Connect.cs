using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
namespace QLSachApp
{
    class Connect
    {
        string str;

        public Connect()
        {
            this.str = ConfigurationManager.ConnectionStrings["QLSachApp.Properties.Settings.Setting"].ConnectionString; ;
        }

        public SqlConnection getConnect()
        {
            return new SqlConnection(str);
        }
    }
}
