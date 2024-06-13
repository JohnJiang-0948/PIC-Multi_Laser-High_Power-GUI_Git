using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.ComponentModel;

namespace Multi_Laser_HighPower_Data
{
    [Serializable]
    [XmlRoot("USB配置")]
    public class USB配置_Data
    {
        [Category("USB通讯配置")]
        [XmlElement("客户代码")]
        public string customer { set; get; }

        [Category("USB通讯配置")]
        [XmlElement("波长")]
        public string waveLength { set; get; }

        [Category("USB通讯配置")]
        [XmlElement("ch_Seq")]
        public string ch_Seq { set; get; }

        [Category("USB通讯配置")]
        [XmlElement("dt_Seq")]
        public string dt_Seq { set; get; }

        [Category("USB通讯配置")]
        [XmlElement("vender Name")]
        public string vender_Name { set; get; }

        [Category("USB通讯配置")]
        [XmlElement("contact")]
        public string contact { set; get; }

        [Category("USB通讯配置")]
        [XmlElement("tel")]
        public string tel { set; get; }

    }
}
