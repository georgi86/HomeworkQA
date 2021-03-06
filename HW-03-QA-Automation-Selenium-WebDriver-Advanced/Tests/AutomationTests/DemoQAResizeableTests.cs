﻿namespace AutomationTests
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using AutomationTests.Utilities;
    using AutomationTests.Pages.ResizablePage;

    [TestFixture]
    public class DemoQAResizableTests
    {
        private IWebDriver driver;

        [SetUp]
        public void BeforeEachTest()
        {
            this.driver = new ChromeDriver();
            this.driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void AfterEachTest()
        {
            this.driver.Log().Quit();
        }

        [Test]
        public void ResizingItemShouldProccessCorrectly()
        {
            //// Arrange
            var resizablePage = new ResizablePage(this.driver);
            int offsetX = 100, offsetY = 100;

            //// Act
            resizablePage.PerformDefaultResize(offsetX, offsetY);

            //// Assert
            resizablePage.AssertDefaultResize(offsetX, offsetY);
        }

        [Test]
        public void ResizingItemWithConstraintShouldProccessCorrectly()
        {
            //// Arrange
            var resizablePage = new ResizablePage(this.driver);
            int offsetX = 100, offsetY = 100;

            //// Act
            resizablePage.PerformConstraintResize(offsetX, offsetY);

            //// Assert
            resizablePage.AssertConstraintResize();
        }

        [Test]
        public void ResizingItemWithMinConstraintShouldProccessCorrectly()
        {
            //// Arrange
            var resizablePage = new ResizablePage(this.driver);
            int offsetX = -100, offsetY = -100;

            //// Act
            resizablePage.PerformMinConstraintResize(offsetX, offsetY);

            //// Assert
            resizablePage.AssertMinConstraintResize();
        }
    }
}