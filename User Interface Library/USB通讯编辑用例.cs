using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using Multi_Laser_HighPower_Data;

namespace User_Interface_Library
{
    public partial class USB通讯编辑用例 : Form
    {
        public USB通讯编辑用例()
        {
            InitializeComponent();
            propertyGrid1.SelectedObject = MLHD_Data;
        }

        public bool USBMode;
        public string USB_XML_Folder;
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Multi_Laser_HighPower_Data.USB配置_Data));
        Multi_Laser_HighPower_Data.USB配置_Data MLHD_Data = new USB配置_Data();
        xmlHelper xmlHelper = new xmlHelper();

        private void USB通讯编辑用例_Click(object sender, EventArgs e)
        {
            
        }

        private void 查找用例_Click(object sender, EventArgs e)
        {
            xmlHelper.xmlSearch(USB_XML_Folder,listBox1);
        }
       
        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if(listBox1.SelectedItem!=null)
            {
                string xml_Path = USB_XML_Folder + "\\" + listBox1.SelectedItem.ToString();
                xmlHelper.xmlDeserialization<USB配置_Data>(xml_Path, out MLHD_Data);

            }
            else
            {
                MessageBox.Show("Failed to get the xml File Content.Please check and try again.");
            }
        }

        private void 编辑用例_Click(object sender, EventArgs e)
        {
            string xml_Path = USB_XML_Folder + "\\" + listBox1.SelectedItem.ToString();
            xmlHelper.xmlSerialization<USB配置_Data>(xml_Path, MLHD_Data);
            this.Close();
        }

        private void USB通讯编辑用例_Load(object sender, EventArgs e)
        {

        }
    }
}
