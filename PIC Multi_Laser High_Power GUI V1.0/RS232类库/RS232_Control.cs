using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace PIC_Multi_Laser_High_Power_GUI_V1._0.RS232类库
{
    class RS232_Control
    {
            SerialPort Serialport = new SerialPort();

        #region//RS232通用函数

            public void SerialPortSearch(List<string> portList)
            {
                foreach (string port in SerialPort.GetPortNames())
                {
                    portList.Add(port);
                }

            }//Search Port

            public void SerialPortOpen(string COM)
            {
                Serialport.PortName = COM;
                Serialport.BaudRate = Convert.ToInt32(115200.ToString());
                Serialport.ReadTimeout = 1000;  //串口读取超时时间
                Serialport.WriteTimeout = 1000; //串口写入超时时间
                Serialport.Open();
                Delay(100);
            }

            public void SerialPortClose()
            {
                Delay(40);
                Serialport.Close();
            }

            public string SerialPortWrite(string COM, string CMD_Input)                         //串口通信读取
            {
                string CMD_Output = "";
                Serialport.Write(CMD_Input);
                Delay(100);
                string temp = Serialport.ReadExisting();
                bool Judge = temp.Contains("\r\n");
                if (Judge == false)
                {
                    CMD_Output = temp;
                }
                else
                {
                    CMD_Output = temp.Trim(new char[2] { '\r', '\n' });
                }
                Serialport.DiscardInBuffer();
                return CMD_Output;
            }

            public static void Delay(int milliSecond)
            {
                int start = Environment.TickCount;
                while (Math.Abs(Environment.TickCount - start) < milliSecond)
                {
                    Application.DoEvents();
                }
            }
        #endregion

        #region //RS232功能函数

        public bool RS232_SetCMD_Process(string Orgin_SetCMD)
        {
            bool Judge;
            if (Orgin_SetCMD.Contains("A "))
            {
                Judge = true;
            }
            else
            {
                Judge = false;
            }
            return Judge;
        }

        public string RS232_GetCMD_Process(string Orgin_GetCMD, string Orgin_Answers)
        {
            string Temp_Str;
            if (Orgin_GetCMD!="")
            {
                Orgin_GetCMD = Regex.Replace(Orgin_GetCMD, @"[^A-Za-z\s]", "");
                Temp_Str = Orgin_Answers.Replace("A " + Orgin_GetCMD.Replace("GET ", ""), "");
            }
            else
            {
                Temp_Str = "";
            }
            return Temp_Str;
        }

        public string RS232_GetInfo_Process(string Orgin_GetCMD, string Orgin_Answers)
        {
            string Temp_Answers;
            if(Orgin_GetCMD!="")
            {
                if (Orgin_GetCMD != "")
                {
                    Temp_Answers = Orgin_Answers.Replace("A " + Orgin_GetCMD.Replace("GET ", ""), "");
                }
                else
                {
                    Temp_Answers = "";
                }
            }
            else
            {
                Temp_Answers = "";
            }
            return Temp_Answers;
        }

        public bool Set_Main_Param(string COM, string Orgin_GetCMD)
        {
            bool Judge;
            string Temp = SerialPortWrite(COM, Orgin_GetCMD);
            if (Temp.Contains("A "))
            {
                Judge = true;
            }
            else
            {
                Judge = false;
            }
            return Judge;
        }

        public string Get_Main_Process(string COM, string Orgin_GetCMD, string Orgin_Answers)
        {
            string result;
            if (Orgin_GetCMD != "")
            {
                string str_Temp = "";
                int secondSpaceIndex = Orgin_GetCMD.IndexOf(' ', Orgin_GetCMD.IndexOf(' ') + 1);
                if (secondSpaceIndex != -1)
                {
                    str_Temp = Orgin_GetCMD.Substring(0, secondSpaceIndex);
                }
                str_Temp = str_Temp.Replace("GET", "A");
                if (Orgin_Answers.Contains(str_Temp))
                {
                    result = Orgin_Answers.Replace(str_Temp, "");
                }
                else
                {
                    result = "";
                }
            }
            else
            {
                result = "";
            }
            return result;
        }

        public bool Get_Main_Param(string COM, string str_Cmd, out string str_Result)
        {
            bool Judge;
            string Orgin_Answer;
            str_Result = "";
            if(str_Cmd!="")
            {
                try
                {
                    Orgin_Answer = SerialPortWrite(COM, str_Cmd);
                    str_Result = Get_Main_Process(COM, str_Cmd, Orgin_Answer);
                    if (str_Result == "")
                    {
                        Judge = false;
                    }
                    else
                    {
                        Judge = true;

                    }
                }
                catch
                {
                    Judge = false;
                }
            }
           else
            {
                Judge = true;
                str_Result = "";
            }
            return Judge;
        }

        #endregion
    }




}
