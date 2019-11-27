using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.LIB.HashTable
{
    public class Item<T>
    {
        public int Key { get; set; }
        public List<T> Nodes { get; set; }

        public Item(int key)
        {
            Key = key;
            Nodes = new List<T>();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            return sb.AppendJoin(' ', Nodes).ToString();
        }
    }
}
