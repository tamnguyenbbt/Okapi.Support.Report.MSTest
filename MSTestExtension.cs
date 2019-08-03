using Microsoft.VisualStudio.TestTools.UnitTesting;
using Okapi.Common.Report;
using TestResult = Okapi.Report.TestResult;

namespace Okapi.Support.Report.MSTest
{
    public static class MSTestExtension
    {
        public static OkapiTestContext ToOkapiTestContext(this TestContext testContext)
        {
            if (testContext == null)
            {
                return null;
            }

            return new OkapiTestContext
            {
                TestName = testContext.TestName,
                FullyQualifiedTestClassName = testContext.FullyQualifiedTestClassName,
                TestResult = MSTestOutcomeToTestResult(testContext.CurrentTestOutcome)
            };
        }

        private static TestResult MSTestOutcomeToTestResult(UnitTestOutcome testOutcome)
        {
            TestResult result = TestResult.Passed;

            switch (testOutcome)
            {
                case UnitTestOutcome.Aborted:
                    result = TestResult.Aborted;
                    break;
                case UnitTestOutcome.Error:
                    result = TestResult.Error;
                    break;
                case UnitTestOutcome.Failed:
                    result = TestResult.Failed;
                    break;
                case UnitTestOutcome.Inconclusive:
                    result = TestResult.Inconclusive;
                    break;
                case UnitTestOutcome.InProgress:
                    result = TestResult.InProgress;
                    break;
                case UnitTestOutcome.Passed:
                    result = TestResult.Passed;
                    break;
                case UnitTestOutcome.Timeout:
                    result = TestResult.Timeout;
                    break;
                default:
                    result = TestResult.Unknown;
                    break;
            }

            return result;
        }
    }
}