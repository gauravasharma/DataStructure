using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinkedListProblems;
using ArrayProblems;
using BinarySearchProblems;
using DesignDataStructures;
using StringProblems;
using TreeProblems;

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
        [TestMethod]
        public void SelctionSorting()
        {
            var nums = new int[] { 100, 200, 29, 8, 20, 1, 3 };
            nums = ArrayProblem.SelectionSort(nums);
        }

        [TestMethod]
        public void BubbleSorting()
        {
            var nums = new int[] { 100, 200, 29, 8, 20, 1, 3 };
            nums = ArrayProblem.BubbleSort(nums);
        }

        [TestMethod]
        public void BubbleSortingUsingRecursion()
        {
            var nums = new int[] { 100, 200, 29, 8, 20, 1, 3 };
            nums = ArrayProblem.BubbleSortUsingRecursion(nums, nums.Length);
        }
        [TestMethod]
        public void SmallerNumbersThanCurrent()
        {
            var nums = new int[] { 8, 1, 2, 2, 3 };
            nums = ArrayProblem.SmallerNumbersThanCurrent(nums);
        }
        [TestMethod]
        public void CreateTargetArray()
        {
            var nums = new int[] { 0, 1, 2, 3, 4 };
            var index = new int[] { 0, 1, 2, 2, 1 };
            var Target = ArrayProblem.CreateTargetArray(nums, index);
        }
        [TestMethod]
        public void TreeTraversalDFS()
        {
            BinaryTree tree = new BinaryTree(1);
            tree.Root.Left = new Node(2);
            tree.Root.Right = new Node(3);
            tree.Root.Left.Left = new Node(4);
            tree.Root.Left.Right = new Node(5);

            var items1=TreeProblem.TraverseInOrder(tree.Root);
            var itmes2 = TreeProblem.TraversePreOrder(tree.Root);
            var itmes3 = TreeProblem.TraversePostOrder(tree.Root);

        }

        [TestMethod]
        public void TreeTraversalBFSUsingQueues()
        {
            BinaryTree tree = new BinaryTree(1);
            tree.Root.Left = new Node(2);
            tree.Root.Right = new Node(3);
            tree.Root.Left.Left = new Node(4);
            tree.Root.Left.Right = new Node(5);

            var items = TreeProblem.BFSTraverseQueue(tree.Root);

        }

        [TestMethod]
        public void FindTreeHeight()
        {
            BinaryTree tree = new BinaryTree(1);
            tree.Root.Left = new Node(2);
            tree.Root.Right = new Node(3);
            tree.Root.Left.Left = new Node(4);
            tree.Root.Left.Right = new Node(5);

            int height = TreeProblem.TreeHeight(tree.Root);

        }

        [TestMethod]
        public void BFSTraversalWithoutQueue()
        {
            BinaryTree tree = new BinaryTree(1);
            tree.Root.Left = new Node(2);
            tree.Root.Right = new Node(3);
            tree.Root.Left.Left = new Node(4);
            tree.Root.Left.Right = new Node(5);
            var item = TreeProblem.BFSTraverse(tree.Root);

        }

        [TestMethod]
        public void LevelOrder()
        {
            BinaryTree tree = new BinaryTree(3);
            tree.Root.Left = new Node(9);
            tree.Root.Right = new Node(20);
            tree.Root.Right.Left = new Node(15);
            tree.Root.Right.Right = new Node(7);
            var item = TreeProblem.LevelOrder(tree.Root);

        }

        [TestMethod]
        public void FloodFill()
        {
            //var arr = new int[3][];
            //arr[0] = new int[] { 1, 1, 1 };
            //arr[1] = new int[] { 1, 1, 0 };
            //arr[2] = new int[] { 1, 0, 1 };

            var arr = new int[2][];
            arr[0] = new int[] { 0, 0, 0 };
            arr[1] = new int[] { 0, 1, 1 };

            var item = TreeProblem.FloodFill(arr, 1,1,1);

        }

        [TestMethod]
        public void ISBST()
        {
            BinaryTree tree = new BinaryTree(2);
            tree.Root.Left = new Node(1);
            tree.Root.Right = new Node(3);

            var items1 = TreeProblem.IsBST(tree.Root);

        }

        [TestMethod]
        public void NumberOfIsland()
        {
            var arr = new int[3][];
            arr[0] = new int[] { 1, 1, 1 };
            arr[1] = new int[] { 1, 1, 0 };
            arr[2] = new int[] { 1, 0, 1 };
            var item = TreeProblem.NumberOfIslands(arr);

        }
        [TestMethod]
        public void FindGCD()
        {
            var item = ArrayProblem.FindGCD(24, 36);
        }

        [TestMethod]
        public void FindGCDOfArray()
        {
            var item = ArrayProblem.gcdOfArray(new int[] { 24,36},2);
        }
        [TestMethod]
        public void FindLongestPalindrome()
        {
            var item = StringProblem.LongestPalindrome("forgeeksskeegfor");
        }

        [TestMethod]
        public void FindMedian()
        {
            int[] arr1 = { 1, 2 };
            int[] arr2 = { 3,4 };
            var item = ArrayProblem.MedianOfSortedArray(arr1,arr2);
        }
        [TestMethod]
        public void FindMissingNumber()
        {
            int[] arr1 = { 1,9,6,3,5,2 };
            var item = ArrayProblem.MissingNumber1(arr1);
        }

        [TestMethod]
        public void FindoptimalCost()
        {
            int[] arr1 = {2,4,3};
            var item = ArrayProblem.FindOptimalCost(arr1);
        }

        [TestMethod]
        public void FindValidParenthesis()
        {
            string s = "]";
            var item = ArrayProblem.IsValidParenthesis(s);
        }

        [TestMethod]
        public void VerifyLRUCache()
        {
            LRUCache cache = new LRUCache(2);
            cache.Put(2, 1);
            cache.Put(1, 1);
            cache.Put(2,3);
            cache.Put(4, 1);

            int i =cache.Get(1);
            int j = cache.Get(2);
        }


        [TestMethod]
        public void GroupAnagram()
        {
            var item = StringProblem.GroupAnagrams(new string[] { "eat", "tea", "tan", "ate", "nat", "bat" });

        }
        [TestMethod]
        public void MostCommonWord()
        {
            var paragraph = "a, a, a, a, b,b,b,c, c";
            var item = StringProblem.MostCommonWord(paragraph,new string[] { "a"});

        }
        [TestMethod]
        public void MinStack()
        {
            MinStack minStack = new MinStack();
            minStack.Push(-2);
            minStack.Push(0);
            minStack.Push(-3);
            int i=minStack.GetMin(); // return -3
            minStack.Pop();
            minStack.Top();    // return 0
            int j=minStack.GetMin(); // return -2

        }

    }
}
