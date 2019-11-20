using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures.LIB.Queue
{
    public class EasyQueue<T>
    {
        private List<T> items = new List<T>();
        private T Head => items.First();
        private T Tail => items.Last();
        public int Count => items.Count;

        public EasyQueue() { }

        public EasyQueue(T data)
        {
            items.Add(data);
        }

        public void Enqueue(T data)
        {
            if (typeof(T).IsValueType || data != null)
            {
                items.Add(data);
            }
        }

        public T Dequeue()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("This queue is empty.");
            }
            var result = Head;
            items.Remove(Head);
            return result;
        }

        public T Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("This queue is empty.");
            }
            return Head;
        }
    }
}
