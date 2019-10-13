using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace GenerateLargeFiles.Helpers
{
    public static class SerialiseHelper
    {
        public static string Serialize<T>(T value)
        {
            var sb = new StringBuilder();
            XmlSerializer xmlserializer = new XmlSerializer(typeof(T));
            using (XmlWriter writer = XmlWriter.Create(sb))
            {
                xmlserializer.Serialize(writer, value);
                writer.Close();
            }
            return sb.ToString();
        }
    }
}
