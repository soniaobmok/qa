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
        private By todoInput = By.XPath("/html/body/ng-view/section/header/form/input");
        private By todoList = By.XPath("/html/body/ng-view/section/section/ul");
        private By allFilterBtn = By.XPath("/html/body/ng-view/section/footer/ul/li[1]/a");
        private By activeFilterBtn = By.XPath("/html/body/ng-view/section/footer/ul/li[2]/a");
        private By completedFilterBtn = By.XPath("/html/body/ng-view/section/footer/ul/li[3]/a");
        private By clearButton = By.XPath("/html/body/ng-view/section/footer/button");
        private By todoDeleteButton = By.XPath(".//div/button");
        private By formInput = By.XPath(".//form/input");

        public ToDoPageObject(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        public void Close()
        {
            driver.Close();
        }

        public ToDoPageObject AddTodo(string todoText)
        {
            var input = driver.FindElement(todoInput);

            input.SendKeys(todoText);
            input.SendKeys(Keys.Return);
            
            return this;
        }

        public ToDoPageObject AddSeveralTodos(string[] todos)
        {
            foreach (string todo in todos) AddTodo(todo);
            return this;
        }

        public bool ContainsTodo(string todoText)
        {
            var createdTodoItems = driver
                .FindElement(todoList)
                .FindElements(By.XPath($"//label[text()='{todoText}']"));
            return createdTodoItems.Count > 0;
        }

        public bool ContainsSeveralTodos(string[] todos)
        {
            foreach (string todo in todos) if (!ContainsTodo(todo)) return false;
            return true;
        }

        public bool IsTodoCompleted(string todoText)
        {
            if (ContainsTodo(todoText))
            {
                var completedTodoItems = driver
                    .FindElement(todoList)
                    .FindElements(By.XPath($".//li[div/label[text()='{todoText}'] and contains(@class, 'completed')]"));
                return completedTodoItems.Count > 0;
            } else
            {
                throw new Exception("No such todo");
            }
        }

        public ToDoPageObject CompleteTodo(string todoText)
        {
            driver
                .FindElement(todoList)
                .FindElement(By.XPath($".//li[div/label[text()='{todoText}'] and not(contains(@class, 'completed'))]/div/input"))
                .Click();

            return this;
        }

        public ToDoPageObject CompleteSeveralTodos(string[] todos)
        {
            foreach (string todo in todos) CompleteTodo(todo);
            return this;
        }

        public ToDoPageObject IncompleteTodo(string todoText)
        {
            driver
                .FindElement(todoList)
                .FindElement(By.XPath($".//li[div/label[text()='{todoText}'] and contains(@class, 'completed')]/div/input"))
                .Click();

            return this;
        }

        public ToDoPageObject IncompleteSeveralTodos(string[] todos)
        {
            foreach (string todo in todos) IncompleteTodo(todo);
            return this;
        }

        public ToDoPageObject DeleteTodo(string todoText)
        {
            var todoToHover = driver
                .FindElement(todoList)
                .FindElement(By.XPath($".//li[div/label[text()='{todoText}']]"));

            new Actions(driver)
                .MoveToElement(todoToHover)
                .Perform();

            todoToHover
                .FindElement(todoDeleteButton)
                .Click();

            return this;
        }

        public ToDoPageObject EditTodo(string todoText, string editedTodoText)
        {
            var todoToDoubleclick = driver
                .FindElement(todoList)
                .FindElement(By.XPath($".//li[div/label[text()='{todoText}']]"));

            new Actions(driver)
                .DoubleClick(todoToDoubleclick)
                .Perform();

            var todoEditInput = todoToDoubleclick.FindElement(formInput);
            todoEditInput.SendKeys(Keys.Control + "a");
            todoEditInput.SendKeys(Keys.Delete);
            todoEditInput.SendKeys(editedTodoText);
            todoEditInput.SendKeys(Keys.Return);

            return this;
        }

        public ToDoPageObject ApplyAllFilter()
        {
            driver
                .FindElement(allFilterBtn)
                .Click();

            return this;
        }

        public ToDoPageObject ApplyActiveFilter()
        {
            driver
                .FindElement(activeFilterBtn)
                .Click();

            return this;
        }

        public ToDoPageObject ApplyCompletedFilter()
        {
            driver
                .FindElement(completedFilterBtn)
                .Click();

            return this;
        }

        public ToDoPageObject ClearCompleted()
        {
            driver
                .FindElement(clearButton)
                .Click();

            return this;
        }
    }
}
