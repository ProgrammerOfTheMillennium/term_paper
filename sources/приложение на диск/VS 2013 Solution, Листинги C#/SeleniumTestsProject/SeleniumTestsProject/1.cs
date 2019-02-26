using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using Selenium;

namespace SeleniumTests
{
    [TestFixture]
    public class The_1_Вход_выход
    {
        private ISelenium selenium;
        private StringBuilder verificationErrors;

        [SetUp]
        public void SetupTest()
        {
            selenium = new DefaultSelenium("localhost", 4444, "*firefox C://Program Files (x86)/Mozilla Firefox/firefox.exe", "http://yandex.ru/");
            selenium.Start();
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                selenium.Stop();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void The_1_RC()
        {
            selenium.Open("https://passport.yandex.ru/");
            selenium.WaitForPageToLoad("");
            selenium.Type("xpath=(//div[@class=\"domik-field\"]/input[@id=\"login\"])", "at01.at01");
            selenium.Type("xpath=(//div[@class=\"domik-field\"]/input[@id=\"passwd\"])", "a.t0_1.01");
            selenium.Click("xpath=(//div[@class=\"domik-row\"]/div/button[@type=\"submit\"])");
            Thread.Sleep(5000);
            selenium.Click("xpath=(//*[contains(text(), \"Почта\")])");
            Thread.Sleep(3000);
            Assert.IsTrue(selenium.IsTextPresent("Настройте ваш почтовый ящик"));
            selenium.Click("xpath=(//a[@data-metric=\"Меню сервисов:Выход\"])");
        }
    }
}
