using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using Selenium;

namespace SeleniumTests
{
    [TestFixture]
    public class The_2_Тестовая_отправка_письма
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
        public void The_2_RC()
        {
            selenium.Open("https://passport.yandex.ru/");
            selenium.WaitForPageToLoad("");
            selenium.Type("xpath=(//div[@class=\"domik-field\"]/input[@id=\"login\"])", "at01.at01");
            selenium.Type("xpath=(//div[@class=\"domik-field\"]/input[@id=\"passwd\"])", "a.t0_1.01");
            selenium.Click("xpath=(//div[@class=\"domik-row\"]/div/button[@type=\"submit\"])");
            Thread.Sleep(5000);
            selenium.Click("xpath=(//*[contains(text(), \"Почта\")])");
            Thread.Sleep(3000);
            selenium.Click("xpath=(//*[contains(text(), \"Написать\")])");
            Thread.Sleep(4000);
            selenium.Click("xpath=(//img[@title=\"Добавить\"])");
            Thread.Sleep(1000);
            selenium.Click("xpath=(//span[@class=\"abook-entry-name-content\"])");
            Thread.Sleep(1000);
            selenium.Click("xpath=(//div[@class=\"abook-popup-footer nb-with-l-left-gap nb-with-xs-bottom-gap js-abook-popup-footer\"]/button)");
            selenium.Type("xpath=(//input[@name=\"subj\"])", "Тестовая отправка");
            selenium.Type("xpath=(//textarea[@id=\"compose-send\"])", "Тестовая отправка письма");
            selenium.Click("xpath=(//button[@id=\"compose-submit\"])");
            Thread.Sleep(4000);
            Assert.AreEqual("Письмо успешно отправлено.", selenium.GetText("xpath=(//div[@class=\"b-done-title\"])"));
            selenium.Click("xpath=(//a[contains(text(), \"Входящие\")])");
            Thread.Sleep(7000);
            selenium.Click("xpath=(//input[@class=\"b-messages__message__checkbox__input\"])");
            selenium.Click("xpath=(//*[@title=\"Удалить (Delete)\"])");
            Thread.Sleep(700);
            selenium.Click("xpath=(//a[@data-metric=\"Меню сервисов:Выход\"])");
        }
    }
}
