using InternTestWebApp.Models;
using System.Data;
using System.Data.SqlClient;

namespace InternTestWebApp.Repository.cs
{
    public class SalesOrdersRepository
    {
        private SqlConnection _connection;
        public SalesOrdersRepository()
        {
            _connection = new SqlConnection("Server=DESKTOP-BL3N4U5\\WINCC;Database=InternTestDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        public void AddSalesOrder(SalesOrders salesOrder)
        {
            SqlCommand command = new SqlCommand("CreateSalesOrder", _connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@SalesOrder", salesOrder.SalesOrder);
            command.Parameters.AddWithValue("@SalesOrderItem", salesOrder.SalesOrderItem);
            command.Parameters.AddWithValue("@WorkOrder", salesOrder.WorkOrder);
            command.Parameters.AddWithValue("@ProductID", salesOrder.ProductID);
            command.Parameters.AddWithValue("@ProductDescription", salesOrder.ProductDescription);
            command.Parameters.AddWithValue("@OrderQuantity", salesOrder.OrderQuantity);
            command.Parameters.AddWithValue("@OrderStatus", salesOrder.OrderStatus);
            command.Parameters.AddWithValue("@Timestamp", salesOrder.Timestamp);
            _connection.Open();
            command.ExecuteNonQuery();
            _connection.Close();
        }

        public void UpdateSalesOrder(SalesOrders salesOrder)
        {
            SqlCommand command = new SqlCommand("UpdateSalesOrder", _connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", salesOrder.Id);
            command.Parameters.AddWithValue("@SalesOrder", salesOrder.SalesOrder);
            command.Parameters.AddWithValue("@SalesOrderItem", salesOrder.SalesOrderItem);
            command.Parameters.AddWithValue("@WorkOrder", salesOrder.WorkOrder);
            command.Parameters.AddWithValue("@ProductID", salesOrder.ProductID);
            command.Parameters.AddWithValue("@ProductDescription", salesOrder.ProductDescription);
            command.Parameters.AddWithValue("@OrderQuantity", salesOrder.OrderQuantity);
            command.Parameters.AddWithValue("@OrderStatus", salesOrder.OrderStatus);
            command.Parameters.AddWithValue("@Timestamp", salesOrder.Timestamp);
            _connection.Open();
            command.ExecuteNonQuery();
            _connection.Close();
        }   

        public bool DeleteSalesOrder(int id)
        {
            SqlCommand command = new SqlCommand("DeleteSalesOrder", _connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", id);
            _connection.Open();
            int i = command.ExecuteNonQuery();
            _connection.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }   

        public SalesOrders GetSalesOrder(int id)
        {
            SqlCommand command = new SqlCommand("GetSalesOrderById", _connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", id);
            _connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            SalesOrders salesOrder = new SalesOrders();
            while (reader.Read())
            {
                salesOrder.Id = reader.GetInt32(0);
                salesOrder.SalesOrder = reader.GetString(1);
                salesOrder.SalesOrderItem = reader.GetString(2);
                salesOrder.WorkOrder = reader.GetString(3);
                salesOrder.ProductID = reader.GetString(4);
                salesOrder.ProductDescription = reader.GetString(5);
                salesOrder.OrderQuantity = reader.GetDecimal(6);
                salesOrder.OrderStatus = reader.GetString(7);
                salesOrder.Timestamp = reader.GetDateTime(8);
            }
            _connection.Close();
            return salesOrder;
        }   

        public IEnumerable<SalesOrders> GetAllSalesOrders()
        {
            SqlCommand command = new SqlCommand("GetAllSalesOrders", _connection);
            command.CommandType = CommandType.StoredProcedure;
            _connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<SalesOrders> salesOrders = new List<SalesOrders>();
            while (reader.Read())
            {
                SalesOrders salesOrder = new SalesOrders();
                salesOrder.Id = reader.GetInt32(0);
                salesOrder.SalesOrder = reader.GetString(1);
                salesOrder.SalesOrderItem = reader.GetString(2);
                salesOrder.WorkOrder = reader.GetString(3);
                salesOrder.ProductID = reader.GetString(4);
                salesOrder.ProductDescription = reader.GetString(5);
                salesOrder.OrderQuantity = reader.GetDecimal(6);
                salesOrder.OrderStatus = reader.GetString(7);
                salesOrder.Timestamp = reader.GetDateTime(8);
                salesOrders.Add(salesOrder);
            }
            _connection.Close();
            return salesOrders;
        }
    }
}
