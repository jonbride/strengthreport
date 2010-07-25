using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using csUnit;
using StrengthReport.Layouting;

namespace StrengthReportTest.Layouting {
    [TestFixture]
    public class EntryDataTypeTest {
        /// <summary>
        /// Ennek éppen semmi értelme nincs, de törekszem minél nagyobb lefedettségre, amennyiben
        /// te is egyet értesz vele, hogy felesleges, akkor légyszi hagyd figyelmenkívül.
        /// </summary>
        [Test]
        public void BasicTest() {
            try {
                Assert.Equals("Empty string", EntryDataTypeFormat.Format(EntryDataType.Empty));
                Assert.Equals("The Notes value of the entry from KeePass database.", EntryDataTypeFormat.Format(EntryDataType.Notes));
                Assert.Equals("The Password value of the entry from KeePass database.", EntryDataTypeFormat.Format(EntryDataType.Password));
                Assert.Equals("The Title value of the entry from KeePass database.", EntryDataTypeFormat.Format(EntryDataType.Title));
                Assert.Equals("The URL value of the entry from KeePass database.", EntryDataTypeFormat.Format(EntryDataType.URL));
                Assert.Equals("The Username value of the entry from KeePass database.", EntryDataTypeFormat.Format(EntryDataType.UserName));
            } catch (Exception e) {
                Assert.Fail("Exception: " + e.GetType().Name + "\n" + e.Message + "\n" + e.StackTrace);
            }
        }
    }
}
