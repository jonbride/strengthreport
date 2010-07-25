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
    public class BuiltInStrengthMeasure_Test {
        private BuiltInStrengthMeasure test_bism;
        private PwEntry pwentry1, pwentry2, pwentry3, pwentry4, pwentry5, pwentry6;

        [FixtureSetUp]
        public void SetUpBeforeClassBuiltIn() {
            test_bism = new BuiltInStrengthMeasure();
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
            pwentry2.Strings.Set(EntryDataType.Password.ToString(), new KeePassLib.Security.ProtectedString(true, "Barany"));
            pwentry3.Strings.Set(EntryDataType.Password.ToString(), new KeePassLib.Security.ProtectedString(true, "12KomiveS"));
            pwentry4.Strings.Set(EntryDataType.Password.ToString(), new KeePassLib.Security.ProtectedString(true, "jd47fnb4LEJ73jhJ"));
            pwentry5.Strings.Set(EntryDataType.Password.ToString(), new KeePassLib.Security.ProtectedString(true, "jd47fnb4LEJ73jhJjd47fnb4LEJ73jhJjd47fnb4LEJ73jhJ"));
            pwentry6.Strings.Set(EntryDataType.Password.ToString(), new KeePassLib.Security.ProtectedString(true, "jd47fnb4L@EJ73j&h#Jjd47fnb4LíEJ73jhJjd47fnb4LEJ73jhJ"));
        }

        [Test]
        public void TestBISMClass() {
            Assert.NotNull(new BuiltInStrengthMeasure());
        }
        [Test]
        public void TestBISMGetTitle() {
            Assert.Equals("BuiltInStrengthMeasure", test_bism.Title);
        }
        [Test]
        public void TestBISMGetDesc() {
            Assert.Equals("Examines the password strength using KeePass's built-in QualityEstimation class.", test_bism.Desc);
        }
        [Test]
        public void TestReturn() {
            Assert.NotNull(test_bism.Evaluate(pwentry1));
            Assert.NotNull(test_bism.Evaluate(pwentry2));
            Assert.NotNull(test_bism.Evaluate(pwentry3));
            Assert.NotNull(test_bism.Evaluate(pwentry4));
            Assert.NotNull(test_bism.Evaluate(pwentry5));
            Assert.NotNull(test_bism.Evaluate(pwentry6));
        }
        [Test]
        public void TestEvaluate() {
            Assert.Equals(Enum.GetName(typeof(PasswordQuality), 0), test_bism.Evaluate(pwentry1).ToString());
            Assert.Equals(Enum.GetName(typeof(PasswordQuality), 1), test_bism.Evaluate(pwentry2).ToString());
            Assert.Equals(Enum.GetName(typeof(PasswordQuality), 2), test_bism.Evaluate(pwentry3).ToString());
            Assert.Equals(Enum.GetName(typeof(PasswordQuality), 3), test_bism.Evaluate(pwentry4).ToString());
            Assert.Equals(Enum.GetName(typeof(PasswordQuality), 4), test_bism.Evaluate(pwentry5).ToString());
            Assert.Equals(Enum.GetName(typeof(PasswordQuality), 5), test_bism.Evaluate(pwentry6).ToString());
        }
    }
}
