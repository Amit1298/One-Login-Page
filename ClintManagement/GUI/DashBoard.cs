using ClintManagement.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClintManagement
{
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
        }

        public static string formType;

        private void DashBoard_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            Login login = new Login();
            login.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            Login login = new Login();
            login.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            ShowEmailSms emailSms = new ShowEmailSms();
            emailSms.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Admins admin = new Admins();
            admin.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Clients display = new Clients();
            display.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            formType = "Email";
            this.Close();
            smsAndEmailSend message = new smsAndEmailSend();
            message.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            formType = "Phone";
            this.Close();
            smsAndEmailSend message = new smsAndEmailSend();
            message.Show();
        }
    }
}
