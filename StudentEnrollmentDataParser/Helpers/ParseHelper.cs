using StudentEnrollmentDataParser.DataParser;
using StudentEnrollmentDataParser.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace StudentEnrollmentDataParser.Helpers
{
    internal static class XmlParseHelper
    {
        public static Stream ToStream(this string @this)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(@this);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        public static T ParseXml<T>(this string @this) where T : class
        {
            var readerSettings = new XmlReaderSettings();
            readerSettings.ConformanceLevel = ConformanceLevel.Document;
            readerSettings.CheckCharacters = false;
            readerSettings.IgnoreWhitespace = true;

            var reader = XmlReader.Create(@this.Trim().ToStream(), readerSettings);
            return new XmlSerializer(typeof(T)).Deserialize(reader) as T;
        }
    }
}
