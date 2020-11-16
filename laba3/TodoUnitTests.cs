using NUnit.Framework;
using OpenQA.Selenium;
using System;

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
            driver = DriverBuilder.GetDriverFromUrlAndTarget(
                "http://todomvc.com/examples/angularjs/#/",
                "/html/body/ng-view/section/header/form/input");

            page = new ToDoPageObject(driver);
        }

        [TearDown]
        public void TearDownTest()
        {
            driver.Close();
        }

        [Test(Description = "Test whether it creates the ToDo")]
        public void Todo_CreatesTodo_OnOneNewTodo()
        {
            //Arrange
            string todo = "Cybernetics";
            //Act
            page.AddTodo(todo);
            //Assert
            Assert.IsTrue(page.ContainsTodo(todo));
        }

        [Test(Description = "Test whether it creates several ToDos")]
        public void Todo_CreatesTodos_OnSeveralNewTodos()
        {
            //Arrange
            string[] todos = { "George", "Sofia", "Tolik", "Max" };
            //Act
            page.AddSeveralTodos(todos);
            //Assert
            Assert.IsTrue(page.ContainsSeveralTodos(todos));
        }

        [Test(Description ="Test whether it makrs the todo as completed")]
        public void Todo_MarksTodo_OnTodoIsCompleted()
        {
            //Arrange
            string todo = "Cybernetics";
            //Act
            page.AddTodo(todo);
            page.CompleteTodo(todo);
            bool result = page.IsTodoCompleted(todo);
            //Assert
            Assert.IsTrue(result);
        }

        [Test(Description ="Test whether it marks several todos as completed")]
        public void Todo_MarksSeveralTodos_OnSeveralTodosAreCompleted()
        {
            //Arrange
            string[] todos = { "George", "Sofia", "Tolik", "Max" };
            //Act
            page.AddSeveralTodos(todos);
            page.CompleteSeveralTodos(todos);
            //Assert
            foreach (string todo in todos)
            {
                bool result = page.IsTodoCompleted(todo);
                Assert.IsTrue(result);
            }
        }

        [Test(Description ="Test whether it deletes the todo")]
        public void Todo_DeletesTodo_OnDeletingTodo()
        {
            //Arange
            string todo = "Cybernetics";
            //Act
            page.AddTodo(todo);
            page.DeleteTodo(todo);
            //Assert
            Assert.IsFalse(page.ContainsTodo(todo));
        }

        [Test(Description ="Test whether it edits the todo")]
        public void Todo_EditsTodo_OnEditingTodo()
        {
            //Arange
            string todo = ".NET core 3.0";
            string updatedTodo = ".NET 5.0";
            //Act
            page.AddTodo(todo);
            page.EditTodo(todo, updatedTodo);
            //Assert
            Assert.IsTrue(page.ContainsTodo(updatedTodo));
            Assert.IsFalse(page.ContainsTodo(todo));
        }

        [Test(Description ="Test whether it marks the todo as uncompleted")]
        public void Todo_UnMarksTodo_OnUncompletingTodo()
        {
            //Arrange
            string todo = "Make homework";
            //Act
            page.AddTodo(todo);
            page.CompleteTodo(todo);
            page.IncompleteTodo(todo);
            //Assert
            Assert.IsFalse(page.IsTodoCompleted(todo));
        }

        [Test(Description ="Test whether it marks several completed todos as incompleted")]
        public void Todo_UnMarksSeveralTodos_OnUnmarkingSeveralTodos()
        {
            //Arrange
            string[] todos = { "George", "Sofia", "Tolik", "Max" };
            //Act
            page.AddSeveralTodos(todos);
            page.CompleteSeveralTodos(todos);
            page.IncompleteSeveralTodos(todos);
            //Assert
            foreach (string todo in todos)
            {
                bool result = page.IsTodoCompleted(todo);
                Assert.IsFalse(result);
            }
        }

        [Test(Description ="Test whether it deltes all completed todos")]
        public void Todo_DeletesOnlyCompletedTodos_OnRemoveCompletedTodos()
        {
            //Assert
            string[] todos = { "George", "Sofia", "Tolik", "Max" };
            string[] todoToComplete = { "Tolik", "Max" };
            //Act
            page.AddSeveralTodos(todos);
            page.CompleteSeveralTodos(todoToComplete);
            page.ClearCompleted();
            //Assert
            Assert.IsTrue(page.ContainsTodo("George"));
            Assert.IsTrue(page.ContainsTodo("Sofia"));
            Assert.IsFalse(page.ContainsTodo("Max"));
            Assert.IsFalse(page.ContainsTodo("Tolik"));
        }

        [Test]
        public void Todo_EnablesAllFilter_OnAllFilter()
        {
            //Arrange
            string[] completedTodos = { "Esom", "Meso" };
            string[] incompletedTodos = { "Some", "Omes" };
            //Act
            page.AddSeveralTodos(completedTodos);
            page.AddSeveralTodos(incompletedTodos);
            page.CompleteSeveralTodos(completedTodos);
            page.ApplyActiveFilter();
            page.ApplyAllFilter();
            //Assert
            Assert.IsTrue(page.ContainsSeveralTodos(completedTodos));
            Assert.IsTrue(page.ContainsSeveralTodos(incompletedTodos));
        }

        [Test]
        public void Todo_EnablesActiveFilter_OnActiveFilter()
        {
            //Arrange
            string[] completedTodos = { "Esom", "Meso" };
            string[] incompletedTodos = { "Some", "Omes" };
            //Act
            page.AddSeveralTodos(completedTodos);
            page.AddSeveralTodos(incompletedTodos);
            page.CompleteSeveralTodos(completedTodos);
            page.ApplyActiveFilter();
            //Assert
            Assert.IsFalse(page.ContainsSeveralTodos(completedTodos));
            Assert.IsTrue(page.ContainsSeveralTodos(incompletedTodos));
        }

        [Test]
        public void Todo_EnablesCompletedFilter_OnCompletedFilter()
        {
            //Arrange
            string[] completedTodos = { "Esom", "Meso" };
            string[] incompletedTodos = { "Some", "Omes" };
            //Act
            page.AddSeveralTodos(completedTodos);
            page.AddSeveralTodos(incompletedTodos);
            page.CompleteSeveralTodos(completedTodos);
            page.ApplyCompletedFilter();
            //Assert
            Assert.IsTrue(page.ContainsSeveralTodos(completedTodos));
            Assert.IsFalse(page.ContainsSeveralTodos(incompletedTodos));
        }
    }
}