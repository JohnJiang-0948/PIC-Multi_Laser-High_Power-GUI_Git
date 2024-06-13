using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using User_Interface_Library;
using Multi_Laser_HighPower_Data;



namespace PIC_Multi_Laser_High_Power_GUI_V1._0
{
    public partial class RadForm1 : Telerik.WinControls.UI.RadForm
    {
        public RadForm1()
        {
            InitializeComponent();
        }
        //类库初始化
        USB类库.USB_BASIC USB_BASIC = new USB类库.USB_BASIC();
        USB类库.USB_Control_Info uSB_Control_Info = new USB类库.USB_Control_Info();
        USB类库.USB_Control_LS uSB_Control_LS = new USB类库.USB_Control_LS();
        USB类库.USB_Control_MyCollect uSB_Control_MyCollect = new USB类库.USB_Control_MyCollect();
        USB类库.USB_Control_RT uSB_Control_RT = new USB类库.USB_Control_RT();
        USB类库.USB_Control_SF uSB_Control_SF = new USB类库.USB_Control_SF();
        public bool External_Net_Mode;
        public string Main_USB_XML_Folder;
        public Multi_Laser_HighPower_Data.USB配置_Data USB配置_Data;
        public string USB_xml_Number;
        public string Main_RS232_Folder;


        private void RadForm1_Load(object sender, EventArgs e)
        {
            USB_Connect = false;
            Main_tabControl.SelectedIndex = 0;
            USB_Event();
            USB_Protocol_Init(); 
            set_External_Net_Mode(); //设置外部单机模式
        }


        #region//通用函数
        public void Delay(uint miliSecond)  //延时函数 
        {
            int start = Environment.TickCount;
            while (Math.Abs(Environment.TickCount - start) < miliSecond)
            {
                Application.DoEvents();
            }
        }

        #endregion


        #region //界面—USB配置及控制

        public bool USB_Connect;
        public int USB_Channel;

        public void USB_Protocol_Init()
        {
            USB_Connect = false;
            USB_BASIC.GridviewInit(dataGridView_Laser, dataGridView_Channel);
        }

        public void USB_Event()
        {
            //USB配置界面.Click += new EventHandler(USB_Protocol_Connect);
            Read_Info.Click += new EventHandler(USB_Get_LaserInfo);
            Write_Info.Click += new EventHandler(USB_Set_LaserInfo);
            Read_Laser.Click += new EventHandler(USB_Get_ChannelInfo);
            Write_Laser.Click += new EventHandler(USB_Set_ChannelInfo);
            主界面.Click += new EventHandler(Main_Change_TabControl);
            USB配置界面.Click += new EventHandler(Main_Change_TabControl);
            USB控制界面.Click += new EventHandler(Main_Change_TabControl);
            串口协议界面.Click += new EventHandler(Main_Change_TabControl);
        }

        public void USB_Protocol_Connect()
        {
            Boolean State = false;
            Byte[] buffer = new Byte[30];
            //State = USB_BASIC.USB_InitDevice();
            State = USB类库.USB_BASIC.FinaDevice();
            Delay(200);
            State = USB类库.USB_BASIC.InitDevice();
            Delay(200);
            if(State==true)
            {
                for (UInt16 i = 0; i < 256; i++)
                { 
                    //State = USB_BASIC.USB_SetCH((byte)i);
                    State = USB类库.USB_BASIC.SetCH((byte)i);
                    if (State)
                    {
                        USB_Channel = i;
                        USB_Connect = true;
                        break;
                    }
                    else
                    {
                        USB_Connect = false;
                    }
                }
            }
        }

        public void USB_Protocol_Close()
        {
            Boolean State = false;
            State=USB类库.USB_BASIC.FinaDevice();
        }

        public void Reset_Datagridview(DataGridView dataGridView)
        {
            for (int i = 0; i < 19; i++)
            {
                dataGridView.Rows[i].Cells[1].Value = "";
                dataGridView.Rows[i].Cells[3].Value = "";
            }
        }

