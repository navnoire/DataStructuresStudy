using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructures_LIB.LinkedList
{
    /// <summary>
    /// Doubly linked circlar list
    /// </summary>
    public class CircularLinkedList<T> : IEnumerable<T>
    {
        public DoublyItem<T> Head { get; set; }
        public int Count { get; private set; }

        public CircularLinkedList()
        {
            Head = null;
            Count = 0;
        }

        public CircularLinkedList(T data)
        {
            SetVeryFirstElement(data);
            Count++;
        }

        public void Add(T data)
        {
            if (Count == 0)
            {
                SetVeryFirstElement(data);
            }
            else
            {
                var item = new DoublyItem<T>(data)
                {
                    NextCell = Head,
                    PrevCell = Head.PrevCell
                };
                item.PrevCell.NextCell = item;
                Head.PrevCell = item;
            }
            Count++;
        }

        public void Remove(T data)
        {
            if (Count > 0)
            {
                //Remove Head element
                if (Head.Data.Equals(data))
                {
                    Head.NextCell.PrevCell = Head.PrevCell;
                    Head.PrevCell.NextCell = Head.NextCell;
                    Head = Head.NextCell;
                    Count--;
                    return;
                }

                //Remove non-Head element
                var current = Head.NextCell;
                while (current != Head)
                {
                    if (current.Data.Equals(data))
                    {
                        current.PrevCell.NextCell = current.NextCell;
                        current.NextCell.PrevCell = current.PrevCell;
                        Count--;
                        return;
                    }
                    current = current.NextCell;
                }
            }
        }

        private void SetVeryFirstElement(T data)
        {
            Head = new DoublyItem<T>(data);
            Head.NextCell = Head;
            Head.PrevCell = Head;

        }

        public IEnumerator GetEnumerator()
        {
            var current = Head;
            for (int i = Count; i > 0; i--)
            {
                yield return current;
                current = current.NextCell;
            }
        }

        public override string ToString()
        {
            StringBuilder sbuilder = new StringBuilder();
            foreach (var item in this)
            {
                sbuilder.Append(item + " ");
            }

            return sbuilder.ToString();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return (IEnumerator<T>)GetEnumerator();
        }
    }
}
