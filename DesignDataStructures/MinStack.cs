using System;
using System.Collections.Generic;
using System.Text;

namespace DesignDataStructures
{
    public class LinkedListMin
    {
        public int val{ get; set; }
        public int minVal { get; set; }
        public LinkedListMin next { get; set; }
    }
    public class MinStack
    {
        LinkedListMin Head;

        public MinStack()
        {
            Head = null;
        }

        public void Push(int x)
        {
            if (Head == null)
            {
                Head = new LinkedListMin();
                Head.val = x;
                Head.minVal = x;
            }
            else
            {
                var node = new LinkedListMin();
                node.val = x;
                node.minVal = Head.minVal < x ? Head.minVal : x;
                node.next = Head;
                Head = node;

            }
        }

        public void Pop()
        {
            if(Head!=null)
            {
                Head = Head.next;
            }
        }

        public int Top()
        {
            if (Head!=null)
            {
                return Head.val;
            }
            return -1;
        }

        public int GetMin()
        {
            if(Head!=null)
            {
                return Head.minVal;
            }
            return -1;

        }
    }
}
