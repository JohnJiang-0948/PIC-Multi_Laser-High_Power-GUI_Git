using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Windows.Forms;

namespace PIC_Multi_Laser_High_Power_GUI_V1._0.USB类库
{
    class USB_BASIC
    {
        #region //调用USB的Common dll文件

        [DllImport("common.dll")]
        internal static extern Boolean InitDevice(); //初始化USB程序

        [DllImport("common.dll")]
        internal static extern Boolean FinaDevice(); //结束USB程序

        [DllImport("common.dll")]
        internal static extern Boolean CheckDeviceReady();//检测USB设备是否准备完成

        [DllImport("common.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Boolean WriteData(Byte cmd, Byte[] data, UInt32 size);//向USB设备发送请求命令或数据

        [DllImport("common.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Boolean SetCH(Byte ch); //设置与USB设备发送端口

        public bool USB_InitDevice()
        {
            bool Judge;
            Judge = InitDevice();
            return Judge;
        }

        public bool USB_FinaDevice()
        {
            bool Judge;
            Judge = FinaDevice();
            return Judge;
        }

        public bool USB_CheckDeviceReady()
        {
            bool Judge;
            Judge = CheckDeviceReady();
            return Judge;
        }

        public bool USB_WriteData(Byte cmd, Byte[] data, UInt32 size)
        {
            bool Judge;
            Judge = WriteData(cmd, data, size);
            return Judge;
        }

        public bool USB_SetCH(Byte ch)
        {
            bool Judge;
            Judge = SetCH(ch);
            return Judge;
        }

        #endregion


        public enum CMD : byte
        {
            CMD_NOP = 0x00,
            CMD_SETUP,
            CMD_EXIT,
            CMD_SEAL_FRAM = 3,
            CMD_UNSEAL_FRAM = 4,
            CMD_READ_FSRAM = 5,
            CMD_WRITE_FSRAM = 6,
            CMD_UPDATE_RAM = 7,
            CMD_READ_COLLECT = 8,
            CMD_WRITE_LAS_EMITTING_WITH_SAVE = 9,
            CMD_WRITE_LAS_EMITTING_WITHOUT_SAVE = 10,
            CMD_READ_LAS_EMITTING = 11,
            CMD_WRITE_SET_POWR_WITH_SAVE = 12,
            CMD_WRITE_SET_POWR_WITHOUT_SAVE = 13,
            CMD_READ_ACTUAL_POWER = 14,
            CMD_MOD_ENABLE,
            CMD_MOD_PLARITY,
            CMD_WR_FSRAM_CRC = 253,
            CMD_RESET = 254,
            CMD_UPDATE = 255,
        };

        public int FieldOffset_SF<T>(string fieldName, int chNumber)
        {
            if (typeof(T).IsValueType == false)
            {
                throw new ArgumentOutOfRangeException("T");
            }
            FieldInfo field = typeof(T).GetField(fieldName);
            if (field == null)
            {
                throw new ArgumentOutOfRangeException("fieldName");
            }
            object[] attributes = field.GetCustomAttributes(
                typeof(FieldOffsetAttribute),
                true
            );
            if (attributes.Length == 0)
            {
                throw new ArgumentException();
            }
            FieldOffsetAttribute fieldOffset = (FieldOffsetAttribute)attributes[0];
            int result = 546 + fieldOffset.Value + (chNumber - 1) * 130;//98 ;
            return result;
        }

        public int FieldOffset<T>(string fieldName)
        {
            if (typeof(T).IsValueType == false)
            {
                throw new ArgumentOutOfRangeException("T");
            }
            FieldInfo field = typeof(T).GetField(fieldName);
            if (field == null)
            {
                throw new ArgumentOutOfRangeException("fieldName");
            }
            object[] attributes = field.GetCustomAttributes(
                typeof(FieldOffsetAttribute),
                true
            );
            if (attributes.Length == 0)
            {
                throw new ArgumentException();
            }
            FieldOffsetAttribute fieldOffset = (FieldOffsetAttribute)attributes[0];
            return fieldOffset.Value;
        }

        #region //Common Method

        public void GridviewInit(DataGridView dataGridView1,DataGridView dataGridView2)
        {
            for (int i = 0; i <= 17; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView2.Rows.Add();
            }
            dataGridView1.Rows[0].Cells[0].Value = "channel";
            dataGridView1.Rows[1].Cells[0].Value = "wave_list";
            dataGridView1.Rows[2].Cells[0].Value = "hardware_info";
            dataGridView1.Rows[3].Cells[0].Value = "software_info";
            dataGridView1.Rows[4].Cells[0].Value = "serial_number";
            dataGridView1.Rows[5].Cells[0].Value = "product_name";
            dataGridView1.Rows[6].Cells[0].Value = "vendor_name";
            dataGridView1.Rows[7].Cells[0].Value = "contact";
            dataGridView1.Rows[8].Cells[0].Value = "tel";
            dataGridView1.Rows[9].Cells[0].Value = "model";
            dataGridView1.Rows[10].Cells[0].Value = "mfg_date";
            dataGridView1.Rows[11].Cells[0].Value = "info_rsvd9";
            dataGridView1.Rows[12].Cells[0].Value = "bt1";
            dataGridView1.Rows[13].Cells[0].Value = "dt1";
            dataGridView1.Rows[14].Cells[0].Value = "dt2";
            dataGridView1.Rows[15].Cells[0].Value = "dt3";
            dataGridView1.Rows[16].Cells[0].Value = "dt4";
            dataGridView1.Rows[17].Cells[0].Value = "dt5";

            dataGridView1.Rows[0].Cells[2].Value = "dt_seq";
            dataGridView1.Rows[1].Cells[2].Value = "ch_seq";
            dataGridView1.Rows[2].Cells[2].Value = "power_on_time";
            dataGridView1.Rows[3].Cells[2].Value = "power_on_cycles";
            dataGridView1.Rows[4].Cells[2].Value = "over_bt_alarm_max";
            dataGridView1.Rows[5].Cells[2].Value = "crystal_temp_set";
            dataGridView1.Rows[6].Cells[2].Value = "dfb_curr_limit_resistance";
            dataGridView1.Rows[7].Cells[2].Value = "coarse_dfb_scan_interval";
            dataGridView1.Rows[8].Cells[2].Value = "fine_dfb_scan_inerval";
            dataGridView1.Rows[9].Cells[2].Value = "dfb_curr";
            dataGridView1.Rows[10].Cells[2].Value = "soa_curr";
            dataGridView1.Rows[11].Cells[2].Value = "over_dt_alarm_high";
            dataGridView1.Rows[12].Cells[2].Value = "over_dt_alarm_low";
            dataGridView1.Rows[13].Cells[2].Value = "over_at_alarm_high";
            dataGridView1.Rows[14].Cells[2].Value = "over_at_alarm_low";
            dataGridView1.Rows[15].Cells[2].Value = "quit_bt_high";
            dataGridView1.Rows[16].Cells[2].Value = "quit_bt_low";
            dataGridView1.Rows[17].Cells[2].Value = "quit_dt_high";
            dataGridView1.Rows[18].Cells[2].Value = "quit_dt_low";

            dataGridView2.Rows[0].Cells[0].Value = "ls_dt_temp_offset";
            dataGridView2.Rows[1].Cells[0].Value = "ls_powr_offset";
            dataGridView2.Rows[2].Cells[0].Value = "ls_powr_gain";
            dataGridView2.Rows[3].Cells[0].Value = "ls_curr_offset";
            dataGridView2.Rows[4].Cells[0].Value = "ls_curr_gain";
            dataGridView2.Rows[5].Cells[0].Value = "ls_volt_offset";
            dataGridView2.Rows[6].Cells[0].Value = "ls_volt_gain";
            dataGridView2.Rows[7].Cells[0].Value = "v2i_res";
            dataGridView2.Rows[8].Cells[0].Value = "spec_power";
            dataGridView2.Rows[9].Cells[0].Value = "set_power";
            dataGridView2.Rows[10].Cells[0].Value = "first_trigged";

            dataGridView2.Rows[0].Cells[2].Value = "power_err_set";
            dataGridView2.Rows[1].Cells[2].Value = "wavelength";
            dataGridView2.Rows[2].Cells[2].Value = "min_power";
            dataGridView2.Rows[3].Cells[2].Value = "max_power";
            dataGridView2.Rows[4].Cells[2].Value = "max_curr";
            dataGridView2.Rows[5].Cells[2].Value = "max_volt";
            dataGridView2.Rows[6].Cells[2].Value = "log_rom";
            dataGridView2.Rows[7].Cells[2].Value = "pwr_level";
            dataGridView2.Rows[8].Cells[2].Value = "pwr_cal";
            dataGridView2.Rows[9].Cells[2].Value = "ls_pm";
            dataGridView2.Rows[10].Cells[2].Value = "ls_cm";
            dataGridView2.Rows[11].Cells[2].Value = "ls_dt";
        }

        public void Unseal()
        {
            Byte[] buf = new Byte[30];
            for (byte i = 0; i < 24; i++)
            {
                buf[i] = (byte)(i + 2);
            }
            WriteData((Byte)CMD.CMD_UNSEAL_FRAM, buf, 30);
        }

        public void UpdateRAM()
        {
            Byte[] buf = new Byte[30];
            for (byte i = 0; i < 24; i++)
            {
                buf[i] = (byte)(i + 2);
            }

            WriteData((Byte)CMD.CMD_UPDATE_RAM, buf, 30);
        }

        public void WriteCRC()
        {
            Byte[] buf = new Byte[30];
            for (byte i = 0; i < 24; i++)
            {
                buf[i] = (byte)(i + 2);
            }

            WriteData((Byte)CMD.CMD_WR_FSRAM_CRC, buf, 30);
        }

        public string str_Process(string str_Raw)
        {
            string str_Final;
            str_Final = str_Raw.Replace("\0", " ");
            return str_Final;
        }

        public String arrayToString(Byte[] data)
        {
            String value;
            Byte count = 0;
            for (Byte index = 0; index < data.Length; index++)
            {
                if (data[index] == 0)
                {
                    break;
                }
                count += 1;
            }
            value = System.Text.Encoding.Default.GetString(data, 0, count);
            return (value);
        }

        public Byte[] ReadFsram(int addr, UInt32 len)
        {
            Byte[] buf = new Byte[30];
            buf[0] = (byte)((addr & 0xFF00) >> 8);
            buf[1] = (byte)(addr & 0x00FF);
            buf[2] = (byte)len;
            WriteData((Byte)CMD.CMD_READ_FSRAM, buf, 30);
            return buf;
        }

        public Byte[] ReadCollect(int addr, UInt32 len)
        {
            Byte[] buf = new Byte[30];
            buf[0] = (byte)((addr & 0xFF00) >> 8);
            buf[1] = (byte)(addr & 0x00FF);
            buf[2] = (byte)len;
            WriteData((Byte)CMD.CMD_READ_COLLECT, buf, 30);
            return buf;
        }

        public void WriteFeramString(int addr, UInt32 len, string input)
        {
            Byte[] buf = new Byte[30];
            byte[] floatByte = System.Text.Encoding.Default.GetBytes(input);
            buf[0] = (byte)((addr & 0xFF00) >> 8);
            buf[1] = (byte)(addr & 0x00FF);
            buf[2] = (byte)len;
            for (int i = 0; i < floatByte.Length; i++)
            {
                buf[i + 3] = floatByte[i];
            }
            WriteData((Byte)CMD.CMD_WRITE_FSRAM, buf, 30);
        }

        public void WriteFeramStringJudge(int addr, UInt32 len, string Allinput)
        {
            byte[] floatByte = System.Text.Encoding.Default.GetBytes(Allinput);
            if (floatByte.Length <= 24)
            {
                WriteFeramString(addr, len, Allinput);
            }
            else
            {
                int a = floatByte.Length / 24;
                int b = floatByte.Length % 24;
                for (int i = 0; i < a; i++)
                {
                    byte[] ProcessfloatByte = floatByte.Skip(i * 24).Take(24).ToArray();
                    WriteFeramString(addr + i * 24, len, System.Text.ASCIIEncoding.ASCII.GetString(ProcessfloatByte));
                }
                byte[] RestfloatByte = floatByte.Skip(a * 24).Take(b).ToArray();
                WriteFeramString(addr + a * 24, len, System.Text.ASCIIEncoding.ASCII.GetString(RestfloatByte));
            }
        }

        public void WriteFsramFloat(int addr, UInt32 len, float input)
        {
            byte[] floatByte = BitConverter.GetBytes(input);
            Byte[] buf = new Byte[30];
            buf[0] = (byte)((addr & 0xFF00) >> 8);
            buf[1] = (byte)(addr & 0x00FF);
            buf[2] = (byte)len;
            buf[3] = floatByte[3];
            buf[4] = floatByte[2];
            buf[5] = floatByte[1];
            buf[6] = floatByte[0];
            WriteData((Byte)CMD.CMD_WRITE_FSRAM, buf, 3 + len);
        }

        public void WriteFsramByte(int addr, UInt32 len, byte input)
        {
            Byte[] buf = new Byte[30];
            buf[0] = (byte)((addr & 0xFF00) >> 8);
            buf[1] = (byte)(addr & 0x00FF);
            buf[2] = (byte)len;
            buf[3] = input;
            WriteData((Byte)CMD.CMD_WRITE_FSRAM, buf, 3 + len);
        }

        public void WriteFsramUint16(int addr, UInt32 len, UInt16 input)
        {
            Byte[] buf = new Byte[30];
            byte[] Uint16Byte = BitConverter.GetBytes(input);
            buf[0] = (byte)((addr & 0xFF00) >> 8);
            buf[1] = (byte)(addr & 0x00FF);
            buf[2] = (byte)len;
            buf[3] = Uint16Byte[1];
            buf[4] = Uint16Byte[0];
            WriteData((Byte)CMD.CMD_WRITE_FSRAM, buf, 3 + len);
        }

        public void WriteFsramUint32(int addr, UInt32 len, UInt32 input)
        {
            Byte[] buf = new Byte[30];
            byte[] Uint32Byte = BitConverter.GetBytes(input);
            buf[0] = (byte)((addr & 0xFF00) >> 8);
            buf[1] = (byte)(addr & 0x00FF);
            buf[2] = (byte)len;
            buf[3] = Uint32Byte[3];
            buf[4] = Uint32Byte[2];
            buf[5] = Uint32Byte[1];
            buf[6] = Uint32Byte[0];
            WriteData((Byte)CMD.CMD_WRITE_FSRAM, buf, 3 + len);
        }

        public float byteTOFloat(byte[] originByte)
        {
            byte[] convertByte = originByte.Skip(0).Take(4).ToArray();
            Array.Reverse(convertByte, 0, 4);
            float result = BitConverter.ToSingle(convertByte, 0);
            return result;
        }

        public float byteTOFloatV2(byte[] originByte)
        {
            byte[] convertByte = originByte.Skip(1).Take(4).ToArray();
            Array.Reverse(convertByte, 0, 4);
            float result = BitConverter.ToSingle(convertByte, 0);
            return result;
        }

        public UInt32 byteTOUint32(byte[] originByte)
        {
            byte[] convertByte = originByte.Skip(0).Take(4).ToArray();
            Array.Reverse(convertByte, 0, 4);
            UInt32 result = BitConverter.ToUInt32(convertByte, 0);
            return result;
        }

        public UInt16 byteTOUint16(byte[] originByte)
        {
            byte[] convertByte = originByte.Skip(0).Take(2).ToArray();
            Array.Reverse(convertByte, 0, 2);
            UInt16 result = BitConverter.ToUInt16(convertByte, 0);
            return result;
        }
        #endregion
    }
}
