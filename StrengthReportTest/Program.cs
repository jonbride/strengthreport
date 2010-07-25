/// <author>Peter Torok (torok.peter@progterv.info)</author>
/// Sandbox for testing

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using StrengthReport.Reporting;
using StrengthReport;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using StrengthReport.Measuring;

namespace StrengthReportTest {
    /// <summary>
    /// SANDBOX
    /// </summary>
    class Program {
        [STAThread]
        public static void Main(string[] args) {
            /*
            EntryDataType edt = EntryDataType.Notes;
            MessageBox.Show(edt.GetType().FullName);

            StrengthReport.Measuring.AdvancedStrengthMeasure fnc = new AdvancedStrengthMeasure();

            XmlSerializer xsa = new XmlSerializer(typeof(Type));
            xsa.Serialize(new XmlTextWriter(new MemoryStream(), Encoding.UTF8), fnc.GetType());
            */
            
            /*
            Layout l;
            LayoutElement e;

            l = new Layout();
            l.Name = "Alma";

            e = new LayoutElement();
            e.Title = "Korte";
            e.Data = new DataElement(EntryDataType.Title);
            l.Add(e);

            e = new LayoutElement();
            e.Title = "Barack";
            e.Data = new DataElement(EntryDataType.UserName);
            l.Add(e);

            e = new LayoutElement();
            e.Title = "AAA";
            e.Data = new DataElement(new StrengthReport.Measuring.AdvancedStrengthMeasure());
            l.Add(e);
            
            //l.Add(new LayoutElement());

            String XmlizedString = null;
            MemoryStream memoryStream = new MemoryStream();
            XmlSerializer xs = new XmlSerializer(typeof(Layout));
            XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);

            xs.Serialize(xmlTextWriter, l);
            memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
            XmlizedString = UTF8ByteArrayToString(memoryStream.ToArray());

            MessageBox.Show(XmlizedString);
            
            
            */

            //FunctionBoxTest.List();
            //LayoutBoxTest.Test1();
            //TemplateTest.TemplateTest1();
            //Console.In.ReadLine();

        }
        private static String UTF8ByteArrayToString(Byte[] characters) {
            UTF8Encoding encoding = new UTF8Encoding();
            String constructedString = encoding.GetString(characters);
            return (constructedString);
        }
    }
}
