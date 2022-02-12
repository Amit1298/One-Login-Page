using ClintManagement.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace ClintManagement.DAL
{
    class ClientDAL
    {
        SqlConnection connection = new SqlConnection(Connection.connectionString);

        //select method
        public DataTable selectData()
        {
            DataTable table = new DataTable();
            try
            {
                string sql = "SELECT *FROM client";
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

        //insert method
        public bool InsertData(ClientBLL client)
        {
            try
            {
                string sql = "INSERT INTO client(name,email,phone,gender,city,address,status,notes,addedDate) VALUES(@name,@email,@phone,@gender,@city,@address,@status,@notes,@addedDate)";
                SqlCommand command = new SqlCommand(sql,connection);
                command.Parameters.AddWithValue("@name", client.Name);
                command.Parameters.AddWithValue("@email", client.Email);
                command.Parameters.AddWithValue("@phone", client.Phone);
                command.Parameters.AddWithValue("@gender", client.Gender);
                command.Parameters.AddWithValue("@city", client.City);
                command.Parameters.AddWithValue("@address", client.Address);
                command.Parameters.AddWithValue("@status", client.Status);
                command.Parameters.AddWithValue("@notes", client.Notes);
                command.Parameters.AddWithValue("@addedDate", client.addedDate);
                connection.Open();
                command.ExecuteNonQuery();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }

        //Update method
        public bool UpdateData(ClientBLL client)
        {
            try
            {
                string sql = "UPDATE client SET name=@name,email=@email,phone=@phone,gender=@gender,city=@city,address=@address,status=@status,notes=@notes,addedDate=@addedDate WHERE id=@id";
                SqlCommand command = new SqlCommand(sql,connection);
                command.Parameters.AddWithValue("@id", client.Id);
                command.Parameters.AddWithValue("@name", client.Name);
                command.Parameters.AddWithValue("@email",client.Email);
                command.Parameters.AddWithValue("@phone", client.Phone);
                command.Parameters.AddWithValue("@gender", client.Gender);
                command.Parameters.AddWithValue("@city", client.City);
                command.Parameters.AddWithValue("@address", client.Address);
                command.Parameters.AddWithValue("@status", client.Status);
                command.Parameters.AddWithValue("@notes", client.Notes);
                command.Parameters.AddWithValue("@addedDate", client.addedDate);
                connection.Open();
                command.ExecuteNonQuery();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }

        //Delete method
        public bool DeleteData(ClientBLL client)
        {
            try
            {
                string sql = "DELETE FROM client WHERE id=@id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", client.Id);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }

        //Search method
        public DataTable SearchData(string keyword)
        {
            DataTable table = new DataTable();
            try
            {
                string sql = "SELECT * FROM client WHERE id LIKE '%"+keyword+"%' OR name LIKE '%"+keyword+"%' OR status = '"+keyword+"' OR city = '"+keyword+"'";
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
    }
}
