using System;
namespace DataStructures.LIB.Stack
{
    public class LinkedListStack<T>
    {
        public Item<T> Head { get; set; }
        public int Count { get; private set; }

        public LinkedListStack()
        {
            Head = null;
            Count = 0;
        }

        public LinkedListStack(T data)
        {
            Head = new Item<T>(data);
            Count++;

        }

        public void Push(T data)
        {
            var item = new Item<T>(data);
            item.Previous = Head;
            Head = item;
            Count++;
        }

        public T Pop()
        {
            if (Count > 0)
            {
                var item = Head;
                Head = Head.Previous;
                Count--;
                return item.Data;
            }
            else
            {
                throw new NullReferenceException("Stack is empty");
            }
        }

        public T Peek()
        {
            if (Count == 0) throw new NullReferenceException("Stack is empty.");
            return Head.Data;
        }

        public override string ToString()
        {
            return $"LinkedListStack is {Count} elements long. Top element is {Head.ToString()}";
        }
    }
}
