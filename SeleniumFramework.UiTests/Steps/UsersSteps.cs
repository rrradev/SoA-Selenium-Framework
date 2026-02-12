using Reqnroll;
using SeleniumFramework.Models;
using SeleniumFramework.Pages;
using SeleniumFramework.Utilities.Constants;

namespace SeleniumFramework.Steps;

[Binding]
public class UsersSteps
{
    private readonly UsersPage _usersPage;
    private readonly ScenarioContext _context;
    
    public UsersSteps(ScenarioContext context, UsersPage usersPage)
    {
        this._context = context;
        this._usersPage = usersPage;
    }
    
    [Then("the user should be displayed in table of user list")]
    public void ThenTheUserShouldBeDisplayedInTableOfUserList()
    {
        var email = _context.Get<UserModel>(ContextConstants.RegisteredUser).Email;
        _usersPage.VerifyUserWithEmailIsPresent(email);
    }
}