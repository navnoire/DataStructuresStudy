using System;
using DataStructures.LIB.LinkedList;

namespace DataStructures.LIB.Deque
{
    public class DoublyLinkedDeque<T>
    {
        private DoublyItem<T> head;
        private DoublyItem<T> tail;

        public int Count;

        public DoublyLinkedDeque()
        {
            head = null;
            tail = null;
            Count = 0;
        }

        public DoublyLinkedDeque(T data)
        {
            PushToHead(data);
        }

        public void PushToHead(T data)
        {
            if (Count == 0)
            {
                SetVeryFirstElement(data);
            }
            else
            {
                var item = new DoublyItem<T>(data);
                item.NextCell = head;
                head.PrevCell = item;
                head = item;
            }
            Count++;
        }

        public void PushToTail(T data)
        {
            if (Count == 0)
            {
                SetVeryFirstElement(data);
            }
            else
            {
                var item = new DoublyItem<T>(data);
                item.PrevCell = tail;
                tail.NextCell = item;
                tail = item;
            }
            Count++;
        }

        public T PopFromHead()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Trying to get value from empty queue.");
            }
            var result = head.Data;
            head = head.NextCell;

            if (head != null)
            {
                head.PrevCell = null;
            }
            else
            {
                tail = null;
            }

            Count--;
            return result;
        }

        public T PopFromTail()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Trying to get value from empty queue.");
            }
            var result = tail.Data;
            tail = tail.PrevCell;

            if (tail != null)
            {
                tail.NextCell = null;
            }
            else
            {
                head = null;
            }

            Count--;
            return result;
        }

        public T PeekHead()
        {
            if (Count > 0)
            {
                return head.Data;
            }
            throw new InvalidOperationException("Trying to get value from empty queue.");
        }

        public T PeekTail()
        {
            if (Count > 0)
            {
                return tail.Data;
            }
            throw new InvalidOperationException("Trying to get value from empty queue.");
        }

        private void SetVeryFirstElement(T data)
        {
            var item = new DoublyItem<T>(data);
            head = item;
            tail = item;
        }
    }
}
