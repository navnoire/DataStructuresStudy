using System;
namespace DataStructures.LIB.LinkedList
{
    /// <summary>
    /// LinkedList cell
    /// </summary>
    /// <typeparam name="T">Cell data type</typeparam>
    public class Item<T>
    {
        private T data = default(T);

        /// <summary>
        /// Data that is stored in a LinkedList cell.
        /// </summary>
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

        /// <summary>
        /// Reference to the next element of LinkedList
        /// </summary>
        public Item<T> Next { get; set; }

        /// <summary>
        /// Construct new cell of LinkedList
        /// </summary>
        /// <param name="data">Type of the data in this cell</param>
        public Item(T data)
        {
            Data = data;
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
