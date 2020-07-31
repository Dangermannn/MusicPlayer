using MusicPlayer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace MusicPlayer.DataAccess
{
    public class XmlImportExport<T>
    {
        //private Stream stream;
        private XmlSerializer xmlSer;

        public XmlImportExport(Stream stream)
        {
            //this.stream = stream;
            this.xmlSer = new XmlSerializer(typeof(T));
        }
        public XmlImportExport()
        {
            //this.stream = File.OpenWrite(Environment.CurrentDirectory + "\\mymusic.xml");
            this.xmlSer = new XmlSerializer(typeof(T));
        }

        public void SetFileStream(string fileName)
        {
            //stream = File.OpenWrite(Environment.CurrentDirectory + "\\" + fileName);
        }

        public void SerializeToXml(T root, string fileName)
        {
            //xmlSer.Serialize(stream, files);
            // Stream stream = File.OpenWrite(Environment.CurrentDirectory + "\\mymusic.txt");
            using (var stream = File.OpenWrite(Environment.CurrentDirectory + "\\" + fileName))
            {
                XmlSerializer xmlSer = new XmlSerializer(typeof(T));
                xmlSer.Serialize(stream, root);
            }
        }

        public T DeserializeXml(string fileName)
        {

            T listOfItems;
            using (var reader = new StreamReader(Environment.CurrentDirectory + "\\" + fileName))
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(T),
                    new XmlRootAttribute("PlaylistList"));
                listOfItems = (T)deserializer.Deserialize(reader);
                return listOfItems;

            }
        }
    }
}
