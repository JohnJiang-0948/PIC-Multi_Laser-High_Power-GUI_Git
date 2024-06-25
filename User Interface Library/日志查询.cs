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

namespace User_Interface_Library
{
    public partial class 日志查询 : Form
    {
        public 日志查询()
        {
            InitializeComponent();
        }

        public bool Judge;
        private void uiButton1_Click(object sender, EventArgs e)
        {
            string fileName = dateTimePicker1.Value.Date.ToString("yyyy_MM_dd") + ".txt";
            string folderPath = Application.StartupPath + "\\log";
            if(Directory.Exists(folderPath))
            {
                string filepath = Path.Combine(folderPath, fileName);
                if(File.Exists(filepath))
                {
                    richTextBox1.Text = File.ReadAllText(filepath);
                    Judge = true;
                }
                else
                {
                    MessageBox.Show("filePath does not exist");
                    Judge = false;
                }
            }
            else
            {
                MessageBox.Show("folderPath does not exist");
                Judge = false;
            }
        }

    }
}
