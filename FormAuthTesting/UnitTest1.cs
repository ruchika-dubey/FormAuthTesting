using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace FormAuthTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]

        public void VerifyValidLogin()
        {
            using (var driver = new ChromeDriver())
            {

                //open register page
                driver.Navigate().GoToUrl("http://localhost:4200/account/register");
              

                new WebDriverWait(driver, TimeSpan.FromMinutes(3)).Until(
                    d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete")
                    );

                var pageTitle = driver.PageSource.Contains("Register");
                Assert.IsTrue(pageTitle);
                //enter data

                driver.FindElementById("exampleInputText1").SendKeys("Test Name First");
                driver.FindElementById("exampleInputText2").SendKeys("Test Name Last");
                driver.FindElementById("exampleInputText3").SendKeys("testname@gmail.com");
                driver.FindElementById("exampleInputText4").SendKeys("123lola123");
                new WebDriverWait(driver, TimeSpan.FromSeconds(25)).Until(
                    d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete")
                    );
                //click on register
                var RegisterButton = driver.FindElementById("button1");
                Assert.IsNotNull(RegisterButton);
                RegisterButton.Click();
                new WebDriverWait(driver, TimeSpan.FromSeconds(25)).Until(
                  d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete")
                  );
                var pageTitle1 = driver.PageSource.Contains("Login");
                Assert.IsTrue(pageTitle1);
                //gives true output as redirects to the login page

            }


        }
        [TestMethod]
        public void VerifyInvalidLogin()
        {
            using (var driver = new ChromeDriver())
            {

                //open register page
                driver.Navigate().GoToUrl("http://localhost:4200/account/register");


                new WebDriverWait(driver, TimeSpan.FromMinutes(3)).Until(
                    d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete")
                    );

                var pageTitle4 = driver.PageSource.Contains("Register");
                Assert.IsTrue(pageTitle4);
                //enter data

                driver.FindElementById("exampleInputText1").SendKeys("Test Name First");
                driver.FindElementById("exampleInputText2").SendKeys("Test Name Last");
                driver.FindElementById("exampleInputText3").SendKeys("testname2@gmail.com");
                driver.FindElementById("exampleInputText4").SendKeys("1");
                new WebDriverWait(driver, TimeSpan.FromSeconds(25)).Until(
                    d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete")
                    );
                //click on register
                var RegisterButton1 = driver.FindElementById("button1");
                Assert.IsNotNull(RegisterButton1);
                RegisterButton1.Click();
                new WebDriverWait(driver, TimeSpan.FromSeconds(25)).Until(
                  d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete")
                  );
                var pageTitle3 = driver.PageSource.Contains("Login");
                Assert.IsTrue(pageTitle3);
                //gives false output as password is invalid


            }


        }
    }

}
