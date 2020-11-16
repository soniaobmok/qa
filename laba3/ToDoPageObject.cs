using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Interactions.Internal;


namespace laba3
{
    public class ToDoPageObject
    {
        private IWebDriver driver;
        private IWebElement todoInput;
        private IWebElement todoList;
        private IWebElement allFilterBtn;
        private IWebElement activeFilterBtn;
        private IWebElement completedFilterBtn;

        public ToDoPageObject(IWebDriver driver)
        {
            this.driver = driver;

            todoInput = driver.FindElement(By.XPath("/html/body/ng-view/section/header/form/input"));
            todoList = driver.FindElement(By.XPath("/html/body/ng-view/section/section/ul"));
            allFilterBtn = driver.FindElement(By.XPath("/html/body/ng-view/section/footer/ul/li[1]/a"));
            activeFilterBtn = driver.FindElement(By.XPath("/html/body/ng-view/section/footer/ul/li[2]/a"));
            completedFilterBtn = driver.FindElement(By.XPath("/html/body/ng-view/section/footer/ul/li[3]/a"));
        }

        public void Close()
        {
            driver.Close();
        }

        public ToDoPageObject AddTodo(string todoText)
        {
            todoInput.SendKeys(todoText);
            todoInput.SendKeys(Keys.Return);
            return this;
        }

        public ToDoPageObject AddSeveralTodos(string[] todos)
        {
            foreach (string todo in todos)
            {
                AddTodo(todo);
            }

            return this;
        }

        public bool ContainsTodo(string todoText)
        {
            var todoList = driver.FindElement(By.XPath("/html/body/ng-view/section/section/ul"));
            var createdTodoItems = todoList.FindElements(By.XPath($"//label[text()='{todoText}']"));
            return createdTodoItems.Count > 0;
        }

        public bool ContainsSeveralTodos(string[] todos)
        {
            foreach (string todo in todos)
            {
                if (!ContainsTodo(todo))
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsTodoCompleted(string todoText)
        {
            if (ContainsTodo(todoText))
            {
                var completedTodoItems = todoList.FindElements(
                    By.XPath($".//li[div/label[text()='{todoText}'] and contains(@class, 'completed')]"));
                return completedTodoItems.Count > 0;
            } else
            {
                throw new Exception("No such todo");
            }
        }

        public ToDoPageObject CompleteTodo(string todoText)
        {
            todoList.FindElement(By.XPath(
                $".//li[div/label[text()='{todoText}'] and not(contains(@class, 'completed'))]/div/input"))
                .Click();

            return this;
        }

        public ToDoPageObject CompleteSeveralTodos(string[] todos)
        {
            foreach (string todo in todos)
            {
                CompleteTodo(todo);
            }

            return this;
        }

        public ToDoPageObject IncompleteTodo(string todoText)
        {
            todoList.FindElement(By.XPath(
                $".//li[div/label[text()='{todoText}'] and contains(@class, 'completed')]/div/input"))
                .Click();

            return this;
        }

        public ToDoPageObject IncompleteSeveralTodos(string[] todos)
        {
            foreach (string todo in todos)
            {
                IncompleteTodo(todo);
            }

            return this;
        }

        public ToDoPageObject DeleteTodo(string todoText)
        {
            var todoToHover = todoList.FindElement(By.XPath(
                $".//li[div/label[text()='{todoText}']]"));

            var hover = new Actions(driver).MoveToElement(todoToHover);
            hover.Perform();

            var deleteButton = todoToHover.FindElement(By.XPath(".//div/button"));
            deleteButton.Click();

            return this;
        }

        public ToDoPageObject EditTodo(string todoText, string editedTodoText)
        {
            var todoToDoubleclick = todoList.FindElement(By.XPath(
                $".//li[div/label[text()='{todoText}']]"));

            var doubleclick = new Actions(driver).DoubleClick(todoToDoubleclick);
            doubleclick.Perform();

            var todoEditInput = todoToDoubleclick.FindElement(By.XPath(".//form/input"));
            todoEditInput.SendKeys(Keys.Control + "a");
            todoEditInput.SendKeys(Keys.Delete);
            todoEditInput.SendKeys(editedTodoText);
            todoEditInput.SendKeys(Keys.Return);

            return this;
        }

        public ToDoPageObject ApplyAllFilter()
        {
            driver.FindElement(By.XPath("/html/body/ng-view/section/footer/ul/li[1]/a")).Click();
            return this;
        }

        public ToDoPageObject ApplyActiveFilter()
        {
            driver.FindElement(By.XPath("/html/body/ng-view/section/footer/ul/li[2]/a")).Click();
            return this;
        }

        public ToDoPageObject ApplyCompletedFilter()
        {
            driver.FindElement(By.XPath("/html/body/ng-view/section/footer/ul/li[3]/a")).Click();
            return this;
        }

        public ToDoPageObject ClearCompleted()
        {
            driver.FindElement(By.XPath(
                "/html/body/ng-view/section/footer/button")).Click();

            return this;
        }
    }
}
