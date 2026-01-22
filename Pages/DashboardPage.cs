using OpenQA.Selenium;

namespace SeleniumFramework.Pages
{
    internal class DashboardPage
    {
        private readonly IWebDriver _driver;

        private IWebElement LoggedUserAnchor => _driver.FindElement(By.XPath("//a[@id='navbarDropdown']"));
        private IWebElement UsernameHeader => _driver.FindElement(By.XPath("//div[contains(@class, 'container-fluid')]/h1"));
        
        public DashboardPage(IWebDriver driver)
        {
            this._driver = driver;
        }

        public void VerifyLoggedUserEmailIs(string expectedUserEmail)
        {
            string actualUserEmail = this.LoggedUserAnchor.Text.Trim();

            Assert.That(actualUserEmail, Is.EqualTo(expectedUserEmail));
        }

        public void VerifyUsernameIs(string username)
        { 
            string headerText = this.UsernameHeader.Text.Trim();
            Assert.That(headerText.Contains(username), Is.True);
        }
    }
}
