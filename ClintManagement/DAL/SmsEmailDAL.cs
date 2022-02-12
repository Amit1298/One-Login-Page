using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace ClintManagement.DAL
{
    class SmsEmailDAL
    {
        SqlConnection connection = new SqlConnection(Connection.connectionString);

        //Select distinct city
        public DataTable UniqueCitySelection()
        {
            DataTable table = new DataTable();
            try
            {
                string sql = "SELECT DISTINCT city FROM client";
                SqlCommand command = new SqlCommand(sql,connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                connection.Open();
                adapter.Fill(table);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return table;
        }

        //Select distinct Status
        public DataTable UniqueStatusSelection()
        {
            DataTable table = new DataTable();
            try
            {
                string sql = "SELECT DISTINCT status FROM client";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                connection.Open();
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return table;
        }
    }
}
