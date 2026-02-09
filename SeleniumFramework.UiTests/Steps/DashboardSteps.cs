using Reqnroll;
using SeleniumFramework.Models;
using SeleniumFramework.Pages;
using SeleniumFramework.Utilities.Constants;

namespace SeleniumFramework.Steps
{
    [Binding]
    public class DashboardSteps
    {
        private readonly SettingsModel _settingsModel;
        private readonly DashboardPage _dashboardPage;
        private readonly ScenarioContext _context;

        public DashboardSteps(ScenarioContext context, DashboardPage dashboardPage, SettingsModel model)
        {
            this._dashboardPage = dashboardPage;
            this._settingsModel = model;
            this._context = context;
        }

        [Then("I should see the logged user in the main header")]
        public void ThenIShouldSeeTheLoggedUserInTheMainHeader()
        {
            this._dashboardPage.VerifyLoggedUserEmailIs(_settingsModel.Email);
            this._dashboardPage.VerifyUsernameIs(_settingsModel.Username);
        }

        [Then("I should see the created user is logged successfully")]
        public void ThenIShouldSeeTheCreatedUserLoggedSuccessfully()
        {
            var registeredUser = this._context.Get<UserModel>(ContextConstants.RegisteredUser);
            this._dashboardPage.VerifyLoggedUserEmailIs(registeredUser.Email);
            this._dashboardPage.VerifyUsernameIs($"{registeredUser.FirstName} {registeredUser.Surname}");
        }

        [Then("I should be able to logout successfully")]
        public void ThenIShouldBeAbleToLogoutSuccessfully()
        {
            this._dashboardPage.Logout();
        }
    }
}
