using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA_HashTable_Ronda
{
    internal class HashTable<Tkey, TValue>
    {
        // creating an Internal Data Class
        private class KeyValueNode
        {
            public Tkey Key;
            public TValue Value;
            public KeyValueNode Next;

            // Constructors for KeyValueNode
            public KeyValueNode(Tkey key, TValue value)
            {
                Key = key;
                Value = value;
                Next = null;
            }
        } // KeyValueNode

        // Field for HashTable
        private KeyValueNode[] buckets; // Array of linked lists to store -key-value pairs

        // Constructor to initialize the hash table with a specified size
        public HashTable(int size = 26)
        {
            buckets = new KeyValueNode[size];
        } // ashTable

        private int GetBucketIndex(Tkey key)
        {
            // Get the hash code for the key
            int hash = key.GetHashCode(); // Note: every object has a hash code!

            // Calculate the index using module operation
            // Keeps the index within the range of the bucket
            int index = hash % buckets.Length;

            return Math.Abs(index); // absolute value ensures index is positive
        } // GetBucketIndex

        // Method to add a key value to the hash table
        public void Add(Tkey key, TValue value)
        {
            int bucketIndex = GetBucketIndex(key);
            KeyValueNode newNode = new KeyValueNode(key, value);

            // If the bucket is null, insert node in the bucket
            if (buckets[bucketIndex] == null)
            {
                buckets[bucketIndex] = newNode;
            }
            // If the node already exists in the bucket, append the
            // new node to the end of the linked list
            else
            {
                KeyValueNode current = buckets[bucketIndex];
                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = newNode;

            }
        } // Add

        // Method to retrieve the value associated with a given key from the hash table
        public TValue Get(Tkey key)
        {
            int bucketIndex = GetBucketIndex(key);
            KeyValueNode current = buckets[bucketIndex];

            // traverse the linked list in the bucket to find the node with the matching key
            while(current != null)
            {
                if (current.Key.Equals(key))
                {
                    return current.Value;
                }
                current = current.Next;
            }

            // We can't return null, so have to throw an exception
            throw new Exception("Key Not Found");
            
        } // Get
        
        public bool Contains(Tkey key)
        {
            int bucketIndex = GetBucketIndex(key);
            KeyValueNode current = buckets[bucketIndex];

            // traverse the linked list in the bucket to find the node with the matching key
            while (current != null)
            {
                if (current.Key.Equals(key))
                {
                    return true;
                }
                current = current.Next;
            }

            return false;
        }
    }
}
