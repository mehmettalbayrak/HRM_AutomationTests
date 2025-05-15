using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace HRM_Tests.HRC.TokenManagement
{
    class HRCTokenManager
    {
        private static HRCTokenManager _instance;
        private static readonly object _lock = new object();
        private string _token;

        private HRCTokenManager() { }

        public static HRCTokenManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new HRCTokenManager();
                        }
                    }
                }
                return _instance;
            }
        }

        public void Login(IWebDriver driver, string email, string password)
        {
            driver.Navigate().GoToUrl("https://hrmapp.com/login");

            driver.FindElement(By.Name("mail")).SendKeys(email);
            driver.FindElement(By.Name("password")).SendKeys(password);
            driver.FindElement(By.XPath("//button[text()='Giriş Yap']")).Click();

            // WebDriverWait ile token'ın localStorage'a yazılmasını bekle
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            try
            {
                _token = wait.Until(d =>
                {
                    string token = (string)js.ExecuteScript("return localStorage.getItem('Access_Token');");
                    return !string.IsNullOrEmpty(token) ? token : null;
                });

                Console.WriteLine("✅ Token alındı: " + _token);
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("⚠️ Uyarı: LocalStorage'da token bulunamadı.");
            }
        }

        public void SetToken(IWebDriver driver)
        {
            if (string.IsNullOrEmpty(_token))
            {
                throw new Exception("❌ Token bulunamadı, önce login olmalısınız!");
            }

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript($"localStorage.setItem('Access_Token', '{_token}');");
        }

        public string GetToken()
        {
            if (string.IsNullOrEmpty(_token))
            {
                throw new Exception("❌ Token bulunamadı, önce login olmalısınız!");
            }

            return _token;
        }
    }
}
