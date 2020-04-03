using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinkedListProblems;
using ArrayProblems;
using BinarySearchProblems;
using DesignDataStructures;
using StringProblems;

namespace MSTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            LinkedList L1 = new LinkedList();
            L1.AddLast(2);
            L1.AddLast(3);

            LinkedList L2 = new LinkedList();
            L2.AddLast(1);
            //L2.AddLast(9);

            LListProblems.AddTwoNumbers(L1.Head, L2.Head);
        }
        [TestMethod]
        public void TestGetMiddleNode()
        {
            LinkedList L1 = new LinkedList();
            L1.AddLast(1);
            L1.AddLast(2);
            L1.AddLast(3);
            L1.AddLast(4);
            L1.AddLast(5);

            ListNode middleNode = LListProblems.GetMiddleNode(L1.Head);
        }

        [TestMethod]
        public void TestReverseLinkedList()
        {
            LinkedList L1 = new LinkedList();
            L1.AddLast(1);
            L1.AddLast(2);
            L1.AddLast(3);
            L1.AddLast(4);
            L1.AddLast(5);

            LListProblems.ReverseLinkedList(L1.Head);
        }

        [TestMethod]
        public void TestRemoveMatchingElements()
        {
            LinkedList L1 = new LinkedList();
            L1.AddLast(2);

            LListProblems.removeAllMatchingElements(L1.Head, 2);
        }

        [TestMethod]
        public void TestSwapPairs()
        {
            LinkedList L1 = new LinkedList();
            L1.AddLast(1);
            L1.AddLast(2);
            L1.AddLast(3);
            L1.AddLast(4);

            var head = LListProblems.SwapPairs(L1.Head);
        }

        [TestMethod]
        public void TestRemoveNthNode()
        {
            LinkedList L1 = new LinkedList();
            L1.AddLast(1);
            L1.AddLast(2);
            L1.AddLast(3);
            //L1.AddLast(4);
            //L1.AddLast(5);
            var head = LListProblems.RemoveNthFromEnd(L1.Head, 3);
        }

        [TestMethod]
        public void TestRotateBykthNumber()
        {
            LinkedList L1 = new LinkedList();
            L1.AddLast(1);
            //L1.AddLast(2);
            //L1.AddLast(3);
            //L1.AddLast(4);
            //L1.AddLast(5);
            var head = LListProblems.RotateLinkedList(L1.Head, 99);
        }

        [TestMethod]
        public void TestCheckPalindrome()
        {
            LinkedList L1 = new LinkedList();
            L1.AddLast(1);
            var head = LListProblems.CheckPalindrom(L1.Head);
        }

        [TestMethod]
        public void TestMergeTwoSortedList()
        {
            LinkedList L1 = new LinkedList();
            L1.AddLast(1);
            L1.AddLast(2);
            L1.AddLast(4);

            LinkedList L2 = new LinkedList();
            L2.AddLast(1);
            L2.AddLast(3);
            L2.AddLast(4);

            var head = LListProblems.MergeTwoSortedList(L1.Head, L2.Head);
        }

        [TestMethod]
        public void TestRemoveDuplicatesFromSorted()
        {
            LinkedList L1 = new LinkedList();
            L1.AddLast(1);
            L1.AddLast(2);
            L1.AddLast(2);
            L1.AddLast(3);
            L1.AddLast(3);

            var head = LListProblems.RemoveDuplicatesFromSortedLinkedList(L1.Head);
        }

        [TestMethod]
        public void TestNextGreaterNode()
        {
            LinkedList L1 = new LinkedList();
            L1.AddLast(1);
            L1.AddLast(4);
            L1.AddLast(3);
            L1.AddLast(5);
            L1.AddLast(2);

            var head = LListProblems.NextGreaterNode(L1.Head);
        }

        [TestMethod]
        public void RemoveDuolicates()
        {
            LinkedList L1 = new LinkedList();
            L1.AddLast(1);
            L1.AddLast(1);
            L1.AddLast(1);
            L1.AddLast(2);
            L1.AddLast(2);
            L1.AddLast(3);
            //L1.AddLast(3);
            //L1.AddLast(4);

            var head = LListProblems.RemoveDuplicateNode(L1.Head);
        }

        [TestMethod]
        public void TestGetInterSectionNode()
        {
            var node6 = new ListNode(6);
            var node5 = new ListNode(5); node5.next = node6;
            var node4 = new ListNode(4); node4.next = node5;

            var nodeA3 = new ListNode(3); nodeA3.next = node4;
            var nodeA2 = new ListNode(2); nodeA2.next = nodeA3;
            var nodeA1 = new ListNode(1); nodeA1.next = nodeA2;

            var nodeB2 = new ListNode(22); nodeB2.next = node4;
            var nodeB1 = new ListNode(4); nodeB1.next = node5;

            var head = LListProblems.FindNodeIntersection(nodeA1, node4);
        }

        [TestMethod]
        public void FindCountofConnectedComponents()
        {
            LinkedList L1 = new LinkedList();
            L1.AddLast(1);
            L1.AddLast(4);
            L1.AddLast(3);
            L1.AddLast(5);
            L1.AddLast(2);

            int[] array = { 1, 4, 3, 2 };

            var counts = LListProblems.ConnectedComponentsCounts(L1.Head, array);
        }

        [TestMethod]
        public void RemoveDuplicates()
        {
            int[] arr = new int[] { 1, 1, 2, 3, 4, 4, 5 };
            int count= ArrayProblem.RemoveDuplicates(arr);
        }
        [TestMethod]
        public void Rotate()
        {
            int[] arr = new int[] { 1,2,3};
            ArrayProblem.Rotate(arr,4);
        }

        [TestMethod]
        public void Reverse()
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            ArrayProblem.Reverse(arr,0,arr.Length-1);
        }

        [TestMethod]
        public void DuplicateZeros()
        {
            int[] arr = new int[] { 0,0,0};
            ArrayProblem.DuplicateZeros(arr);
        }

        [TestMethod]
        public void MoveZeros()
        {
            int[] arr = new int[] { 1,0,2,3,0,4};
            ArrayProblem.MovingZeroEnd(arr);
        }

        [TestMethod]
        public void MaxConsecutive1()
        {
            int[] arr = new int[] { 1, 0, 1,1,0 };
            ArrayProblem.MaxConsecutiveOne(arr);
        }
        [TestMethod]
        public void MissingNumber()
        {
            int[] arr = new int[] { 1, 0 };
            ArrayProblem.MissingNumber(arr);
        }

        [TestMethod]
        public void Decompress()
        {
            int[] arr = new int[] { 1,2,3,4 };
            ArrayProblem.Decompress(arr);
        }

        [TestMethod]
        public void SumZero()
        {
            ArrayProblem.SumZero(5);
        }

        [TestMethod]
        public void TransposeMatrix()
        {
            ArrayProblem.Transpose(new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 } });
        }

        [TestMethod]
        public void SumaAndProblem()
        {
            ArrayProblem.ProductAndSum(234);
        }

        [TestMethod]
        public void BinarySearch()
        {
            int[] nums = { 100, 200, 300, 400, 500, 600, 700, 800, 900 };
            int pos= BinarySearchProblem.FindPosition(nums, 0, 8, 400);
        }

        [TestMethod]
        public void BinarySearchWithoutRecursion()
        {
            int[] nums = { -1,0,3,5,9,12};
            int pos = BinarySearchProblem.FindPosition(nums, 2);
        }

        [TestMethod]
        public void Intersection()
        {
            int[] nums1 = { 4,9,5 };
            int[] nums2 = { 9,4,9,8,4};
            var result = BinarySearchProblem.Intersection(nums1, nums2);
        }

        [TestMethod]
        public void ToLowerCase()
        {
            var result = ArrayProblem.ToLowerCase("gaurava");
        }

        [TestMethod]
        public void Fibonacci()
        {
            var result = ArrayProblem.Fib(2);
        }

        [TestMethod]
        public void DeckRevealedIncreasing()
        {
            int[] arr = { 17, 13, 11, 2, 3, 5, 7 };
            var result = ArrayProblem.DeckRevealedIncreasing(arr);
        }

        [TestMethod]
        public void MinSetSize()
        {
            int[] arr = { 7, 7, 7, 7, 7, 7 };
            var result = ArrayProblem.MinSetSize(arr);
        }
        [TestMethod]
        public void TestQueue()
        {
            MyQueue queue = new MyQueue();

            queue.Push(1);
            queue.Push(2);
            queue.Peek();  // returns 1
            queue.Pop();   // returns 1
            queue.Empty(); // returns false
        }

        [TestMethod]
        public void CheckForPalindrome()
        {
            bool isPalindrome = StringProblem.IsPalindrome("ababababaYZababababa");
        }
    }
}
