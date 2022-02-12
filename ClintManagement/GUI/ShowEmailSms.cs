using ClintManagement.BLL;
using ClintManagement.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClintManagement.GUI
{
    public partial class ShowEmailSms : Form
    {
        public ShowEmailSms()
        {
            InitializeComponent();
        }

        ShowEmailSmsDAL smsEmailDAL = new ShowEmailSmsDAL();
        ShowEmailSmsBLL smsEmailBLL = new ShowEmailSmsBLL();

        private void ShowEmailSms_Load(object sender, EventArgs e)
        {
            DataTable table = smsEmailDAL.selectData();
            dgvRecord.DataSource = table;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            DashBoard display = new DashBoard();
            display.Show();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            DataTable table = smsEmailDAL.selectData();
            dgvRecord.DataSource = table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textID.Text != "")
            {
                smsEmailBLL.Id = int.Parse(textID.Text); 
                if (smsEmailDAL.DeleteData(smsEmailBLL))
                {
                    MessageBox.Show("Record Deleted");
                    DataTable table = smsEmailDAL.selectData();
                    dgvRecord.DataSource = table;
                    textID.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Please select the record first");
            }
        }

        private void textDelete_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textSearch.Text == "")
            {
                DataTable table = smsEmailDAL.selectData();
                dgvRecord.DataSource = table;
            }
            else
            {
                DataTable table = smsEmailDAL.SearchData(textSearch.Text);
                dgvRecord.DataSource = table;
            }
        }

        private void dgvRecord_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indexRow = e.RowIndex;
            textID.Text = dgvRecord.Rows[indexRow].Cells[0].Value.ToString();
        }

        private void dgvRecord_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
