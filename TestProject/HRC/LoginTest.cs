using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace HRM_Tests.HRC
{
    public class LoginTest
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Login_HRMApplication()
        {
            driver.Navigate().GoToUrl("http://localhost:3000/tr/login?/");

            // E-posta alanına giriş yap
            driver.FindElement(By.Name("mail")).SendKeys("oliver.q2424@gmail.com");

            // Şifre alanına giriş yap
            driver.FindElement(By.Name("password")).SendKeys("Neyasis123.");

            // Giriş butonuna bas
            driver.FindElement(By.XPath("//button[contains(text(), 'Giriş Yap')]")).Click();

            // Sayfanın yüklenmesini bekle
            Thread.Sleep(3000);  // Bu kısmı ileride Explicit Wait ile düzelteceğiz!

            // Başarılı giriş kontrolü
            // Başarılı giriş kontrolü
            // Başarılı giriş kontrolü
            NUnit.Framework.Assert.That(driver.Url, Does.Contain("dashboard"), "Giriş başarısız oldu!");   
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
