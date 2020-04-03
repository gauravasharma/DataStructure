using System;

namespace DesignDataStructures
{
    public class MyHashSet
    {

        private int? [] array;
        /** Initialize your data structure here. */
        public MyHashSet()
        {
            array = new int?[1000000];
        }

        public void Add(int key)
        {
            array[key] = key;
        }

        public void Remove(int key)
        {
            array[key] = null;   
        }

        /** Returns true if this set contains the specified element */
        public bool Contains(int key)
        {
            return array[key] == null ? false : true;
        }
    }
}
