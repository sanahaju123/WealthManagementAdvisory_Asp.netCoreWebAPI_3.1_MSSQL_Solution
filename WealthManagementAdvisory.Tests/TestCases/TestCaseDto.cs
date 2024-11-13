using System;
using System.Collections.Generic;
using System.Text;

namespace WealthManagementAdvisory.Tests.TestCases
{
    public class TestCaseDto
    {
        public class TestCaseResultDto
        {
            public string MethodName { get; set; }
            public string MethodType { get; set; }
            public int? ActualScore { get; set; }
            public int EarnedScore { get; set; }
            public string Status { get; set; }
            public bool IsMandatory { get; set; }
            public string ErroMessage { get; set; }
        }

        public class TestResults
        {
            public string TestCaseResults { get; set; } // string format of dictionary object
            public string CustomData { get; set; }  // custom.ih
        }
    }
}
