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
using System.IO;
using System.Xml.Serialization;

namespace User_Interface_Library
{
    public partial class 通讯新建用例 : Form
    {
        public 通讯新建用例()
        {
            InitializeComponent();
        }

        public bool USBMode;
        public string USB_XML_Path;
        public string USB_XML_Folder;
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(USB配置_Data));
        Multi_Laser_HighPower_Data.USB配置_Data MLHD_USB配置_Data = new USB配置_Data();

        private void USB通讯用例_Load(object sender, EventArgs e)
        {
            propertyGrid1.SelectedObject = MLHD_USB配置_Data;
            新建用例.Click += new EventHandler(新建用例_Click);
        }

        public void 新建用例_Click(object sender,EventArgs e) //USB配置用例
        {
            if(USB_XML_Name.Text!="")
            {
                //USB_XML_Folder = System.Windows.Forms.Application.StartupPath+ "\\System_Configuration\\USB_Configuration";
                USB_XML_Path = USB_XML_Folder + "\\"+USB_XML_Name.Text + ".xml";
                if(!Directory.Exists(USB_XML_Folder))
                {
                    Directory.CreateDirectory(USB_XML_Folder);
                }
                try
                {
                    using (FileStream FS = new FileStream(USB_XML_Path, FileMode.Create))
                    {
                        xmlSerializer.Serialize(FS, MLHD_USB配置_Data);
                    }
                    MessageBox.Show("Succssfully create the new USB xml script!");
                    this.Close();
                }
                catch 
                {
                    MessageBox.Show("Failed create the new USB xml script! Please check and try again.");
                }
            }
            else
            {
                MessageBox.Show("Please set the XML File Name and try again!");
            }
        }

        private void 新建用例_Click_1(object sender, EventArgs e)
        {

        }
    }
}
