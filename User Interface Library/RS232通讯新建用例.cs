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
using Multi_Laser_HighPower_Data;

namespace User_Interface_Library
{
    public partial class RS232通讯新建用例 : Form
    {
        public RS232通讯新建用例()
        {
            InitializeComponent();
            RS232配置_CommonData RC = new RS232配置_CommonData();
            propertyGrid1.SelectedObject = RC;
            dataGridView1.Columns.Add(Colunm1, Colunm1);
            dataGridView1.Columns.Add(Colunm2, Colunm2);
            dataGridView1.Columns[Colunm1].Width = 150;
            dataGridView1.Columns[Colunm2].Width = 250;
            for (int i = 0; i < 30; i++)
            {
                dataGridView1.Rows.Add();
            }
        }

        public string Colunm1 = "Instruction_Semantics";
        public string Colunm2 = "Instruction_Summary";
        public string RS232_XML_Path;
        public string RS232_XML_Folder;
        xmlHelper xmlHelper = new xmlHelper();

        private void 新建用例_Click(object sender, EventArgs e)
        {
            if(RS232_XML_Name.Text!="")
            {
                RS232_XML_Path = RS232_XML_Folder + "\\" + RS232_XML_Name.Text + ".xml";
            }
            if (!Directory.Exists(RS232_XML_Folder))
            {
                Directory.CreateDirectory(RS232_XML_Folder);
            }
            try
            {
                xmlHelper.Set_UsbXml(RS232_XML_Path, dataGridView1, propertyGrid1);
                MessageBox.Show("Successfully to create the XML File.");
            }
            catch
            {
                MessageBox.Show("Failed to create the XML File.Please check and set again.");
            }

        }
    }
}
