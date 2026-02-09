using OpenQA.Selenium;
using Reqnroll;
using SeleniumFramework.DatabaseOperations.Operations;
using SeleniumFramework.Models;
using SeleniumFramework.Utilities.Constants;

namespace SeleniumFramework.Hooks
{
    [Binding]
    public class RegisterHooks
    {
        private readonly IWebDriver _driver;
        private readonly UserOperations _userOperations;
        private readonly ScenarioContext _scenarioContext;

        public RegisterHooks(ScenarioContext scenarioContext, IWebDriver webDriver, UserOperations userOperations)
        {
            this._driver = webDriver;
            this._userOperations = userOperations;
            this._scenarioContext = scenarioContext;
        }

        [AfterScenario]
        public void CloseBrowser()
        {
            _driver.Quit();
        }

        [AfterScenario("DeleteRegisteredUser", Order = 9999)]
        public void DeleteCurrentUser()
        {
            var registeredUser = this._scenarioContext.Get<UserModel>(ContextConstants.RegisteredUser);
            _userOperations.DeleteUserWithEmail(registeredUser.Email);
        }
    }
}
