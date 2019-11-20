using System;
namespace DataStructures.LIB.LinkedList
{
    public class DoublyItem<T>
    {
        private T data;
        public T Data
        {
            get { return data; }
            set
            {
                if (typeof(T).IsValueType || value != null)
                {
                    data = value;
                }
                else
                {
                    throw new ArgumentNullException(nameof(value));
                }
            }
        }
        public DoublyItem<T> PrevCell { get; set; }
        public DoublyItem<T> NextCell { get; set; }

        public DoublyItem(T data)
        {
            Data = data;
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
