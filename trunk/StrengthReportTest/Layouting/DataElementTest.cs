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
    public class DataElementTest {
        [Test]
        public void Properties_Equality() {
            try {
                DataElement[] dataElementArray = new DataElement[8];

                dataElementArray[0] = new DataElement(EntryDataType.Password);
                dataElementArray[1] = new DataElement(EntryDataType.Password);
                dataElementArray[2] = new DataElement(new StrengthReport.Measuring.BasicStrengthMeasure());
                dataElementArray[3] = new DataElement(new StrengthReport.Measuring.BasicStrengthMeasure());
                dataElementArray[4] = new DataElement(EntryDataType.Empty);
                dataElementArray[5] = new DataElement(EntryDataType.Empty);

                Assert.Equals(dataElementArray[0], dataElementArray[1]);
                Assert.Equals(dataElementArray[2], dataElementArray[3]);
                Assert.Equals(dataElementArray[4], dataElementArray[5]);

                try {
                    Assert.Equals(dataElementArray[0], dataElementArray[0].Clone());
                    Assert.Equals(dataElementArray[2], dataElementArray[2].Clone());
                } catch (Exception e) {
                    Assert.Fail("Clone()" + e.Message + "\n" + e.StackTrace);
                }

                dataElementArray[0] = new DataElement(EntryDataType.Password);
                dataElementArray[1] = new DataElement(EntryDataType.Notes);
                dataElementArray[1].StaticData = EntryDataType.Password;

                dataElementArray[2] = new DataElement(new StrengthReport.Measuring.BasicStrengthMeasure());
                dataElementArray[3] = new DataElement(new StrengthReport.Measuring.BuiltInStrengthMeasure());
                dataElementArray[3].FunctionType = (new StrengthReport.Measuring.BasicStrengthMeasure()).GetType().FullName;

                dataElementArray[4] = new DataElement(EntryDataType.Empty);
                dataElementArray[5] = new DataElement(EntryDataType.Empty);
                dataElementArray[5].FunctionType = (new StrengthReport.Measuring.BasicStrengthMeasure()).GetType().FullName;
                dataElementArray[5].StaticData = EntryDataType.Empty;

                dataElementArray[6] = new DataElement(new StrengthReport.Measuring.BasicStrengthMeasure()); ;
                dataElementArray[7] = new DataElement(EntryDataType.Empty);
                dataElementArray[7].FunctionType = (new StrengthReport.Measuring.BasicStrengthMeasure()).GetType().FullName;

                Assert.Equals(dataElementArray[0], dataElementArray[1]);
                Assert.Equals(dataElementArray[2], dataElementArray[3]);
                Assert.Equals(dataElementArray[4], dataElementArray[5]);
                Assert.Equals(dataElementArray[6], dataElementArray[7]);

            } catch (Exception e) {
                Assert.Fail("Exception: " + e.Message + "\n" + e.StackTrace);
            }
        }

        [Test]
        public void Properties_NotEquality() {
            try {
                DataElement[] dataElementArray = new DataElement[8];

                dataElementArray[0] = new DataElement(EntryDataType.Password);
                dataElementArray[1] = dataElementArray[0].Clone();
                dataElementArray[1].StaticData = EntryDataType.Notes;

                dataElementArray[2] = new DataElement(new StrengthReport.Measuring.BasicStrengthMeasure());
                dataElementArray[3] = dataElementArray[2].Clone();
                dataElementArray[3].FunctionType = (new StrengthReport.Measuring.AdvancedStrengthMeasure()).GetType().FullName;

                dataElementArray[4] = new DataElement(EntryDataType.Empty);
                dataElementArray[5] = dataElementArray[4].Clone();
                dataElementArray[5].FunctionType = (new StrengthReport.Measuring.BasicStrengthMeasure()).GetType().FullName;

                dataElementArray[6] = new DataElement(new StrengthReport.Measuring.BasicStrengthMeasure());
                dataElementArray[7] = dataElementArray[6].Clone();
                dataElementArray[7].StaticData = EntryDataType.Empty;

                Assert.NotEquals(dataElementArray[0], dataElementArray[1]);
                Assert.NotEquals(dataElementArray[2], dataElementArray[3]);
                Assert.NotEquals(dataElementArray[4], dataElementArray[5]);
                Assert.NotEquals(dataElementArray[6], dataElementArray[7]);

            } catch (Exception e) {
                Assert.Fail("Exception: " + e.Message + "\n" + e.StackTrace);
            }
        }

        [Test]
        public void Serialization() {
            try {

                DataElement[] dataElementArray = new DataElement[3];

                dataElementArray[0] = new DataElement(EntryDataType.Password);
                dataElementArray[1] = new DataElement(EntryDataType.Empty);
                dataElementArray[2] = new DataElement(new StrengthReport.Measuring.BasicStrengthMeasure());

                for (int i = 0; i < dataElementArray.Length; i++) {
                    
                    StringWriter stringWriter = new StringWriter();
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(DataElement));
                    XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
                    xmlSerializer.Serialize(xmlTextWriter, dataElementArray[i]);

                    DataElement result = (DataElement)xmlSerializer.Deserialize(new StringReader(stringWriter.ToString()));

                    Assert.Equals(dataElementArray[i], result);
                }

            } catch (Exception e) {
                Assert.Fail("Exception: " + e.Message + "\n" + e.StackTrace);
            }
        }
    }
}
