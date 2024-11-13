using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static WealthManagementAdvisory.Tests.TestCases.TestCaseDto;

namespace WealthManagementAdvisory.Tests.TestCases
{
    public class CallAPI
    {
        public static string UniqueGuid = "18f69543-da90-412c-8a01-4825f31340bb";
        public static async Task<string> saveTestResult(string testName, string status, string type)
        {
            TestResults testResults = new TestResults();
            Dictionary<string, TestCaseResultDto> testCaseResults = new Dictionary<string, TestCaseResultDto>();
            string customValue = System.IO.File.ReadAllText("../../../../../custom.ih");
            testResults.CustomData = customValue;
            int earnedScore = 0;
            String testStatus = "Failed";
            if (status.Equals("True"))
            {
                earnedScore = 1;
                testStatus = "Passed";
            }

            testCaseResults.Add(UniqueGuid, new TestCaseResultDto
            {
                MethodName = testName,
                MethodType = type,
                EarnedScore = earnedScore,
                ActualScore = 1,
                Status = testStatus,
                IsMandatory = true
            });

            using (HttpClient _httpClient = new HttpClient())
            {
                testResults.TestCaseResults = JsonConvert.SerializeObject(testCaseResults);
                var testResultsJson = JsonConvert.SerializeObject(testResults);
                await _httpClient.PostAsync("https://yaksha-prod-sbfn.azurewebsites.net/api/YakshaMFAEnqueue?code=jSTWTxtQ8kZgQ5FC0oLgoSgZG7UoU9Asnmxgp6hLLvYId/GW9ccoLw==", new StringContent(testResultsJson, Encoding.UTF8, "application/json"));
            }
            return status;
        }

        public static string GetCurrentMethodName([System.Runtime.CompilerServices.CallerMemberName] string name = "")
        {
            return name;
        }

    }
}
