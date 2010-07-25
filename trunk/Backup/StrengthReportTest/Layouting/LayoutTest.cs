using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using csUnit;
using StrengthReport.Layouting;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using StrengthReport;

namespace StrengthReportTest.Layouting {
    [TestFixture]
    public class LayoutTest {
        [Test]
        public void Serializable() {
            try {

                Layout[] layouts = new Layout[2];
                Layout layout;

                layouts[0] = new Layout();
                layout = layouts[0];
                {
                    LayoutElement[] layoutElement = new LayoutElement[2];

                    layoutElement[0] = new LayoutElement();
                    layoutElement[0].Data = new DataElement(EntryDataType.Notes);
                    layoutElement[0].Title = "Notes for me";
                    layoutElement[0].Width = 123;
                    layoutElement[0].Filter = new Filter();

                    layoutElement[1] = layoutElement[0].Clone();
                    layout.Add(layoutElement[1]);

                    layoutElement[1] = layoutElement[1].Clone();
                    layoutElement[1].Data = new DataElement(EntryDataType.Notes);
                    layout.Add(layoutElement[1]);

                    layoutElement[1] = layoutElement[1].Clone();
                    layoutElement[1].Data = new DataElement(EntryDataType.Empty);
                    layout.Add(layoutElement[1]);

                    layoutElement[1] = layoutElement[1].Clone(); 
                    layoutElement[1].Title = "Different title";
                    layout.Add(layoutElement[1]);

                    layoutElement[1] = layoutElement[1].Clone(); 
                    layoutElement[1].Width = 999;
                    layout.Add(layoutElement[1]);
                }

                layouts[1] = new Layout();
                layout = layouts[1];
                {
                    LayoutElement[] layoutElement = new LayoutElement[2];

                    layoutElement[0] = new LayoutElement();
                    layoutElement[0].Data = new DataElement(EntryDataType.Notes);
                    layoutElement[0].Title = "Notes for me";
                    layoutElement[0].Width = 123;
                    layoutElement[0].Filter = new Filter();

                    layoutElement[1] = layoutElement[0].Clone();
                    layout.Add(layoutElement[1]);

                    layoutElement[1] = layoutElement[1].Clone();
                    layoutElement[1].Data = new DataElement(new StrengthReport.Measuring.BasicStrengthMeasure());
                    layout.Add(layoutElement[1]);

                    layoutElement[1] = layoutElement[1].Clone();
                    layoutElement[1].Data = new DataElement(new StrengthReport.Measuring.BasicStrengthMeasure()); 
                    layout.Add(layoutElement[1]);

                    layoutElement[1] = layoutElement[1].Clone();
                    layoutElement[1].Title = "ŐÚŰÁÓÜaa";
                    layout.Add(layoutElement[1]);

                    layoutElement[1] = layoutElement[1].Clone();
                    layoutElement[1].Width = 999;
                    layout.Add(layoutElement[1]);
                }

                for (int i = 0; i < layouts.Length; i++) {

                    Utf8StringWriter stringWriter = new Utf8StringWriter();
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(Layout));
                    XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
                    xmlSerializer.Serialize(xmlTextWriter, layouts[i]);

                    Layout result = (Layout)xmlSerializer.Deserialize(new StringReader(stringWriter.ToString()));

                    Assert.Equals(layouts[i], result);
                }

            } catch (Exception e) {
                Assert.Fail("Exception: " + e.GetType().Name + "\n" + e.Message + "\n" + e.StackTrace);
            }
        }
    }
}
