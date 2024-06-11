using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PIC_Multi_Laser_High_Power_GUI_V1._0.USB类库
{
    class USB_Control_MyCollect : USB_Control_RT
    {
        [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Ansi, Pack = 1)]
        unsafe public struct My_COLLECT
        {
            [FieldOffset(0)]
            public float ls1_pm;
            [FieldOffset(4)]
            public float ls1_cm;
            [FieldOffset(8)]
            public float ls2_pm;
            [FieldOffset(12)]
            public float ls2_cm;
            [FieldOffset(16)]
            public float ls3_pm;
            [FieldOffset(20)]
            public float ls3_cm;
            [FieldOffset(24)]
            public float ls4_pm;
            [FieldOffset(28)]
            public float ls4_cm;
            [FieldOffset(32)]
            public float ls5_pm;
            [FieldOffset(36)]
            public float ls5_cm;
            [FieldOffset(40)]
            public float ls6_pm;
            [FieldOffset(44)]
            public float ls6_cm;
            [FieldOffset(48)]
            public float ls7_pm;
            [FieldOffset(52)]
            public float ls7_cm;
            [FieldOffset(56)]
            public float ls8_pm;
            [FieldOffset(60)]
            public float ls8_cm;
            [FieldOffset(64)]
            public float ls9_pm;
            [FieldOffset(68)]
            public float ls9_cm;
            [FieldOffset(72)]
            public float dt1;
            [FieldOffset(76)]
            public float dt2;
            [FieldOffset(80)]
            public float dt3;
            [FieldOffset(84)]
            public float bt1;
            [FieldOffset(88)]
            public float dt5;
            [FieldOffset(92)]
            public float dt4;
        };

        public void chNumJudge(ComboBox comboBox, out int chNum)
        {
            string strTemp = comboBox.SelectedItem.ToString();
            int Num = 0;
            switch (strTemp)
            {
                case "CH1":
                    Num = 1;
                    break;

                case "CH2":
                    Num = 2;
                    break;

                case "CH3":
                    Num = 3;
                    break;

                case "CH4":
                    Num = 4;
                    break;

                case "CH5":
                    Num = 5;
                    break;

                case "CH6":
                    Num = 6;
                    break;

                case "CH7":
                    Num = 7;
                    break;

                case "CH8":
                    Num = 8;
                    break;

                case "CH9":
                    Num = 9;
                    break;
            }
            chNum = Num;
        }

        public void dtChoose(ComboBox comboBox, out string dtValue)
        {
            int chNum;
            char chNumChar;
            int index = 0;
            int Num = 0;
            chNumJudge(comboBox, out chNum);
            chNumChar = (chNum.ToString())[0];

            byte[] buffer = ReadFsram(FieldOffset<RT>("ch_seq"), 4);
            UInt32 Number = byteTOUint32(buffer);
            var NumberConvert = (Convert.ToString(Number));
            char[] Array_ch = (NumberConvert.ToCharArray()).Reverse<char>().ToArray<char>();
            for (int i = 0; i < Array_ch.Count(); i++)
            {
                if (chNumChar == Array_ch[i])
                {
                    index = i;
                }
            }
            buffer = ReadFsram(FieldOffset<RT>("dt_seq"), 4);
            Number = byteTOUint32(buffer);
            NumberConvert = (Convert.ToString(Number));
            char[] Array_dt = (NumberConvert.ToCharArray()).Reverse<char>().ToArray<char>();
            dtValue = "dt" + Array_dt[index];
        }

        public void Get_MyCollect1(DataGridView dataGridView)
        {
            dataGridView.Rows[12].Cells[1].Value = byteTOFloat(ReadCollect(FieldOffset<My_COLLECT>("bt1"), 4)).ToString();
            dataGridView.Rows[13].Cells[1].Value = byteTOFloat(ReadCollect(FieldOffset<My_COLLECT>("dt1"), 4)).ToString();
            dataGridView.Rows[14].Cells[1].Value = byteTOFloat(ReadCollect(FieldOffset<My_COLLECT>("dt2"), 4)).ToString();
            dataGridView.Rows[15].Cells[1].Value = byteTOFloat(ReadCollect(FieldOffset<My_COLLECT>("dt3"), 4)).ToString();
            dataGridView.Rows[16].Cells[1].Value = byteTOFloat(ReadCollect(FieldOffset<My_COLLECT>("dt4"), 4)).ToString();
            dataGridView.Rows[17].Cells[1].Value = byteTOFloat(ReadCollect(FieldOffset<My_COLLECT>("dt5"), 4)).ToString();
        }

        public void Get_MyCollect2(DataGridView dataGridView, ComboBox comboBox,int chNum)
        {

            string dtValue;
            dtChoose(comboBox,out dtValue);
            dataGridView.Rows[11].Cells[3].Value = byteTOFloat(ReadCollect(FieldOffset<My_COLLECT>(dtValue), 4)).ToString();
            switch (chNum)
            {
                case 1:
                    dataGridView.Rows[9].Cells[3].Value = byteTOFloat(ReadCollect(FieldOffset<My_COLLECT>("ls1_pm"), 4)).ToString();
                    dataGridView.Rows[10].Cells[3].Value = byteTOFloat(ReadCollect(FieldOffset<My_COLLECT>("ls1_cm"), 4)).ToString();
                    break;

                case 2:
                    dataGridView.Rows[9].Cells[3].Value = byteTOFloat(ReadCollect(FieldOffset<My_COLLECT>("ls2_pm"), 4)).ToString();
                    dataGridView.Rows[10].Cells[3].Value = byteTOFloat(ReadCollect(FieldOffset<My_COLLECT>("ls2_cm"), 4)).ToString();
                    break;

                case 3:
                    dataGridView.Rows[9].Cells[3].Value = byteTOFloat(ReadCollect(FieldOffset<My_COLLECT>("ls3_pm"), 4)).ToString();
                    dataGridView.Rows[10].Cells[3].Value = byteTOFloat(ReadCollect(FieldOffset<My_COLLECT>("ls3_cm"), 4)).ToString();
                    break;

                case 4:
                    dataGridView.Rows[9].Cells[3].Value = byteTOFloat(ReadCollect(FieldOffset<My_COLLECT>("ls4_pm"), 4)).ToString();
                    dataGridView.Rows[10].Cells[3].Value = byteTOFloat(ReadCollect(FieldOffset<My_COLLECT>("ls4_cm"), 4)).ToString();
                    break;

                case 5:
                    dataGridView.Rows[9].Cells[3].Value = byteTOFloat(ReadCollect(FieldOffset<My_COLLECT>("ls5_pm"), 4)).ToString();
                    dataGridView.Rows[10].Cells[3].Value = byteTOFloat(ReadCollect(FieldOffset<My_COLLECT>("ls5_cm"), 4)).ToString();
                    break;

                case 6:
                    dataGridView.Rows[9].Cells[3].Value = byteTOFloat(ReadCollect(FieldOffset<My_COLLECT>("ls6_pm"), 4)).ToString();
                    dataGridView.Rows[10].Cells[3].Value = byteTOFloat(ReadCollect(FieldOffset<My_COLLECT>("ls6_cm"), 4)).ToString();
                    break;

                case 7:
                    dataGridView.Rows[9].Cells[3].Value = byteTOFloat(ReadCollect(FieldOffset<My_COLLECT>("ls7_pm"), 4)).ToString();
                    dataGridView.Rows[10].Cells[3].Value = byteTOFloat(ReadCollect(FieldOffset<My_COLLECT>("ls7_cm"), 4)).ToString();
                    break;

                case 8:
                    dataGridView.Rows[9].Cells[3].Value = byteTOFloat(ReadCollect(FieldOffset<My_COLLECT>("ls8_pm"), 4)).ToString();
                    dataGridView.Rows[10].Cells[3].Value = byteTOFloat(ReadCollect(FieldOffset<My_COLLECT>("ls8_cm"), 4)).ToString();
                    break;

                case 9:
                    dataGridView.Rows[9].Cells[3].Value = byteTOFloat(ReadCollect(FieldOffset<My_COLLECT>("ls9_pm"), 4)).ToString();
                    dataGridView.Rows[10].Cells[3].Value = byteTOFloat(ReadCollect(FieldOffset<My_COLLECT>("ls9_cm"), 4)).ToString();
                    break;
            }
        }
    }
}
