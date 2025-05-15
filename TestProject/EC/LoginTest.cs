using HRM_Tests.EC.TokenManagement;
using HRM_Tests.HRC.TokenManagement;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace HRM_Tests.HRC.Modules
{
    public class LoginTest
    {
        [Test]
        public void Login_HRMApplication()
        {
            IWebDriver driver = new ChromeDriver();
            TokenManagement.HRCTokenManager.Instance.Login(driver, "kullanıcı@mail.com", "Test123.");

            Console.WriteLine("Login başarılı, token alındı: " + HRCTokenManager.Instance.GetToken());

            driver.Quit();
        }
    }
}
