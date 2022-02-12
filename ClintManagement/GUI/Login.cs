using ClintManagement.BLL;
using ClintManagement.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClintManagement
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        adminBll adminBLL = new adminBll();
        AdminDal adminDAL = new AdminDal();
        public static string userEmail;
        public static string userPassword;
        private void textPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            System.Windows.Forms.Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //DashBoard dashboard = new DashBoard();
            //dashboard.Show();
            if (textEmail.Text != "" && textPassword.Text != "")
            {
                adminBLL.Password = textPassword.Text;
                adminBLL.Email = textEmail.Text;
                if (adminDAL.LoginUser(adminBLL))
                {
                    userEmail = textEmail.Text;
                    userPassword = textPassword.Text;
                     this.Hide();
                    DashBoard display = new DashBoard();
                     display.Show();
                }
                else
                {
                    MessageBox.Show("Please enter valid email or password");
                }
            }
            else
            {
                MessageBox.Show("Plesae Enter All the Fields");
            }
        }
    }
}
