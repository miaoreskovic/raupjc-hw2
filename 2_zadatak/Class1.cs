using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _2_zadatak
{
    public class TodoItem
    {
        public Guid Id { get; set; }
        public string Text { get; set; }

        public bool IsCompleted
        {
            get
            {
                return DateCompleted.HasValue;
            }
        }

        public DateTime? DateCompleted { get; set; }
        public DateTime DateCreated { get; set; }

        public TodoItem(string text)
        {
            //Generates new unique identifier
            Id = Guid.NewGuid();

            // DateTime.Now returns local time, it wont always be what you expect
            //    (depending where the server is).
            // We want to use universal (UTC) time which we can easily convert to
            //    local when needed
            // (usually done in browser on the client side)
            DateCreated = DateTime.UtcNow;

            Text = text;
        }

        public bool MarkAsCompleted()
        {
            if (!IsCompleted)
            {
                DateCompleted = DateTime.Now;
                return true;
            }
            return false;
        }

        public bool Equals(TodoItem other)
        {
            // Would still want to check for null etc. first.
            return
                this.Id == other.Id;
        }

        public bool Equals(Guid other)
        {
            // Would still want to check for null etc. first.
            return
                this.Id == other;
        }

        public override int GetHashCode()
        {
            int hashId = Id == null ? 0 : Id.GetHashCode();
            //int hashJmbag = Jmbag == null ? 0 : Jmbag.GetHashCode();

            return hashId;
        }

        public static bool operator ==(TodoItem x, TodoItem y)
        {
            if (Equals(x, null))
            {
                return (Equals(y, null));
            }
            else if (Equals(y, null))
            {
                return false;
            }
            else
            {
                if (x.Id == y.Id) return true;
            }
            return false;
        }

        public static bool operator !=(TodoItem x, TodoItem y)
        {
            return !(x == y);
        }



    }

    /// <summary >
    /// Class that encapsulates all the logic for accessing TodoTtems .
    /// </ summary >
    public class TodoRepository : ITodoRepository
    {
        /// <summary >
        /// Repository does not fetch todoItems from the actual database ,
        /// it uses in memory storage for this excersise .
        /// </ summary >
        private readonly IGenericList<TodoItem> _inMemoryTodoDatabase;
        public TodoRepository(IGenericList<TodoItem> initialDbState = null)
        {
            if (initialDbState != null)
            {
                _inMemoryTodoDatabase = initialDbState;
            }
            else
            {
                _inMemoryTodoDatabase = new GenericList<TodoItem>();
            }
            // Shorter way to write this in C# using ?? operator :
            // x ?? y = > if x is not null , expression returns x. Else it will
            //return y.
            // _inMemoryTodoDatabase = initialDbState ?? new List < TodoItem >();
        }

        public TodoItem Add(TodoItem todoItem)
        {
            bool firstPass = false;
            if (_inMemoryTodoDatabase.Count() == 0) firstPass = true;
            TodoItem temp = _inMemoryTodoDatabase.Where(o => o.Id.Equals(todoItem.Id)).FirstOrDefault();
            if (temp != null && !firstPass) throw new duplicateTodoItemException(new { message = "Duplicate id = { " + todoItem.Id + " }" });
            else
            {
                _inMemoryTodoDatabase.Add(todoItem);
                firstPass = false;
                return todoItem;
            }
            //throw new NotImplementedException();
        }
        /// Gets TodoItem for a given id
        /// </ summary >
        /// <returns > TodoItem if found , null otherwise </ returns >
        public TodoItem Get(TodoItem todoItem)
        {
            if (todoItem != null)
            {
                TodoItem temp = _inMemoryTodoDatabase.Where(o => o.Equals(todoItem)).FirstOrDefault();
                return temp;
            }
            return todoItem;
        }

        public TodoItem Get(Guid todoId)
        {
            /// <summary >
            /// Gets TodoItem for a given id
            /// </ summary >
            /// <returns > TodoItem if found , null otherwise </ returns >
            TodoItem temp = _inMemoryTodoDatabase.Where(o => o.Id.Equals(todoId)).FirstOrDefault();
            return temp;
            //throw new NotImplementedException();
        }

        public List<TodoItem> GetActive()
        {
            /// <summary >
            /// Gets all incomplete TodoItem objects in the database
            /// </ summary >
            List<TodoItem> incompleteTodoItems = _inMemoryTodoDatabase.Where(o => !o.IsCompleted).ToList();
            return incompleteTodoItems;
        }

        public List<TodoItem> GetAll()
        {
            /// <summary >
            /// Gets all TodoItem objects in the database , sorted by date created
            /// (descending )
            /// </ summary >
            List<TodoItem> SortedAllTodoItems = _inMemoryTodoDatabase.OrderByDescending(o => o.DateCreated).ToList();
            return SortedAllTodoItems;
            //throw new NotImplementedException();
        }

        public List<TodoItem> GetCompleted()
        {
            /// <summary >
            /// Gets all completed TodoItem objects in the database
            /// </ summary >
            List<TodoItem> completeTodoItems = _inMemoryTodoDatabase.Where(o => o.IsCompleted).ToList();
            return completeTodoItems;
            
        }

        public List<TodoItem> GetFiltered(Func<TodoItem, bool> filterFunction)
        {
            /// <summary >
            /// Gets all TodoItem objects in database that apply to the filter
            /// </ summary >
            
            throw new NotImplementedException();
        }

        public bool MarkAsCompleted(Guid todoId)
        {
            /// <summary >
            /// Tries to mark a TodoItem as completed in the database .
            /// </ summary >
            /// <returns > True if success , false otherwise </ returns >
            ///TodoItem temp = null;
            TodoItem temp = _inMemoryTodoDatabase.Where(o => o.Id.Equals(todoId)).FirstOrDefault();
            if (temp != null)
            {
                _inMemoryTodoDatabase.Remove(temp);
                temp.MarkAsCompleted();
                _inMemoryTodoDatabase.Add(temp);
                return true;
            }
             return false;
            //throw new NotImplementedException();
        }

        public bool Remove(Guid todoId)
        {
            /// <summary >
            /// Tries to remove a TodoItem with given id from the database .
            /// </ summary >
            /// <returns > True if success , false otherwise </ returns >
            TodoItem temp = _inMemoryTodoDatabase.Where(o => o.Id.Equals(todoId)).FirstOrDefault();
            if (temp != null)
            {
                //int index = _inMemoryTodoDatabase.IndexOf(temp);
                return _inMemoryTodoDatabase.RemoveAt(_inMemoryTodoDatabase.IndexOf(temp));
            }
            return false;
            //throw new NotImplementedException();
        }

        public TodoItem Update(TodoItem todoItem)
        {
            /// <summary >
            /// Updates given TodoItem in the database .
            /// If TodoItem does not exist , method will add one .
            /// </ summary >
            /// <returns > TodoItem that was updated </ returns >
            ///Student s = students.Where(s => s.Jmbag == "00324432")
            ///    .FirstOrDefault();
            TodoItem temp = _inMemoryTodoDatabase.Where(o => o.Id.Equals(todoItem.Id)).FirstOrDefault();
            //List<TodoItem> items = _inMemoryTodoDatabase.Where(item => item.Id == todoItem.Id).ToList();
            if (temp == null)
            {
                _inMemoryTodoDatabase.Add(todoItem);
                return todoItem;
            }
            else
            {
                _inMemoryTodoDatabase.Remove(temp);
                 _inMemoryTodoDatabase.Add(todoItem);
                return todoItem;
            }

 
        }

    }

    class duplicateTodoItemException  : Exception
    {
        public duplicateTodoItemException(dynamic json)
            : base("Plep")
        {
            _Message = json.message;
        }

        public override string Message
        {
            get { return _Message; }
        }

        private string _Message;
    }


}
