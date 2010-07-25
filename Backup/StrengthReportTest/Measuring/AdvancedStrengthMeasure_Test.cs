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
    public class AdvancedStrengthMeasure_Test {
        private AdvancedStrengthMeasure test_asm;
        private PwEntry pwentry1, pwentry2, pwentry3, pwentry4, pwentry5, pwentry6;

        [FixtureSetUp]
        public void SetUpBeforeClassBuiltIn() {
            test_asm = new AdvancedStrengthMeasure();
            pwentry1 = new PwEntry(null, false, false);
            pwentry2 = new PwEntry(null, false, false);
            pwentry3 = new PwEntry(null, false, false);
            pwentry4 = new PwEntry(null, false, false);
            pwentry5 = new PwEntry(null, false, false);
            pwentry6 = new PwEntry(null, false, false);

        }

        [SetUp]
        public void SetUp() {
            pwentry1.Strings.Set(EntryDataType.UserName.ToString(), new KeePassLib.Security.ProtectedString(true, "s"));
            pwentry2.Strings.Set(EntryDataType.UserName.ToString(), new KeePassLib.Security.ProtectedString(true, "julcsi"));
            pwentry3.Strings.Set(EntryDataType.UserName.ToString(), new KeePassLib.Security.ProtectedString(true, "maris"));
            pwentry4.Strings.Set(EntryDataType.UserName.ToString(), new KeePassLib.Security.ProtectedString(true, "geza76Sanyi52"));
            pwentry5.Strings.Set(EntryDataType.UserName.ToString(), new KeePassLib.Security.ProtectedString(true, "LJohn82"));
            pwentry6.Strings.Set(EntryDataType.UserName.ToString(), new KeePassLib.Security.ProtectedString(true, "anonymous"));
            pwentry1.Strings.Set(EntryDataType.Password.ToString(), new KeePassLib.Security.ProtectedString(true, "birka"));
            pwentry2.Strings.Set(EntryDataType.Password.ToString(), new KeePassLib.Security.ProtectedString(true, "iscluj92G"));
            pwentry3.Strings.Set(EntryDataType.Password.ToString(), new KeePassLib.Security.ProtectedString(true, "brutal@69D"));
            pwentry4.Strings.Set(EntryDataType.Password.ToString(), new KeePassLib.Security.ProtectedString(true, "&#@Gezak1l@l1kazeG@#&dj34AIUG8OB AÉ"));
            pwentry5.Strings.Set(EntryDataType.Password.ToString(), new KeePassLib.Security.ProtectedString(true, "jd47fnb4LEJ73jhJjd47fnb4LEJ73jhJjd47fnb4LEJ73jhJ"));
            pwentry6.Strings.Set(EntryDataType.Password.ToString(), new KeePassLib.Security.ProtectedString(true, "jd47fnb4L@EJ73j&h#Jjd47fnb4LíEJ73jhJjd47fnb4LEJ73jhJ"));
        }

        [Test]
        public void TestASMClass() {
            Assert.NotNull(new AdvancedStrengthMeasure());
        }
        [Test]
        public void TestASMGetTitle() {
            Assert.Equals("AdvancedStrengthMeasure", test_asm.Title);
        }
        [Test]
        public void TestASMGetDesc() {
            Assert.Equals("Examines the password using BuiltInStrengthMeasure and BasicStrengthMeasure functions, and looking for correspondence with the username or the reverse of username or a dictionary word.", test_asm.Desc);
        }
        [Test]
        public void TestReturn() {
            Assert.NotNull(test_asm.Evaluate(pwentry1));
            Assert.NotNull(test_asm.Evaluate(pwentry2));
            Assert.NotNull(test_asm.Evaluate(pwentry3));
            Assert.NotNull(test_asm.Evaluate(pwentry4));
            Assert.NotNull(test_asm.Evaluate(pwentry5));
            Assert.NotNull(test_asm.Evaluate(pwentry6));
        }
        [Test]
        public void TestEvaluate() {
            Assert.Equals(Enum.GetName(typeof(PasswordQuality), 0), test_asm.Evaluate(pwentry1).ToString());
            Assert.Equals(Enum.GetName(typeof(PasswordQuality), 1), test_asm.Evaluate(pwentry2).ToString());
            Assert.Equals(Enum.GetName(typeof(PasswordQuality), 2), test_asm.Evaluate(pwentry3).ToString());
            Assert.Equals(Enum.GetName(typeof(PasswordQuality), 3), test_asm.Evaluate(pwentry4).ToString());
            Assert.Equals(Enum.GetName(typeof(PasswordQuality), 4), test_asm.Evaluate(pwentry5).ToString());
            Assert.Equals(Enum.GetName(typeof(PasswordQuality), 5), test_asm.Evaluate(pwentry6).ToString());
        }
    }
}
