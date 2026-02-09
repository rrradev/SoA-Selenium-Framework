using OpenQA.Selenium;
using SeleniumFramework.Models;
using SeleniumFramework.Utilities.Extensions;

namespace SeleniumFramework.Pages
{
    public class RegisterUserPage : BasePage
    {
        private IWebElement FirstNameInput => _driver.FindElement(By.Id("first_name"));
        private IWebElement SurnameInput => _driver.FindElement(By.Id("sir_name"));
        private IWebElement EmailInput => _driver.FindElement(By.Id("email"));
        private IWebElement PasswordInput => _driver.FindElement(By.Id("pass"));
        private IWebElement CountryInput => _driver.FindElement(By.Id("country"));
        private IWebElement CityInput => _driver.FindElement(By.Id("city"));
        private IWebElement TermsOfServiceCheckbox => _driver.FindElement(By.Id("tos"));
        private IWebElement RegisterButton => _driver.FindElement(By.XPath("//button[@type='submit']"));

        public RegisterUserPage(IWebDriver driver) : base(driver)
        {
        }

        public void RegisterNewUser(UserModel user)
        {
            _driver.ScrollToElementAndSendText(FirstNameInput, user.FirstName);
            _driver.ScrollToElementAndSendText(SurnameInput, user.Surname);
            _driver.ScrollToElementAndSendText(EmailInput, user.Email);
            _driver.ScrollToElementAndSendText(PasswordInput, user.Password);
            _driver.ScrollToElementAndSendText(CountryInput, user.Country);
            _driver.ScrollToElementAndSendText(CityInput, user.City);

            _driver.ScrollToElementAndClick(TermsOfServiceCheckbox);
            _driver.ScrollToElementAndClick(RegisterButton);
        }
    }
}
