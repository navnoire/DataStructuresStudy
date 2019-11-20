using System;
using System.Collections.Generic;

namespace DataStructures.LIB.Deque
{
    public class EasyDeque<T>
    {
        private List<T> items = new List<T>();
        private int TailIndex => items.Count - 1;

        public EasyDeque() { }

        public EasyDeque(T data)
        {
            items.Add(data);
        }

        #region Head Operations
        public void AddToHead(T data)
        {
            items.Insert(0, data);
        }

        public T GetFromHead()
        {
            if (items.Count > 0)
            {
                var result = items[0];
                items.RemoveAt(0);
                return result;
            }
            else
            {
                throw new InvalidOperationException("Trying to get value from empty deque.");
            }
        }

        public T PeekHead()
        {
            if (items.Count > 0)
            {
                return items[0];
            }
            else
            {
                throw new InvalidOperationException("Trying to get value from empty deque.");
            }
        }
        #endregion

        #region Tail Operations
        public void AddToTail(T data)
        {
            items.Add(data);
        }

        public T GetFromTail()
        {
            if (items.Count > 0)
            {
                var result = items[TailIndex];
                items.RemoveAt(TailIndex);
                return result;
            }
            else
            {
                throw new InvalidOperationException("Trying to get value from empty deque.");
            }
        }

        public T PeekTail()
        {
            if (items.Count > 0)
            {
                return items[TailIndex];
            }
            else
            {
                throw new InvalidOperationException("Trying to get value from empty deque.");
            }
        }

        #endregion



    }
}
