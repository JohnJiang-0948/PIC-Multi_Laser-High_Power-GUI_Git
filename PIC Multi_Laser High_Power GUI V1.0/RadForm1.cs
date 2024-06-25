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
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.IO;


namespace PIC_Multi_Laser_High_Power_GUI_V1._0
{
    public partial class RadForm1 : Telerik.WinControls.UI.RadForm
    {
        public RadForm1()
        {
            InitializeComponent();
            登录_Init();
            Admin_Show(Admin);
            tabcontrolHide(Main_tabControl);
            tabcontrolHide(Tab_USB配置);     //USB初始化
            tabcontrolHide(Main_tabControl);
            RS232_Open = false;
            Connect_OK(true);
            RS232_SerialPort.Items.Clear();
            RS232_DeviceSearch();
            Channel = 0;                     //RS232初始化
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
        public void tabcontrolHide(TabControl tabControl)
        {
            tabControl.Appearance = TabAppearance.FlatButtons;
            tabControl.ItemSize = new Size(0, 1);
            tabControl.SizeMode = TabSizeMode.Fixed;
        }

        #endregion


        #region //界面—USB配置及控制

        public bool USB_Connect;
        public int USB_Channel;

        public void USB_Protocol_Init()
        {
            USB_Connect = false;
            USB_BASIC.GridviewInit(Next_Page, dataGridView_Channel);
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
                    uSB_Control_Info.Get_Info(Next_Page);
                    uSB_Control_RT.Get_RT(Next_Page);
                    uSB_Control_LS.Get_LS(Next_Page);
                    uSB_Control_MyCollect.Get_MyCollect1(Next_Page);
                }
                catch
                {
                    MessageBox.Show("Failed get the Laser Info.Please try again.");
                    Reset_Datagridview(Next_Page);
                }
                USB_Protocol_Close();
            }
            else
            {
                Reset_Datagridview(Next_Page);
                MessageBox.Show("Please check the USB Connection and try again.");
                Log_报警("Please check the USB Connection and try again.");
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
                    uSB_Control_Info.Set_Info(Next_Page);
                    uSB_Control_RT.Set_RT(Next_Page);
                    uSB_Control_LS.Set_LS(Next_Page);
                    MessageBox.Show("Successfully complete the Laser Configuration.");
                    Log_日志("Successfully complete the Laser Configuration.");
                }
                catch
                {
                    MessageBox.Show("Failed get the Laser Info.Please try again.");
                    Log_报警("Failed get the Laser Info.Please try again.");
                }
                USB_Protocol_Close();
            }
            else
            {
                MessageBox.Show("Please check the USB Connection and try again.");
                Log_报警("Please check the USB Connection and try again.");
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
                    Log_报警("Failed get the Laser Info.Please try again.");
                }
                USB_Protocol_Close();
            }
            else
            {
                Reset_Datagridview(dataGridView_Channel);
                MessageBox.Show("Please check the USB Connection and try again.");
                Log_报警("Please check the USB Connection and try again.");
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
                    Log_日志("Successfully complete the Laser Configuration.");
                }
                catch
                {
                    MessageBox.Show("Failed get the Laser Info.Please try again.");
                    Log_报警("Failed get the Laser Info.Please try again.");
                }
                USB_Protocol_Close();
            }
            else
            {
                MessageBox.Show("Please check the USB Connection and try again.");
                Log_报警("Please check the USB Connection and try again.");
            }
        }

        public void Main_Change_TabControl(object sender,EventArgs e)
        {
            RadButtonElement Click_Button = sender as RadButtonElement;
            if(Click_Button.Name.Contains("主"))
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

        private void Next_Page1_Click(object sender, EventArgs e)
        {
            Tab_USB配置.SelectedIndex = 1;
        }

        private void Previous_Page_Click(object sender, EventArgs e)
        {
            Tab_USB配置.SelectedIndex = 0;
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
                网络模式显示.Text = "                   ---外部单机模式---                 ";
                MessageBox.Show("The system has been switched to external Network mode!");
                Log_日志("The system has been switched to external Network mode!");
            }            
        }

        private void 内部联网模式_Click(object sender, EventArgs e)
        {
            if (External_Net_Mode == true)
            {
                set_Internal_Net_Mode();
                External_Net_Mode = false;
                网络模式显示.Text = "                   ---内部单机模式---                 ";
                MessageBox.Show("The system has been switched to internal Network mode!");
                Log_日志("The system has been switched to internal Network mode!");
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
            USB_Configuration.Text = USB_xml_Number+".xml";
        }

        private void RS232新建配置用例_Click(object sender, EventArgs e)
        {
            User_Interface_Library.RS232通讯新建用例 UIL_RS232新建 = new RS232通讯新建用例();
            UIL_RS232新建.RS232_XML_Folder = Main_RS232_Folder;
            UIL_RS232新建.ShowDialog();
        }

        private void RS232编辑配置用例_Click(object sender, EventArgs e)
        {
            User_Interface_Library.RS232通讯编辑用例 UIL_RS232编辑 = new RS232通讯编辑用例();
            UIL_RS232编辑.RS232_XML_Folder = Main_RS232_Folder;
            UIL_RS232编辑.ShowDialog();
        }

        private void RS232载入配置用例_Click(object sender, EventArgs e)
        {
            User_Interface_Library.RS232通讯载入用例 UIL_RS232载入 = new RS232通讯载入用例();
            UIL_RS232载入.RS232_XML_Folder = Main_RS232_Folder;
            UIL_RS232载入.ShowDialog();
            RCD = UIL_RS232载入.RCD;
            Rest_DataTable = UIL_RS232载入.Rest_DataTable;
            主界面_Configure.Text = UIL_RS232载入.RS232_XML;
            串口协议_Configure.Text= UIL_RS232载入.RS232_XML;
            if((RCD!=null)&(RS232_SerialPort.Text!=""))
            {
                RSCL.SerialPortClose();
                Device_Connect_Refresh();
            }
        }

        private void Apply_Configuration_Click(object sender, EventArgs e)
        {
            if(USB_Configuration.Text!="")
            {
                USB_Configuration_Apply(Next_Page);
            }
            else
            {
                MessageBox.Show("Please import the Configuration File first.");
                Log_报警("Please import the Configuration File first.");
            }
        }

        public void USB_Configuration_Apply(DataGridView dataGridView)
        { 
            if(USB_Configuration.Text!="")
            {
                dataGridView.Rows[1].Cells[1].Value = USB配置_Data.waveLength;
                dataGridView.Rows[6].Cells[1].Value = USB配置_Data.vender_Name;
                dataGridView.Rows[7].Cells[1].Value = USB配置_Data.contact;
                dataGridView.Rows[8].Cells[1].Value = USB配置_Data.tel;
                dataGridView.Rows[0].Cells[3].Value = USB配置_Data.dt_Seq;
                dataGridView.Rows[1].Cells[3].Value = USB配置_Data.ch_Seq;
            }
        }

        #endregion


        public bool Admin;

        public void Admin_Show(bool Judge)
        {
            if(Judge==true)
            {
                USB配置界面.Visibility = ElementVisibility.Visible;
                USB控制界面.Visibility= ElementVisibility.Visible;
                USB通讯新建用例.Visibility= ElementVisibility.Visible;
                USB通讯编辑用例.Visibility= ElementVisibility.Visible;
                USB通讯载入用例.Visibility= ElementVisibility.Visible;
            }
            else
            {
                USB配置界面.Visibility = ElementVisibility.Hidden;
                USB控制界面.Visibility = ElementVisibility.Hidden;
                USB通讯新建用例.Visibility = ElementVisibility.Hidden;
                USB通讯编辑用例.Visibility = ElementVisibility.Hidden;
                USB通讯载入用例.Visibility = ElementVisibility.Hidden;
            }
        }

        #region 界面—管理员登录

        public void 登录_Init()
        {
            Admin = false;
            管理员显示.Text = "                  操作员模式              ";
            管理员显示.ForeColor = Color.Black;
        }

        private void 管理员界面登录_Click(object sender, EventArgs e)
        {
            if(Admin==false)
            {
                管理员登录 登录 = new 管理员登录();
                登录.ShowDialog();
                Admin = 登录.Admin;
                Admin_Show(Admin);
                if(Admin==true)
                {
                    管理员显示.Text = "                  管理员模式              ";
                    管理员显示.ForeColor = Color.Red;
                }
                else
                {
                    管理员显示.Text = "                  操作员模式              ";
                    管理员显示.ForeColor = Color.Black;
                }
            }
        }

        private void 密码修改_Click(object sender, EventArgs e)
        {
            密码修改 修改 = new 密码修改();
            修改.ShowDialog();
        }

        private void 管理员退出_Click(object sender, EventArgs e)
        {
            if(Admin==true)
            {
                Admin = false;
                MessageBox.Show("Successfully Login Out the Admin Mode.");
                管理员显示.Text = "                  操作员模式              ";
                管理员显示.ForeColor = Color.Black;
                Log_日志("Successfully Login Out the Admin Mode.");
                Admin_Show(Admin);
            }
        }

        #endregion 

        private void 网络模式显示_Click(object sender, EventArgs e)
        {

        }

        private void RS232_ClearText_Button_Click(object sender, EventArgs e)
        {

        }

        private void RS232_Command_Button_Click(object sender, EventArgs e)
        {

        }

        private void Command_List_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        #region//界面—RS232控制

        RS232类库.RS232_Control RSCL = new RS232类库.RS232_Control();
        //RS232类库.RS232_Function RSF = new RS232类库.RS232_Function();
        List<string> Device_List = new List<string>();
        public bool RS232_Open;
        public RS232配置_CommonData RCD;
        public string COM="";
        public DataTable Rest_DataTable;
        public List<string> WaveList;
        public int Channel;

        public void RS232_DeviceSearch()
        {
            Device_List = new List<string>();
            RSCL.SerialPortSearch(Device_List);
            foreach(string Device in Device_List)
            {
                RS232_SerialPort.Items.Add(Device);
            }
        }

        public void RS232_DeviceOpen()
        {
            if(RS232_SerialPort.Text!="")
            {
                try
                {
                    RSCL.SerialPortOpen(RS232_SerialPort.Text);
                    RS232_Open = true;
                }
                catch
                {
                    MessageBox.Show("Failed to open the device. Please check and set again.");
                    RS232_Open = false;
                    Log_报警("Failed to open the device. Please check and set again.");
                }
            }
            else
            {
                MessageBox.Show("Failed to open the device. Please check and set again.");
                RS232_Open = false;
                Log_报警("Failed to open the device. Please check and set again.");
            }
        }

        public void RS232_DeviceClose()
        {
            try
            {
                RSCL.SerialPortClose();
            }
            catch
            {
                MessageBox.Show("Failed to close the device. Please check and set again.");
            }
            RS232_Open = false;
            Device_Status.Text = "-----No Connection to Device";
            Device_Status.ForeColor = Color.Red;
            dataGridView1.Rows.Clear();
            Connect_OK(true);
        }

        public bool RS232_Init(out List<bool> CH_ONOFF_Read)
        {
            string Wave_Str;
            string Temp_Str;
            string Feedback_Str;
            bool RS232_Init;
            bool ONOFF;
            CH_ONOFF_Read = new List<bool>();
            if((RS232_Open==true)&(RCD!=null))
            {
                Wave_Str=RSCL.SerialPortWrite(RS232_SerialPort.Text, RCD.LaserChannel_Read+"\r\n");
                WaveList = RS232_WaveList_Convert(Wave_Str);
                try
                {
                    RS232_Init = true;
                    for (int i = 0; i < WaveList.Count; i++)
                    {
                        Temp_Str = RCD.LaserOnOff_Read.Replace("*", i.ToString());
                        Feedback_Str=RSCL.SerialPortWrite(RS232_SerialPort.Text, Temp_Str + "\r\n");
                        RS232_Init=Process_Feedback_Str(Feedback_Str, out ONOFF);
                        if(RS232_Init==false)
                        {
                            break;
                        }
                        CH_ONOFF_Read.Add(ONOFF);
                    }
                }
                catch
                {
                    RS232_Init = false;
                }
            }
            else
            {
                RS232_Init = false;
            }
            return RS232_Init;
        }

        public bool Process_Feedback_Str(string Temp_str,out bool ONOFF)
        {
            bool Init_OK;
            char[] Temp_char;
            List<char> char_List = new List<char>();
            Temp_char = Temp_str.ToCharArray();
            foreach(char temp in Temp_str)
            {
                if((temp>='0')&(temp <='9'))
                {
                    char_List.Add(temp);
                }
            }
            string Process_Str = string.Concat(char_List);
            if(Process_Str=="1")
            {
                ONOFF = true;
                Init_OK = true;
            }
            else if(Process_Str == "0")
            {
                ONOFF = false;
                Init_OK = true;
            }
            else
            {
                ONOFF = false;
                Init_OK = false;
            }
            return Init_OK;
        }

        public List<string> RS232_WaveList_Convert(string Orgin_Str)
        {
            List<string> waveList = new List<string>();
            string pattern = @"[^A-Za-z0-9\s]";
            string process_Temp = Regex.Replace(Orgin_Str, pattern, "");
            process_Temp = process_Temp.Replace("A CHMAP ", "").TrimEnd();
            string[] waveArray = process_Temp.Split(' ');
            foreach (string wave in waveArray)
            {
                waveList.Add(wave);
            }
            return waveList;
        }
        
        private void Refresh_Click(object sender, EventArgs e)
        {
            RS232_SerialPort.Items.Clear();
            RS232_DeviceSearch();
        }

        public void Connect_OK(bool Connect_OK)
        {
            if(Connect_OK==true)
            {
                Device_Connect.Visible = true;
                Device_Close.Visible = false;
            }
            else
            {
                Device_Connect.Visible = false;
                Device_Close.Visible = true;
            }
        }

        public void Device_Connect_Refresh()
        {
            bool Init_OK;
            List<bool> CH_ONOFF_Read = new List<bool>();
            RS232_DeviceOpen();
            Info_FW.Text = "";
            Info_Model.Text = "";
            Info_PN.Text = "";
            Info_SN.Text = "";
            if ((RS232_Open == true) & (RCD != null))
            {
                Init_OK = RS232_Init(out CH_ONOFF_Read);
                if (Init_OK == false)
                {
                    RS232_DeviceClose();
                    MessageBox.Show("Please check the import script first and check again.");
                    Log_报警("Please check the import script first and check again.");
                    Device_Status.Text = "-----No Connection to Device";
                    Device_Status.ForeColor = Color.Red;
                    Connect_OK(true);
                }
                else
                {
                    Device_Status.Text = "--------Connected to Device";
                    Device_Status.ForeColor = Color.Green;
                    Connect_OK(false);
                    COM = RS232_SerialPort.Text;
                    RS232_GetALLInfo();
                    RS232_Datagridview_Init(dataGridView1, WaveList, CH_ONOFF_Read);
                    Task_LaserRead();
                    RS232_RestCommand_Show();
                }
            }
            else
            {
                RS232_DeviceClose();
                Device_Status.Text = "-----No Connection to Device";
                Device_Status.ForeColor = Color.Red;
                Connect_OK(true);
                MessageBox.Show("Please check the Laser connection or import script first.");
                Log_报警("Please check the Laser connection or import script first.");
            }
        }

        #endregion


        #region //RS232初始化及连接
        private void Device_Connect_Click(object sender, EventArgs e)
        {
            Device_Connect_Refresh();
        }

        private void Device_Close_Click(object sender, EventArgs e)
        {
            CTS1.Cancel();
            Delay(500);
            Task.WaitAll(task);
            RS232_DeviceClose();
            RS232_Open = false;
            RS232_GetALLInfo();
            RS232_Mode.Active = false;
        }

        public void RS232_Datagridview_Init(DataGridView datagridview, List<string> wave_List, List<bool> CH_ONOFF_Read)
        {
            for (int i = 0; i < wave_List.Count(); i++)
            {
                datagridview.Rows.Add();
                datagridview.Rows[i].Height = 30;
                if (CH_ONOFF_Read[i] == true)
                {
                    datagridview.Rows[i].Cells[0].Value = Properties.Resources.Green222;
                }
                else
                {
                    datagridview.Rows[i].Cells[0].Value = Properties.Resources.Green111;
                }
                datagridview.Rows[i].Cells[1].Value = "CH" + i;
                datagridview.Rows[i].Cells[2].Value = wave_List[i];
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

        public void RS232_GetALLInfo()
        {
            if(RS232_Open==true)
            {
                try
                {
                    Info_FW.Text = RSCL.RS232_GetInfo_Process(RCD.LaserFWVersion_Read, RSCL.SerialPortWrite(RS232_SerialPort.Text, RCD.LaserFWVersion_Read+"\r\n"));
                    Info_Model.Text= RSCL.RS232_GetInfo_Process(RCD.LaserModel_Read, RSCL.SerialPortWrite(RS232_SerialPort.Text, RCD.LaserModel_Read + "\r\n"));
                    Info_PN.Text= RSCL.RS232_GetInfo_Process(RCD.LaserPN_Read, RSCL.SerialPortWrite(RS232_SerialPort.Text, RCD.LaserPN_Read + "\r\n"));
                    Info_SN.Text = RSCL.RS232_GetInfo_Process(RCD.LaserSN_Read, RSCL.SerialPortWrite(RS232_SerialPort.Text, RCD.LaserSN_Read + "\r\n"));
                    if(RCD.permilleRatio == "Yes")
                    {
                        Power_Unit.Text = "‰";
                    }
                    else
                    {
                        Power_Unit.Text = "%";
                    }
                }
                catch
                {
                    MessageBox.Show("Failed to get the Laser Information.");
                    Log_报警("Failed to get the Laser Information.");
                    Info_FW.Text = "";
                    Info_Model.Text = "";
                    Info_PN.Text = "";
                    Info_SN.Text = "";
                    Power_Unit.Text = "";
                }
            }
            else
            {
                Info_FW.Text = "";
                Info_Model.Text = "";
                Info_PN.Text = "";
                Info_SN.Text = "";
                Power_Unit.Text = "";
            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            channel_Label_Setting1.Text = "CH" + e.RowIndex.ToString();
            channel_Label_Setting2.Text = "CH" + e.RowIndex.ToString();
            Channel = e.RowIndex;
            RS232_RestCommand_Show();
        }

        #endregion


        #region //RS232功能设置
        Task task;
        ManualResetEvent MRE = new ManualResetEvent(true);
        CancellationTokenSource CTS1;
        CancellationToken CT1;

        private void RS232_Mode_Click(object sender, EventArgs e)
        {
            bool Judge;
            if ((RS232_Open == true) & (RCD != null))
            {
                if (RS232_Mode.Active == true)
                {
                    Judge = RSCL.Set_Main_Param(RS232_SerialPort.Text, RCD.LaserTTLMode_Set + "\r\n");
                    if (Judge == false)
                    {
                        MessageBox.Show("Failed to set the Laser TTL Mode");
                        Log_报警("Failed to set the Laser TTL Mode");
                    }
                }
                else
                {
                    Judge = RSCL.Set_Main_Param(RS232_SerialPort.Text, RCD.LaserFWMode_Set + "\r\n");
                    if (Judge == false)
                    {
                        MessageBox.Show("Failed to set the Laser TTL Mode");
                        Log_报警("Failed to set the Laser TTL Mode");
                    }
                }
            }
        }

        private void RS232_ONOFF_Button_Click(object sender, EventArgs e)
        {
            bool Judge;       
            if ((RS232_Open == true) & (RCD != null))
            {
                CTS1.Cancel();
                Delay(500);
                Task.WaitAll(task);
                if (RS232_ONOFF_Button.Text=="OFF")
                {
                    Judge = RSCL.Set_Main_Param(RS232_SerialPort.Text, RCD.LaserON_Set.Replace("*", Channel.ToString()) + "\r\n");
                    if (Judge == true)
                    {
                        RS232_ONOFF_Button.Text = "ON";
                    }
                    else
                    {
                        MessageBox.Show("Failed to set the Laser ON.");
                        Log_报警("Failed to set the Laser ON.");
                    }
                }
                else
                {
                    Judge = RSCL.Set_Main_Param(RS232_SerialPort.Text, RCD.LaserOff_Set.Replace("*", Channel.ToString()) + "\r\n");
                    if (Judge == true)
                    {
                       RS232_ONOFF_Button.Text = "OFF";
                    }
                    else
                    {
                       MessageBox.Show("Failed to set the Laser OFF.");
                       Log_报警("Failed to set the Laser OFF.");
                    }
                }
                Task_LaserRead();
            }
        }

        private void RS232_Power_Button_Click(object sender, EventArgs e)
        {
            bool Judge;
            if ((RS232_Open == true) & (RCD != null))
            {
                CTS1.Cancel();
                Delay(500);
                Task.WaitAll(task);
                try
                {
                    double Power_MaxSet;
                    Power_MaxSet = Convert.ToDouble(RS232_Power_Set.Text);
                    if (Power_MaxSet<=1000)
                    {
                        Judge = RSCL.Set_Main_Param(RS232_SerialPort.Text, RCD.LaserPower_Set.Replace("*", Channel.ToString()).Replace("#", RS232_Power_Set.Text)+"\r\n");
                        if (Judge == false)
                        {
                            MessageBox.Show("Failed to set the Laser Power.");
                            Log_报警("Failed to set the Laser Power.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please set the correct Power Value.");
                        Log_报警("Please set the correct Power Value.");
                    }
                }
                catch
                {
                    MessageBox.Show("Failed to set the Laser Power.");
                    Log_报警("Failed to set the Laser Power.");
                }
                finally
                {
                    Task_LaserRead();
                }
            }
        }

        public bool RS232_Get_TTLMode()
        {
            string Orgin_Answer;
            string Result;
            bool Judge;
            if ((RS232_Open == true) & (RCD != null))
            {
                Result = RSCL.RS232_GetInfo_Process(COM, RSCL.SerialPortWrite(COM, RCD.LaserMode_Read + "\r\n"));
                Result = Result.TrimEnd();
                Result = Result.TrimStart();
                Judge = true;
                if (Result == "1")
                {
                    if (this.InvokeRequired)
                    {
                        Invoke(new Action(() => { RS232_Mode.Active = false; }));
                    }
                    else
                    {
                        RS232_Mode.Active = false;
                    }
                }
                else if (Result == "0")
                {
                    if (this.InvokeRequired)
                    {
                        Invoke(new Action(() => { RS232_Mode.Active = true; }));
                    }
                    else
                    {
                        RS232_Mode.Active = true;
                    }
                }
                else
                {
                    Judge = false;
                }
            }
            else
            {
                Judge = false;
            }
            return Judge;
        }

        public bool RS232_Get_ActualPower()
        {
            string Orgin_Answer;
            string Result;
            bool Judge;
            if ((RS232_Open == true) & (RCD != null))
            {
                Judge = RSCL.Get_Main_Param(COM, RCD.LaserPower_Read.Replace("*", Channel.ToString()) + "\r\n", out Orgin_Answer);
                Result = Orgin_Answer.TrimEnd();
                Result = Result.TrimStart();
                if (this.InvokeRequired)
                {
                    Invoke(new Action(() => { RS232_Power_Read.Text = Result; }));
                }
                else
                {
                    RS232_Power_Read.Text = Result;
                }
                Judge = true;
            }
            else
            {
                Judge = false;
            }
            return Judge;
        }

        public bool RS232_Get_ONOFF()
        {
            bool Judge;
            bool ONOFF;
            if ((RS232_Open == true) & (RCD != null))
            {
                string Feedback_Str = RSCL.SerialPortWrite(COM, RCD.LaserOnOff_Read.Replace("*", Channel.ToString()) + "\r\n");
                bool RS232_Init = Process_Feedback_Str(Feedback_Str, out ONOFF);
                if (ONOFF == true)
                {
                    if (this.InvokeRequired)
                    {
                        Invoke(new Action(() => { RS232_ONOFF_Button.Text = "ON"; }));
                    }
                    else
                    {
                        RS232_ONOFF_Button.Text = "ON";
                    }
                }
                else
                {
                    if (this.InvokeRequired)
                    {
                        Invoke(new Action(() => { RS232_ONOFF_Button.Text = "OFF"; }));
                    }
                    else
                    {
                        RS232_ONOFF_Button.Text = "OFF";
                    }
                }
                Judge = true;
            }
            else
            {
                Judge = false;
            }
            return Judge;
        }

        public void Datagridview1_ReadPower_ONOFF(CancellationToken CT)
        {
            string Orgin_Answer;
            bool ONOFF;
            if ((RS232_Open == true) & (RCD != null))
            {
                for(int i=0;i<WaveList.Count;i++)
                {
                    if (CT.IsCancellationRequested)
                    {
                        return;
                    }
                    string Feedback_Str = RSCL.SerialPortWrite(COM, RCD.LaserOnOff_Read.Replace("*", i.ToString()) + "\r\n");
                    if (CT.IsCancellationRequested)
                    {
                        return;
                    }
                    Process_Feedback_Str(Feedback_Str, out ONOFF);
                    Invoke(new Action(() => {
                        if (ONOFF == true)
                        {                           
                            dataGridView1.Rows[i].Cells[0].Value = Properties.Resources.Green222;
                        }
                        else
                        {
                            dataGridView1.Rows[i].Cells[0].Value = Properties.Resources.Green111;
                        }
                        if (i == Channel)
                        {
                            if (ONOFF == true)
                            {
                                RS232_ONOFF_Button.Text = "ON";
                            }
                            else
                            {
                                RS232_ONOFF_Button.Text = "OFF";
                            }
                        }
                    }));

                    RSCL.Get_Main_Param(COM, RCD.LaserPower_Read.Replace("*", i.ToString()) + "\r\n", out Orgin_Answer);
                    if (CT.IsCancellationRequested)
                    {
                        return;
                    }
                    Invoke(new Action(() => {
                        dataGridView1.Rows[i].Cells[3].Value = Orgin_Answer;
                    }));
                    if(i==Channel)
                    {
                        Invoke(new Action(() => {
                            RS232_Power_Read.Text = Orgin_Answer;
                        }));
                    }
                }
            }
        }

        public void Task_LaserRead()
        {
            CTS1 = new CancellationTokenSource();
            CT1 = CTS1.Token;
            bool Judge1;
            bool Judge2;
            bool Judge3;
            string Orgin_Answer="";
            task = Task.Run(() =>
             {
             while (true)
             {
                    Datagridview1_ReadPower_ONOFF(CT1);
                    if (CT1.IsCancellationRequested)
                    {
                        return;
                    }
                    Judge2 = RS232_Get_TTLMode();
                    if (CT1.IsCancellationRequested)
                    {
                        return;
                    }
                }                
            }, CT1);
        }

        public void RS232_RestCommand_Show()
        {
            string str_Temp;
            Command_List.Items.Clear();
            for (int i=0;i < Rest_DataTable.Rows.Count;i++)
            {
                str_Temp = Rest_DataTable.Rows[i][1].ToString().Replace("*", Channel.ToString());
                Command_List.Items.Add(str_Temp);
            }
        }

        private void RS232_Command_Button_Click_1(object sender, EventArgs e)
        {
            string Output_Result;
            if((RS232_SerialPort.Text!="")&(Rest_DataTable.Rows.Count>=1))
            {
                CTS1.Cancel();
                Delay(500);
                Task.WaitAll(task);
                RS232_Command.Text = Command_List.Text;
                richTextBox3.AppendText(Command_List.Text+"\r\n");
                Output_Result =RSCL.SerialPortWrite(COM, Command_List.Text+"\r\n");
                richTextBox3.AppendText(Output_Result+ "\r\n");
                Task_LaserRead();
            }
        }

        private void RS232_ClearText_Button_Click_1(object sender, EventArgs e)
        {
            richTextBox3.Clear();
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            bool Judge = RS232_Get_ONOFF();
        }

        private void 退出界面_Click(object sender, EventArgs e)
        {
            DialogResult DR = MessageBox.Show("Confirm to close the program?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(DR==DialogResult.Yes)
            {
                if(CTS1!=null)
                {
                    CTS1.Cancel();
                    Delay(500);
                    Task.WaitAll(task);
                }

                RS232_DeviceClose();
                RS232_Open = false;
                RS232_GetALLInfo();
                RS232_Mode.Active = false;
                this.Close();
                Application.Exit();
            }
        }


        #region //报警信息
        public void SetLog(string Message, Color msColor, int FontSize)
        {
            try
            {
                if (!Directory.Exists(Application.StartupPath + "\\log"))
                {
                    Directory.CreateDirectory(Application.StartupPath + "\\log");
                }
                this.Invoke(new MethodInvoker(() =>
                {
                    if (报警信息.Lines.Length > 10000)
                    {
                        报警信息.Clear();
                    }
                    Message += "------" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n";
                    报警信息.AppendText(Message);
                    报警信息.Select(报警信息.TextLength - Message.Length > 0 ? 报警信息.TextLength - Message.Length + 1 : 0, Message.Length + 1);
                    报警信息.SelectionColor = msColor;
                    报警信息.SelectionFont = new Font("Times New Roman", FontSize);
                    报警信息.ScrollToCaret();
                    using (StreamWriter sw = new StreamWriter(Application.StartupPath + "\\log\\" + DateTime.Now.ToString("yyyy_MM_dd") + ".txt", true))
                    {
                        sw.Write(Message);
                    }
                }));
            }
            catch
            {

            }
        }

        public void Log_日志(string Input)
        {
            SetLog(Input, Color.Black, 8);
        }

        public void Log_报警(string Input)
        {
            SetLog(Input, Color.Red, 10);
        }

        private void radMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void radMenuItem1_Click(object sender, EventArgs e)
        {
            报警信息.Clear();
            Log_日志("Successfully clear the Log context.");
        }

        private void 历史查询_Click(object sender, EventArgs e)
        {
            日志查询 查询日志 = new 日志查询();
            查询日志.ShowDialog();
            if (查询日志.Judge == false)
            {
                Log_报警("Log filePath does not exist");
            }
        }


        #endregion

        private void USB控制界面_Click(object sender, EventArgs e)
        {
            
        }
    }
}
