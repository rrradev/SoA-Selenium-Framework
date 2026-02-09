using Reqnroll;
using SeleniumFramework.DatabaseOperations.Operations;
using SeleniumFramework.Models.Factories;
using SeleniumFramework.Pages;
using SeleniumFramework.Utilities;
using SeleniumFramework.Utilities.Constants;

namespace SeleniumFramework.Steps
{
    [Binding]
    public class RegisterUserSteps
    {
        private readonly ScenarioContext _context;
        private readonly RegisterUserPage _registerUserPage;
        private readonly LoginPage _loginPage;
        private readonly UserOperations _userOperations;
        private readonly IUserFactory _userFactory;

        public RegisterUserSteps(IUserFactory userFactory, ScenarioContext context, LoginPage loginPage, RegisterUserPage registerUserPage, UserOperations userOperations)
        {
            this._userFactory = userFactory;
            this._context = context;
            this._loginPage = loginPage; 
            this._registerUserPage = registerUserPage;
            this._userOperations = userOperations;
        }

        [Given("I register new user with valid details")]
        public void GivenIRegisterNewUserWithValidDetails()
        {
            this._loginPage.ClickRegisterNewUser();

            // Extract as Factory pattern and showcase builder pattern for user creation
            var registeredUser = _userFactory.CreateDefault();
            _context.Add(ContextConstants.RegisteredUser, registeredUser);

            _registerUserPage.RegisterNewUser(registeredUser);

            Retry.Until(() =>
            {
                var doUserExist = this._userOperations.CheckIfUserExistsByEmail(registeredUser.Email);
                if (doUserExist == false)
                    throw new RetryException("Registerd User is not found in the database.");
            });
        }
    }
}
