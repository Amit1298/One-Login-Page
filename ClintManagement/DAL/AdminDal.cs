using ClintManagement.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace ClintManagement.DAL
{
    class AdminDal
    {
        SqlConnection connection = new SqlConnection(Connection.connectionString);

        //select data from database
        public DataTable selectData()
        {
            DataTable table = new DataTable();       //datatable is creating a row and column

            try
            {
                string sql = "SELECT * FROM admin";
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


        //Update Method
        public bool UpdateData(adminBll admin)
        {
            try
            {
                string sql = "UPDATE admin SET name=@name, phone=@phone, email=@email, password=@password, addedDate=@addedDate WHERE id=@id";
                SqlCommand command = new SqlCommand(sql,connection);
                command.Parameters.AddWithValue("@id", admin.Id);
                command.Parameters.AddWithValue("@name", admin.Name);
                command.Parameters.AddWithValue("@phone", admin.Phone);
                command.Parameters.AddWithValue("@email", admin.Email);
                command.Parameters.AddWithValue("@password", admin.Password);
                command.Parameters.AddWithValue("@addedDate", admin.AddedDate);
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

        //Insert method
        public bool InsertData(adminBll admin)
        {
            try
            {
                string sql = "INSERT INTO admin(name,phone,email,password,addedDate) VALUES(@name,@phone,@email,@password,@addedDate)";
                SqlCommand command = new SqlCommand(sql,connection);
                command.Parameters.AddWithValue("@name", admin.Name);
                command.Parameters.AddWithValue("@phone", admin.Phone);
                command.Parameters.AddWithValue("@email", admin.Email);
                command.Parameters.AddWithValue("@password", admin.Password);
                command.Parameters.AddWithValue("@addedDate", admin.AddedDate);
                connection.Open();
                command.ExecuteNonQuery();

            }
            catch(Exception ex)
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
        public bool DeleteData(adminBll admin)
        {
            try
            {
                string sql = "DELETE FROM admin WHERE id=@id";
                SqlCommand command = new SqlCommand(sql,connection);
                command.Parameters.AddWithValue("@id", admin.Id);

                connection.Open();
                command.ExecuteNonQuery();
            }
            catch(Exception ex)
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
                string sql = "SELECT * FROM admin WHERE id LIKE '%"+keyword+"%' OR name LIKE '%"+keyword+"%'";
                SqlCommand command = new SqlCommand(sql,connection);
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

        //Login method
        public bool LoginUser(adminBll admin)
        {
            try
            {
                DataTable table = new DataTable();
                string sql = "SELECT * FROM admin WHERE email=@email AND password=@password";
                SqlCommand command = new SqlCommand(sql,connection);
                command.Parameters.AddWithValue("@email", admin.Email);
                command.Parameters.AddWithValue("@password", admin.Password);
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
                if (table.Rows.Count>0)
                {
                    return true;
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
            return false;
        }

    }
}
