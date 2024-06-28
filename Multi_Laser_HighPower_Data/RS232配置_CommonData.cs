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
        [XmlElement("设置激光器TTL模式_指令")]
        public string LaserTTLMode_Set { get; set; }

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
        public string LaserPowerPercent_Set { get; set; }

        [Category("Common Data")]
        [XmlElement("读取激光器功率")]
        public string LaserPowerValue_Read { get; set; }

        [Category("Common Data")]
        [XmlElement("读取激光器整体状态")]
        public string SystemStatus_Read { get; set; }

        [Category("Common Data")]
        [XmlElement("读取激光器通道状态")]
        public string LaserChannelStatus_Read { get; set; }

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

        [Category("Common Data")]
        [XmlElement("设置激光器FW模式_指令")]
        public string LaserFWMode_Set { get; set; }

        [Category("Common Data")]
        [XmlElement("读取激光器底板温度")]
        public string LaserBT_Temp_Read { get; set; }

        [Category("Common Data")]
        [XmlElement("读取激光器通道LD温度")]
        public string LaserChannelLD_Temp_Read { get; set; }

        [Category("Common Data")]
        [XmlElement("读取激光器系统温度")]
        public string LaserSystem_Temp_Read { get; set; }

        [Category("Common Data")]
        [XmlElement("读取激光器开启时间")]
        public string Laser_OnTime_Read { get; set; }

        [Category("Common Data")]
        [XmlElement("设置激光器功率值")]
        public string Laser_PowerValue_Set { get; set; }

        [Category("Common Data")]
        [XmlElement("允许设置激光器功率值")]
        public string Allow_PowerValue_Set { get; set; }

        [Category("Common Data")]
        [XmlElement("允许设置激光器百分比值")]
        public string Allow_PowerIntensity_Set { get; set; }

        [Category("Common Data")]
        [XmlElement("获取设置激光器模式")]
        public string PowerSet_Mode_Read { get; set; }

    }
}
