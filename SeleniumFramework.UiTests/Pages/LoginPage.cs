using OpenQA.Selenium;
using SeleniumFramework.Utilities.Extensions;

namespace SeleniumFramework.Pages
{
    public class LoginPage : BasePage
    {
        // Elements 
        private IWebElement EmailInput => _driver.FindElement(By.XPath("//input[@type='email']"));
        private IWebElement PasswordInput => _driver.FindElement(By.XPath("//input[@type='password']"));
        private IWebElement SubmitButton => _driver.FindElement(By.XPath("//button[@type='submit' and contains(text(), 'Sign In')]"));
        private IWebElement RegisterNewUserButton => _driver.FindElement(By.XPath("//a[@href='register.php']"));

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        // Actions
        public void LoginWith(string email, string password)
        {
            this.EmailInput.SendKeys(email);
            this.PasswordInput.SendKeys(password);

            _driver.ScrollToElementAndClick(this.SubmitButton);
        }

        public void ClickRegisterNewUser()
        {
            _driver.ScrollToElementAndClick(this.RegisterNewUserButton);
        }

        // Validations
        public void VerifyPasswordInputIsEmpty()
        {
            string? text = PasswordInput.GetAttribute("value");
            Assert.That(text, Is.EqualTo(string.Empty));
        }

        public bool IsPasswordEmpty()
        {
            return string.IsNullOrEmpty(PasswordInput.GetAttribute("value"));
        }

        public void VerifyErrorMessageIsDisplayed(string errorMessage)
        {
            string errorDialogText = _driver.FindElement(By.ClassName("alert")).Text;
            Assert.That(errorDialogText, Is.EqualTo(errorMessage));
        }

        public void VerifyTheFormIsVisible()
        {
            Assert.Multiple(() =>
            {
                Assert.That(EmailInput.Displayed, Is.True);
                Assert.That(PasswordInput.Displayed, Is.True);
                Assert.That(SubmitButton.Displayed, Is.True);
            });
        }
    }
}
