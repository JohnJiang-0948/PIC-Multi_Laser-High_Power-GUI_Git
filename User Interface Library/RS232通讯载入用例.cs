using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Multi_Laser_HighPower_Data;

namespace User_Interface_Library
{
    public partial class RS232通讯载入用例 : Form
    {
        public RS232通讯载入用例()
        {
            InitializeComponent();
        }

        public string RS232_XML_Folder;
        xmlHelper xmlHelper = new xmlHelper();
        public RS232配置_CommonData RCD;
        public DataTable Rest_DataTable;

        private void 查找用例_Click(object sender, EventArgs e)
        {
            xmlHelper.xmlSearch(RS232_XML_Folder, listBox1);
        }

        public void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string xml_Path = RS232_XML_Folder + "\\" + listBox1.SelectedItem.ToString();
                xmlHelper.Get_UsbXml(xml_Path, dataGridView1, propertyGrid1);
            }
            else
            {
                MessageBox.Show("Failed to get the xml File Content.Please check and try again.");
            }
        }

        public void 载入用例_Click(object sender, EventArgs e)
        {
            try
            {
                RCD = (RS232配置_CommonData)propertyGrid1.SelectedObject;
                Rest_DataTable = xmlHelper.tableData;
                MessageBox.Show("Successfully to load the xml File Content.Please check and try again.");
            }
            catch
            {
                MessageBox.Show("Failed to load the xml File Content.Please check and try again.");
            }
        }

        private void 查找用例_Click_1(object sender, EventArgs e)
        {
            
        }
    }
}
