using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListProblems
{

    public class ListNode
    {
        public ListNode(int value)
        {
            val = value;
        }

        /// <summary>
        /// The Node Value.
        /// </summary>
        public int val { get; set; }

        /// <summary>
        /// The Next Node in the Linked list.
        /// </summary>
        public ListNode next { get; set; }
    }
}
