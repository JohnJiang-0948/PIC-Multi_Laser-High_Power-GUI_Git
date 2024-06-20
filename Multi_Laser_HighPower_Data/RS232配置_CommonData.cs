using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.ComponentModel;

namespace Multi_Laser_HighPower_Data
{
    [Serializable]
    [XmlRoot("RS232配置")]
    public class RS232配置_CommonData
    {
        [Category("Common Data")]
        [XmlElement("读取激光器模式_指令")]
        public string LaserMode_Read { get; set; }

        [Category("Common Data")]
        [XmlElement("设置激光器模式_指令")]
        public string LaserMode_Set { get; set; }

        [Category("Common Data")]
        [XmlElement("设置激光器开启_指令")]
        public string LaserON_Set { get; set; }

        [Category("Common Data")]
        [XmlElement("设置激光器关闭_指令")]
        public string LaserOff_Set { get; set; }

        [Category("Common Data")]
        [XmlElement("读取激光器开关_指令")]
        public string LaserOnOff_Read { get; set; }

        [Category("Common Data")]
        [XmlElement("激光器功率比率为千分比")]
        public string permilleRatio { get; set; }

        [Category("Common Data")]
        [XmlElement("设置激光器功率")]
        public string LaserPower_Set { get; set; }

        [Category("Common Data")]
        [XmlElement("读取激光器功率")]
        public string LaserPower_Read { get; set; }

        [Category("Common Data")]
        [XmlElement("读取激光器整体状态")]
        public string LaserStatus_Read { get; set; }

        [Category("Common Data")]
        [XmlElement("读取激光器通道")]
        public string LaserChannel_Read { get; set; }

        [Category("Common Data")]
        [XmlElement("读取激光器FW版本号")]
        public string LaserFWVersion_Read { get; set; }

        [Category("Common Data")]
        [XmlElement("读取激光器Model号")]
        public string LaserModel_Read { get; set; }

        [Category("Common Data")]
        [XmlElement("读取激光器PN号")]
        public string LaserPN_Read { get; set; }

        [Category("Common Data")]
        [XmlElement("读取激光器SN号")]
        public string LaserSN_Read { get; set; }
    }
}
