using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class LinkedListNode<T>
    {
        public LinkedListNode(T value)
        {
            Value = value;
        }

        /// <summary>
        /// The Node Value.
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// The Next Node in the Linked list.
        /// </summary>
        public LinkedListNode<T> Next { get; set; }
    }
}
