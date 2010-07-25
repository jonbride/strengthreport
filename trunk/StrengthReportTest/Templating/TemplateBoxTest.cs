using System;
using System.Collections.Generic;
using System.Text;

using csUnit;
using Microsoft.XmlDiffPatch;
using StrengthReport.Templating;
using System.IO;
using System.Xml;
using StrengthReport;

namespace StrengthReportTest.Templating {
    [TestFixture]
    public class TemplateBoxTest {
        [Test]
        public void Serialization() {
            try {
                XmlDiff diff = new XmlDiff();
                TemplateBox templateBox = new TemplateBox(TemplatingResources.TemplatesDefault);
                String result = templateBox.Serialize();
                //Utils.WriteToFile(@"C:\temp\templates.xml", result);

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
                bool diffBool = diff.Compare(new XmlTextReader(new StringReader(result)), new XmlTextReader(new StringReader(TemplatingResources.TemplatesDefault)), diffgramXml);
                //MessageBox.Show(diffgramString.ToString());
                Assert.True(diffBool, diffgramXml.ToString());



            } catch (Exception e) {
                Assert.Fail("Exception: " + e.GetType().Name + "\n" + e.Message + "\n" + e.StackTrace);
            }
        }
    }
}
