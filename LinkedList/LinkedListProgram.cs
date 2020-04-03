using System;

namespace LinkedList
{
    public class LinkedListProgram
    {
        static void Main(string[] args)
        {
            LinkedList<int> number = new LinkedList<int>();
            number.Add(1000);
            number.Add(500);
            number.Add(21);
            number.Add(404);
            number.Add(70);
            number.Add(6);
            number.Add(7);
            number.Add(8);
            number.Add(9);


            foreach (var num in number)
            {
                Console.WriteLine(num);
            }


            #region reverse
            //number.Reverse();

            //Console.WriteLine("After Reversing");
            //foreach (var num in number)
            //{
            //    Console.WriteLine(num);
            //}
            #endregion

            #region  Swap

            //number.Swap();
            //number.Swap_1();
            //Console.WriteLine("After Swapping");
            //foreach (var num in number)
            //{
            //    Console.WriteLine(num);
            //}
            #endregion

            #region Sort the linked List
            number.SortLinkedList();
            Console.WriteLine("After Sorting");
            foreach (var num in number)
            {
                Console.WriteLine(num);
            }
            #endregion

            #region remove
            //number.Remove(6);
            //Console.WriteLine("Delete node 8");
            //foreach (var num in number)
            //{
            //    Console.WriteLine(num);
            //}
            #endregion
            Console.Read();
        }
        #region Company Problems

        public LinkedListNode<int> AddTwoNumbers(LinkedListNode<int> L1, LinkedListNode<int> L2)
        {
            LinkedListNode<int> result;
            LinkedListNode<int> L1Temp = L1;
            LinkedListNode<int> L2Temp = L2;

            while (L1Temp != null && L2Temp != null)
            {
                var value = Convert.ToInt32(L1Temp.Value) + Convert.ToInt32(L2Temp.Value);
                result = new LinkedListNode<int>(value);

                L1Temp = L1Temp.Next;
                L2Temp = L2Temp.Next;
            }
            return null;
        }

        public LinkedListNode<int> GetMiddleNode(LinkedListNode<int> Head)
        {
            LinkedListNode<int> slowPtr = Head;
            LinkedListNode<int> fastptr = Head.Next;

            while (fastptr.Next!=null)
            {
                slowPtr = slowPtr.Next;
                fastptr = fastptr.Next.Next;
                if (fastptr==null)
                {
                    break;
                }
            }
            return slowPtr;
        }
        #endregion
    }
}
