using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using csUnit;
using StrengthReport.Reporting;
using System.IO;
using StrengthReport.Layouting;
using StrengthReport.Templating;
using KeePassLib;

namespace StrengthReportTest.Reporting {
    [TestFixture]
    public class ReportConfigTest {
        [Test]
        public void Basic() {
            Stream stream = new MemoryStream();
            Layout layout = new Layout();
            Template template = new Template();
            List<PwGroup> groups = new List<PwGroup>();
            Dictionary<string, string> configParams = new Dictionary<string,string>();

            ReportConfig config = new ReportConfig(stream, "PDF", layout, template, groups, configParams);

            Assert.Equals(stream, config.Output);
            Assert.Equals(layout, config.Layout);
            Assert.Equals(template, config.Template);
            Assert.Equals(groups, config.Groups);
            Assert.Equals(configParams, config.ConfigParams);
        }
    }
}
