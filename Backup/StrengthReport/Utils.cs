using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace StrengthReport {
    public class Utils {
        private Utils() { }

        /*
        #region Helper methods (utf)
        /// <summary>
        /// To convert a Byte Array of Unicode values (UTF-8 encoded) to a complete String.
        /// </summary>
        /// <param name="characters">Unicode Byte Array to be converted to String</param>
        /// <returns>String converted from Unicode Byte Array</returns>

        public static String Utf8ByteArrayToString(Byte[] characters) {
            UTF8Encoding encoding = new UTF8Encoding();
            String constructedString = encoding.GetString(characters);
            return (constructedString);
        }

        /// <summary>
        /// Converts the String to UTF8 Byte array and is used in De serialization
        /// </summary>
        /// <param name="pXmlString"></param>
        /// <returns></returns>
        public static Byte[] StringToUtf8ByteArray(String pXmlString) {
            UTF8Encoding encoding = new UTF8Encoding();
            Byte[] byteArray = encoding.GetBytes(pXmlString);
            return byteArray;
        }
        #endregion
        */



        public static void WriteToFile(string path, string result) {
            StreamWriter fs = new StreamWriter(File.Create(path));
            fs.Write(result);
            fs.Close();
        }


    }

    public class EncodedStringWriter : StringWriter {
        private Encoding m_Encoding;

        public EncodedStringWriter(Encoding encoding) {
            m_Encoding = encoding;
        }

        public override Encoding Encoding {
            get {
                return m_Encoding;
            }
        }

    }

    public class Utf8StringWriter : EncodedStringWriter {
        public Utf8StringWriter() : base(Encoding.UTF8) { }
    }
}
