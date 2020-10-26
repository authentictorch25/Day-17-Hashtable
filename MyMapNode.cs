﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace HashsetsAndBinaryTree
{
    public class MyMapNode<K, V>
    {
        public struct KeyValue<k, v>
        {
            public k Key { get; set; }
            public v Value { get; set; }
        }
        private readonly int size;
        private readonly LinkedList<KeyValue<K, V>>[] items;

        public MyMapNode(int size)
        {
            this.size = size;
            this.items = new LinkedList<KeyValue<K, V>>[size];
        }

        /// <summary>
        /// Gets a unique array items[] position for entered key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        protected int GetArrayPosition(K key)
        {
            /// Returns a unique position to each different key
            int position = key.GetHashCode() % size;
            return Math.Abs(position);
        }

        /// <summary>
        /// Gets the linked list present at the entered position in the items[] array
        /// </summary>
        /// <param name="position">The position.</param>
        /// <returns></returns>
        protected LinkedList<KeyValue<K, V>> GetLinkedList(int position)
        {
            LinkedList<KeyValue<K, V>> linkedList = items[position];
            if (linkedList == null)
            {
                /// Creates new linked list and update items[] array with the same
                linkedList = new LinkedList<KeyValue<K, V>>();
                items[position] = linkedList;
            }
            return linkedList;
        }

        /// <summary>
        /// Gets the value at the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public V Get(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            foreach (KeyValue<K, V> item in linkedList)
            {
                if (item.Key.Equals(key))
                    return item.Value;
            }
            return default(V);
        }

        /// <summary>
        /// Adds the specified key,value pair at the end of the linked list present at the position corresponding to the key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void Add(K key, V value)
        {
            /// Gets the position to the key
            int position = GetArrayPosition(key);
            /// Gets the linked list present at the position
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            KeyValue<K, V> kvp = new KeyValue<K, V>() { Key = key, Value = value };
            /// Adds the key-value pair at the end of the linked list
            linkedList.AddLast(kvp);
            Console.WriteLine(linkedList.Last.Value.Key + " " + linkedList.Last.Value.Value);
        }

        /// <summary>
        /// UC 1 : Prints the frequency of the specified value in the hashtable.
        /// </summary>
        /// <param name="value">The value.</param>
        public void GetFrequencyOf(V value)
        {
            int count = 0;
            foreach (var linkedList in items)
            {
                if (linkedList != null)
                {
                    foreach (var v in linkedList)
                    {
                        if (v.Value.Equals(value))
                            count++;
                    }
                }
            }
            Console.WriteLine($"Frequency of '{value}'= {count}");
        }
    }
}
