using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using Selenium;

namespace SeleniumTests
{
    [TestFixture]
    public class The_5_Отправка_документа_MS_Word
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
        public void The_5_RC()
        {
            selenium.Open("https://passport.yandex.ru/");
            Thread.Sleep(3000);
            selenium.Type("xpath=(//div[@class=\"domik-field\"]/input[@id=\"login\"])", "at21.at21");
            selenium.Type("xpath=(//div[@class=\"domik-field\"]/input[@id=\"passwd\"])", "a.t2_1.21");
            selenium.Click("xpath=(//div[@class=\"domik-row\"]/div/button[@type=\"submit\"])");
            Thread.Sleep(5000);
            selenium.Click("xpath=(//*[contains(text(), \"Почта\")])");
            Thread.Sleep(3500);
            selenium.Click("xpath=(//*[contains(text(), \"Написать\")])");
            Thread.Sleep(4000);
            selenium.Click("xpath=(//img[@title=\"Добавить\"])");
            Thread.Sleep(1000);
            selenium.Click("xpath=(//span[@class=\"abook-entry-name-content\"])");
            Thread.Sleep(1000);
            selenium.Click("xpath=(//div[@class=\"abook-popup-footer nb-with-l-left-gap nb-with-xs-bottom-gap js-abook-popup-footer\"]/button)");
            Thread.Sleep(700);
            selenium.Type("xpath=(//input[@name=\"att\"])", "C:\\Selenium\\document.docx");
            Thread.Sleep(4000);
            selenium.Type("xpath=(//input[@name=\"subj\"])", "Отправка документа MS Word");
            selenium.Type("xpath=(//textarea[@id=\"compose-send\"])", "Отправка документа MS Word");
            selenium.Click("xpath=(//button[@id=\"compose-submit\"])");
            Thread.Sleep(4000);
            Assert.AreEqual("Письмо успешно отправлено.", selenium.GetText("xpath=(//div[@class=\"b-done-title\"])"));
            selenium.Click("xpath=(//a[contains(text(), \"Входящие\")])");
            Thread.Sleep(7000);
            selenium.Click("xpath=(//a[@data-metric=\"Меню сервисов:Выход\"])");
            Thread.Sleep(7000);
            selenium.Open("https://passport.yandex.ru/");
            selenium.WaitForPageToLoad("");
            selenium.Type("xpath=(//div[@class=\"domik-field\"]/input[@id=\"login\"])", "at22.at22");
            selenium.Type("xpath=(//div[@class=\"domik-field\"]/input[@id=\"passwd\"])", "a.t2_2.22");
            selenium.Click("xpath=(//div[@class=\"domik-row\"]/div/button[@type=\"submit\"])");
            Thread.Sleep(5000);
            selenium.Click("xpath=(//*[contains(text(), \"Почта\")])");
            Thread.Sleep(3000);
            Thread.Sleep(5000);
            selenium.Click("xpath=(//*[contains(text(), \"Отправка документа MS Word\")])");
            Thread.Sleep(700);
            Assert.IsTrue(selenium.IsTextPresent("at21.at21@yandex.ru"));
            Thread.Sleep(700);
            Assert.IsTrue(selenium.IsTextPresent("document.docx"));
            selenium.Click("xpath=(//a[contains(text(), \"Входящие\")])");
            Thread.Sleep(7000);
            selenium.Click("xpath=(//input[@class=\"b-messages__message__checkbox__input\"])");
            selenium.Click("xpath=(//*[@title=\"Удалить (Delete)\"])");
            Thread.Sleep(700);
            selenium.Click("xpath=(//a[@data-metric=\"Меню сервисов:Выход\"])");
        }
    }
}
