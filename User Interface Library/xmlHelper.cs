using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;

namespace User_Interface_Library
{
    public class xmlHelper
    {
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

    }
}
