using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using Selenium;

namespace SeleniumTests
{
    [TestFixture]
    public class The_4_Переотправка_письма_другому_пользователю
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
        public void The_4_RC()
        {
            selenium.Open("https://passport.yandex.ru/");
            Thread.Sleep(5000);
            selenium.Type("xpath=(//div[@class=\"domik-field\"]/input[@id=\"login\"])", "at01.at01");
            selenium.Type("xpath=(//div[@class=\"domik-field\"]/input[@id=\"passwd\"])", "a.t0_1.01");
            selenium.Click("xpath=(//div[@class=\"domik-row\"]/div/button[@type=\"submit\"])");
            Thread.Sleep(5000);
            Thread.Sleep(5000);
            selenium.Click("xpath=(//*[contains(text(), \"Почта\")])");
            Thread.Sleep(3000);
            selenium.Click("xpath=(//*[contains(text(), \"Написать\")])");
            Thread.Sleep(4000);
            selenium.Click("xpath=(//img[@title=\"Добавить\"])");
            Thread.Sleep(1000);
            selenium.Click("xpath=(//span[@class=\"abook-entry-name-content\"])[2]");
            Thread.Sleep(1000);
            selenium.Click("xpath=(//div[@class=\"abook-popup-footer nb-with-l-left-gap nb-with-xs-bottom-gap js-abook-popup-footer\"]/button)");
            selenium.Type("xpath=(//input[@name=\"subj\"])", "Переотправка письма другому пользователю");
            selenium.Type("xpath=(//textarea[@id=\"compose-send\"])", "Переотправка письма другому пользователю");
            selenium.Click("xpath=(//button[@id=\"compose-submit\"])");
            Thread.Sleep(3500);
            Assert.AreEqual("Письмо успешно отправлено.", selenium.GetText("xpath=(//div[@class=\"b-done-title\"])"));
            selenium.Click("xpath=(//a[contains(text(), \"Входящие\")])");
            Thread.Sleep(7000);
            selenium.Click("xpath=(//a[@data-metric=\"Меню сервисов:Выход\"])");
            Thread.Sleep(7000);
            selenium.WaitForPageToLoad("");
            selenium.Open("https://passport.yandex.ru/");
            selenium.Type("xpath=(//div[@class=\"domik-field\"]/input[@id=\"login\"])", "at11.at11");
            selenium.Type("xpath=(//div[@class=\"domik-field\"]/input[@id=\"passwd\"])", "a.t1_1.11");
            selenium.Click("xpath=(//div[@class=\"domik-row\"]/div/button[@type=\"submit\"])");
            Thread.Sleep(5000);
            selenium.Click("xpath=(//*[contains(text(), \"Почта\")])");
            Thread.Sleep(5000);
            selenium.Click("xpath=(//*[contains(text(), \"Переотправка письма другому пользователю\")])");
            Thread.Sleep(6000);
            Assert.IsTrue(selenium.IsTextPresent("at01.at01@yandex.ru"));
            Assert.IsTrue(selenium.IsTextPresent("Переотправка письма другому пользователю"));
            Thread.Sleep(7000);
            selenium.Click("xpath=(//a/img[@class=\"b-ico b-ico_forward\"])");
            Thread.Sleep(7000);
            selenium.Click("xpath=(//img[@title=\"Добавить\"])");
            Thread.Sleep(1000);
            selenium.Click("xpath=(//span[@class=\"abook-entry-name-content\"])[1]");
            Thread.Sleep(1000);
            selenium.Click("xpath=(//span[@class=\"ui-button-text\"]/span[contains(text(), \"Готово\")])");
            Thread.Sleep(1000);
            selenium.Click("xpath=(//span[@class=\"ui-button-text\"]/span[contains(text(), \"Отправить\")])[2]");
            selenium.Click("xpath=(//a[contains(text(), \"Входящие\")])");
            Thread.Sleep(7000);
            selenium.Click("xpath=(//input[@class=\"b-messages__message__checkbox__input\"])");
            selenium.Click("xpath=(//*[@title=\"Удалить (Delete)\"])");
            Thread.Sleep(700);
            selenium.Click("xpath=(//a[@data-metric=\"Меню сервисов:Выход\"])");
            Thread.Sleep(5000);
            selenium.Open("https://passport.yandex.ru/");
            Thread.Sleep(5000);
            selenium.Type("xpath=(//div[@class=\"domik-field\"]/input[@id=\"login\"])", "at21.at21");
            selenium.Type("xpath=(//div[@class=\"domik-field\"]/input[@id=\"passwd\"])", "a.t2_1.21");
            selenium.Click("xpath=(//div[@class=\"domik-row\"]/div/button[@type=\"submit\"])");
            Thread.Sleep(5000);
            selenium.Click("xpath=(//*[contains(text(), \"Почта\")])");
            Thread.Sleep(3000);
            selenium.Click("xpath=(//*[contains(text(), \"Переотправка письма другому пользователю\")])");
            Assert.IsTrue(selenium.IsTextPresent("at01.at01@yandex.ru"));
            Assert.IsTrue(selenium.IsTextPresent("at11.at11@yandex.ru"));
            Assert.IsTrue(selenium.IsTextPresent("Переотправка письма другому пользователю"));
            Thread.Sleep(7000);
            selenium.Click("xpath=(//a[contains(text(), \"Входящие\")])");
            Thread.Sleep(7000);
            selenium.Click("xpath=(//input[@class=\"b-messages__message__checkbox__input\"])");
            selenium.Click("xpath=(//*[@title=\"Удалить (Delete)\"])");
            Thread.Sleep(700);
            selenium.Click("xpath=(//a[@data-metric=\"Меню сервисов:Выход\"])");
        }
    }
}
