using System;
using System.Collections.Generic;
using System.Text;

using csUnit;
using System.Reflection;
using StrengthReport.Layouting;
using StrengthReport;

namespace StrengthReportTest.Layouting {
    [TestFixture]
    public class FunctionBoxTest {
        [Test]
        public void Discovery() {
            try {

                List<FunctionAbstract> functionClasses = FunctionBox.GetFunctionClasses();
                List<string> functionNames = FunctionBox.GetFunctionNames();

                Assert.Equals(functionClasses.Count, functionNames.Count);

                foreach (FunctionAbstract functionClass in functionClasses) {
                    Assert.True(functionNames.IndexOf(functionClass.GetType().Name) >= 0, "Not found: "+functionClass.GetType().Name);
                }

            } catch (Exception e) {
                Assert.Fail("Exception: " + e.GetType().Name + "\n" + e.Message + "\n" + e.StackTrace);
            }
        }
    }
}
