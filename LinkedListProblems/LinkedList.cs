using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListProblems
{
    public class LinkedList : ICollection
    {
        public ListNode Head { get; private set; }

        public ListNode Tail { get; private set; }

        #region Add
        public void AddFirst(int item)
        {
            AddFirst(new ListNode(item));
        }

        public void AddFirst(ListNode node)
        {
            ListNode temp = Head;
            Head = node;
            Head.next = temp;
            Count++;

            if (Count == 1)
            {
                Tail = Head;
            }

        }


        #region swap
        public void Swap()
        {
            if (Count > 1)
            {
                ListNode current = Head;
                ListNode next = null;
                ListNode next1 = null;
                ListNode previous = null;

                int count = 1;
                while (count < Count)
                {
                    if (current.next != null)
                    {
                        next = current.next;
                        next1 = next.next;
                        if (count % 2 != 0)
                        {
                            if (count == 1)
                            {
                                Head = next;
                            }
                            current.next = next1;
                            next.next = current;
                            if (previous != null)
                            {
                                previous.next = next;
                            }

                            if (next1 == null)
                            {
                                Tail = current;
                            }
                        }
                        else
                        {
                            previous = current;
                            current = current.next;
                        }
                        count++;
                    }
                }

            }
        }

        public void Swap_1()
        {
            ListNode previous = null;
            ListNode next = null;
            ListNode current = Head;
            ListNode Temp = null;

            if (Count > 1)
            {
                int count = 1;
                while (count < Count)
                {

                    previous = current.next;
                    Temp = current.next.next;
                    next = current.next.next.next;
                    current.next = next;
                    previous.next = current;
                    Temp.next = next.next;
                    next.next = Temp;
                    current = Temp.next;
                    if (count == 1)
                    {
                        Head = previous;
                    }
                    if (current.next == null)
                    {
                        Tail = current;
                    }
                    count = count + 4;
                }
            }

        }
        #endregion

        #region Merge Sort

        private ListNode getMiddle(ListNode head)
        {
            // Base case 
            if (head == null)
                return head;
            ListNode fastptr = Head.next;
            ListNode slowptr = head;

            // Move fastptr by two and slow ptr by one 
            // Finally slowptr will point to middle node 
            while (fastptr != null)
            {
                fastptr = fastptr.next;
                if (fastptr != null)
                {
                    slowptr = slowptr.next;
                    fastptr = fastptr.next;
                }
            }
            return slowptr;
        }

        public void SortLinkedList()
        {
            var h = MergeSort(Head);
            Head = h;
        }
        public ListNode MergeSort(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            // get the middle of the list 
            ListNode middle = getMiddle(head);
            ListNode nextofmiddle = middle.next;

            // set the next of middle node to null 
            middle.next = null;

            // Apply mergeSort on left list 
            ListNode left = MergeSort(head);

            // Apply mergeSort on right list 
            ListNode right = MergeSort(nextofmiddle);

            // Merge the left and right lists 
            ListNode sortedlist = sortedMerge(left, right);
            return sortedlist;


        }

        ListNode sortedMerge(ListNode a, ListNode b)
        {
            ListNode result = null;
            /* Base cases */
            if (a == null)
                return b;
            if (b == null)
                return a;

            /* Pick either a or b, and recur */
            if (Convert.ToInt32(a.val) <= Convert.ToInt32(b.val))
            {
                result = a;
                result.next = sortedMerge(a.next, b);
            }
            else
            {
                result = b;
                result.next = sortedMerge(a, b.next);
            }
            return result;
        }
        #endregion

        public void AddLast(ListNode node)
        {
            if (Count == 0)
            {
                Head = node;
            }
            else
            {
                Tail.next = node;
            }
            Tail = node;
            Count++;
        }

        public void AddLast(int val)
        {
            AddLast(new ListNode(val));
        }
        #endregion

        #region remove
        public void RemoveLast()
        {
            if (Count != 0)
            {
                if (Count == 1)
                {
                    Head = null;
                    Tail = null;
                }
                else
                {
                    ListNode currrent = Head;
                    while (currrent.next != Tail)
                    {
                        currrent.next = null;
                        Tail = currrent;
                    }
                }

                Count--;
            }
        }

        public void RemoveFirst()
        {
            if (Count != 0)
            {
                Head = Head.next;
                Count--;

                if (Count == 0)
                {
                    Tail = null;
                }
            }
        }
        #endregion

        #region Reverse Linked List

        public void Reverse()
        {
            if (Count != 0)
            {
                ListNode previous = null;
                ListNode current = Head;
                Tail = Head;
                ListNode next = null;
                if (Count == 1)
                {
                    return;
                }
                else
                {
                    while (current != null)
                    {
                        next = current.next;
                        current.next = previous;
                        previous = current;
                        current = next;
                    }

                    Head = previous;
                }
            }
        }

        #endregion

        #region ICollection
        public int Count
        {
            get;
            private set;
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public bool IsSynchronized => throw new NotImplementedException();

        public object SyncRoot => throw new NotImplementedException();

        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public bool Contains(int item)
        {
            ListNode Current = Head;
            while (Current != null)
            {
                if (Current.val.Equals(item))
                {
                    return true;
                }

                Current = Current.next;
            }

            return false;
        }

        public void CopyTo(int[] array, int arrayIndex)
        {
            ListNode current = Head;
            while (current != null)
            {
                array[arrayIndex++] = current.val;
                current = current.next;
            }
        }

        public IEnumerator GetEnumerator()
        {
            ListNode current = Head;

            while (current != null)
            {
                yield return current.val;
                current = current.next;
            }
        }

        public bool Remove(int item)
        {
            ListNode previous = null;
            ListNode current = Head;
            while (current != null)
            {
                if (current.val.Equals(item))
                {
                    if (previous != null)
                    {
                        previous.next = current.next;

                        //if it was end
                        if (current.next == null)
                        {
                            Tail = previous;
                        }
                        Count--;
                    }
                    else
                    {
                        RemoveFirst();
                    }
                    return true;
                }
                previous = current;
                current = current.next;
            }
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            ListNode current = Head;

            while (current != null)
            {
                yield return current.val;
                current = current.next;
            }

        }


        public void Add(int item)
        {
            AddFirst(new ListNode(item));
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
