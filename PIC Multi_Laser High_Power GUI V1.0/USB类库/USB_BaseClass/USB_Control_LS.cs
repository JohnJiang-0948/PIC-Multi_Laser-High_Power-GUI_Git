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
    class USB_Control_LS:USB_BASIC
    {
        [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Ansi, Pack = 1)]
        unsafe public struct LS
        {
            [FieldOffset(496)]
            public float crystal_temp_set;
            [FieldOffset(500)]
            public float rsvd1;
            [FieldOffset(504)]
            public float rsvd2;
            [FieldOffset(508)]
            public float rsvd3;
            [FieldOffset(512)]
            public UInt16 dfb_curr_limit_resistance;
            [FieldOffset(514)]
            public UInt16 coarse_dfb_scan_interval;
            [FieldOffset(516)]
            public UInt16 fine_dfb_scan_inerval;
            [FieldOffset(518)]
            public UInt16 mins_dfb;
            [FieldOffset(520)]
            public UInt16 dfb_curr;
            [FieldOffset(522)]
            public UInt16 soa_curr;
            [FieldOffset(524)]
            public UInt16 rsdv4;
            [FieldOffset(526)]
            public UInt16 rsdv5;
            [FieldOffset(528)]
            public UInt16 rsdv6;
            [FieldOffset(530)]
            public UInt16 rsdv7;
            [FieldOffset(532)]
            public UInt16 rsdv8;
            [FieldOffset(534)]
            public UInt16 rsdv9;
            [FieldOffset(536)]
            public UInt16 rsdv10;
            [FieldOffset(538)]
            public UInt16 rsdv11;
            [FieldOffset(540)]
            public UInt16 rsdv12;
            [FieldOffset(542)]
            public UInt16 rsdv13;
            [FieldOffset(544)]
            public byte signature_ls;
            [FieldOffset(545)]
            public byte ctc_ls;
        };

        public void Get_LS(DataGridView dataGridView)
        {
            Byte[] buffer = new Byte[30];
            buffer = ReadFsram(FieldOffset<LS>("crystal_temp_set"), 4);
            dataGridView.Rows[5].Cells[3].Value = byteTOFloat(buffer).ToString();

            buffer = ReadFsram(FieldOffset<LS>("dfb_curr_limit_resistance"), 2);
            dataGridView.Rows[6].Cells[3].Value = byteTOUint16(buffer).ToString();

            buffer = ReadFsram(FieldOffset<LS>("coarse_dfb_scan_interval"), 2);
            dataGridView.Rows[7].Cells[3].Value = byteTOUint16(buffer).ToString();

            buffer = ReadFsram(FieldOffset<LS>("fine_dfb_scan_inerval"), 2);
            dataGridView.Rows[8].Cells[3].Value = byteTOUint16(buffer).ToString();

            buffer = ReadFsram(FieldOffset<LS>("dfb_curr"), 2);
            dataGridView.Rows[9].Cells[3].Value = byteTOUint16(buffer).ToString();

            buffer = ReadFsram(FieldOffset<LS>("soa_curr"), 2);
            dataGridView.Rows[10].Cells[3].Value = byteTOUint16(buffer).ToString();
        }

        public void Set_LS(DataGridView dataGridView)
        {
            WriteFsramFloat(FieldOffset<LS>("crystal_temp_set"), 4, float.Parse(dataGridView.Rows[5].Cells[3].Value.ToString()));
            WriteFsramUint16(FieldOffset<LS>("dfb_curr_limit_resistance"), 2, UInt16.Parse(dataGridView.Rows[6].Cells[3].Value.ToString()));
            WriteFsramUint16(FieldOffset<LS>("coarse_dfb_scan_interval"), 2, UInt16.Parse(dataGridView.Rows[7].Cells[3].Value.ToString()));
            WriteFsramUint16(FieldOffset<LS>("fine_dfb_scan_inerval"), 2, UInt16.Parse(dataGridView.Rows[8].Cells[3].Value.ToString()));
            WriteFsramUint16(FieldOffset<LS>("dfb_curr"), 2, UInt16.Parse(dataGridView.Rows[9].Cells[3].Value.ToString()));
            WriteFsramUint16(FieldOffset<LS>("soa_curr"), 2, UInt16.Parse(dataGridView.Rows[10].Cells[3].Value.ToString()));
        }

    }
}
