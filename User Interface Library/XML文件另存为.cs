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
    public partial class XML文件另存为 : Form
    {
        public XML文件另存为()
        {
            InitializeComponent();
            Update = false;
        }
        public string RS232_XML_name;
        public bool Update;
        private void Confirm_Click(object sender, EventArgs e)
        {
            RS232_XML_name = RS232_XML_Name.Text;
            Update = true;
            this.Close();
        }
        private void Cancel_Click(object sender, EventArgs e)
        {
            Update = false;
            this.Close();
        }
    }
}
