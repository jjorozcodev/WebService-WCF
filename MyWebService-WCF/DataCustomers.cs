using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MyWebService_WCF
{
    public class DataCustomers
    {
        public DataSet GetCustomers()
        {
            DataSet dataTable = new DataSet();
            
            using (SqlConnection con = new SqlConnection(
                ConfigurationManager.ConnectionStrings["NorthwindConnection"].ConnectionString))
            {
                con.Open();

                using (SqlDataAdapter sqlAdapter = new SqlDataAdapter("SELECT [CustomerID],[CompanyName],[ContactName],[ContactTitle],[City],[Country] FROM [Northwind].[dbo].[Customers]", con))
                {
                    sqlAdapter.Fill(dataTable);
                }
            }

            return dataTable;
        }
    }
}