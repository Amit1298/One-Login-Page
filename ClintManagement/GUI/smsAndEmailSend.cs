using ClintManagement.BLL;
using ClintManagement.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace ClintManagement.GUI
{
    public partial class smsAndEmailSend : Form
    {
        public smsAndEmailSend()
        {
            InitializeComponent();
        }

        ClientDAL clientDAL = new ClientDAL();
        ClientBLL clientBLL = new ClientBLL();
        SmsEmailDAL email = new SmsEmailDAL();
        DataTable messageTable = new DataTable();

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            reset();
        }

        public void reset()
        {
            textSubject.Text = "";
            textMessage.Text = "";
            dgvAddedClients.ClearSelection();
            messageTable.Clear();
            dgvAddedClients.DataSource = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            DashBoard display = new DashBoard();
            display.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textSearch.Text == "")
            {
                DataTable table = clientDAL.selectData();
            }
            else
            {
                DataTable table = clientDAL.SearchData(textSearch.Text);
                dgvClients.DataSource = table;
            }
        }

        private void smsAndEmailSend_Load(object sender, EventArgs e)
        {
            lblSmsEmail.Text = DashBoard.formType;
            DataTable table = clientDAL.SearchData(textSearch.Text);
            dgvClients.DataSource = table;

            comboCity.DataSource = email.UniqueCitySelection();
            comboCity.DisplayMember = "city";
            comboCity.ValueMember = "city";

            comboStatus.DataSource = email.UniqueStatusSelection();
            comboStatus.DisplayMember = "status";
            comboStatus.ValueMember = "status";

            dgvAddedClients.DataSource = "";

            messageTable.Columns.Add("Id");
            messageTable.Columns.Add("Name");
            messageTable.Columns.Add("Email");
            messageTable.Columns.Add("Phone");
            messageTable.Columns.Add("Gender");
            messageTable.Columns.Add("City");
            messageTable.Columns.Add("Address");
            messageTable.Columns.Add("Status");
            messageTable.Columns.Add("Notes");
            messageTable.Columns.Add("AddedDate");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            DashBoard display = new DashBoard();
            display.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable table = clientDAL.selectData();
            dgvAddedClients.DataSource = table;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dgvClients_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indexRow = e.RowIndex;
            messageTable.Rows.Add(
            dgvClients.Rows[indexRow].Cells[0].Value.ToString(),
            dgvClients.Rows[indexRow].Cells[1].Value.ToString(),
            dgvClients.Rows[indexRow].Cells[2].Value.ToString(),
            dgvClients.Rows[indexRow].Cells[3].Value.ToString(),
            dgvClients.Rows[indexRow].Cells[4].Value.ToString(),
            dgvClients.Rows[indexRow].Cells[5].Value.ToString(),
            dgvClients.Rows[indexRow].Cells[6].Value.ToString(),
            dgvClients.Rows[indexRow].Cells[7].Value.ToString(),
            dgvClients.Rows[indexRow].Cells[8].Value.ToString()
                );
            dgvAddedClients.DataSource = messageTable;
        }

        private void dgvAddedClients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboCity.Text != "")
            {
                DataTable table = clientDAL.SearchData(comboCity.Text);
                dgvAddedClients.DataSource = table;
            }
        }

        private void comboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboStatus.Text != "")
            {
                DataTable table = clientDAL.SearchData(comboStatus.Text);
                dgvAddedClients.DataSource = table;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string logedUserEmail = Login.userEmail;
            string logedUserPassword = Login.userPassword;
            int success = 0;
            if (textMessage.Text != ""&&textSubject.Text!=""&&dgvAddedClients.Rows.Count>0)
            {
                if (DashBoard.formType == "Email")
                {
                    try
                    {
                        for(int i = 0; i < dgvAddedClients.Rows.Count - 1; i++)
                        {
                            string textTo = dgvAddedClients.Rows[i].Cells[2].Value.ToString();
                            MailMessage mailMessage = new MailMessage(logedUserEmail, textTo, textSubject.Text, textMessage.Text);
                            mailMessage.IsBodyHtml = true;
                            SmtpClient client = new SmtpClient("smtp.gmail.com");
                            client.UseDefaultCredentials = false;
                            NetworkCredential clientCredential = new NetworkCredential(logedUserEmail, logedUserPassword);
                            client.Credentials = clientCredential;
                            client.EnableSsl = true;
                            client.Send(mailMessage);
                            success++;
                        }
                        if (success > 0)
                        {
                            MessageBox.Show(success + "Mail Sent.");
                            reset();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {

                }
            }
            else
            {
                MessageBox.Show("Please enter all the fields");
            }
        }
    }
}
