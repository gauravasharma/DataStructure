using System;
using System.Collections.Generic;
using System.Text;

namespace DesignDataStructures
{
    public class MyQueue
    {
        Stack<int> input = new Stack<int>();
        Stack<int> output = new Stack<int>();
        public MyQueue()
        {

        }

        /** Push element x to the back of queue. */
        public void Push(int x)
        {
            input.Push(x);
        }

        /** Removes the element from in front of queue and returns that element. */
        public int Pop()
        {
            Peek();
            return output.Pop();
        }

        /** Get the front element. */
        public int Peek()
        {
            if (output.Count ==0)
            {
                while (input.Count != 0)
                {
                    output.Push(input.Pop());
                }
            }
            return Convert.ToInt32(output.Peek());
        }

        /** Returns whether the queue is empty. */
        public bool Empty()
        {
            if (input.Count == 0 && output.Count == 0) return true;
            else return false;
        }
    }
}
