using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WealthManagementAdvisory.BusinessLayer.Interfaces;
using WealthManagementAdvisory.BusinessLayer.Services.Repository;
using WealthManagementAdvisory.BusinessLayer.Services;
using WealthManagementAdvisory.Entities;
using Xunit;
using Xunit.Abstractions;

namespace WealthManagementAdvisory.Tests.TestCases
{
    public class BoundaryTests
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

        private static string type = "Boundary";

        public BoundaryTests(ITestOutputHelper output)
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
        public async Task<bool> Testfor_UserId_NotEmpty()
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
                if (result.UserId!=0)
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
        public async Task<bool> Testfor_InvestmentAmount_NotEmpty()
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
                if (result.Amount != 0)
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
        public async Task<bool> Testfor_UserIncome_NotEmpty()
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
                if (result.Income>0)
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
        public async Task<bool> Testfor_InvestmentId_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                investmentservice.Setup(repos => repos.AddInvestmentAsync(_investment)).ReturnsAsync(_investment);
                var result = await _investmentService.AddInvestmentAsync(_investment);
                if (result.InvestmentId!=0)
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
        public async Task<bool> Testfor_PortfolioId_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            int id = 1;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                portfolioservice.Setup(repos => repos.ViewPortfolioAsync(id)).ReturnsAsync(_portfolio);
                var result = await _portfolioService.ViewPortfolioAsync(id);
                if (result.PortfolioId != 0)
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