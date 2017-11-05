using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _2_zadatak;

namespace _2_zadatakTests
{
    [TestClass]
    public class TodoItemTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            TodoItem toDoItem = new TodoItem("Ja sam todo");
            //default value of property IsCompleted is false;
            Assert.AreEqual(false,toDoItem.IsCompleted);
            toDoItem.MarkAsCompleted();
            Assert.AreEqual(true, toDoItem.IsCompleted);

        }
    }
}
