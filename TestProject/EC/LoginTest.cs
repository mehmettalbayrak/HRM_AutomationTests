using HRM_Tests.EC.TokenManagement;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace HRM_Tests.EC
{
    public class LoginTest
    {
        [Test]
        public void Login_HRMApplication()
        {
            IWebDriver driver = new ChromeDriver();
            TokenManagement.ECTokenManager.Instance.Login(driver, "oliver.q2424@gmail.com", "Neyasis123.");

            Console.WriteLine("Login başarılı, token alındı: " + ECTokenManager.Instance.GetToken());

            driver.Quit();
        }
    }
}
