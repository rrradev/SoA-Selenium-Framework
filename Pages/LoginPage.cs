using OpenQA.Selenium;
using SeleniumFramework.Extensions;

namespace SeleniumFramework.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;

        // Elements 
        private IWebElement EmailInput => _driver.FindElement(By.XPath("//input[@type='email']"));
        private IWebElement PasswordInput => _driver.FindElement(By.XPath("//input[@type='password']"));
        private IWebElement SubmitButton => _driver.FindElement(By.XPath("//button[@type='submit' and contains(text(), 'Sign In')]"));

        public LoginPage(IWebDriver driver)
        {
            this._driver = driver;
        }

        // Actions
        public void LoginWith(string email, string password)
        {
            this.EmailInput.SendKeys(email);
            this.PasswordInput.SendKeys(password);

            this.SubmitButton.Click();
        }

        public bool IsPasswordEmpty()
        {
            return string.IsNullOrEmpty(PasswordInput.GetAttribute("value"));
        }

        // Validations
        public void VerifyPasswordInputIsEmpty()
        {
            string? text = PasswordInput.GetAttribute("value");
            Assert.That(text, Is.EqualTo(string.Empty));
        }

        public void VerifyErrorMessageIsDisplayed(string errorMessage)
        {
            string errorDialogText = _driver.FindElement(By.ClassName("alert")).Text;
            Assert.That(errorDialogText, Is.EqualTo(errorMessage));
        }
    }
}