        public void USB_Get_LaserInfo(object sender,EventArgs e)
        {
            USB_Protocol_Connect();
            if (USB_Connect==true)
            {
                try
                {
                    USB类库.USB_BASIC.SetCH((byte)USB_Channel);
                    USB_BASIC.Unseal();
                    Delay(500);
                    uSB_Control_Info.Get_Info(dataGridView_Laser);
                    uSB_Control_RT.Get_RT(dataGridView_Laser);
                    uSB_Control_LS.Get_LS(dataGridView_Laser);
                    uSB_Control_MyCollect.Get_MyCollect1(dataGridView_Laser);
                }
                catch
                {
                    MessageBox.Show("Failed get the Laser Info.Please try again.");
                    Reset_Datagridview(dataGridView_Laser);
                }
                USB_Protocol_Close();
            }
            else
            {
                Reset_Datagridview(dataGridView_Laser);
                MessageBox.Show("Please check the USB Connection and try again.");
            }
        }

        public void USB_Set_LaserInfo(object sender, EventArgs e)
        {
            USB_Protocol_Connect();
            if (USB_Connect == true)
            {
                try
                {
                    USB类库.USB_BASIC.SetCH((byte)USB_Channel);
                    USB_BASIC.Unseal();
                    Delay(500);
                    uSB_Control_Info.Set_Info(dataGridView_Laser);
                    uSB_Control_RT.Set_RT(dataGridView_Laser);
                    uSB_Control_LS.Set_LS(dataGridView_Laser);
                    MessageBox.Show("Successfully complete the Laser Configuration.");
                }
                catch
                {
                    MessageBox.Show("Failed get the Laser Info.Please try again.");
                }
                USB_Protocol_Close();
            }
            else
            {
                MessageBox.Show("Please check the USB Connection and try again.");
            }
        }

        public void USB_Get_ChannelInfo(object sender,EventArgs e)
        {
            USB_Protocol_Connect();
            int chNum = 1;
            if(USB_Connect==true)
            {
                try
                {
                    USB类库.USB_BASIC.SetCH((byte)USB_Channel);
                    uSB_Control_SF.Get_SF(dataGridView_Channel, chNum);
                    uSB_Control_MyCollect.Get_MyCollect2(dataGridView_Channel, comboBox1, chNum);
                    Delay(100);
                }
                catch
                {
                    Reset_Datagridview(dataGridView_Channel);
                    MessageBox.Show("Failed get the Laser Info.Please try again.");
                }
                USB_Protocol_Close();
            }
            else
            {
                Reset_Datagridview(dataGridView_Channel);
                MessageBox.Show("Please check the USB Connection and try again.");
            }
        }

        public void USB_Set_ChannelInfo(object sender, EventArgs e)
        {
            USB_Protocol_Connect();
            int chNum = 1;
            if (USB_Connect == true)
            {
                try
                {
                    USB类库.USB_BASIC.SetCH((byte)USB_Channel);
                    uSB_Control_SF.Set_SF(dataGridView_Channel, chNum);
                    USB_BASIC.UpdateRAM();
                    USB_BASIC.WriteCRC();
                    USB_BASIC.UpdateRAM();
                    Delay(100);
                    MessageBox.Show("Successfully complete the Laser Configuration.");
                }
                catch
                {
                    MessageBox.Show("Failed get the Laser Info.Please try again.");
                }
                USB_Protocol_Close();
            }
            else
            {
                MessageBox.Show("Please check the USB Connection and try again.");
            }
        }

        public void Main_Change_TabControl(object sender,EventArgs e)
        {
            RadButtonElement Click_Button = sender as RadButtonElement;
            if(Click_Button.Name.Contains("主 界面"))
            {
                Main_tabControl.SelectedIndex = 0;
            }
            else if (Click_Button.Name.Contains("USB配置界面"))
            {
                Main_tabControl.SelectedIndex = 1;
            }
            else if (Click_Button.Name.Contains("USB控制界面"))
            {
                Main_tabControl.SelectedIndex = 2;
            }
            else if (Click_Button.Name.Contains("串口协议界面"))
            {
                Main_tabControl.SelectedIndex = 3;
            }
        }

