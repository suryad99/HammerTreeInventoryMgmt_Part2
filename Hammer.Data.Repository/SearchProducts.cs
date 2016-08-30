using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hammer.Data.BusinesssModel;
using System.Data.SqlClient;
using System.Configuration;

namespace Hammer.Data.Repository
{
    public class ProductsSearch
    {
        public DataTable SearchProducts(string criteria)
        {
            DataTable dt = new DataTable();
            try
            {
                string cmdText = String.Format("SELECT * FROM Hammers WHERE HammerName LIKE '%{0}%'", criteria);

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["XYZConnectionString"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand(cmdText, conn);
                    cmd.CommandType = CommandType.Text;

                    conn.Open();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dt;
        }
    }
}
