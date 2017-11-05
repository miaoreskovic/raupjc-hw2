using Microsoft.VisualStudio.TestTools.UnitTesting;
using _2_zadatak;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_zadatak.Tests
{
    [TestClass()]
    public class TodoRepositoryTests
    {
        
        
        //TodoItem todo2 = new TodoItem("Drugi todo");
        //TodoRepository _internalRepository = new TodoRepository();
        [TestMethod()]
        public void AddItemInRepositoryTest()
        {
            TodoItem todo1 = new TodoItem("Prvi todo");
            TodoItem todo2 = new TodoItem("Drugi todo");
            Assert.IsNotNull(todo1);
            TodoRepository _internalRepository = new TodoRepository();
            Assert.IsNotNull(_internalRepository);
            
            Assert.AreEqual(todo1, _internalRepository.Add(todo1));
            Assert.AreEqual(todo2, _internalRepository.Add(todo2));
            _internalRepository.Remove(todo1.Id);
            Assert.AreEqual(_internalRepository.Get(todo2),todo2);
            Assert.AreEqual(null, _internalRepository.Get(todo1));
        }

        [TestMethod()]
        public void MarkAsCompletedInRepositoryTest()
        {
            TodoRepository _internalRepository = new TodoRepository();
            TodoItem todo = new TodoItem("Prvi todo");
            _internalRepository.Add(todo);
            Assert.AreEqual(false, _internalRepository.Get(todo).IsCompleted);
            _internalRepository.MarkAsCompleted(todo.Id);
            Assert.AreEqual(true, _internalRepository.Get(todo).IsCompleted);
        }

        [TestMethod()]
        public void GetwithItemTest()
        {
            /// test for method Get(TodoItem todo)
            TodoRepository _internalRepository = new TodoRepository();
            TodoItem todo1 = new TodoItem("Prvi todo");
            TodoItem todo2 = new TodoItem("Drugi todo");
            TodoItem todo3 = new TodoItem("Treci todo");
            TodoItem todo4 = new TodoItem("Cetvrti todo");
            _internalRepository.Add(todo3);
            _internalRepository.Add(todo1);
            _internalRepository.Add(todo2);
            /// 3 items are added, with method Get we are getting one of the items
            /// it is expected that they are Equal
            Assert.AreEqual(todo1, _internalRepository.Get(todo1));
            ///if method Get does not find TodoItem in repository it returns null
            Assert.IsNull(_internalRepository.Get(todo4));
            Assert.IsNull(_internalRepository.Get(null));
        }

        [TestMethod()]
        public void GetwithItemIdTest()
        {
            TodoRepository _internalRepository = new TodoRepository();
            TodoItem todo1 = new TodoItem("Prvi todo");
            TodoItem todo2 = new TodoItem("Drugi todo");
            TodoItem todo3 = new TodoItem("Treci todo");
            TodoItem todo4 = new TodoItem("Cetvrti todo");
            _internalRepository.Add(todo3);
            _internalRepository.Add(todo1);
            _internalRepository.Add(todo2);
            /// 3 items are added, with method Get we are getting one of the items
            /// it is expected that they are Equal
            Assert.AreEqual(todo1, _internalRepository.Get(todo1.Id));
            ///if method Get does not find TodoItem in repository it returns null
            Assert.IsNull(_internalRepository.Get(todo4));
            //Assert.IsNull(_internalRepository.Get(null));

        }

        [TestMethod()]
        public void GetActiveTest()
        {
            TodoRepository _internalRepository = new TodoRepository();
            TodoItem todo1 = new TodoItem("Prvi todo");
            TodoItem todo2 = new TodoItem("Drugi todo");
            TodoItem todo3 = new TodoItem("Treci todo");
            TodoItem todo4 = new TodoItem("Cetvrti todo");
            todo1.MarkAsCompleted();
            todo3.MarkAsCompleted();
            // list should be empty, containing 0 elements
            List<TodoItem> activeTodoItems = _internalRepository.GetActive();
            Assert.AreEqual(0, activeTodoItems.Count());

            _internalRepository.Add(todo1);
            _internalRepository.Add(todo2);
            _internalRepository.Add(todo3);
            _internalRepository.Add(todo4);
            activeTodoItems = _internalRepository.GetActive();
            /// list should contain two items that are not completed, todo2 and todo4
            Assert.AreEqual(2, activeTodoItems.Count());
            Assert.AreEqual(true, activeTodoItems.Contains(todo2));
            Assert.AreEqual(false, activeTodoItems.Contains(todo1));

        }

        [TestMethod()]
        public void GetAllTest()
        {
            TodoRepository _internalRepository = new TodoRepository();
            TodoItem todo1 = new TodoItem("Prvi todo");
            TodoItem todo2 = new TodoItem("Drugi todo");
            TodoItem todo3 = new TodoItem("Treci todo");
            todo1.MarkAsCompleted();
            todo3.MarkAsCompleted();
            // list should be empty, containing 0 elements
            List<TodoItem> activeTodoItems = _internalRepository.GetActive();
            Assert.AreEqual(0, activeTodoItems.Count());

            _internalRepository.Add(todo1);
            _internalRepository.Add(todo2);
            _internalRepository.Add(todo3);
            activeTodoItems = _internalRepository.GetAll();
            /// list should contain threee items
            Assert.AreEqual(3, activeTodoItems.Count());
            Assert.AreEqual(true, activeTodoItems.Contains(todo1));
            Assert.AreEqual(true, activeTodoItems.Contains(todo2));
            Assert.AreEqual(true, activeTodoItems.Contains(todo3));
        }

        [TestMethod()]
        public void GetCompletedTest()
        {
            TodoRepository _internalRepository = new TodoRepository();
            TodoItem todo1 = new TodoItem("Prvi todo");
            TodoItem todo2 = new TodoItem("Drugi todo");
            TodoItem todo3 = new TodoItem("Treci todo");
            TodoItem todo4 = new TodoItem("Cetvrti todo");
            todo1.MarkAsCompleted();
            todo3.MarkAsCompleted();
            // list should be empty, containing 0 elements
            List<TodoItem> activeTodoItems = _internalRepository.GetCompleted();
            Assert.AreEqual(0, activeTodoItems.Count());

            _internalRepository.Add(todo1);
            _internalRepository.Add(todo2);
            _internalRepository.Add(todo3);
            _internalRepository.Add(todo4);
            activeTodoItems = _internalRepository.GetCompleted();
            /// list should contain two items
            Assert.AreEqual(2, activeTodoItems.Count());
            Assert.AreEqual(true, activeTodoItems.Contains(todo3));
            Assert.AreEqual(false, activeTodoItems.Contains(todo2));
            Assert.AreEqual(true, activeTodoItems.Contains(todo1));
        }

        [TestMethod()]
        public void RemoveTest()
        {
            TodoRepository _internalRepository = new TodoRepository();
            TodoItem todo1 = new TodoItem("Prvi todo");
            TodoItem todo2 = new TodoItem("Drugi todo");
            TodoItem todo3 = new TodoItem("Treci todo");
            TodoItem todo4 = new TodoItem("Cetvrti todo");
            todo1.MarkAsCompleted();
            todo3.MarkAsCompleted();
            // list should be empty, containing 0 elements
            List<TodoItem> allTodoItems = _internalRepository.GetAll();
            Assert.AreEqual(0, allTodoItems.Count());

            _internalRepository.Add(todo1);
            _internalRepository.Add(todo2);
            _internalRepository.Add(todo3);
            _internalRepository.Add(todo4);
            allTodoItems = _internalRepository.GetAll();
            Assert.AreEqual(4, allTodoItems.Count());
            Assert.AreEqual(true, _internalRepository.Remove(todo3.Id));
            Assert.AreEqual(null, _internalRepository.Get(todo3));
            //allTodoItems = _internalRepository.GetAll();
            //Assert.AreEqual(3, allTodoItems.Count());
            //Assert.AreEqual(true, allTodoItems.Contains(todo3));
            //Assert.AreEqual(true, allTodoItems.Contains(todo1));
            //Assert.AreEqual(true, allTodoItems.Contains(todo2));
            ////Assert.AreEqual(true, allTodoItems.Contains(todo4));
            //Assert.AreEqual(true, _internalRepository.Remove(todo3.Id));
            //allTodoItems = _internalRepository.GetAll();
            //Assert.AreEqual(2, allTodoItems.Count());
            //Assert.AreEqual(false, allTodoItems.Contains(todo3));
            //Assert.AreEqual(true, allTodoItems.Contains(todo1));
            //Assert.AreEqual(true, allTodoItems.Contains(todo2));
            //Assert.AreEqual(true, allTodoItems.Contains(todo2));
            //Assert.AreEqual(true, allTodoItems.Contains(todo1));
        }

        [TestMethod()]
        public void UpdateTest()
        {
            TodoRepository _internalRepository = new TodoRepository();
            TodoItem todo1 = new TodoItem("Prvi todo");
            TodoItem todo2 = new TodoItem("Drugi todo");
            TodoItem todo3 = new TodoItem("Treci todo");
            TodoItem todo4 = new TodoItem("Cetvrti todo");
            
            // list should be empty, containing 0 elements
            List<TodoItem> activeTodoItems = _internalRepository.GetCompleted();
            Assert.AreEqual(0, activeTodoItems.Count());

            _internalRepository.Add(todo1);
            _internalRepository.Add(todo2);
            _internalRepository.Add(todo3);
            _internalRepository.Add(todo4);
            Assert.AreEqual(false, _internalRepository.Get(todo4).IsCompleted);
            todo4.MarkAsCompleted();
            _internalRepository.Update(todo4);
            Assert.AreEqual(true, _internalRepository.Get(todo4).IsCompleted);
        }

        [TestMethod()]
        public void GetFilteredTest()
        {
            //not implemented
        }

    }
}