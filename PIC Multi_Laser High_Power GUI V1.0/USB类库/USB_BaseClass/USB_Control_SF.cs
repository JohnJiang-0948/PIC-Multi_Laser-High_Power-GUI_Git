using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PIC_Multi_Laser_High_Power_GUI_V1._0.USB类库
{
    class USB_Control_SF:USB_BASIC
    {
        [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Ansi, Pack = 1)]
        unsafe public struct SF
        {//98
            [FieldOffset(0)]
            public float ls_dt_temp_offset;
            [FieldOffset(4)]
            public float rsdv0;
            [FieldOffset(8)]
            public float ls_powr_offset;
            [FieldOffset(12)]
            public float ls_powr_gain;
            [FieldOffset(16)]
            public float ls_curr_offset;
            [FieldOffset(20)]
            public float ls_curr_gain;
            [FieldOffset(24)]
            public float ls_volt_offset;
            [FieldOffset(28)]
            public float ls_volt_gain;
            [FieldOffset(32)]
            public UInt16 v2i_res;
            [FieldOffset(34)]
            public UInt16 spec_power;
            [FieldOffset(36)]
            public UInt16 pes;
            [FieldOffset(38)]
            public UInt16 wavelength;
            [FieldOffset(40)]
            public UInt16 min_power;
            [FieldOffset(42)]
            public UInt16 max_power;
            [FieldOffset(44)]
            public UInt16 max_curr;
            [FieldOffset(46)]
            public UInt16 max_volt;
            [FieldOffset(48)]
            public UInt16 rsvd1;
            [FieldOffset(50)]
            public UInt16 rsvd2;
            [FieldOffset(52)]
            public float over_dt_alarm_max;
            [FieldOffset(56)]
            public float over_dt_alarm_min;
            [FieldOffset(60)]
            public float pa;
            [FieldOffset(64)]
            public float ca;
            [FieldOffset(68)]
            public float set_power;
            [FieldOffset(72)]
            public float rsvd3;
            [FieldOffset(76)]
            public UInt32 total_run_time;
            [FieldOffset(94)]
            public Byte first_trigged;
            [FieldOffset(95)]
            public Byte log_rom;
            [FieldOffset(96)]
            public float pwr_level;
            [FieldOffset(100)]
            public float pwr_cal;
            [FieldOffset(104)]
            public float rsvd4;
            [FieldOffset(108)]
            public float rsvd5;
            [FieldOffset(112)]
            public float rsvd6;
            [FieldOffset(116)]
            public float rsvd7;
            [FieldOffset(120)]
            public float rsvd8;
            [FieldOffset(124)]
            public float rsvd9;
            [FieldOffset(128)]
            public byte signature_sf;
            [FieldOffset(129)]
            public byte crc_sf;
        };

        public void Get_SF(DataGridView dataGridView,int chNum)
        {
            Byte[] buffer = new Byte[30];
            buffer = ReadFsram(FieldOffset_SF<SF>("ls_dt_temp_offset", chNum), 4);
            dataGridView.Rows[0].Cells[1].Value = byteTOFloat(buffer).ToString();

            buffer = ReadFsram(FieldOffset_SF<SF>("ls_powr_offset", chNum), 4);
            dataGridView.Rows[1].Cells[1].Value = byteTOFloat(buffer).ToString();

            buffer = ReadFsram(FieldOffset_SF<SF>("ls_powr_gain", chNum), 4);
            dataGridView.Rows[2].Cells[1].Value = byteTOFloat(buffer).ToString();

            buffer = ReadFsram(FieldOffset_SF<SF>("ls_curr_offset", chNum), 4);
            dataGridView.Rows[3].Cells[1].Value = byteTOFloat(buffer).ToString();

            buffer = ReadFsram(FieldOffset_SF<SF>("ls_curr_gain", chNum), 4);
            dataGridView.Rows[4].Cells[1].Value = byteTOFloat(buffer).ToString();

            buffer = ReadFsram(FieldOffset_SF<SF>("ls_volt_offset", chNum), 4);
            dataGridView.Rows[5].Cells[1].Value = byteTOFloat(buffer).ToString();

            buffer = ReadFsram(FieldOffset_SF<SF>("ls_volt_gain", chNum), 4);
            dataGridView.Rows[6].Cells[1].Value = byteTOFloat(buffer).ToString();

            buffer = ReadFsram(FieldOffset_SF<SF>("v2i_res", chNum), 2);
            dataGridView.Rows[7].Cells[1].Value = byteTOUint16(buffer).ToString();

            buffer = ReadFsram(FieldOffset_SF<SF>("spec_power", chNum), 2);
            dataGridView.Rows[8].Cells[1].Value = byteTOUint16(buffer).ToString();

            buffer = ReadFsram(FieldOffset_SF<SF>("set_power", chNum), 4);
            dataGridView.Rows[9].Cells[1].Value = byteTOFloat(buffer).ToString();

            buffer = ReadFsram(FieldOffset_SF<SF>("first_trigged", chNum), 1);
            dataGridView.Rows[10].Cells[1].Value = buffer[0].ToString();

            buffer = ReadFsram(FieldOffset_SF<SF>("pes", chNum), 2);
            dataGridView.Rows[0].Cells[3].Value = byteTOUint16(buffer).ToString();

            buffer = ReadFsram(FieldOffset_SF<SF>("wavelength", chNum), 2);
            dataGridView.Rows[1].Cells[3].Value = byteTOUint16(buffer).ToString();

            buffer = ReadFsram(FieldOffset_SF<SF>("min_power", chNum), 2);
            dataGridView.Rows[2].Cells[3].Value = byteTOUint16(buffer).ToString();

            buffer = ReadFsram(FieldOffset_SF<SF>("max_power", chNum), 2);
            dataGridView.Rows[3].Cells[3].Value = byteTOUint16(buffer).ToString();

            buffer = ReadFsram(FieldOffset_SF<SF>("max_curr", chNum), 2);
            dataGridView.Rows[4].Cells[3].Value = byteTOUint16(buffer).ToString();

            buffer = ReadFsram(FieldOffset_SF<SF>("max_volt", chNum), 2);
            dataGridView.Rows[5].Cells[3].Value = byteTOUint16(buffer).ToString();

            buffer = ReadFsram(FieldOffset_SF<SF>("log_rom", chNum), 1);
            dataGridView.Rows[6].Cells[3].Value = buffer[0].ToString();

            buffer = ReadFsram(FieldOffset_SF<SF>("pwr_level", chNum), 4);
            dataGridView.Rows[7].Cells[3].Value = byteTOFloat(buffer).ToString();

            buffer = ReadFsram(FieldOffset_SF<SF>("pwr_cal", chNum), 4);
            dataGridView.Rows[8].Cells[3].Value = byteTOFloat(buffer).ToString();
        }

        public void Set_SF(DataGridView dataGridView, int chNum)
        {
            WriteFsramFloat(FieldOffset_SF<SF>("ls_dt_temp_offset", chNum), 4, float.Parse(dataGridView.Rows[0].Cells[1].Value.ToString()));
            WriteFsramFloat(FieldOffset_SF<SF>("ls_powr_offset", chNum), 4, float.Parse(dataGridView.Rows[1].Cells[1].Value.ToString()));
            WriteFsramFloat(FieldOffset_SF<SF>("ls_powr_gain", chNum), 4, float.Parse(dataGridView.Rows[2].Cells[1].Value.ToString()));
            WriteFsramFloat(FieldOffset_SF<SF>("ls_curr_offset", chNum), 4, float.Parse(dataGridView.Rows[3].Cells[1].Value.ToString()));
            WriteFsramFloat(FieldOffset_SF<SF>("ls_curr_gain", chNum), 4, float.Parse(dataGridView.Rows[4].Cells[1].Value.ToString()));
            WriteFsramFloat(FieldOffset_SF<SF>("ls_volt_offset", chNum), 4, float.Parse(dataGridView.Rows[5].Cells[1].Value.ToString()));
            WriteFsramFloat(FieldOffset_SF<SF>("ls_volt_gain", chNum), 4, float.Parse(dataGridView.Rows[6].Cells[1].Value.ToString()));
            WriteFsramUint16(FieldOffset_SF<SF>("v2i_res", chNum), 2, UInt16.Parse(dataGridView.Rows[7].Cells[1].Value.ToString()));
            WriteFsramUint16(FieldOffset_SF<SF>("spec_power", chNum), 2, UInt16.Parse(dataGridView.Rows[8].Cells[1].Value.ToString()));
            WriteFsramFloat(FieldOffset_SF<SF>("set_power", chNum), 4, float.Parse(dataGridView.Rows[9].Cells[1].Value.ToString()));
            WriteFsramByte(FieldOffset_SF<SF>("first_trigged", chNum), 1, byte.Parse(dataGridView.Rows[10].Cells[1].Value.ToString()));
            WriteFsramUint16(FieldOffset_SF<SF>("pes", chNum), 2, UInt16.Parse(dataGridView.Rows[0].Cells[3].Value.ToString()));
            WriteFsramUint16(FieldOffset_SF<SF>("wavelength", chNum), 2, UInt16.Parse(dataGridView.Rows[1].Cells[3].Value.ToString()));
            WriteFsramUint16(FieldOffset_SF<SF>("min_power", chNum), 2, UInt16.Parse(dataGridView.Rows[2].Cells[3].Value.ToString()));
            WriteFsramUint16(FieldOffset_SF<SF>("max_power", chNum), 2, UInt16.Parse(dataGridView.Rows[3].Cells[3].Value.ToString()));
            WriteFsramUint16(FieldOffset_SF<SF>("max_curr", chNum), 2, UInt16.Parse(dataGridView.Rows[4].Cells[3].Value.ToString()));
            WriteFsramUint16(FieldOffset_SF<SF>("max_volt", chNum), 2, UInt16.Parse(dataGridView.Rows[5].Cells[3].Value.ToString()));
            WriteFsramByte(FieldOffset_SF<SF>("log_rom", chNum), 1, byte.Parse(dataGridView.Rows[6].Cells[3].Value.ToString()));
            WriteFsramFloat(FieldOffset_SF<SF>("pwr_level", chNum), 4, float.Parse(dataGridView.Rows[7].Cells[3].Value.ToString()));
            WriteFsramFloat(FieldOffset_SF<SF>("pwr_cal", chNum), 4, float.Parse(dataGridView.Rows[8].Cells[3].Value.ToString()));
        }
    }
}
