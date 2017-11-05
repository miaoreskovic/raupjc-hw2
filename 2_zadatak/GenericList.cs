using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_zadatak
{
    public class GenericList<X> : IGenericList<X>
    {
        private X[] _internalStorage;
        private int _lastIndex;
        private int size;
        private int _removeFromIndex;

        public GenericList()
        {
            _internalStorage = new X[3];
            _lastIndex = -1;
            size = 3;
        }

        public GenericList(int initialSize)
        {
            _internalStorage = new X[initialSize];
            _lastIndex = -1;
            size = initialSize;
        }

        public void Add(X item)
        {
            X[] internalStorage = new X[size];
            internalStorage = _internalStorage;
            //int lastIndex = _lastIndex;
            if ((_lastIndex + 1) == size)
            {
                for (int i = 0; i < size; i++)
                {
                    internalStorage[i] = _internalStorage[i];
                }
                _internalStorage = new X[2 * size];
                for (int i = 0; i < size; i++)
                {
                    _internalStorage[i] = internalStorage[i];
                }
                //internalStorage = _internalStorage;
            }
            _internalStorage[_lastIndex + 1] = item;
            _lastIndex++;
        }

        public bool Remove(X item)
        {
            for (int i = 0; i < size; i++)
            {
                if (_internalStorage[i].Equals(item))
                {
                    _removeFromIndex = i;
                    return RemoveAt(_removeFromIndex);
                }
            }
            return false;
        }

        public bool RemoveAt(int index)
        {
            int[] internalStorage = new int[size];
            X temp;
            if (index > size) throw new IndexOutOfRangeException();
            //int j = 0;
            for (int i = index; i + 1 < size; i++)
            {
                temp = _internalStorage[i + 1];
                _internalStorage[i] = temp;
            }
            //_internalStorage = internalStorage;
            _lastIndex--;
            return true;
        }

        public X GetElement(int index)
        {
            if (index <= size) return _internalStorage[index];
            throw new IndexOutOfRangeException();
        }

        public int IndexOf(X item)
        {
            for (int i = 0; i < size; i++)
            {
                if (_internalStorage[i].Equals(item)) return i;
            }
            return -1;
        }


        public int Count { get => _lastIndex + 1; }
        public void Clear()
        {
            _lastIndex = -1;
        }

        public bool Contains(X item)
        {
            //int[] internalStorage = _internalStorage;
            if (_lastIndex == -1) return false;
            for (int i = 0; i < size; i++)
            {
                if (_internalStorage[i].Equals(item)) return true;
            }
            return false;
        }

        public IEnumerator<X> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
                yield return _internalStorage[i];
        }

        private IEnumerator GetEnumerator1()
        {
            return this.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator1();
        }
        //// Must implement GetEnumerator, which returns a new StreamReaderEnumerator.
        //public IEnumerator<string> GetEnumerator()
        //{
        //    return new TodoRepositoryEnumerator(_filePath);
        //}

        //// Must also implement IEnumerable.GetEnumerator, but implement as a private method.
        //private IEnumerator GetEnumerator1()
        //{
        //    return this.GetEnumerator();
        //}
        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return GetEnumerator1();
        //}
    }
}
