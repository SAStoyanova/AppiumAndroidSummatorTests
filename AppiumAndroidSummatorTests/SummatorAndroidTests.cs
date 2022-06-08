using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;

namespace AppiumAndroidSummatorTests
{
    public class SummatorAndroidTests
    {
        private AndroidDriver<AndroidElement> driver;
        private AppiumOptions options;

        [SetUp]
        public void StartApp()
        {
            this.options = new AppiumOptions() { PlatformName = "Android" };
            options.AddAdditionalCapability("app", @"C:\Users\Sunny\Desktop\QA auto\7\com.example.androidappsummator.apk");
            this.driver = new AndroidDriver<AndroidElement>(new Uri("http://127.0.0.1:4723/wd/hub"), options);
        }

        [TearDown]
        public void CloseApp()
        {
            driver.Quit();
        }

        [Test]
        public void Test_SummatorApp_Two_PositiveNumbers()
        {
            var field1 = driver.FindElementById("com.example.androidappsummator:id/editText1");
            field1.SendKeys("5");

            var field2 = driver.FindElementById("com.example.androidappsummator:id/editText2");
            field2.SendKeys("15");

            var calcButton = driver.FindElementById("com.example.androidappsummator:id/buttonCalcSum");
            calcButton.Click();

            var resultField = driver.FindElementById("com.example.androidappsummator:id/editTextSum").Text;

            Assert.That(resultField, Is.EqualTo("20"));

        }
    }
}