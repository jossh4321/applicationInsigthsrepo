using System.Data.SqlClient;
using WebAppPractice.IService;
using WebAppPractice.Model;

namespace WebAppPractice.Services
{
    public class ProductService : IProductService
    {
        public SqlConnection GetConnection()
        {
            string conn = "Server=tcp:sqlserver0200.database.windows.net,1433;Initial Catalog=sql0100;Persist Security Info=False;User ID=sqlusr;Password=PR1M4V3R42023..;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            return new SqlConnection(conn);
        }

        public String GetSlogan()
        {
            return "slogan";
        }

        public List<Product> GetAllProducts()
        {
            List<Product> productList = new List<Product>();
            SqlConnection connection = GetConnection();
            connection.Open();
            string query = "SELECT ProductId, ProductName, Quantity FROM Products";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                productList.Add(new Product()
                {
                    ProductID = reader.GetString(0),
                    ProductName = reader.GetString(1),
                    Quantity = reader.GetInt32(2)
                });
            }
            connection.Close();
            return productList;
        }

        public async Task<bool> IsFeatureFlagEnabled(string featureFlag)
        {
            return false;
        }
    }
}
