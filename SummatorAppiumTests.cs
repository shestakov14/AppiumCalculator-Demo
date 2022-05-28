using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Windows;
using System;

namespace AppiumSummatorTests
{
    public class SummatorAppiumTests
    {

        private WindowsDriver<WindowsElement> driver;
        private const string AppiumServer = "http://127.0.0.1:4723/wd/hub";
        private AppiumOptions options;

        [OneTimeSetUp]
        public void Setup()
        {
           this.options = new AppiumOptions()   { PlatformName = "Windows"};
           options.AddAdditionalCapability(MobileCapabilityType.App, @"C:\Calculator.exe");
           this.driver = new WindowsDriver<WindowsElement>(new Uri(AppiumServer), options);
        }
        [OneTimeTearDown]
        public void ShutDownApp()
        {
            this.driver.Quit();
        }

        [Test]
        public void Test_Sum_Two_Positive_Numbers()
        {
            var enterField = driver.FindElementByAccessibilityId("CalcText");
            enterField.Click();
            enterField.SendKeys("5+5");

            var calcButton = driver.FindElementByAccessibilityId("ButtonEqual");
            calcButton.Click();
            
            var result = enterField.Text;

            var clearButton = driver.FindElementByAccessibilityId("ButtonClear");

            Assert.AreEqual("10",result);
            clearButton.Click();
        }

        [Test]
        public void Test_Subtraction_Two_Numbers()
        {
            var enterField = driver.FindElementByAccessibilityId("CalcText");
            enterField.Click();
            enterField.SendKeys("10-5");

            var calcField = driver.FindElementByAccessibilityId("ButtonEqual");
            calcField.Click();

            var result = enterField.Text;
            var clearButton = driver.FindElementByAccessibilityId("ButtonClear");

            Assert.AreEqual("5", result);
            clearButton.Click();
        }

        [Test]
        public void Test_Devide_Two_Numbers()
        {
            var enterField = driver.FindElementByAccessibilityId("CalcText");
            enterField.Click();
            enterField.SendKeys("10÷5");

            var calcButton = driver.FindElementByAccessibilityId("ButtonEqual");
            calcButton.Click();

            var result = enterField.Text;
            var clearButton = driver.FindElementByAccessibilityId("ButtonClear");

            Assert.AreEqual("2", result);
            clearButton.Click();
        }
        [Test]
        public void Test_Multiple_Two_Numbers()
        {
            var enterField = driver.FindElementByAccessibilityId("CalcText");
            enterField.Click();
            enterField.SendKeys("10x5");

            var calcButton = driver.FindElementByAccessibilityId("ButtonEqual");
            calcButton.Click();

            var result = enterField.Text;
            var clearButton = driver.FindElementByAccessibilityId("ButtonClear");

            Assert.AreEqual("50", result);
            clearButton.Click();
        }


        [Test]
        public void Test_Clear_Enter_Field()
        {
            var enterField = driver.FindElementByAccessibilityId("CalcText");
            enterField.Click();
            enterField.SendKeys("10x5");


            var clearButton = driver.FindElementByAccessibilityId("ButtonClear");
            clearButton.Click();

            Assert.IsEmpty(enterField.Text);

        }
    }
}