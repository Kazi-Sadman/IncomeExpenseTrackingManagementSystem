using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IncomeExpenseTrackingManagementSystem
{
    internal class DatabaseHelper
    {
        private SqlConnection connection;

        private string connectionString =
           @"Server=.\SQLEXPRESS;Database=IncomeExpenseTrackingManagementSystem;Trusted_Connection=True;";


        public void OpenConnection()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        public void CloseConnection()
        {
            if (connection != null)
                connection.Close();
        }

        public DataTable GetDataTable(string query)
        {
            DataTable table = new DataTable();

            try
            {
                OpenConnection();
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseConnection();
            }

            return table;
        }

        public bool InsertUpdateDelete(string query)
        {
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand(query, connection);
                int rows = command.ExecuteNonQuery();
                return rows > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
