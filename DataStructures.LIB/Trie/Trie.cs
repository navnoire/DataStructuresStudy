using System;
using System.Collections.Generic;

namespace DataStructures.LIB.Trie
{
    public class Trie<T>
    {
        private Node<T> root;
        public int WordCount { get; set; }

        public Trie()
        {
            root = new Node<T>
            {
                Pointer = '\0'
            };
        }

        /// <summary>
        /// Adds new word to the current trie
        /// </summary>
        /// <param name="key">Word to add.</param>
        /// <param name="data">Optional data</param>
        public void AddIteratively(string key, T data)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key), "Key can not be empty or whitespace");
            }

            var currentNode = root;
            for (int i = 0; i < key.Length; i++)
            {
                var symbol = key[i];
                if (currentNode.SubNodes.ContainsKey(symbol))
                {
                    currentNode = currentNode.SubNodes[symbol];
                }
                else
                {
                    var newNode = new Node<T>(symbol);
                    newNode.Prefix = key.Substring(0, i);
                    newNode.IsWord |= i == key.Length - 1;

                    currentNode.SubNodes.Add(symbol, newNode);
                    currentNode = newNode;
                }
            }
            currentNode.Data = data;
            WordCount++;
        }

        public void AddRecursively(string key, T data, Node<T> node = null)
        {
            if (node == null)
            {
                node = root;
            }

            if (key.Length == 0)
            {
                if (!node.IsWord)
                {
                    node.Data = data;
                    node.IsWord = true;
                    WordCount++;
                }
            }
            else
            {
                var symbol = key[0];
                if (node.SubNodes.ContainsKey(symbol))
                {
                    AddRecursively(key.Substring(1), data, node.SubNodes[symbol]);
                }
                else
                {
                    var newNode = new Node<T>(symbol);
                    newNode.Prefix = node.Prefix + node.Pointer;
                    node.SubNodes.Add(symbol, newNode);
                    AddRecursively(key.Substring(1), data, newNode);
                }
            }
        }

        public void RemoveRecursively(string key, Node<T> node = null)
        {
            if (node == null) node = root;
            if (string.IsNullOrEmpty(key))
            {
                if (node.IsWord)
                {
                    node.IsWord = false;
                    node.Data = default;
                    WordCount--;
                }
            }
            else
            {
                var symbol = key[0];
                if (node.SubNodes.ContainsKey(symbol))
                {
                    RemoveRecursively(key.Substring(1), node.SubNodes[symbol]);
                }
            }
        }

        public void RemoveIteratively(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key), "Key can not be empty or whitespace");
            }

            var currentNode = root;
            for (int i = 0; i < key.Length; i++)
            {
                var symbol = key[i];
                if (currentNode.SubNodes.ContainsKey(symbol))
                {
                    currentNode = currentNode.SubNodes[symbol];
                }
                else
                {
                    return;
                }
            }

            if (currentNode.IsWord)
            {
                currentNode.IsWord = false;
                currentNode.Data = default;
                WordCount--;
            }
        }

        public bool TrySearchIteratively(string key, out T value)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key), "Key can not be empty or whitespace");
            }

            var currentNode = root;
            for (int i = 0; i < key.Length; i++)
            {
                var symbol = key[i];
                if (currentNode.SubNodes.ContainsKey(symbol))
                {
                    currentNode = currentNode.SubNodes[symbol];
                }
                else
                {
                    break;
                }
            }

            if (currentNode.IsWord)
            {
                value = currentNode.Data;
                return true;
            }

            value = default;
            return false;
        }

        public bool TrySearchRecursively(string key, out T value, Node<T> node = null)
        {
            value = default;

            if (node == null) node = root;
            if (string.IsNullOrEmpty(key))
            {
                if (node.IsWord)
                {
                    value = node.Data;
                    return true;
                }
            }
            else
            {
                var symbol = key[0];
                if (node.SubNodes.ContainsKey(symbol))
                {
                    return TrySearchRecursively(key.Substring(1), out value, node.SubNodes[symbol]);
                }
            }
            return false;
        }


        //TODO Реализовать поиск слов (возвращаем список слов) по заданному префиксу
        public List<T> PrefixSearch(string prefix)
        {
            return new List<T>();
        }
    }
}
