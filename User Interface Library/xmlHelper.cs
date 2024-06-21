using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;
using Multi_Laser_HighPower_Data;
using System.Xml;
using System.Reflection;
using System.Data;

namespace User_Interface_Library
{
    public class xmlHelper
    {

        public string Colunm1 = "Instruction_Semantics";
        public string Colunm2 = "Instruction_Summary";
        RS232配置_CommonData CD = new RS232配置_CommonData();
        public DataTable tableData;

        public void xmlSearch(string Filefolder,ListBox listBox)
        {
            listBox.Items.Clear();
            string[] xmlFiles = Directory.GetFiles(Filefolder);
             string xml_Temp;
            foreach(string xml in xmlFiles)
            {
                xml_Temp=xml.Substring(xml.LastIndexOf("\\")).Replace("\\","");
                listBox.Items.Add(xml_Temp);
            }
        }

        public void xmlSerialization<T>(string filePath,T obj)  //序列化xml文件
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                using (FileStream FS = new FileStream(filePath, FileMode.Create))
                {
                    xmlSerializer.Serialize(FS, obj);
                }
            }
            catch
            {
                MessageBox.Show("Failed to set the xml file.Please check and set again!");
            }

        }

        public void xmlDeserialization<T>(string filePath,out T obj)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                using (FileStream FS = new FileStream(filePath, FileMode.Open))
                {
                    obj = (T)xmlSerializer.Deserialize(FS);
                    
                    //propertyGrid.SelectedObject = obj;
                }
            }
            catch
            {
                obj = default(T);
                MessageBox.Show("Failed to get the xml file.Please check and get again!");
            }

        }

        public void Set_UsbXml(string FilePath,DataGridView dataGridView,PropertyGrid propertyGrid)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlElement rootNode = xmlDoc.CreateElement("RS232_Command");
            xmlDoc.AppendChild(rootNode);    //创建根节点

            XmlElement tableNode = xmlDoc.CreateElement("Customize_Data");
            rootNode.AppendChild(tableNode); //创建数据节点

            foreach (DataGridViewRow Row in dataGridView.Rows)
            {
                if ((Row.Cells[Colunm1].Value != null) & (Row.Cells[Colunm2].Value != null))
                {
                    XmlElement dataNode = xmlDoc.CreateElement("Sequence");
                    tableNode.AppendChild(dataNode);

                    XmlElement column1Node = xmlDoc.CreateElement(Colunm1);
                    column1Node.InnerText = Row.Cells[Colunm1].Value.ToString();
                    dataNode.AppendChild(column1Node);

                    XmlElement column2Node = xmlDoc.CreateElement(Colunm2);
                    column2Node.InnerText = Row.Cells[Colunm2].Value.ToString();
                    dataNode.AppendChild(column2Node);
                }
            }
            Type type = typeof(RS232配置_CommonData);  //类的反射
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            XmlElement GridNode = xmlDoc.CreateElement("Standard_Data");
            rootNode.AppendChild(GridNode); //创建数据节点
            object selectObject = propertyGrid.SelectedObject;

            foreach (PropertyInfo property in properties)
            {
                XmlElement SequnenceNode = xmlDoc.CreateElement("Sequnence");
                GridNode.AppendChild(SequnenceNode); //创建数据节点

                XmlElementAttribute xmlElementAttribute = property.GetCustomAttribute<XmlElementAttribute>();
                XmlElement column3Node = xmlDoc.CreateElement(xmlElementAttribute.ElementName);
                string Name_Value = (string)selectObject.GetType().GetProperty(property.Name)?.GetValue(selectObject, null);
                column3Node.InnerText = Name_Value;
                SequnenceNode.AppendChild(column3Node);
            }
            xmlDoc.Save(FilePath);
        }

        public void Get_UsbXml(string xmlFilePath,DataGridView dataGridView,PropertyGrid propertyGrid)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);

            XmlNode xmlNode = xmlDoc.DocumentElement;
            tableData = new DataTable();
            tableData.Columns.Add(Colunm1);
            tableData.Columns.Add(Colunm2);

            XmlNodeList tableDataNodes = xmlNode.SelectNodes("Customize_Data/Sequence");
            foreach (XmlNode rowNode in tableDataNodes)
            {
                DataRow row = tableData.NewRow();
                row[Colunm1] = rowNode.SelectSingleNode(Colunm1)?.InnerText;
                row[Colunm2] = rowNode.SelectSingleNode(Colunm2)?.InnerText;
                tableData.Rows.Add(row);
            }
            dataGridView.DataSource = tableData;
            dataGridView.Columns[Colunm1].Width = 150;
            dataGridView.Columns[Colunm2].Width = 150;

            PropertyInfo[] properties = CD.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance); //类的反射
            XmlNodeList GridDataNodes = xmlNode.SelectNodes("Standard_Data/Sequnence");

            if (GridDataNodes.Count > 0)
            {
                CD.LaserMode_Read = GridDataNodes[0].InnerText;
                CD.LaserTTLMode_Set= GridDataNodes[1].InnerText;
                CD.LaserON_Set= GridDataNodes[2].InnerText;
                CD.LaserOff_Set = GridDataNodes[3].InnerText;
                CD.LaserOnOff_Read= GridDataNodes[4].InnerText;
                CD.permilleRatio = GridDataNodes[5].InnerText;
                CD.LaserPower_Set= GridDataNodes[6].InnerText;
                CD.LaserPower_Read = GridDataNodes[7].InnerText;
                CD.LaserStatus_Read = GridDataNodes[8].InnerText;
                CD.LaserChannel_Read= GridDataNodes[9].InnerText;
                CD.LaserFWVersion_Read= GridDataNodes[10].InnerText;
                CD.LaserModel_Read= GridDataNodes[11].InnerText;
                CD.LaserPN_Read= GridDataNodes[12].InnerText;
                CD.LaserSN_Read= GridDataNodes[13].InnerText;
                CD.LaserFWMode_Set= GridDataNodes[14].InnerText;
                propertyGrid.SelectedObject = CD;
            }
        }

    }
}
