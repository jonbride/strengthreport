/// <author>Adam Erdelyi (Erdelyi.Adam@stud.u-szeged.hu)</author>

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StrengthReport;
using StrengthReport.Measuring;
using KeePassLib;
using csUnit;
using StrengthReport.Layouting;

namespace StrengthReportTest.Measuring {
    [TestFixture]
    public class BasicStrengthMeasure_Test {
        private BasicStrengthMeasure test_bsm;
        private PwEntry pwentry1, pwentry2, pwentry3, pwentry4, pwentry5, pwentry6;

        [FixtureSetUp]
        public void SetUpBeforeClassBuiltIn() {
            test_bsm = new BasicStrengthMeasure();
            pwentry1 = new PwEntry(null, false, false);
            pwentry2 = new PwEntry(null, false, false);
            pwentry3 = new PwEntry(null, false, false);
            pwentry4 = new PwEntry(null, false, false);
            pwentry5 = new PwEntry(null, false, false);
            pwentry6 = new PwEntry(null, false, false);
        }

        [SetUp]
        public void SetUp() {
            pwentry1.Strings.Set(EntryDataType.Password.ToString(), new KeePassLib.Security.ProtectedString(true, "birka"));
            pwentry2.Strings.Set(EntryDataType.Password.ToString(), new KeePassLib.Security.ProtectedString(true, "Bari"));
            pwentry3.Strings.Set(EntryDataType.Password.ToString(), new KeePassLib.Security.ProtectedString(true, "Kicsibarany"));
            pwentry4.Strings.Set(EntryDataType.Password.ToString(), new KeePassLib.Security.ProtectedString(true, "12Komives"));
            pwentry5.Strings.Set(EntryDataType.Password.ToString(), new KeePassLib.Security.ProtectedString(true, "12K@m!ves"));
            pwentry6.Strings.Set(EntryDataType.Password.ToString(), new KeePassLib.Security.ProtectedString(true, "jd47fnb4L@EJ73j&h#Jjd47fnb4LíEJ73jhJjd47fnb4LEJ73jhJ"));
        }

        [Test]
        public void TestBSMClass() {
            Assert.NotNull(new BasicStrengthMeasure());
        }
        [Test]
        public void TestBSMGetTitle() {
            Assert.Equals("BasicStrengthMeasure", test_bsm.Title);
        }
        [Test]
        public void TestBSMGetDesc() {
            Assert.Equals("Examines the password length and whether it contains lower and uppercase carachters, numbers, special characters.", test_bsm.Desc);
        }
        [Test]
        public void TestReturn() {
            Assert.NotNull(test_bsm.Evaluate(pwentry1));
            Assert.NotNull(test_bsm.Evaluate(pwentry2));
            Assert.NotNull(test_bsm.Evaluate(pwentry3));
            Assert.NotNull(test_bsm.Evaluate(pwentry4));
            Assert.NotNull(test_bsm.Evaluate(pwentry5));
            Assert.NotNull(test_bsm.Evaluate(pwentry6));
        }
        [Test]
        public void TestEvaluate() {
            Assert.Equals(Enum.GetName(typeof(PasswordQuality), 0), test_bsm.Evaluate(pwentry1).ToString());
            Assert.Equals(Enum.GetName(typeof(PasswordQuality), 1), test_bsm.Evaluate(pwentry2).ToString());
            Assert.Equals(Enum.GetName(typeof(PasswordQuality), 2), test_bsm.Evaluate(pwentry3).ToString());
            Assert.Equals(Enum.GetName(typeof(PasswordQuality), 3), test_bsm.Evaluate(pwentry4).ToString());
            Assert.Equals(Enum.GetName(typeof(PasswordQuality), 4), test_bsm.Evaluate(pwentry5).ToString());
            Assert.Equals(Enum.GetName(typeof(PasswordQuality), 5), test_bsm.Evaluate(pwentry6).ToString());
        }
    }
}