        public void RS232_datagridViewInit(DataGridView datagridview, string[] waveListArray)
        {
            datagridview.Rows.Clear();
            bool[] lightListArray;
            //MLR.PIC_Get_AllLight_State(RS232_SerialPort.Text, waveListArray, out lightListArray);
            for (int i = 0; i < waveListArray.Count(); i++)
            {
                datagridview.Rows.Add();
                datagridview.Rows[i].Height = 30;
                //if (lightListArray[i] == true)
                //{
                //    datagridview.Rows[i].Cells[0].Value = Properties.Resources.Green222;
                //}
                //else
                //{
                //    datagridview.Rows[i].Cells[0].Value = Properties.Resources.Green111;
                //}
                datagridview.Rows[i].Cells[1].Value = "CH" + (i + 1);
                datagridview.Rows[i].Cells[2].Value = waveListArray[i];
            }
            datagridview.BorderStyle = BorderStyle.None;
            datagridview.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            datagridview.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            datagridview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            datagridview.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            datagridview.DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            datagridview.MultiSelect = false;
            datagridview.AllowUserToAddRows = false;
        }

        #endregion


        #region//网络运行模式

        public void set_External_Net_Mode()
        {
            External_Net_Mode = true;
            Main_USB_XML_Folder= System.Windows.Forms.Application.StartupPath + "\\System_Configuration\\USB_Configuration";
            Main_RS232_Folder= System.Windows.Forms.Application.StartupPath + "\\System_Configuration\\RS232_Configuration";
        }

        public void set_Internal_Net_Mode()
        {
            External_Net_Mode = false;
            Main_USB_XML_Folder = "S:\\John Jiang\\System_Configuration\\USB_Configuration";
            Main_RS232_Folder= "S:\\John Jiang\\System_Configuration\\RS232_Configuration";
        }

        private void 外部单机模式_Click(object sender, EventArgs e)
        {
            if(External_Net_Mode==false)
            {
                set_External_Net_Mode();
                External_Net_Mode = true;
                网络模式显示.Text = "----------外部单机模式-----------";
                MessageBox.Show("The system has been switched to external Network mode!");
            }            
        }

        private void 内部联网模式_Click(object sender, EventArgs e)
        {
            if (External_Net_Mode == true)
            {
                set_Internal_Net_Mode();
                External_Net_Mode = false;
                网络模式显示.Text = "----------内部联网模式-----------";
                MessageBox.Show("The system has been switched to internal Network mode!");
            }
        }

        #endregion


        #region //界面—用例配置
        private void USB通讯新建用例_Click(object sender, EventArgs e)
        {
            User_Interface_Library.USB通讯新建用例 UIL_新建 = new USB通讯新建用例();
            UIL_新建.USB_XML_Folder = Main_USB_XML_Folder;
            UIL_新建.ShowDialog();
        }

        private void USB通讯编辑用例_Click(object sender, EventArgs e)
        {
            User_Interface_Library.USB通讯编辑用例 UIL_编辑 = new USB通讯编辑用例();
            UIL_编辑.USB_XML_Folder= Main_USB_XML_Folder;
            UIL_编辑.ShowDialog();
        }

        private void USB通讯载入用例_Click(object sender, EventArgs e)
        {
            User_Interface_Library.USB通讯载入用例 UIL_载入 = new USB通讯载入用例();
            UIL_载入.USB_XML_Folder = Main_USB_XML_Folder;
            UIL_载入.ShowDialog();
            USB_xml_Number = UIL_载入.xml_Number;
            USB配置_Data = UIL_载入.USB配置_Data;
            USB_Configuration.Text = USB_xml_Number;
        }

        private void Apply_Configuration_Click(object sender, EventArgs e)
        {
            USB_Configuration_Apply(dataGridView_Laser);
        }

        public void USB_Configuration_Apply(DataGridView dataGridView)
        {
            dataGridView.Rows[1].Cells[1].Value = USB配置_Data.waveLength;
            dataGridView.Rows[6].Cells[1].Value = USB配置_Data.vender_Name;
            dataGridView.Rows[7].Cells[1].Value = USB配置_Data.contact;
            dataGridView.Rows[8].Cells[1].Value = USB配置_Data.tel;
            dataGridView.Rows[0].Cells[3].Value = USB配置_Data.dt_Seq;
            dataGridView.Rows[1].Cells[3].Value = USB配置_Data.ch_Seq;
        }

        #endregion


    }
}
