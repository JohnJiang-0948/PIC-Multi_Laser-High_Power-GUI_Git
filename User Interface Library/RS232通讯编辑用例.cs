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
    public partial class RS232通讯编辑用例 : Form
    {
        public RS232通讯编辑用例()
        {
            InitializeComponent();
        }

        public string RS232_XML_Folder;
        xmlHelper xmlHelper = new xmlHelper();

        private void 查找用例_Click(object sender, EventArgs e)
        {
            xmlHelper.xmlSearch(RS232_XML_Folder, listBox1);
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(listBox1.Items.Count>=1)
            {
                xmlHelper.tableData.Rows.Add();
            }
            else
            {
                MessageBox.Show("Please select the xml first and then try again.");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if(listBox1.Items.Count >= 1)
            {
                if (xmlHelper.tableData.Rows.Count >= 1)
                {
                    xmlHelper.tableData.Rows.RemoveAt(xmlHelper.tableData.Rows.Count - 1);
                }
            }
            else
            {
                MessageBox.Show("Please select the xml first and then try again.");
            }
        }

        private void 保存用例_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count >= 1)
            {
                try
                {
                    string xml_Path = RS232_XML_Folder + "\\" + listBox1.SelectedItem.ToString();
                    xmlHelper.Set_UsbXml(xml_Path, dataGridView1, propertyGrid1);
                    MessageBox.Show("Successfully to save the xml File.");
                }
                catch
                {
                    MessageBox.Show("Failed to save the xml File.Please check and try again.");
                }
            }
            else
            {
                MessageBox.Show("Please select the xml first and then try again.");
            }           
        }

        private void 另存为用例_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count >= 1)
            {
                XML文件另存为 xML_Dialog = new XML文件另存为();
                xML_Dialog.ShowDialog(); //------------------------//
                if (xML_Dialog.Update == true)
                {
                    try
                    {
                        string xml_Path = RS232_XML_Folder + "\\" + xML_Dialog.RS232_XML_name + ".xml";
                        xmlHelper.Set_UsbXml(xml_Path, dataGridView1, propertyGrid1);
                        MessageBox.Show("Successfully to save the xml File.");
                    }
                    catch
                    {
                        MessageBox.Show("Failed to save the xml File.Please check and try again.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select the xml first and then try again.");
            }          
        }
    }
}
