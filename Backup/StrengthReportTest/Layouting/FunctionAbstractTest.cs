using System;
using System.Collections.Generic;
using System.Text;

using csUnit;
using StrengthReport.Layouting;

namespace StrengthReportTest.Layouting {
    class Func1 : FunctionAbstract {
        public override StrengthReport.Measuring.PasswordQuality Evaluate(KeePassLib.PwEntry entry) {
            return StrengthReport.Measuring.PasswordQuality.Better;
        }
    }

    class Func2 : FunctionAbstract {
        public override StrengthReport.Measuring.PasswordQuality Evaluate(KeePassLib.PwEntry entry) {
            return StrengthReport.Measuring.PasswordQuality.Strong;
        }
    }

    [TestFixture]
    public class FunctionAbstractTest {
        [Test]
        public void EqualityTest() {
            try {
                Func1 func1a = new Func1();
                Func1 func1b = new Func1();
                Func2 func2a = new Func2();

                Assert.True(func1a.Equals(func1a));
                Assert.True(func1a.Equals(func1b));
                Assert.False(func1a.Equals(func2a));

            } catch (Exception e) {
                Assert.Fail("Exception: " + e.GetType().Name + "\n" + e.Message + "\n" + e.StackTrace);
            }
        }
    }
}
