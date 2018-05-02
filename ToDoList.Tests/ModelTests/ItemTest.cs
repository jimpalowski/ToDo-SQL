using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoList.Models;
using System;

namespace ToDoList.Tests
{

    [TestClass]
    public class ItemTests : IDisposable
    {
        public void Dispose()
        {
            Item.DeleteAll();
        }
        public ItemTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=todo_testt;";
        }

        [TestMethod]
        public void GetAll_DbStartsEmpty_0()
        {
          //Arrange
          //Act
          int result = Item.GetAll().Count;

          //Assert
          Assert.AreEqual(0, result);
        }
    }
}
