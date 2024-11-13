using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WealthManagementAdvisory.BusinessLayer.Interfaces;
using WealthManagementAdvisory.BusinessLayer.Services.Repository;
using WealthManagementAdvisory.BusinessLayer.Services;
using WealthManagementAdvisory.Entities;
using Xunit;
using Xunit.Abstractions;

namespace WealthManagementAdvisory.Tests.TestCases
{
    public class ExceptionalTests
    {
        private readonly ITestOutputHelper _output;
        private readonly IUserService _userService;
        private readonly IInvestmentService _investmentService;
        private readonly IPortfolioService _portfolioService;
        private readonly IAdvisoryService _advisoryService;

        public readonly Mock<IUserRepository> userservice = new Mock<IUserRepository>();
        public readonly Mock<IInvestmentRepository> investmentservice = new Mock<IInvestmentRepository>();
        public readonly Mock<IPortfolioRepository> portfolioservice = new Mock<IPortfolioRepository>();
        public readonly Mock<IAdvisoryRepository> advisoryservice = new Mock<IAdvisoryRepository>();

        private readonly User _user;
        private readonly List<User> _userList;
        private readonly Investment _investment;
        private readonly List<Investment> _investmentList;
        private readonly Portfolio _portfolio;
        private readonly List<Portfolio> _portfolioList;
        private readonly Advisory _advisoryRequest;

        private static string type = "Exception";

        public ExceptionalTests(ITestOutputHelper output)
        {
            _userService = new UserService(userservice.Object);
            _investmentService = new InvestmentService(investmentservice.Object);
            _portfolioService = new PortfolioService(portfolioservice.Object);
            _advisoryService = new AdvisoryService(advisoryservice.Object);

            _output = output;

            _user = new User
            {
                UserId = 1,
                FinancialGoals = "High",
                Income = 100000,
                RiskAppetite = "High"
            };

            _investment = new Investment
            {
                Amount = 100,
                PurchaseDate = DateTime.Now,
                InvestmentId = 1,
                InvestmentType = "New",
                UserId = 1
            };

            _investmentList = new List<Investment>
             {
               new Investment
               {
                UserId = 1,
                PurchaseDate = DateTime.Now,
                Amount = 100,
                InvestmentId = 1,
                InvestmentType = "MF"
               }
            };

            _userList = new List<User>
             {
               new User
               {
                UserId = 1,
                FinancialGoals = "High",
                Income = 100000,
                RiskAppetite = "High"
               }
            };

            _portfolio = new Portfolio
            {
                AssetAllocation = "Gold",
                PortfolioId = 1,
                PortfolioPerformance = 10,
                TotalInvestmentValue = 1,
                UserId = 1
            };

            _advisoryRequest = new Advisory
            {
                AdvisoryDate = DateTime.Now,
                AdvisoryId = 1,
                RecommendationDescription = "Invest in MF",
                RecommendationTitle = "123456789",
                SessionType = "Free",
                RiskLevel = "Low",
                UserId = 1
            };
        }

        [Fact]
        public async Task<bool> Testfor_Validate_IfInvalidUserIdIsPassed()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            int userid = 1;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                userservice.Setup(repos => repos.UpdateUserProfileAsync(userid, _user)).ReturnsAsync(_user);
                var result = await _userService.UpdateUserProfileAsync(userid, _user);
                if (result != null || result.UserId !=0)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        [Fact]
        public async Task<bool> Testfor_Validate_IfInvalidInvestmentTypeIsPassed()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            int userid = 1;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                investmentservice.Setup(repos => repos.AddInvestmentAsync(_investment)).ReturnsAsync(_investment);
                var result = await _investmentService.AddInvestmentAsync(_investment);
                if (result != null || result.InvestmentType != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        [Fact]
        public async Task<bool> Testfor_Validate_IfInvalidAdvisoryIdIsPassed()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            int id = 1;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                advisoryservice.Setup(repos => repos.GetInvestmentRecommendationsAsync(id)).ReturnsAsync(_advisoryRequest);
                var result = await _advisoryService.GetInvestmentRecommendationsAsync(id);
                if (result != null || result.UserId != 0)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        [Fact]
        public async Task<bool> Testfor_Validate_IfInvalidPortfolioIdIsPassed()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            int id = 1;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                portfolioservice.Setup(repos => repos.AddPortfolioAsync(_portfolio)).ReturnsAsync(_portfolio);
                var result = await _portfolioService.AddPortfolioAsync(_portfolio);
                if (result != null || result.PortfolioId != 0)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        [Fact]
        public async Task<bool> Testfor_Validate_IfInvalidIncomeIsPassed()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            int userid = 1;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                userservice.Setup(repos => repos.UpdateUserProfileAsync(userid, _user)).ReturnsAsync(_user);
                var result = await _userService.UpdateUserProfileAsync(userid, _user);
                if (result != null || result.Income != 0)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

    }
}
