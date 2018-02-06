using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.PhantomJS;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        // Dominio base a utilizar
        private string baseURL = "https://www.google.es/";
        private RemoteWebDriver driver;
        public TestContext TestContext { get; set; }

        [TestMethod]
        [TestCategory("Selenium")]
        [Priority(1)]
        [Owner("Chrome")]
        public void TestMethod1()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("--verbose");
            chromeOptions.AddArguments("--whitelisted-ips=''");

            // 1. Crear nueva instancia de chrome
            driver = new ChromeDriver(chromeOptions);

            // 2. Maximizar la ventana
            driver.Manage().Window.Maximize();

            // 3. Esperar un tiempo determinado para que todo cargue
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            // 4. Ir a la dirección destino
            driver.Navigate().GoToUrl(this.baseURL);

            #region Encontrar elementos de la pantalla
                //driver.FindElementById("search - box").Clear();
                //driver.FindElementById("search - box").SendKeys("tire");
            #endregion
        }

        #region Cerrar navegador
        
        [TestCleanup()]
        public void MyTestCleanup()
        {
            driver.Quit();
        }

        #endregion

        [TestInitialize()]
        public void MyTestInitialize()
        {
        }
        
    }
}
