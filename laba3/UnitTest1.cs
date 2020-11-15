using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Interactions.Internal;

namespace laba3
{
    [TestFixture]
    public class Tests
    {
        IWebDriver driver;
        ToDoPageObject page;

        [SetUp]
        public void Setup()
        {
            driver = DriverHelper.GetChromeDriverForSite(
                "http://todomvc.com/examples/angularjs/#/",
                "/html/body/ng-view/section/header/form/input");

            page = new ToDoPageObject(driver);
        }

        [TearDown]
        public void TearDownTest()
        {
            driver.Close();
        }

        [Test]
        public void todo_CreatesTodo_OnNewTodo()
        {
            string todoText = "abcd";

            page.AddTodo(todoText);

            Assert.IsTrue(page.ContainsTodo(todoText));
        }
    }
}