using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowDesign.Model;
using FlowDesign.Model.Flow;
using System.Xml.Serialization;
using System.Xml;

namespace FlowDesign.DataAccess.Converter
{
    /// <summary>
    /// Konvertiert ein <see cref="FlowDesign.Model.Project"/> in einen string
    /// </summary>
    public class XmlConverter : IProjectConverter
    {
        public string ConvertObject<T>(T objectData)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

            using (StringWriter textWriter = new Utf8StringWriter())
            {
                xmlSerializer.Serialize(textWriter, objectData);
                return textWriter.ToString();
            }
        }

        public T ConvertObjectBack<T>(string objectDataString)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(objectDataString);
            MemoryStream stream = new MemoryStream(byteArray);
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            return (T)serializer.Deserialize(stream);
        }

        public string[] SimpleConvertBackToString(string dataString)
        {
            dataString.Replace("</", "<");
            char[] delimiters = new char[] { '<', '>'};
            string[] splittedData = dataString.Split(delimiters);
            return splittedData;
        }

        /// <summary>
        /// Ändert das Encoding von dem Serializer von UTF-16 auf UTF-8
        /// </summary>
        private class Utf8StringWriter : StringWriter
        {
            public override Encoding Encoding => Encoding.UTF8;
        }
    }
}
