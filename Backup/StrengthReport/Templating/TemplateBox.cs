using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using StrengthReport.Layouting;

namespace StrengthReport.Templating {
    [XmlRoot("TemplateBox")]
    public class TemplateBox : List<Template> {
        public TemplateBox() : base() {
        }

        #region Serialization
        public String Serialize() {
            Utf8StringWriter stringWriter = new Utf8StringWriter();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(TemplateBox));
            XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
            xmlSerializer.Serialize(xmlTextWriter, this);
            return stringWriter.ToString();
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="pXmlizedString">The serialized string.</param>
        public TemplateBox(String xmlSerialized)
            : this() {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(TemplateBox));
            StringReader stringReader = new StringReader(xmlSerialized);
            TemplateBox box = (TemplateBox)xmlSerializer.Deserialize(stringReader);
            this.AddRange(box);
        }

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

        public void SaveToFile() {
            SaveToFile("StrengthReportTemplates.xml");
        }

        static public TemplateBox LoadFromFile(string fileName) {
            if (!File.Exists(fileName)) return new TemplateBox();
            using (FileStream fs = File.Open(fileName, FileMode.Open, FileAccess.Read)) {
                StreamReader rd = new StreamReader(fs);
                string xml = rd.ReadToEnd();
                rd.Close();
                return new TemplateBox(xml);
            }
        }

        internal static TemplateBox LoadFromString(string p) {
            return new TemplateBox(p);
        }

        #endregion


    }
}
