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
    class USB_Control_RT:USB_BASIC
    {
        [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Ansi, Pack = 1)]
        unsafe public struct RT
        {
            [FieldOffset(400)]
            public byte channel;
            [FieldOffset(401)]
            public byte rsvd3;
            [FieldOffset(402)]
            public UInt32 power_on_time;
            [FieldOffset(406)]
            public UInt32 power_on_cycles;
            [FieldOffset(410)]
            public UInt32 rt_rsvd1;
            [FieldOffset(414)]
            public UInt32 rt_rsvd2;
            [FieldOffset(418)]
            public UInt32 ch_seq;
            [FieldOffset(422)]
            public UInt32 dt_seq;
            [FieldOffset(426)]
            public UInt16 misc1;
            [FieldOffset(428)]
            public UInt16 misc2;
            [FieldOffset(430)]
            public UInt16 misc3;
            [FieldOffset(432)]
            public UInt16 misc4;
            [FieldOffset(434)]
            public UInt16 misc5;
            [FieldOffset(436)]
            public UInt16 misc6;
            [FieldOffset(438)]
            public UInt16 misc7;
            [FieldOffset(440)]
            public UInt16 misc8;
            [FieldOffset(442)]
            public UInt16 misc9;
            [FieldOffset(444)]
            public UInt16 misc10;
            [FieldOffset(446)]
            public float over_bt_alarm_max;
            [FieldOffset(450)]
            public float over_bt_alarm_min;
            [FieldOffset(454)]
            public float sys_bt1_temp_offset;
            [FieldOffset(458)]
            public float sys_bt2_temp_offset;
            [FieldOffset(462)]
            public float over_dt_alarm_high;
            [FieldOffset(466)]
            public float over_dt_alarm_low;
            [FieldOffset(470)]
            public float over_at_alarm_high;
            [FieldOffset(474)]
            public float over_at_alarm_low;
            [FieldOffset(478)]
            public float quit_bt_high;
            [FieldOffset(482)]
            public float quit_bt_low;
            [FieldOffset(486)]
            public float quit_dt_high;
            [FieldOffset(490)]
            public float quit_dt_low;
            [FieldOffset(494)]
            public byte signature_rt;
            [FieldOffset(495)]
            public byte crc_rt;
        };

        public void Get_RT(DataGridView dataGridView)
        {
            Byte[] buffer = new Byte[30];
            buffer = ReadFsram(FieldOffset<RT>("channel"), 1);
            dataGridView.Rows[0].Cells[1].Value = buffer[0].ToString();

            buffer = ReadFsram(FieldOffset<RT>("ch_seq"), 4);
            UInt32 ch_seq_result = byteTOUint32(buffer);
            dataGridView.Rows[1].Cells[3].Value = ch_seq_result.ToString();

            buffer = ReadFsram(FieldOffset<RT>("dt_seq"), 4);
            UInt32 dt_seq_result = byteTOUint32(buffer);
            dataGridView.Rows[0].Cells[3].Value = dt_seq_result.ToString();

            buffer = ReadFsram(FieldOffset<RT>("power_on_time"), 4);
            UInt32 power_on_time_Result = byteTOUint32(buffer);
            dataGridView.Rows[2].Cells[3].Value = power_on_time_Result.ToString();

            buffer = ReadFsram(FieldOffset<RT>("power_on_cycles"), 4);
            UInt32 power_on_cycles_Result = byteTOUint32(buffer);
            dataGridView.Rows[3].Cells[3].Value = power_on_cycles_Result.ToString();

            buffer = ReadFsram(FieldOffset<RT>("over_bt_alarm_max"), 4);
            float over_bt_alarm_max_Result = byteTOFloat(buffer);
            dataGridView.Rows[4].Cells[3].Value = over_bt_alarm_max_Result.ToString();

            buffer = ReadFsram(FieldOffset<RT>("over_dt_alarm_high"), 4);
            float over_dt_alarm_high = byteTOFloat(buffer);
            dataGridView.Rows[11].Cells[3].Value = over_dt_alarm_high.ToString();

            buffer = ReadFsram(FieldOffset<RT>("over_dt_alarm_low"), 4);
            float over_dt_alarm_low = byteTOFloat(buffer);
            dataGridView.Rows[12].Cells[3].Value = over_dt_alarm_low.ToString();

            buffer = ReadFsram(FieldOffset<RT>("over_at_alarm_high"), 4);
            float over_at_alarm_high = byteTOFloat(buffer);
            dataGridView.Rows[13].Cells[3].Value = over_at_alarm_high.ToString();

            buffer = ReadFsram(FieldOffset<RT>("over_at_alarm_low"), 4);
            float over_at_alarm_low = byteTOFloat(buffer);
            dataGridView.Rows[14].Cells[3].Value = over_at_alarm_low.ToString();

            buffer = ReadFsram(FieldOffset<RT>("quit_bt_high"), 4);
            float quit_bt_high = byteTOFloat(buffer);
            dataGridView.Rows[15].Cells[3].Value = quit_bt_high.ToString();

            buffer = ReadFsram(FieldOffset<RT>("quit_bt_low"), 4);
            float quit_bt_low = byteTOFloat(buffer);
            dataGridView.Rows[16].Cells[3].Value = quit_bt_low.ToString();

            buffer = ReadFsram(FieldOffset<RT>("quit_dt_high"), 4);
            float quit_dt_high = byteTOFloat(buffer);
            dataGridView.Rows[17].Cells[3].Value = quit_dt_high.ToString();

            buffer = ReadFsram(FieldOffset<RT>("quit_dt_low"), 4);
            float quit_dt_low = byteTOFloat(buffer);
            dataGridView.Rows[18].Cells[3].Value = quit_dt_low.ToString();
        }

        public void Set_RT(DataGridView dataGridView)
        {
            WriteFsramByte(FieldOffset<RT>("channel"), 1, byte.Parse(dataGridView.Rows[0].Cells[1].Value.ToString()));
            WriteFsramUint32(FieldOffset<RT>("dt_seq"), 4, UInt32.Parse(dataGridView.Rows[0].Cells[3].Value.ToString()));
            WriteFsramUint32(FieldOffset<RT>("ch_seq"), 4, UInt32.Parse(dataGridView.Rows[1].Cells[3].Value.ToString()));
            WriteFsramUint32(FieldOffset<RT>("power_on_time"), 4, UInt32.Parse(dataGridView.Rows[2].Cells[3].Value.ToString()));
            WriteFsramUint32(FieldOffset<RT>("power_on_cycles"), 4, UInt32.Parse(dataGridView.Rows[3].Cells[3].Value.ToString()));
            WriteFsramFloat(FieldOffset<RT>("over_bt_alarm_max"), 4, float.Parse(dataGridView.Rows[4].Cells[3].Value.ToString()));

            WriteFsramFloat(FieldOffset<RT>("over_dt_alarm_high"), 4, float.Parse(dataGridView.Rows[11].Cells[3].Value.ToString()));
            WriteFsramFloat(FieldOffset<RT>("over_dt_alarm_low"), 4, float.Parse(dataGridView.Rows[12].Cells[3].Value.ToString()));
            WriteFsramFloat(FieldOffset<RT>("over_at_alarm_high"), 4, float.Parse(dataGridView.Rows[13].Cells[3].Value.ToString()));
            WriteFsramFloat(FieldOffset<RT>("over_at_alarm_low"), 4, float.Parse(dataGridView.Rows[14].Cells[3].Value.ToString()));
            WriteFsramFloat(FieldOffset<RT>("quit_bt_high"), 4, float.Parse(dataGridView.Rows[15].Cells[3].Value.ToString()));
            WriteFsramFloat(FieldOffset<RT>("quit_bt_low"), 4, float.Parse(dataGridView.Rows[16].Cells[3].Value.ToString()));
            WriteFsramFloat(FieldOffset<RT>("quit_dt_high"), 4, float.Parse(dataGridView.Rows[17].Cells[3].Value.ToString()));
            WriteFsramFloat(FieldOffset<RT>("quit_dt_low"), 4, float.Parse(dataGridView.Rows[18].Cells[3].Value.ToString()));
        }
    }
}
