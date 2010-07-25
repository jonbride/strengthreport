using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using csUnit;
using StrengthReport.Layouting;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace StrengthReportTest.Layouting {
    [TestFixture]
    public class LayoutElementTest {
        [Test]
        public void Cloning() {
            try {
                LayoutElement[] layoutElement = new LayoutElement[8];

                layoutElement[0] = new LayoutElement();
                layoutElement[0].Data = new DataElement(EntryDataType.Notes);
                layoutElement[0].Title = "Notes for me";
                layoutElement[0].Width = 123;
                layoutElement[0].Filter = new Filter();

                Assert.Equals(layoutElement[0], layoutElement[0].Clone(), "Clone()");

                layoutElement[1] = layoutElement[0].Clone();
                layoutElement[1].Data = new DataElement(EntryDataType.Notes);
                Assert.Equals(layoutElement[0], layoutElement[1], "Data same meaning, different object.");

                layoutElement[1].Data = new DataElement(EntryDataType.Empty);
                Assert.NotEquals(layoutElement[0], layoutElement[1], "Different Data");

                layoutElement[1] = layoutElement[0].Clone();
                layoutElement[1].Title = "Different title";
                Assert.NotEquals(layoutElement[0], layoutElement[1], "Different Title");

                layoutElement[1] = layoutElement[0].Clone();
                layoutElement[1].Width = 999;
                Assert.NotEquals(layoutElement[0], layoutElement[1], "Different Width");

                Filter filter;

                layoutElement[1] = layoutElement[0].Clone();
                filter = new Filter();
                filter.Comparator = "<=";
                layoutElement[1].Filter = filter;
                Assert.NotEquals(layoutElement[0], layoutElement[1], "Different Filter");

                layoutElement[1] = layoutElement[0].Clone();
                filter = new Filter();
                layoutElement[1].Filter = filter;
                Assert.Equals(layoutElement[0], layoutElement[1], "Same Filter");

            } catch (Exception e) {
                Assert.Fail("Exception: " + e.GetType().Name + "\n" + e.Message + "\n" + e.StackTrace);
            }
        }

        [Test]
        public void Serialization() {
            try {
                LayoutElement[] layoutElement = new LayoutElement[3];

                layoutElement[0] = new LayoutElement();
                layoutElement[0].Data = new DataElement(EntryDataType.Notes);
                layoutElement[0].Title = "Notes for me";
                layoutElement[0].Width = 123;
                layoutElement[0].Filter = new Filter();

                layoutElement[1] = new LayoutElement();
                layoutElement[1].Data = new DataElement(new StrengthReport.Measuring.BasicStrengthMeasure());
                layoutElement[1].Title = "Abcdeűáéúőóöüö";
                layoutElement[1].Width = 999;
                layoutElement[1].Filter = new Filter();

                layoutElement[2] = new LayoutElement();
                layoutElement[2].Data = new DataElement(EntryDataType.Empty);
                layoutElement[2].Title = "";
                layoutElement[2].Width = 0;
                layoutElement[2].Filter = new Filter();

                for (int i = 0; i < layoutElement.Length; i++) {

                    StringWriter stringWriter = new StringWriter();
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(LayoutElement));
                    XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
                    xmlSerializer.Serialize(xmlTextWriter, layoutElement[i]);

                    LayoutElement result = (LayoutElement)xmlSerializer.Deserialize(new StringReader(stringWriter.ToString()));

                    Assert.Equals(layoutElement[i], result, "Not equals: index: "+i);
                }

            } catch (Exception e) {
                Assert.Fail("Exception: " + e.GetType().Name + "\n" + e.Message + "\n" + e.StackTrace);
            }
        }

    }
}
