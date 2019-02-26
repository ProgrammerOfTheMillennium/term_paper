using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
//using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class Test
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://www.yandex.ru/";
            verificationErrors = new StringBuilder();
        }
        
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [Test]
        public void The2Test()
        {
            driver.Navigate().GoToUrl("https://passport.yandex.ru/");
            driver.FindElement(By.XPath("(//div[@class=\"domik-field\"]/input[@id=\"login\"])")).Clear();
            driver.FindElement(By.XPath("(//div[@class=\"domik-field\"]/input[@id=\"login\"])")).SendKeys("at01.at01");
            driver.FindElement(By.XPath("(//div[@class=\"domik-field\"]/input[@id=\"passwd\"])")).Clear();
            driver.FindElement(By.XPath("(//div[@class=\"domik-field\"]/input[@id=\"passwd\"])")).SendKeys("a.t0_1.01");
            driver.FindElement(By.XPath("(//div[@class=\"domik-row\"]/div/button[@type=\"submit\"])")).Click();
            driver.FindElement(By.XPath("(//*[contains(text(), \"Почта\")])")).Click();
            driver.FindElement(By.XPath("(//*[contains(text(), \"Написать\")])")).Click();


            driver.FindElement(By.XPath("//td[@class=\"b-compose-head__field__value\"]/div[2]/input")).SendKeys("at01.at01@yandex.ru");
            driver.FindElement(By.XPath("(//input[@class=\"b-yabble__input js-add-contact js-kbd-compose-input\"])")).SendKeys(Keys.Tab);
            
            driver.FindElement(By.XPath("(//input[@name=\"subj\"])")).Clear();
            driver.FindElement(By.XPath("(//input[@name=\"subj\"])")).SendKeys("Тестовая отправка");
            driver.FindElement(By.XPath("(//textarea[@id=\"compose-send\"])")).Clear();
            driver.FindElement(By.XPath("(//textarea[@id=\"compose-send\"])")).SendKeys("Тестовая отправка письма");
            driver.FindElement(By.XPath("(//button[@id=\"compose-submit\"])")).Click();
            Assert.AreEqual("Письмо успешно отправлено.", driver.FindElement(By.XPath("(//div[@class=\"b-done-title\"])")).Text);
            driver.FindElement(By.XPath("(//a[contains(text(), \"Входящие\")])")).Click();
            driver.FindElement(By.XPath("(//input[@class=\"b-messages__message__checkbox__input\"])")).Click();
            driver.FindElement(By.XPath("(//*[@title=\"Удалить (Delete)\"])")).Click();
            driver.FindElement(By.XPath("(//a[@data-metric=\"Меню сервисов:Выход\"])")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
