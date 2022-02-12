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
    public partial class Clients : Form
    {
        public Clients()
        {
            InitializeComponent();
        }

        ClientBLL clientBLL = new ClientBLL();
        ClientDAL clientDAL = new ClientDAL();

        private void Clients_Load(object sender, EventArgs e)
        {
            DataTable table = clientDAL.selectData();
            dgvClient.DataSource = table;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            DashBoard display = new DashBoard();
            display.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }

        private void textCity_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            DashBoard display = new DashBoard();
            display.Show();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (textName.Text!=""&&textEmail.Text!=""&&textPhone.Text!=""&&textCity.Text!=""&&comboGender.Text!=""&&textAddress.Text!=""&&textNotes.Text!=""&&textStatus.Text!="")
            {
                clientBLL.Name = textName.Text;
                clientBLL.Email = textEmail.Text;
                clientBLL.Phone = textPhone.Text;
                clientBLL.Gender = comboGender.Text;
                clientBLL.City = textCity.Text;
                clientBLL.Address = textAddress.Text;
                clientBLL.Status = textStatus.Text;
                clientBLL.Notes = textNotes.Text;
                clientBLL.addedDate = DateTime.Now;
                if (clientDAL.InsertData(clientBLL))
                {
                    MessageBox.Show("Data Inserted");
                    DataTable table = clientDAL.selectData();
                    dgvClient.DataSource = table;
                    reset();
                }
            }
            else
            {
                MessageBox.Show("Please fill all the fields");
            }
        }
        public void reset()
        {
            textId.Text = "";
            textName.Text = "";
            textEmail.Text = "";
            textPhone.Text = "";
            comboGender.Text = "";
            textCity.Text = "";
            textAddress.Text = "";
            textStatus.Text = "";
            textNotes.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void dgvClient_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indexRow = e.RowIndex;
            textId.Text = dgvClient.Rows[indexRow].Cells[0].Value.ToString();
            textName.Text = dgvClient.Rows[indexRow].Cells[1].Value.ToString();
            textEmail.Text = dgvClient.Rows[indexRow].Cells[2].Value.ToString();
            textPhone.Text = dgvClient.Rows[indexRow].Cells[3].Value.ToString();
            comboGender.Text = dgvClient.Rows[indexRow].Cells[4].Value.ToString();
            textCity.Text = dgvClient.Rows[indexRow].Cells[5].Value.ToString();
            textAddress.Text = dgvClient.Rows[indexRow].Cells[6].Value.ToString();
            textStatus.Text = dgvClient.Rows[indexRow].Cells[7].Value.ToString();
            textNotes.Text = dgvClient.Rows[indexRow].Cells[8].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textId.Text != "" && textName.Text != "" && textEmail.Text != "" && textPhone.Text != "" && textCity.Text != "" && comboGender.Text != "" && textAddress.Text != "" && textNotes.Text != "" && textStatus.Text != "")
            {
                clientBLL.Id = int.Parse(textId.Text);
                clientBLL.Name = textName.Text;
                clientBLL.Email = textEmail.Text;
                clientBLL.Phone = textPhone.Text;
                clientBLL.Gender = comboGender.Text;
                clientBLL.City = textCity.Text;
                clientBLL.Address = textAddress.Text;
                clientBLL.Status = textStatus.Text;
                clientBLL.Notes = textNotes.Text;
                clientBLL.addedDate = DateTime.Now;
                if (clientDAL.UpdateData(clientBLL))
                {
                    MessageBox.Show("Data Updated");
                    DataTable table = clientDAL.selectData();
                    dgvClient.DataSource = table;
                    reset();
                }
            }
            else
            {
                MessageBox.Show("Please fill all the fields");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textId.Text != "")
            {
                clientBLL.Id = int.Parse(textId.Text);
                if (clientDAL.DeleteData(clientBLL))
                {
                    MessageBox.Show("Data Deleted");
                    DataTable table = clientDAL.selectData();
                    dgvClient.DataSource = table;
                    reset();
                }
            }
            else
            {
                MessageBox.Show("Please fill all the fields");
            }
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            if(textSearch.Text == "")
            {
                DataTable table = clientDAL.selectData();
                dgvClient.DataSource = table;
            }
            else
            {
                DataTable table = clientDAL.SearchData(textSearch.Text);
                dgvClient.DataSource = table;
            }
        }
    }
}
