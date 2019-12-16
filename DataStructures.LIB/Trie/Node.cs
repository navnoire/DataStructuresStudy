using System;
using System.Collections.Generic;

namespace DataStructures.LIB.Trie
{
    public class Node<T>
    {
        public char Pointer { get; set; }
        public T Data { get; set; }
        public bool IsWord { get; set; }
        public string Prefix { get; set; }

        public Dictionary<char, Node<T>> SubNodes { get; set; }

        public Node()
        {
            SubNodes = new Dictionary<char, Node<T>>();
        }

        public Node(char pointer) : this()
        {
            Pointer = pointer;
        }


        public Node(char pointer, T data) : this(pointer)
        {
            Data = data;
        }

        public override string ToString()
        {
            return Data.ToString();
        }

        public override bool Equals(object obj)
        {
            //FIXME: в видео сравнение по данным, но, по-моему, он ошибся.
            if (obj is Node<T> item)
            {
                return Pointer == item.Pointer;
            }
            return false;
        }
    }
}
