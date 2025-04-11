using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using HRM_Tests.EC.TokenManagement;
using System;
using System.Linq;
using System.Threading;

namespace HRM_Tests.EC.Modules
{
    [TestFixture]
    public class LeavesFormTest
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            Thread.Sleep(3000); // Gözlemlemek için kısa bekleme
            driver.Quit();
        }

        [Test]
        public void SubmitLeaveForm_ShouldSucceed()
        {
            var tokenManager = ECTokenManager.Instance;
            tokenManager.Login(driver, "oliver.q2424@gmail.com", "Neyasis123.");

            ((IJavaScriptExecutor)driver).ExecuteScript("window.open('about:blank','_blank');");
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            driver.Navigate().GoToUrl("https://test-employeecenter.azurewebsites.net/");
            tokenManager.SetToken(driver);

            driver.Navigate().GoToUrl("https://test-employeecenter.azurewebsites.net/tr/my-profile/permit");
            Thread.Sleep(3000); // Gözlemlemek için kısa bekleme
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            var talepOlusturBtn = wait.Until(d => d.FindElement(By.XPath("//*[@id=\"id\"]/div/div[4]/div/div/div[3]/div[3]/div/div/button")));
            talepOlusturBtn.Click();

            try
            {
                var devamEtBtn = wait.Until(d => d.FindElement(By.XPath("//div[@id='__next']/div[1]/div[2]/div[1]/div[1]/div[4]/div[3]/div[1]/div[1]/button[2]")));
                devamEtBtn.Click();
            
                var checkBtn = wait.Until(c => c.FindElement(By.ClassName("form-check-label")));
                checkBtn.Click();

                var onaylaBtn = wait.Until(o => o.FindElement(By.XPath("//div[@id='__next']/div[1]/div[2]/div[1]/div[1]/div[4]/div[3]/div[1]/div[2]/div[1]/div[1]/div[2]/button[1]")));
                onaylaBtn.Click();
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("Modal görünmedi, devam ediliyor.");
            }

            try
            {
                var devamEtBtn = wait.Until(d => d.FindElement(By.XPath("//button[text()='Devam Et']")));
                devamEtBtn.Click();
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("Modal görünmedi, devam ediliyor.");
            }

            var izinTipiInput = wait.Until(d => d.FindElement(By.Name("permitType")));
            izinTipiInput.Click();

            var dropdownItems = wait.Until(d =>
                d.FindElements(By.CssSelector(".rbt-menu.dropdown-menu.show .dropdown-item"))
            );

            if (dropdownItems.Count > 0)
            {
                Random rnd = new Random();
                var randomItem = dropdownItems[rnd.Next(dropdownItems.Count)];
                randomItem.Click();
            }

            driver.FindElement(By.Name("startDate")).SendKeys("10.04.2025");
            driver.FindElement(By.Name("endDate")).SendKeys("11.04.2025");
            driver.FindElement(By.Name("reason")).SendKeys("Test otomasyonu nedeniyle");

            driver.FindElement(By.XPath("//button[contains(., 'Gönder')]"))?.Click();

            NUnit.Framework.Assert.That(driver.PageSource, Does.Contain("başarıyla"), "Form gönderimi başarılı olmadı.");
        }
    }
}