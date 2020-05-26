using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedListProblems
{
    public static class LListProblems
    {
        #region Add number
        public static ListNode AddTwoNumbers(ListNode L1, ListNode L2)
        {
            ListNode result = null;
            ListNode L1Temp = L1;
            ListNode L2Temp = L2;
            ListNode Head = null;

            int carryForward = 0;

            while (L1Temp != null || L2Temp != null)
            {
                int l1val = L1Temp == null ? 0: Convert.ToInt32(L1Temp.val);
                int l2val = L2Temp == null ? 0 : Convert.ToInt32(L2Temp.val);
                var val = l1val + l2val + carryForward;
                carryForward = val / 10;

                var node = new ListNode(val%10);
                if (result == null)
                {
                    result = node;
                    Head = node;
                }
                else
                {
                    result.next = node;
                    result = node;
                }
                L1Temp = L1Temp?.next;
                L2Temp = L2Temp?.next;
            }

            if (carryForward>0)
            {
                result.next = new ListNode(carryForward);
            }
            return Head;
        }
        #endregion

        #region Get Middle Node or Hare Tortoise Problem
        public static ListNode GetMiddleNode(ListNode head)
        {
            if (head == null)
            {
                return null;
            }
            ListNode slowPtr = head;
            ListNode fastptr = head.next;

            while (fastptr != null)
            {
                slowPtr = slowPtr.next;
                fastptr = fastptr.next;
                if (fastptr != null)
                {
                    fastptr = fastptr.next;
                }
            }
            return slowPtr;
        }
        #endregion

        #region Reverse the Linked List
        //1->2->3->4->5
        //2->1  3->4->5
        //3->2->1  4->5
        public static ListNode ReverseLinkedList(ListNode head)
        {
            if (head==null)
            {
                return null;
            }
            ListNode current = head;
            ListNode previous = null;

            while (current!=null)
            {
                var temp = current.next;
                current.next = previous;
                previous = current;
                current = temp;
            }

            return previous;
        }
        #endregion

        public static ListNode ReverseKGroup(ListNode head, int k)
        {
            ListNode current = head;
            ListNode next = null;
            ListNode prev = null;

            int length = 0;

            while (current!=null)
            {
                length++;
                current = current.next;
            }
            current = head;

            int count = 0;
            if (k>length)
            {
                return head;
            }
            /* Reverse first k nodes of linked list */
            while (count < k && current != null)
            {
                next = current.next;
                current.next = prev;
                prev = current;
                current = next;
                count++;
            }

            /* next is now a pointer to (k+1)th node  
                Recursively call for the list starting from current.  
                And make rest of the list as next of first node */
            if (next != null)
                head.next = ReverseKGroup(next, k);

            // prev is now head of input list  
            return prev;
        }

        #region delete a nodde from Linked list.

        //1->2->3->4->5->6
        public static void DeleteNode(ListNode node)
        {
            node.val = node.next.val;
            node.next = node.next.next;
        }

        #endregion

        #region Remove all occrence of number from a linked list

        //2->10-2->2
        public static ListNode removeAllMatchingElements(ListNode head, int val)
        {
            ListNode current = head;
            ListNode Head = head;
            ListNode previous = null;
            while (current!=null)
            {
                if (current.val.Equals(val))
                {
                    var next = current.next;
                    if (current.Equals(Head))
                    {
                        if (next != null)
                        {
                            Head.val = next.val;
                            Head.next = next.next;
                        }
                        else
                        {
                            Head = null;
                        }
                        current = Head;
                        previous = null;
                    }
                    else
                    {
                        if (next != null)
                        {
                            current.val = next.val;
                            current.next = next.next;
                        }
                        else
                        {
                            previous.next = null;
                            current = null;
                        }
                    }

                }
                else
                {
                    previous = current;
                    current = current.next;
                }
                
            }
            return Head;
        }

        #endregion

        #region Swap  Pairs
        public static ListNode SwapPairs(ListNode head)
        {
            ListNode current = head;
            ListNode previous = null;
            ListNode next;
            var Head = head;

            while (current != null)
            {
                next = current.next;

                if (next != null)
                {
                    if (previous == null)
                    {
                        Head = next;
                    }
                    else
                    {
                        previous.next = next;
                    }
                    var temp = next.next;
                    current.next = temp;
                    next.next = current;
                    previous = current;
                }

                current = current.next;
            }

            return Head;
        }
        #endregion

        #region Remove the nth node node from the end

        public  static ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode slowptr = head;
            ListNode fastptr = head;
            ListNode previous = null;

            int i = 0;

            while ( fastptr!=null)
            {
                if (i < n)
                {
                    fastptr = fastptr.next;
                    i++;
                }
                else
                {
                    previous = slowptr;
                    slowptr = slowptr.next;
                    fastptr = fastptr.next;
                }           
            }

            var next = slowptr.next;

            if (previous == null)
            {
                head = next;
            }
            else
            {
                previous.next = slowptr.next;
            }

            return head;

        }

        #endregion

        #region Rotate by K

        public static ListNode RotateLinkedList(ListNode head, int k)
        {
            ListNode slowPtr = head;
            ListNode fastPtr = head;
            ListNode last = null;
            ListNode previous = null;

            if (head==null)
            {
                return null;
            }
            if (k==0)
            {
                return head;
            }
            int i = 0;
            while (true)
            {

                if (i < k)
                {
                    last = fastPtr;
                    fastPtr = fastPtr.next;
                    i++;
                }
                if (i==k)
                {
                    break;
                }
                if (fastPtr==null)
                {
                    break;
                }

            }

            if (i<k)
            {
                k = k % i;
                i = 0;
                fastPtr = head;
            }

            if (k==0)
            {
                return head;
            }
            while (fastPtr!=null)
            {
                if (i < k)
                {
                    fastPtr = fastPtr.next;
                    i++;
                }
                else
                {
                    last = fastPtr;
                    previous = slowPtr;
                    fastPtr = fastPtr.next;
                    slowPtr = slowPtr.next;
                }
            }

            if (slowPtr!=head)
            {
                if (slowPtr.Equals(last))
                {
                    previous.next = null;
                    var next = head.next;
                    slowPtr.next = head;
                    head = slowPtr;
                }
                else
                {
                    previous.next = null;
                    last.next = head;
                    head = slowPtr;
                }
            }
            return head;
        }

        #endregion

        #region Check if given linked list is a Palindrom

        public static bool CheckPalindrom(ListNode head)
        {
            bool isPalindrome = true;
            ListNode current = head;
            ListNode Temp = head;
            var stack = new Stack<int>();

            if (head!=null && head.next!=null)
            {
                while (current!=null)
                {
                    stack.Push(current.val);
                    current = current.next;
                }

                while (Temp!=null)
                {
                    var value = stack.Pop();
                    if (value!=Temp.val)
                    {
                        isPalindrome = false;
                        break;
                    }
                    Temp = Temp.next;
                }
            }

            return isPalindrome;
        }

        #endregion

        #region Merge Two Sorted List
        public static ListNode MergeTwoSortedList(ListNode head1, ListNode head2)
        {
            ListNode head = null;
            ListNode current1 = head1;
            ListNode current2 = head2;
            ListNode current = null;

            int count = 0;

            if (head1 != null && head2 != null)
            {
                while (current1 != null && current2 != null)
                {

                    if (count == 0)
                    {

                        if (current1.val.Equals(current2.val))
                        {
                            head = new ListNode(current1.val);
                            head.next = new ListNode(current2.val);
                            current = head.next;
                            current1 = current1.next;
                            current2 = current2.next;
                        }
                        else if (current1.val < current2.val)
                        {
                            head = new ListNode(current1.val);
                            current = head;
                            current1 = current1.next;
                        }
                        else if (current1.val > current2.val)
                        {
                            head = new ListNode(current2.val);
                            current = head;
                            current2 = current2.next;
                        }
                    }
                    else
                    {
                        if (current1.val.Equals(current2.val))
                        {
                            current.next = new ListNode(current1.val);
                            current.next.next = new ListNode(current2.val);
                            current = current.next.next;
                            current1 = current1.next;
                            current2 = current2.next;
                        }
                        else if (current1.val < current2.val)
                        {
                            current.next = new ListNode(current1.val);
                            current = current.next;
                            current1 = current1.next;
                        }
                        else if (current1.val > current2.val)
                        {
                            current.next = new ListNode(current2.val);
                            current = current.next;
                            current2 = current2.next;
                        }
                    }

                    count++;
                }

                if (current1 == null && current2 != null)
                {
                    current.next = current2;
                }
                else if (current1 != null && current2 == null)
                {
                    current.next = current1;
                }
            }
            else if (head1 == null && head2 != null)
            {
                head = head2;
            }
            else if (head1!=null && head2==null)
            {
                head = head1;
            }

            return head;
        }
        #endregion

        #region Merge two Sorted List using recursion

        public static ListNode MergeList(ListNode l1, ListNode l2)
        {
            if (l1 == null)
            {
                return l2;
            }
            else if (l2 == null)
            {
                return l1;
            }
            else if (l1.val<l2.val)
            {
                l1.next = MergeList(l1.next, l2);
                return l1;
            }
            else
            {
                l2.next = MergeList(l1, l2.next);
                return l2;
            }
        }

        #endregion

        #region Merge K Sorted List

        public static ListNode MergeKSortedList(ListNode[] lists)
        {
            ListNode Head = null;
            int length = lists.Length;
            ListNode result = null;
            for (int i=0; i<length-1; i++)
            {
                if(result==null)
                {
                    result = lists[0];
                }
                result = MergeList(result, lists[i+1]);
            }

            return Head;
        }

        #endregion

        #region remove Duplicates from the Sorted Linked list.


        //1->2->2->3->3
        public static ListNode RemoveDuplicatesFromSortedLinkedList(ListNode head)
        {
            var current = head;

            if (head == null)
            {
                return null;
            }

            while (current != null)
            {
                var next = current.next;

                if (next != null)
                {
                    var next1 = next.next;
                    if (current.val.Equals(next.val))
                    {
                        current.next = next1;
                    }
                    else
                    {
                        current = current.next;
                    }
                }
                else
                {
                    current = current.next;
                }
            }

            return head;
        }

        public static int[] NextGreaterNode(ListNode head)
        {
            if (head == null)
            {
                return null;
            }

            var current = head;
            Dictionary<int, int> dict = new Dictionary<int, int>();

            int length = 0;
            while (current != null)
            {
                dict.Add(length, current.val);
                length++;
                current = current.next;
            }

            int[] result = new int[length];
            int len = 0;
            while (head != null)
            {
                bool found = false;
                foreach (var item in dict)
                {
                    if (item.Value > head.val)
                    {
                        if (item.Key > len)
                        {
                            result[len] = item.Value;
                            found = true;
                            break;
                        }
                    }
                }

                if (!found)
                {
                    result[len] = 0;
                }

                head = head.next;
                len++;
            }

            return result;
        }
        #endregion

        #region Remove Duplicate nodes

        //1->1->2->2-4>5
        public static ListNode RemoveDuplicateNode(ListNode head)
        {
            var current = head;
            ListNode previous = null;

            if (head==null)
            {
                return head;
            }
            while (current != null)
            { 
                bool isFound = false;
                while (current.next!=null && current.val == current.next.val)
                {
                    current = current.next;
                    isFound = true;
                }

                if (isFound)
                {

                    if (previous == null)
                    {
                        head = current.next;
                    }
                    else
                    {
                        previous.next = current.next;
                    }
                }
                else
                {
                    if (previous == null)
                    {
                        previous = head;
                    }
                    else
                    {
                        previous = current;
                    }
                }
                current = current.next;
            }

            return head;
        }

        #endregion

        #region Intersection of Linked list
        public static ListNode FindNodeIntersection(ListNode headA, ListNode headB)
        {
            ListNode node = null;

            int lenA = 0;
            int lenB = 0;
            var currentA = headA;
            var currentB = headB;
            while (currentA!=null)
            {
                currentA = currentA.next;
                lenA++;
            }

            while (currentB != null)
            {
                currentB = currentB.next;
                lenB++;
            }

            if (lenA>lenB)
            {
                if (lenB > 1)
                {

                    var diff = lenA - lenB;
                    while (diff != 0)
                    {
                        headA = headA.next;
                        diff--;
                    }
                }
            }
            if (lenB>lenA)
            {
                if (lenA>1)
                {
                    var diff = lenB = lenA;
                    while (diff != 0)
                    {
                        headB = headB.next;
                        diff--;
                    }
                }
            }

            while (headA!=null && headB!=null)
            {
                if (headA.Equals(headB))
                {
                    node = headA;
                    break;
                }
                if (lenA>1)
                {
                    headA = headA.next;
                }
                if (lenB>1)
                {
                    headB = headB.next;
                }

            }

            return node;
        }
        #endregion

        #region  Connected components in Linked List

        public static int ConnectedComponentsCounts(ListNode head, int[] G)
        {
            HashSet<int> hash = new HashSet<int>();
            foreach (int x in G)
                hash.Add(x);

            while (head != null)
            {
                if (head.next != null && hash.Contains(head.next.val))
                    hash.Remove(head.val);
                head = head.next;
            }

            return hash.Count;
        }

        #endregion

        #region  ReOrder List

        public static ListNode ReorderList(ListNode head)
        {

            if (head == null)
            {
                return head;
            }
            var middle = GetMiddleNode(head);

            var newnode = ReverseLinkedList(middle);

            var nd= MergeListSpecial(head, newnode);

            return head;
        }

        public static ListNode MergeListSpecial(ListNode l1, ListNode l2)
        {
            if (l1 == null)
            {
                return l2;
            }
            else if (l2 == null)
            {
                return l1;
            }
            else 
            {
                l1.next = MergeListSpecial(l2, l1.next);
                return l1;
            }
        }
        #endregion

        #region IsPalindrome

        public static bool IsPalindrome(ListNode head)
        {

            if (head == null || head.next == null)
            {
                return true;
            }

            Stack<int> stack = new Stack<int>();
            var current = head;
            while (current != null)
            {
                stack.Push(current.val);
                current = current.next;
            }

            current = head;

            while (current != null)
            {
                if (stack.Pop() != current.val)
                {
                    return false;
                }

                current = current.next;
            }
            return true;
        }
        #endregion
    }
}
