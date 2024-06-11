using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PIC_Multi_Laser_High_Power_GUI_V1._0.USB类库
{
    class USB_Control_Info:USB_BASIC
    {
        [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Ansi, Pack = 1)]
        unsafe public struct INFO
        {
            [FieldOffset(0)]
            public fixed byte wave_list[60];
            [FieldOffset(60)]
            public fixed byte hardware_info[30];
            [FieldOffset(90)]
            public fixed byte software_info[30];
            [FieldOffset(120)]
            public fixed byte serial_number[30];
            [FieldOffset(150)]
            public fixed byte product_name[30];
            [FieldOffset(180)]
            public fixed byte vendor_name[30];
            [FieldOffset(210)]
            public fixed byte contact[60];
            [FieldOffset(270)]
            public fixed byte tel[30];
            [FieldOffset(300)]
            public fixed byte model[30];
            [FieldOffset(330)]
            public fixed byte mfg_date[30];
            [FieldOffset(360)]
            public fixed byte info_rsvd9[22];
            [FieldOffset(382)]
            public UInt16 info_rsvd1;
            [FieldOffset(384)]
            public UInt16 info_rsvd2;
            [FieldOffset(386)]
            public UInt16 info_rsvd3;
            [FieldOffset(388)]
            public UInt16 info_rsvd4;
            [FieldOffset(390)]
            public UInt16 info_rsvd5;
            [FieldOffset(392)]
            public UInt16 info_rsvd6;
            [FieldOffset(394)]
            public UInt16 info_rsvd7;
            [FieldOffset(396)]
            public UInt16 info_rsvd8;
            [FieldOffset(398)]
            public fixed byte signature_info[1];
            [FieldOffset(399)]
            public fixed byte crc_info[1];
        };

        public Byte[] ReadFsram(int addr, UInt32 len)
        {
            Byte[] buf = new Byte[30];
            buf[0] = (byte)((addr & 0xFF00) >> 8);
            buf[1] = (byte)(addr & 0x00FF);
            buf[2] = (byte)len;
            WriteData((Byte)CMD.CMD_READ_FSRAM, buf, 30);
            return buf;
        }

        public string Convert_Str(string Orgin_Str)
        {
            string Process_Str;
            Process_Str = Orgin_Str.Replace("\0", "");
            return Process_Str;
        }

        public void Get_Info(DataGridView dataGridView)
        {
            Byte[] buffer = new Byte[30];
            Byte[] bufferAddress1 = new Byte[30];
            Byte[] bufferAddress2 = new Byte[30];
            string waveList1;
            string waveList2;

            bufferAddress1 = ReadFsram(FieldOffset<INFO>("contact"), 30);
            bufferAddress2 = ReadFsram(FieldOffset<INFO>("contact") + 30, 30);
            dataGridView.Rows[7].Cells[1].Value = Convert_Str(System.Text.ASCIIEncoding.ASCII.GetString(bufferAddress1) + System.Text.ASCIIEncoding.ASCII.GetString(bufferAddress2));

            buffer = ReadFsram(FieldOffset<INFO>("wave_list"), 30);
            waveList1 = System.Text.ASCIIEncoding.ASCII.GetString(buffer);
            buffer = ReadFsram(FieldOffset<INFO>("wave_list") + 30, 30);
            waveList2 = System.Text.ASCIIEncoding.ASCII.GetString(buffer);
            dataGridView.Rows[1].Cells[1].Value = Convert_Str(str_Process(waveList1 + waveList2));

            buffer = ReadFsram(FieldOffset<INFO>("hardware_info"), 30);
            dataGridView.Rows[2].Cells[1].Value = Convert_Str(System.Text.ASCIIEncoding.ASCII.GetString(buffer));

            buffer = ReadFsram(FieldOffset<INFO>("software_info"), 30);
            dataGridView.Rows[3].Cells[1].Value = Convert_Str(str_Process(System.Text.ASCIIEncoding.ASCII.GetString(buffer)));

            buffer = ReadFsram(FieldOffset<INFO>("serial_number"), 30);
            string Temp = System.Text.ASCIIEncoding.ASCII.GetString(buffer);
            dataGridView.Rows[4].Cells[1].Value = Convert_Str(System.Text.ASCIIEncoding.ASCII.GetString(buffer));

            buffer = ReadFsram(FieldOffset<INFO>("product_name"), 30);
            dataGridView.Rows[5].Cells[1].Value = Convert_Str(System.Text.ASCIIEncoding.ASCII.GetString(buffer));

            buffer = ReadFsram(FieldOffset<INFO>("vendor_name"), 30);
            dataGridView.Rows[6].Cells[1].Value = Convert_Str(System.Text.ASCIIEncoding.ASCII.GetString(buffer));

            buffer = ReadFsram(FieldOffset<INFO>("tel"), 30);
            dataGridView.Rows[8].Cells[1].Value = Convert_Str(System.Text.ASCIIEncoding.ASCII.GetString(buffer));

            buffer = ReadFsram(FieldOffset<INFO>("model"), 30);
            dataGridView.Rows[9].Cells[1].Value = Convert_Str(System.Text.ASCIIEncoding.ASCII.GetString(buffer));

            buffer = ReadFsram(FieldOffset<INFO>("mfg_date"), 30);
            dataGridView.Rows[10].Cells[1].Value = Convert_Str(System.Text.ASCIIEncoding.ASCII.GetString(buffer));

            buffer = ReadFsram(FieldOffset<INFO>("info_rsvd9"), 30);
            dataGridView.Rows[11].Cells[1].Value = Convert_Str(str_Process(System.Text.ASCIIEncoding.ASCII.GetString(buffer)));        
        }

        public void Set_Info(DataGridView dataGridView)
        {            
            WriteFeramStringJudge(FieldOffset<INFO>("wave_list"), 60, dataGridView.Rows[1].Cells[1].Value.ToString());
            WriteFeramStringJudge(FieldOffset<INFO>("hardware_info"), 30, dataGridView.Rows[2].Cells[1].Value.ToString());
            WriteFeramStringJudge(FieldOffset<INFO>("software_info"), 30, dataGridView.Rows[3].Cells[1].Value.ToString());
            WriteFeramStringJudge(FieldOffset<INFO>("serial_number"), 30, dataGridView.Rows[4].Cells[1].Value.ToString());
            WriteFeramStringJudge(FieldOffset<INFO>("product_name"), 30, dataGridView.Rows[5].Cells[1].Value.ToString());
            WriteFeramStringJudge(FieldOffset<INFO>("vendor_name"), 30, dataGridView.Rows[6].Cells[1].Value.ToString());
            WriteFeramStringJudge(FieldOffset<INFO>("contact"), 30, dataGridView.Rows[7].Cells[1].Value.ToString());
            WriteFeramStringJudge(FieldOffset<INFO>("tel"), 30, dataGridView.Rows[8].Cells[1].Value.ToString());
            WriteFeramStringJudge(FieldOffset<INFO>("model"), 30, dataGridView.Rows[9].Cells[1].Value.ToString());
            WriteFeramStringJudge(FieldOffset<INFO>("mfg_date"), 30, dataGridView.Rows[10].Cells[1].Value.ToString());
            WriteFeramStringJudge(FieldOffset<INFO>("info_rsvd9"), 30, dataGridView.Rows[11].Cells[1].Value.ToString());
        }
    }
}
