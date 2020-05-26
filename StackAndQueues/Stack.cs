using System;

namespace StackAndQueues
{
    public class Stack
    {
        private Node Head;
        public Stack()
        {
            Head = null;
        }
        public void Push(int val)
        {
            var node = new Node(val);
            if(Head==null)
            {
                Head = node;
            }
            else
            {
                node.next = Head;
                Head = node;
            }
        }
        public int Pop()
        {
            if(Head==null)
            {
                throw new Exception("Stack is empty");
            }
            else
            {
                var head = Head;
                var value = head.val;
                Head = head.next;
                return value;
            }
        }

        public int? Peek()
        {
            if(Head==null)
            {
                return null;
            }
            else
            {
                return Head.val;
            }
        }
    }

    public class Node
    {
        public Node(int value)
        {
            val = value;
        }
        public int val { get; set; }
        public Node next { get; set; }
    }
}
