using ClintManagement.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace ClintManagement.DAL
{
    class ShowEmailSmsDAL
    {
        SqlConnection connection = new SqlConnection(Connection.connectionString);
        
        //Select Data
        public DataTable selectData()
        {
            DataTable table = new DataTable();
            try
            {
                string sql = "SELECT * FROM sms_mail";
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

        //Insert method
        public bool InsertData(ShowEmailSmsBLL emailSms)
        {
            try
            {
                string sql = "INSERT INTO sms_mail(clientId,message,subject,status) VALUES(@clientId,@message,@subject,@status)";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@clientId", emailSms.ClientId);
                command.Parameters.AddWithValue("@message", emailSms.Message);
                command.Parameters.AddWithValue("@subject", emailSms.Subject);
                command.Parameters.AddWithValue("@status", emailSms.Status);

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
        public bool DeleteData(ShowEmailSmsBLL emailSms)
        {
            try
            {
                string sql = "DELETE FROM sms_mail WHERE id=@id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", emailSms.Id);

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

        //Search method
        public DataTable SearchData(string keyword)
        {
            DataTable table = new DataTable();
            try
            {
                string sql = "SELECT * FROM sms_mail WHERE id LIKE '%"+keyword+"%' OR status LIKE '%"+keyword+"%'";
                SqlCommand command = new SqlCommand(sql, connection);
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
