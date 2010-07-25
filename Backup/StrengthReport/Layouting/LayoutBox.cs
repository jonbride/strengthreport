/// <author>Peter Torok (torok.peter@progterv.info)</author>

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;


namespace StrengthReport.Layouting {
    /// <summary>
    /// Set of built-in layouts.
    /// </summary>
    [XmlRoot("LayoutBox")]
    
    public class LayoutBox : List<Layout> {
        public LayoutBox() : base() {
        }

        #region Serialization
        /// <summary>
        /// Xml serialization of this object.
        /// </summary>
        /// <returns></returns>
        public String Serialize() {
            try {
                Utf8StringWriter stringWriter = new Utf8StringWriter();
                XmlSerializer xs = new XmlSerializer(typeof(LayoutBox));
                xs.Serialize(stringWriter, this);
                return stringWriter.ToString();
            } catch (Exception e) {
                System.Console.WriteLine(e);
                return "";
            }
        }

        /// <summary>
        /// Deserialize.
        /// </summary>
        /// <param name="pXmlizedString"></param>
        private LayoutBox(String pXmlizedString) : this() {
            try {
                XmlSerializer xs = new XmlSerializer(typeof(LayoutBox));
                LayoutBox box = (LayoutBox)xs.Deserialize(new StringReader(pXmlizedString));
                this.AddRange(box);
            } catch (Exception e) {
                System.Console.WriteLine(e);
            }
        }

        /// <summary>
        /// Save the object to file (though xml serialization)
        /// </summary>
        /// <param name="Filename"></param>
        public void SaveToFile(string fileName) {
            try {
                FileStream fs = File.Open(fileName, FileMode.Create, FileAccess.Write);
                StreamWriter wr = new StreamWriter(fs);
                string serialized = Serialize();
                wr.Write(serialized);
                wr.Close();
            } catch (IOException e) {
                System.Console.Out.WriteLine(e.ToString());
            } catch (InvalidOperationException e) {
                System.Console.Out.WriteLine(e.ToString());
            }
        }

        /// <summary>
        /// Save the object to file (though xml serialization)
        /// </summary>
        public void SaveToFile() {
            SaveToFile("StrengthReportLayouts.xml");
        }

        /// <summary>
        /// Load xml serialized form of this class from file.
        /// </summary>
        /// <param name="Filename"></param>
        /// <returns></returns>
        static public LayoutBox LoadFromFile(string fileName) {
            if (!File.Exists(fileName)) return new LayoutBox();
            using (FileStream fs = File.Open(fileName, FileMode.Open, FileAccess.Read)) {
                StreamReader rd = new StreamReader(fs);
                string xml = rd.ReadToEnd();
                rd.Close();
                return new LayoutBox(xml);
            }
        }

        /// <summary>
        /// Load xml serialized form of this class from string.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static LayoutBox LoadFromString(string xmlSrializedLayoutBox) {
            return new LayoutBox(xmlSrializedLayoutBox);
        }
        #endregion


    }
}
