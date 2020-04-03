using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class LinkedList<T> : ICollection<T>
    {
        public LinkedListNode<T> Head { get; private set; }

        public LinkedListNode<T> Tail { get; private set; }

        #region Add
        public void AddFirst(T item)
        {
            AddFirst(new LinkedListNode<T>(item));
        }

        public void AddFirst(LinkedListNode<T> node)
        {
            LinkedListNode<T> temp = Head;
            Head = node;
            Head.Next = temp;
            Count++;

            if (Count == 1)
            {
                Tail = Head;
            }

        }


        #region swap
        public void Swap()
        {
            if (Count>1)
            {
                LinkedListNode<T> current = Head;
                LinkedListNode<T> next = null;
                LinkedListNode<T> next1 = null;
                LinkedListNode<T> previous = null;

                int count = 1;
                while (count < Count)
                {
                    if (current.Next != null)
                    {
                        next = current.Next;
                        next1 = next.Next;
                        if (count % 2 != 0)
                        {
                            if (count == 1)
                            {
                                Head = next;
                            }
                            current.Next = next1;
                            next.Next = current;
                            if (previous!=null)
                            {
                                previous.Next = next;
                            }

                            if (next1 == null)
                            {
                                Tail = current;
                            }
                        }
                        else
                        {
                            previous = current;
                            current = current.Next;
                        }
                        count++;
                    }
                }

            }
        }

        public void Swap_1()
        {
            LinkedListNode<T> previous = null;
            LinkedListNode<T> next = null;
            LinkedListNode<T> current = Head;
            LinkedListNode<T> Temp = null;

            if (Count>1)
            {
                int count = 1;
                while (count < Count)
                {

                    previous = current.Next;
                    Temp = current.Next.Next;
                    next = current.Next.Next.Next;
                    current.Next = next;
                    previous.Next = current;
                    Temp.Next = next.Next;
                    next.Next = Temp;
                    current = Temp.Next;
                    if (count == 1)
                    {
                        Head = previous;
                    }
                    if (current.Next==null)
                    {
                        Tail = current;
                    }
                    count = count + 4;
                }
            }

        }
        #endregion

        #region Merge Sort

        private LinkedListNode<T> getMiddle(LinkedListNode<T> head)
        {
            // Base case 
            if (head == null)
                return head;
            LinkedListNode<T> fastptr = Head.Next;
            LinkedListNode<T> slowptr = head;

            // Move fastptr by two and slow ptr by one 
            // Finally slowptr will point to middle node 
            while (fastptr != null)
            {
                fastptr = fastptr.Next;
                if (fastptr != null)
                {
                    slowptr = slowptr.Next;
                    fastptr = fastptr.Next;
                }
            }
            return slowptr;
        }

        public void SortLinkedList()
        {
            var h = MergeSort(Head);
            Head = h;
        }
        public LinkedListNode<T> MergeSort(LinkedListNode<T> head)
        {
            if (head == null || head.Next == null)
            {
                return head;
            }
            
                // get the middle of the list 
                LinkedListNode<T> middle = getMiddle(head);
                LinkedListNode<T> nextofmiddle = middle.Next;

                // set the next of middle node to null 
                middle.Next = null;

                // Apply mergeSort on left list 
                LinkedListNode<T> left = MergeSort(head);

                // Apply mergeSort on right list 
                LinkedListNode<T> right = MergeSort(nextofmiddle);

                // Merge the left and right lists 
                LinkedListNode<T> sortedlist = sortedMerge(left, right);
                return sortedlist;
            

        }

        LinkedListNode<T> sortedMerge(LinkedListNode<T> a, LinkedListNode<T> b)
        {
            LinkedListNode<T> result = null;
            /* Base cases */
            if (a == null)
                return b;
            if (b == null)
                return a;

            /* Pick either a or b, and recur */
            if (Convert.ToInt32(a.Value) <= Convert.ToInt32(b.Value))
            {
                result = a;
                result.Next = sortedMerge(a.Next, b);
            }
            else
            {
                result = b;
                result.Next = sortedMerge(a, b.Next);
            }
            return result;
        }
        #endregion

        public void AddLast(LinkedListNode<T> node)
        {
            if (Count == 0)
            {
                Head = node;
            }
            else
            {
                Tail.Next = node;
            }
            Tail = node;
            Count++;
        }

        public void AddLast(T value)
        {
            AddLast(new LinkedListNode<T>(value));
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
                    LinkedListNode<T> currrent = Head;
                    while (currrent.Next != Tail)
                    {
                        currrent.Next = null;
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
                Head = Head.Next;
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
            if (Count!=0)
            {
                LinkedListNode<T> previous = null;
                LinkedListNode<T> current = Head;
                Tail = Head;
                LinkedListNode<T> next = null;
                if (Count == 1)
                {
                    return;
                }
                else
                {
                    while (current!=null)
                    {
                        next = current.Next;
                        current.Next = previous;
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


        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            LinkedListNode<T> Current = Head;
            while (Current!=null)
            {
                if (Current.Value.Equals(item))
                {
                    return true;
                }

                Current = Current.Next;
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            LinkedListNode<T> current = Head;
            while (current!=null)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            LinkedListNode<T> current = Head;

            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        public bool Remove(T item)
        {
            LinkedListNode<T> previous = null;
            LinkedListNode<T> current = Head;
            while (current!=null)
            {     
                if (current.Value.Equals(item))
                    {
                    if (previous != null)
                    {
                        previous.Next = current.Next;

                        //if it was end
                        if (current.Next==null)
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
                current = current.Next;
            }
            return false;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            LinkedListNode<T> current = Head;

            while (current!=null)
            {
                yield return current.Value;
                current = current.Next;
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((System.Collections.Generic.IEnumerable<T>)this).GetEnumerator();
        }

        public void Add(T item)
        {
            AddFirst(new LinkedListNode<T>(item));
        }
        #endregion

    }
}
