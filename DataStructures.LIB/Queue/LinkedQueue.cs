using System;
using DataStructures.LIB.LinkedList;

namespace DataStructures.LIB.Queue
{
    /// <summary>
    /// Queue based on LinkedList.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkedQueue<T>
    {
        /// <summary>
        /// First element of the queue.
        /// </summary>
        private Item<T> head;
        /// <summary>
        /// Last element of the queue.
        /// </summary>
        private Item<T> tail;
        /// <summary>
        /// Total number of elements in the queue.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Create new empty linked queue.
        /// </summary>
        public LinkedQueue()
        {
            head = null;
            tail = null;
            Count = 0;
        }

        /// <summary>
        /// Add an item to the tail of the queue.
        /// </summary>
        /// <param name="data">Data to add.</param>
        public void Enqueue(T data)
        {
            var item = new Item<T>(data);
            if (Count == 0)
            {
                head = item;
                tail = item;
            }
            else
            {
                tail.Next = item;
                tail = item;
            }
            Count++;
        }

        /// <summary>
        /// Get an element from the head of the queue.
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Trying to get value from empty queue.");
            }

            var result = head.Data;
            head = head.Next;
            Count--;
            return result;
        }

        /// <summary>
        /// View the first element in the queue.
        /// </summary>
        /// <returns>Element of the queue</returns>
        public T Peek()
        {
            return head.Data;
        }

    }
}
