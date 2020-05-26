using System;
using System.Collections.Generic;
using System.Text;

namespace StackAndQueues
{
    public class Queue
    {
        Stack stack;
        Stack output;
        public Queue()
        {
            stack=new Stack();
            output = new Stack();
        }

        public void Push(int val)
        {
            stack.Push(val);
        }

        public int Pop()
        {
            Peek();
            return output.Pop();
        }

        public int? Peek()
        {
           
            while (stack.Peek() != null)
            {
                output.Push(stack.Pop());
            }

            return output.Peek();
        }
    }
}
