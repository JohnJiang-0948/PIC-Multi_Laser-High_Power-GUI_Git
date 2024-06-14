using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace User_Interface_Library
{
    public partial class 管理员登录 : Form
    {
        public 管理员登录()
        {
            InitializeComponent();
        }
        public bool Admin;

        private void button4_Click(object sender, EventArgs e)
        {
            Properties.Settings SET = new Properties.Settings();
            if(Password.Text==SET.密码)
            {
                Admin = true;
                MessageBox.Show("Successfully get the Admin Password.");
                this.Close();
            }
            else
            {
                Admin = false;
                MessageBox.Show("Failed Admin Password.Please check and try again.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Admin = false;
            this.Close();
        }
    }
}
