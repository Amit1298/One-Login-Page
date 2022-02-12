using ClintManagement.BLL;
using ClintManagement.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClintManagement
{
    public partial class Admins : Form
    {
        public Admins()
        {
            InitializeComponent();
        }

        adminBll adminBLL = new adminBll();
        AdminDal adminDAL = new AdminDal();
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            DashBoard display = new DashBoard();
            display.Show();
        }

        private void Admins_Load(object sender, EventArgs e)
        {
            DataTable table = adminDAL.selectData();
            dgvwAdmin.DataSource = table;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void labelPhone_Click(object sender, EventArgs e)
        {

        }

        private void labelPassword_Click(object sender, EventArgs e)
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

        public void reset()
        {
            textId.Text = "";
            textName.Text = "";
            textEmail.Text = "";
            textPhone.Text = "";
            textPassword.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(textName.Text!=""&& textEmail.Text!="" && textPhone.Text!="" && textPassword.Text != "")
            {
                adminBLL.Name = textName.Text;
                adminBLL.Email = textEmail.Text;
                adminBLL.Phone = textPhone.Text;
                adminBLL.Password = textPassword.Text;
                adminBLL.AddedDate = DateTime.Now;

                if (adminDAL.InsertData(adminBLL))
                {
                    MessageBox.Show("Data inserted Sucessfully");
                    DataTable table = adminDAL.selectData();
                    dgvwAdmin.DataSource = table;
                    reset();
                }
            }
            else
            {
                MessageBox.Show("Please Enter All the Fields");
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void dgvwAdmin_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            textId.Text = dgvwAdmin.Rows[rowIndex].Cells[0].Value.ToString();
            textName.Text = dgvwAdmin.Rows[rowIndex].Cells[1].Value.ToString();
            textPhone.Text = dgvwAdmin.Rows[rowIndex].Cells[2].Value.ToString();
            textEmail.Text = dgvwAdmin.Rows[rowIndex].Cells[3].Value.ToString();
            textPassword.Text = dgvwAdmin.Rows[rowIndex].Cells[4].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textId.Text!="")
            {
                adminBLL.Id = int.Parse(textId.Text);
                if (adminDAL.DeleteData(adminBLL))
                {
                    MessageBox.Show("Data Deleted");
                    DataTable table = adminDAL.selectData();
                    dgvwAdmin.DataSource = table;
                    reset();
                }
            }
            else
            {
                MessageBox.Show("Please select the record first");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textId.Text != "" && textName.Text != "" && textEmail.Text != "" && textPhone.Text != "" && textPassword.Text != "")
            {
                adminBLL.Id = int.Parse(textId.Text);
                adminBLL.Name = textName.Text;
                adminBLL.Email = textEmail.Text;
                adminBLL.Phone = textPhone.Text;
                adminBLL.Password = textPassword.Text;
                adminBLL.AddedDate = DateTime.Now;

                if (adminDAL.UpdateData(adminBLL))
                {
                    MessageBox.Show("Data Updated Sucessfully");
                    DataTable table = adminDAL.selectData();
                    dgvwAdmin.DataSource = table;
                    reset();
                }
            }
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            if(textSearch.Text == "")
            {
                DataTable table = adminDAL.selectData();
                dgvwAdmin.DataSource = table;
            }
            else
            {
                DataTable table = adminDAL.SearchData(textSearch.Text);
                dgvwAdmin.DataSource = table;
            }
        }
    }
}
