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
    public partial class 密码修改 : Form
    {
        public 密码修改()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Properties.Settings PS = new Properties.Settings();
            if((Password_Default.Text==PS.密码)&(Password_New.Text!=""))
            {
                PS.密码 = Password_New.Text;
                MessageBox.Show("Successfully update the Admin Password.");
                this.Close();
            }
            else
            {
                Password_Default.Text = "";
                Password_New.Text = "";
                MessageBox.Show("Failed to update the Admin Password.Please check and try again.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
