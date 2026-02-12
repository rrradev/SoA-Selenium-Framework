
using OpenQA.Selenium;
using SeleniumFramework.Utilities.Extensions;

namespace SeleniumFramework.Pages;

public class UsersPage: BasePage
{
    
    private IWebElement usersTable => _driver.FindElement(By.Id("users_list"));

    private IWebElement EmailCell(string email) =>
        _driver.FindElement(By.XPath($"//td[contains(text(), '{email}')]"));
    
    public UsersPage(IWebDriver driver) : base(driver)
    {
    
    }

    public void VerifyUserWithEmailIsPresent(string email)
    {
        Assert.That(email, Is.Not.Null.And.Not.Empty, "Email should not be null or empty");
        
        var targetEmailCell = EmailCell(email);
        _driver.ScrollToElement(targetEmailCell);
        
        Assert.That(targetEmailCell.Displayed, Is.True);
    }
    
}