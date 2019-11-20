using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructures_LIB.LinkedList
{
    public class DoublyLinkedList<T> : IEnumerable<T>
    {
        public DoublyItem<T> Head { get; set; }
        public DoublyItem<T> Tail { get; set; }
        public int Count { get; private set; }

        public DoublyLinkedList()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public DoublyLinkedList(T data)
        {
            SetVeryFirstElement(data);
            Count++;
        }

        public void Add(T data)
        {
            if (Head == null)
            {
                SetVeryFirstElement(data);
            }
            else
            {
                var item = new DoublyItem<T>(data);
                Tail.NextCell = item;
                item.PrevCell = Tail;
                Tail = item;
            }
            Count++;
        }

        public void Remove(T data)
        {
            if (Head != null)
            {
                //remove head element
                if (Head.Data.Equals(data))
                {
                    Head = Head.NextCell;
                    Head.PrevCell = null;
                    Count--;
                    return;
                }

                //remove all other elements
                var current = Head.NextCell;
                while (current != null)
                {
                    if (current.Data.Equals(data))
                    {
                        current.PrevCell.NextCell = current.NextCell;
                        if (current.NextCell != null)
                        {
                            current.NextCell.PrevCell = current.PrevCell;
                        }
                        else
                        {
                            Tail = current.PrevCell;
                        }
                        Count--;
                        return;
                    }
                    current = current.NextCell;
                }
            }
        }

        public void RemoveAt(int index)
        {

        }

        public DoublyLinkedList<T> Reverse()
        {
            var resList = new DoublyLinkedList<T>();

            var current = Tail;
            while (current != null)
            {
                resList.Add(current.Data);
                current = current.PrevCell;
            }
            return resList;
        }

        private void SetVeryFirstElement(T data)
        {
            var item = new DoublyItem<T>(data);
            Head = item;
            Tail = item;
        }

        public IEnumerator GetEnumerator()
        {
            var current = Head;
            while (current != null)
            {
                yield return current.Data;
                current = current.NextCell;
            }
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

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return (IEnumerator<T>)GetEnumerator();
        }

        public DoublyLinkedList<T> Clone()
        {
            var cloneList = new DoublyLinkedList<T>();
            foreach (T item in this)
            {
                cloneList.Add(item);
            }
            return cloneList;
        }
    }
}
