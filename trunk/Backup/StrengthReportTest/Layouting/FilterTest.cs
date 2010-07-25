using System;
using System.Collections.Generic;
using System.Text;

using csUnit;
using StrengthReport.Layouting;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace StrengthReportTest.Layouting {
    [TestFixture]
    public class FilterTest {

        [Test]
        public void Cloning() {
            Filter[] filter = new Filter[2];

            filter[0] = new Filter();
            filter[0].Comparator = "< (string)";
            filter[0].CompareWith = "Abcd";
            filter[0].Enabled = true;

            Assert.Equals(filter[0], filter[0].Clone());

            filter[1] = filter[0].Clone();
            filter[1].Comparator = "> (string)";
            Assert.NotEquals(filter[0], filter[1], "Different Comparator");

            filter[1] = filter[0].Clone();
            filter[1].CompareWith = "Qxyz";
            Assert.NotEquals(filter[0], filter[1], "Different CompareWith");

            filter[1] = filter[0].Clone();
            filter[1].Enabled = false;
            Assert.NotEquals(filter[0], filter[1], "Different Enabled");

        }

        [Test]
        public void StringComparison() {
            try {
                Filter filter = null;

                /**
                 * "< (string)", 
                 * "<= (string)", 
                 * "= (string)", 
                 * ">= (string)", 
                 * "> (string)"
                 */

                filter = new Filter();
                filter.Enabled = true;
                filter.Comparator = "< (string)";
                filter.CompareWith = "Ab";
                Assert.True(filter.Evaluate("Aa"));
                Assert.False(filter.Evaluate("Ab"));
                Assert.False(filter.Evaluate("Ac"));

                filter = new Filter();
                filter.Enabled = true;
                filter.Comparator = "<= (string)";
                filter.CompareWith = "Ab";
                Assert.True(filter.Evaluate("Aa"));
                Assert.True(filter.Evaluate("Ab"));
                Assert.False(filter.Evaluate("Ac"));

                filter = new Filter();
                filter.Enabled = true;
                filter.Comparator = "= (string)";
                filter.CompareWith = "Ab";
                Assert.False(filter.Evaluate("Aa"));
                Assert.True(filter.Evaluate("Ab"));
                Assert.False(filter.Evaluate("Ac"));

                filter = new Filter();
                filter.Enabled = true;
                filter.Comparator = ">= (string)";
                filter.CompareWith = "Ab";
                Assert.False(filter.Evaluate("Aa"));
                Assert.True(filter.Evaluate("Ab"));
                Assert.True(filter.Evaluate("Ac"));

                filter = new Filter();
                filter.Enabled = true;
                filter.Comparator = "> (string)";
                filter.CompareWith = "Ab";
                Assert.False(filter.Evaluate("Aa"));
                Assert.False(filter.Evaluate("Ab"));
                Assert.True(filter.Evaluate("Ac"));

                /**
                 * "shorter than", 
                 * "length is", 
                 * "longer than", 
                 * "contains", 
                 * "not contains" 
                 */

                filter = new Filter();
                filter.Enabled = true;
                filter.Comparator = "shorter than";
                filter.CompareWith = "3";
                Assert.True(filter.Evaluate("A"));
                Assert.True(filter.Evaluate("Ab"));
                Assert.False(filter.Evaluate("Abc"));
                Assert.False(filter.Evaluate("Abcd"));

                filter = new Filter();
                filter.Enabled = true;
                filter.Comparator = "length is";
                filter.CompareWith = "3";
                Assert.False(filter.Evaluate("A"));
                Assert.False(filter.Evaluate("Ab"));
                Assert.True(filter.Evaluate("Abc"));
                Assert.False(filter.Evaluate("Abcd"));

                filter = new Filter();
                filter.Enabled = true;
                filter.Comparator = "longer than";
                filter.CompareWith = "3";
                Assert.False(filter.Evaluate("A"));
                Assert.False(filter.Evaluate("Ab"));
                Assert.False(filter.Evaluate("Abc"));
                Assert.True(filter.Evaluate("Abcd"));

                filter = new Filter();
                filter.Enabled = true;
                filter.Comparator = "contains";
                filter.CompareWith = "Ab";
                Assert.False(filter.Evaluate("aBc"));
                Assert.False(filter.Evaluate("axc"));
                Assert.True(filter.Evaluate("Abx"));
                Assert.True(filter.Evaluate("xAbx"));

                filter = new Filter();
                filter.Enabled = true;
                filter.Comparator = "not contains";
                filter.CompareWith = "Ab";
                Assert.True(filter.Evaluate("aBc"));
                Assert.True(filter.Evaluate("axc"));
                Assert.False(filter.Evaluate("Abx"));
                Assert.False(filter.Evaluate("xAbx"));

            } catch (Exception e) {
                Assert.Fail("Exception: " + e.GetType().Name + "\n" + e.Message + "\n" + e.StackTrace);
            }
        }

        [Test]
        public void Serialization() {
            try {
                Filter[] filter = new Filter[3];

                filter[0] = new Filter();
                filter[0].Comparator = "< (string)";
                filter[0].CompareWith = "Abcd";
                filter[0].Enabled = true;

                filter[1] = new Filter();
                filter[1].Comparator = "longer than";
                filter[1].CompareWith = "ÜÓŐÚŰÁÉüóőúűáé";
                filter[1].Enabled = true;

                filter[2] = new Filter();
                filter[2].Comparator = "<=";
                filter[2].CompareWith = "Better";
                filter[2].Enabled = false;

                for (int i = 0; i < filter.Length; i++) {

                    StringWriter stringWriter = new StringWriter();
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(Filter));
                    XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
                    xmlSerializer.Serialize(xmlTextWriter, filter[i]);

                    Filter result = (Filter)xmlSerializer.Deserialize(new StringReader(stringWriter.ToString()));

                    Assert.Equals(filter[i], result);
                }
            } catch (Exception e) {
                Assert.Fail("Exception: " + e.GetType().Name + "\n" + e.Message + "\n" + e.StackTrace);
            } 
        }
    }
}
