using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;

namespace PIC_Multi_Laser_High_Power_GUI_V1._0
{
    class RS232_Control
    {
            SerialPort Serialport = new SerialPort();
            #region//RS232基本函数

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
        }
}
