using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using csUnit;
using KeePassLib;

namespace StrengthReportTest.Reporting {
    [TestFixture]
    public class ReportEngineTest {
        [Test]
        public void Functions() {
            PwGroup[] groups = new PwGroup[5];

            for (int i = 0; i < groups.Length; i++) {
                groups[i] = new PwGroup();
                groups[i].Name = "Group " + i.ToString();
                if (i > 0) groups[i - 1].AddGroup(groups[i], false);
            }

            Assert.Equals("(Root)", StrengthReport.ReportEngine.GetGroupPath(groups[0]));
            Assert.Equals("Group 1", StrengthReport.ReportEngine.GetGroupPath(groups[1]));
            Assert.Equals("Group 1/Group 2", StrengthReport.ReportEngine.GetGroupPath(groups[2]));
            Assert.Equals("Group 1/Group 2/Group 3", StrengthReport.ReportEngine.GetGroupPath(groups[3]));
            Assert.Equals("Group 1/Group 2/Group 3/Group 4", StrengthReport.ReportEngine.GetGroupPath(groups[4]));

        }
    }
}
