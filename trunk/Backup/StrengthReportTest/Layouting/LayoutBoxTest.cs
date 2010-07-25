using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using csUnit;
using StrengthReport.Layouting;
using Microsoft.XmlDiffPatch;
using System.Xml;
using System.Windows.Forms;
using System.IO;

namespace StrengthReportTest.Layouting {
    [TestFixture]
    public class LayoutBoxTest {

        [Test]
        public void Serializable() {

            XmlDiff diff = new XmlDiff();
            LayoutBox layoutBox = LayoutBox.LoadFromString(LayoutingResource.LayoutsDefault);
            String result = layoutBox.Serialize();

            diff.IgnoreChildOrder = true;
            diff.IgnoreComments = true;
            diff.IgnoreDtd = true;
            diff.IgnoreNamespaces = true;
            diff.IgnorePI = true;
            diff.IgnorePrefixes = true;
            diff.IgnoreWhitespace = true;
            diff.IgnoreXmlDecl = true;

            StringWriter diffgramString = new StringWriter();
            XmlTextWriter diffgramXml = new XmlTextWriter(diffgramString);
            bool diffBool = diff.Compare(new XmlTextReader(new StringReader(result)), new XmlTextReader(new StringReader(LayoutingResource.LayoutsDefault)), diffgramXml);
            //MessageBox.Show(diffgramString.ToString());
            Assert.True(diffBool);


        }
    }
}
