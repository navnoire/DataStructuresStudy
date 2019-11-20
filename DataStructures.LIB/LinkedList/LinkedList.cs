using System;
using System.Collections;
using System.Text;

namespace DataStructures.LIB.LinkedList
{
    /// <summary>
    /// Linked List.
    /// </summary>
    /// <typeparam name="T">Type of elements to put in this list.</typeparam>
    public class LinkedList<T> : IEnumerable
    {
        /// <summary>
        /// First element of LinkedList.
        /// </summary>
        public Item<T> Head { get; private set; }

        /// <summary>
        /// Last element of LinkedList.
        /// </summary>
        public Item<T> Tail { get; private set; }

        /// <summary>
        /// Total number of items in the LinkedList.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Default empty LinkedList constructor.
        /// </summary>
        public LinkedList()
        {
            Clear();
        }

        /// <summary>
        /// Сreate a list while adding the first item simultaneously.
        /// </summary>
        /// <param name="data">Data to be added as first item of the LinkedList.</param>
        public LinkedList(T data)
        {
            SetVeryFirstElement(data);
            Count++;
        }

        /// <summary>
        /// Remove all elements from the list.
        /// </summary>
        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        /// <summary>
        /// Add new element to the top of the list.
        /// </summary>
        /// <param name="data">Data to put in this cell.</param>
        public void Append(T data)
        {
            if (Head == null)
            {
                SetVeryFirstElement(data);
            }
            else
            {
                var item = new Item<T>(data);
                item.Next = Head;
                Head = item;
            }
            Count++;
        }
        /// <summary>
        /// Insert data into specific index in a list.
        /// </summary>
        /// <param name="data">Data</param>
        /// <param name="index">Index</param>
        public void Insert(T data, int index)
        {
            if (index > Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            if (index == 0)
            {
                Append(data);
                return;
            }

            int i = 0;
            var previous = Head;
            var current = Head.Next;

            while (i < index - 1)
            {
                previous = current;
                current = current.Next;
                i++;
            }

            var item = new Item<T>(data);
            previous.Next = item;
            item.Next = current;
            Count++;

        }

        /// <summary>
        /// Add new element at the end of LinkedList.
        /// </summary>
        /// <param name="data">Data to put in this cell.</param>
        public void Add(T data)
        {
            if (Head == null)
            {
                SetVeryFirstElement(data);
            }
            else
            {
                var item = new Item<T>(data);
                Tail.Next = item;
                Tail = item;
            }
            Count++;
        }

        /// <summary>
        /// Remove first occurrence of matching item from list.
        /// </summary>
        /// <param name="data">Data for comparison.</param>
        public void Remove(T data)
        {
            if (Head != null)
            {
                // if we need to remove head element
                if (Head.Data.Equals(data))
                {
                    Head = Head.Next;
                    Count--;
                    return;
                }

                //if we need to remove an item in the middle of the list
                var current = Head.Next;
                var previous = Head;
                while (current != null)
                {
                    if (current.Data.Equals(data))
                    {
                        previous.Next = current.Next;
                        if (previous.Next == null)
                        {
                            Tail = previous;
                        }
                        Count--;
                        return;
                    }
                    previous = current;
                    current = previous.Next;
                }
            }
        }

        private void SetVeryFirstElement(T data)
        {
            var item = new Item<T>(data);
            Head = item;
            Tail = item;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in this)
            {
                sb.Append(item + ", ");
            }
            return sb.ToString();
        }

        public IEnumerator GetEnumerator()
        {
            var current = Head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}
