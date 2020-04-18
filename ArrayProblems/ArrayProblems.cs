using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArrayProblems
{
    public static class ArrayProblem
    {
        #region DayofTheWeek
        public static string DayOfTheWeek(int day, int month, int year)
        {
            return new DateTime(year, month, day).DayOfWeek.ToString();

        }
        #endregion

        #region Remove Element
        public static int RemoveElement(int[] nums, int val)
        {
            int i = 0;

            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[j] != val)
                {
                    nums[i] = nums[j];
                    i++;
                }
            }

            return i;
        }
        #endregion

        #region Remove Duplicates
        public static int RemoveDuplicates(int[] nums)
        {
            int i = 0;
            if (nums.Length==0)
            {
                return 0;
            }
            for (int j = 1; j < nums.Length; j++)
            {
                if (nums[j] != nums[i])
                {
                    i++;
                    nums[i] = nums[j];
                }
            }
            return i+1;
        }

        public static int RemoveDuplicates_1(int[] nums)
        {
            return 0;
        }

        public static void Rotate(int[] nums, int k)
        {
            if (nums!=null && nums.Length>1)
            {
                int l = nums.Length;
                if (k > l)
                {
                    k = k - l;
                }
                Reverse(nums, 0, l - k - 1);
                Reverse(nums, l - k, l - 1);
                Reverse(nums, 0, l - 1);
            }
        }

        public static void Reverse(int[] nums, int start,int end)
        {
            if (start>-1 && end>-1)
            {
                while (start < end)
                {
                    var temp = nums[start];
                    nums[start] = nums[end];
                    nums[end] = temp;
                    start++;
                    end--;
                }
            }
          
        }
        #endregion

        #region Duplicates Zeros

        public static void DuplicateZeros(int [] arr)
        {
            var queue = new Queue<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                queue.Enqueue(arr[i]);
            }
            int j = 0;
            while (j<arr.Length)
            {
                int value = queue.Dequeue();
                arr[j] = value;
                if (value==0 && j<arr.Length-1)
                {
                    j++;
                    arr[j] = 0;
                }
                j++;
            }
        }

        #endregion

        #region Move Zeros to End

        public static void MovingZeroEnd(int[] nums)
        {
            int j = 0;
            for (int i=0; i<nums.Length;i++)
            {
                if (nums[i] != 0)
                {
                    nums[j] = nums[i];
                    j++;
                }
            }
            while (j<nums.Length)
            {
                nums[j] = 0;
                j++;
            }
        }

        #endregion

        public static int MaxConsecutiveOne(int [] nums)
        {
            int count = 0;
            int previous = 0;

            for (int i=0; i<nums.Length;i++)
            {
                if (nums[i] == 1)
                {
                    count++;
                }
                else
                {

                    if(count>previous)
                    {
                        previous = count;
                    }

                    count = 0;
                }
            }

            return previous > count ? previous : count;
        }

        public static int MissingNumber(int [] nums)
        {

            int n = nums.Length;
            int expectedSum = n *(n + 1) / 2;
            int actualSum = 0;
            for (int j=0; j<nums.Length; j++)
            {
                actualSum += nums[j];
            }
            return expectedSum - actualSum;
        }

        public static bool ContainsDuplicate(int[] nums)
        {
            return new HashSet<int>(nums).Count != nums.Length;
        }

        public static int [] Decompress(int [] nums)
        {
            var list = new List<int>();
            for (int i = 0; i < nums.Length; i=i+2)
            {
                int f = nums[i];
                
                while (f>0){
                    list.Add(nums[i + 1]);
                    f--;
                }
            }
            return list.ToArray();
             
        }

        public static int[] SumZero(int n)
        {
            int[] arr = new int[n];

            if (n == 1)
            {
                arr[0] = 0;
            }
            else
            {
                int k = 1;
                int i = n % 2 == 0 ? n - 1 : n - 2;

                for (int j=0; j < i; j=j+2)
                {
                    arr[j] = -k;
                    arr[j + 1] = k;

                    k = k + 1;
                }

                if (n % 2!=0)
                {
                    arr[n - 1] = 0;
                }
            }
            return arr;
        }

        public static int JewelAndStone(string J, string S)
        {
            int count = 0;

            foreach(var j in J)
            {
                foreach (var s in S)
                {
                    if (s==j)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public static int[][] Transpose(int[][] A)
        {
            int row = A.Length;
            int col = A[0].Length;

            int[][] newMatrix = new int[col][];
            for(int j=0;j<col;j++)
            {
                newMatrix[j] = new int[row];

            }

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    newMatrix[j][i] = A[i][j];
                }
            }

            return newMatrix;

        }

        public static int ProductAndSum(int n)
        {
            int sum = 0;
            int product = 1;
            while(n>0)
            {
                var num = n % 10;
                sum += num;
                product *= num;
                n = n / 10;
            }

            return product - sum;
        }

        #region Convert string to Lower Case
        // A-65
        // a-97

        public static string ToLowerCase(string str)
        {

            char [] arr = new char[str.Length];
            for(int k=0; k<str.Length; k++)
            {
                arr[k] = (str[k] >= 'A' && str[k] <= 'Z') ? (char)(str[k] - 'A' + 'a') : str[k];
            }

            return String.Join("", arr);

        }

        #endregion

        #region Count negative number in Sorted (non increasing order) Matrix
        public  static int CountNegatives(int[][] grid)
        {
            int count = 0;
           
            foreach(int [] x in grid)
            {
                foreach (int number in x)
                {
                    if (number < 0)
                    {
                        count++;
                    }
                }
            }

            return count;
        }
        #endregion

        #region Replace Elements with Greatest Element on Right Side

        public static int[] ReplaceElements(int[] arr)
        {
            int[] result = new int[arr.Length];

            int max = -1;
            result[arr.Length - 1] = max;
            for (int i=arr.Length-1; i>0; i--)
            {
                if (arr[i]>max)
                {
                    max = arr[i];                    
                }

                result[i - 1] = max;
            }

            return result;
        }

        #endregion

        #region Flipping an Image
        public static  int[][] FlipAndInvertImage(int[][] A)
        {
            foreach (int [] row in A)
            {
                int i = 0;
                int j = row.Length - 1;

                while (i < j)
                {
                    var temp = row[i];
                    row[i] = row[j];
                    row[j] = temp;
                    if (row[i] == 0)
                    {
                        row[i] = 1;
                    }
                    else
                    {
                        row[i] = 0;
                    }

                    if (row[j] == 0)
                    {
                        row[j] = 1;
                    }
                    else
                    {
                        row[j] = 0;
                    }
                    i++;
                    j--;
                }
            }

            return A;
        }

        private static int[] reverse(int[] row)
        {
            int i = 0;
            int j = row.Length - 1;

            while (i<j)
            {
                var temp = row[i];
                row[i] = row[j];
                row[j] = temp;
                row[i] = row[i] == 0 ? 1 : 0;
                row[j] = row[j] == 0 ? 1 : 0;
                i++;
                j--;
            }

            return row;
        }

        #endregion

        #region Height Checker
        public static int HeightChecker(int[] heights)
        {
            int count = 0;

            int[] heights1 = heights.Select(x => x).OrderBy(x => x).ToArray();

            int k = 0;
            while (k< heights1.Length)
            {
                if (heights[k]!= heights1[k])
                {
                    count++;
                }
                k++;
            }

            return count;
           
        }

        #endregion

        #region Fibonacci Number
        public static int Fib(int N)
        {
            int num = 0;
            int i = 0;
            int temp1 = 0;
            int temp2 = 1;

            while (i<=N)
            {
                if (i > 1)
                {
                    num = temp1 + temp2;
                    temp1 = temp2;
                    temp2 = num;
                }
                i++;
            }

            if (N == 0)
            { num = 0; }

            if (N==1)
            {
                num = 1;
            }
               
            return num;
        }

        #endregion

        #region Sort Matrix
        public static int[,] SortMatrix(int[,] A)
        {
            int i = A.GetLength(0);
            int j = A.GetLength(1);
            var temp = new int[i*j];
            int k = 0;
            for (int p=0; p<i; p++)
            {
                for(int q=0; q<j; q++)
                {
                    temp[k++] = A[p, q];
                }
            }

            temp = temp.OrderBy(x => x).ToArray();

            int count = 0;
            for (int p = 0; p < i; p++)
            {
                for (int q = 0; q < j; q++)
                {
                    A[p, q] = temp[count];
                    count++;
                }
            }

            return A;
        }
        #endregion

        #region Sort Matrix Diagonally.
        public static int[][] DiagonalSort(int[][] mat)
        {
            for (int i = 0; i < mat.Length; i++)
            {
                for (int j = 0; j < mat[0].Length; j++)
                {
                    List<int> lst = new List<int>();
                    int c = i;
                    for (int k = j; k < mat[0].Length; k++)
                    {
                        if (c < mat.Length && k < mat[0].Length)
                        {
                            lst.Add(mat[c][k]);
                        }
                        c = c + 1;
                    }

                    c = i;

                    lst = lst.OrderBy(x => x).ToList();
                    int lstCounter = 0;

                    for (int k = j; k < mat[0].Length; k++)
                    {
                        if (c < mat.Length && k < mat[0].Length && lstCounter < lst.Count())
                        {
                            mat[c][k] = lst[lstCounter];
                        }
                        c = c + 1;
                        lstCounter++;
                    }

                }
            }
            return mat;
        }
        #endregion

        #region Reveal Cards In Increasing Order

        /// <summary>
        /// 1- Sort the given array in increasing order.
        /// 2- Create queue with all the index position starting from 0;
        /// 3- Create a result array with same length as deck array
        /// 4- for each loop on result array
        ///    first pop the queue and use the fetched value as 
        ///     res[queue.enquue]= dec[i]
        ///     queue.enqueue(queue.dequeue)
        /// </summary>
        /// <param name="deck"></param>
        /// <returns></returns>
        public static  int[] DeckRevealedIncreasing(int[] deck)
        {
            //Sor the array in increasing order first
            for (int i=0; i<deck.Length; i++)
            {
                for (int j = 0; j < deck.Length - i - 1; j++)
                {
                    if (deck[j]>deck[j+1])
                    {
                        int temp = deck[j];
                        deck[j] = deck[j + 1];
                        deck[j + 1] = temp;
                    }
                }
            }

            Queue<int> queues = new Queue<int>();
            int[] result = new int[deck.Length];
            for (int i = 0; i < deck.Length; i++)
            {
                queues.Enqueue(i);
            }

            for(int i=0; i<result.Length; i++)
            {
                result[queues.Dequeue()] = deck[i];
                if (queues.Count>0)
                queues.Enqueue(queues.Dequeue());
            }

            return result;
        }

        #endregion

        #region Reduce Array Size to The Half
        public static int MinSetSize(int[] arr)
        {
            var item = arr.GroupBy(x => x).Select(x => x.Count());

            int half = (int)arr.Length / 2;
            int count = 0;
            foreach (var i in item.OrderByDescending(x=>x))
            {
                if (half>0)
                {
                    half = half - i;
                    count++;
                }
            }

            return count;
        }
        #endregion

        #region Container With Most Water

        public static int MaxArea(int[] height)
        {
            int maxArea = 0;int l = 0; int r = height.Length - 1;

            while(l<r)
            {
                maxArea = Math.Max(maxArea, Math.Min(height[l], height[r]) * (r - l));

                if (height[l]<height[r])
                {
                    l++;
                }
                else
                {
                    r--;
                }
                
            }

            return maxArea;
        }
        #endregion
        #region Selection Sort( In Place Sorting)   

        /// <summary>
        /// No Extra Space is required, only order of elements is changed within array.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int[] SelectionSort(int[] nums)
        {
            int n = nums.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int min_indx = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (nums[j] < nums[min_indx])
                    {
                        min_indx = j;
                    }
                }

                int temp = nums[min_indx];
                nums[min_indx] = nums[i];
                nums[i] = temp;

            }

            return nums;
        }
        #endregion

        #region Bubble Sort

        public static int[] BubbleSort(int[] nums)
        {
            int n = nums.Length;
            for (int i = 0; i < n - 1; i++)
            {
                bool swapped = false; ;
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (nums[j] > nums[j + 1])
                    {
                        int temp = nums[j + 1];
                        nums[j + 1] = nums[j];
                        nums[j] = temp;
                        swapped = true;
                    }
                }
                // iF no element swapped break the loop
                if (swapped == false)
                {
                    break;
                }
            }

            return nums;
        }

        #endregion

        #region Bubble Sort using recursion

        public static int[] BubbleSortUsingRecursion(int[] nums, int n)
        {
            if (n == 1)
            {
                return nums;
            }

            for (int i = 0; i < n - 1; i++)
            {

                if (nums[i] > nums[i + 1])
                {
                    int temp = nums[i + 1];
                    nums[i + 1] = nums[i];
                    nums[i] = temp;
                }

            }

            BubbleSortUsingRecursion(nums, n - 1);
            return nums;
        }

        #endregion

        #region SmallerNumbersThanCurrent 
        public static int[] SmallerNumbersThanCurrent(int[] nums)
        {
            int[] arr = new int[nums.Length];
            nums.CopyTo(arr, 0);
            int n = nums.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int min_indx = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (nums[j] < nums[min_indx])
                    {
                        min_indx = j;
                    }
                }

                int temp = nums[min_indx];
                nums[min_indx] = nums[i];
                nums[i] = temp;

            }

            for (int i = 0; i < n; i++)
            {
                int len = Array.IndexOf(nums, arr[i]);
                arr[i] = len;
            }

            return arr;
        }
        #endregion

        #region CreateTargetArray
        public static int[] CreateTargetArray(int[] nums, int[] index)
        {
            int n = nums.Length;
            int[] arr = new int[n];
            nums.CopyTo(arr, 0);
            for (int i = 0; i < n; i++)
            {
                int pos = index[i];
                int value = nums[i];

                if (pos < i)
                {
                    arr = Reshift(arr, pos);
                }

                arr[pos] = value;
            }

            return arr;
        }

        private static int[] Reshift(int[] nums, int pos)
        {
            int[] arr = new int[nums.Length];
            nums.CopyTo(arr, 0);

            for (int i = pos; i < nums.Length - 1; i++)
            {
                arr[i + 1] = nums[i];
            }
            return arr;
        }
        #endregion

        #region find GCD

        public static int FindGCD(int a , int b)
        {
            if(a==0)
            {
                return b;
            }

            return FindGCD(b % a, a);
        }

        #endregion

        #region find GCD of Given Array

        public static int gcdOfArray(int [] arr, int n)
        {
            int gcd = arr[0];
            for (int i=1; i<n; i++)
            {
                gcd = FindGCD(arr[i], gcd);
            }

            return gcd;
        }

        #endregion

        #region Median of two sorted array

        public static decimal MedianOfSortedArray(int [] arr1,int [] arr2)
        {
            decimal median = 0;
            List<int> list = new List<int>();
            list.AddRange(arr1.ToList());
            list.AddRange(arr2.ToList());

            var orderlist = list.OrderBy(x => x).ToList();

            if (orderlist.Count % 2 == 1)
            {
                median = orderlist[orderlist.Count/ 2];
            }
            else 
            {
                median = (orderlist[orderlist.Count / 2] + orderlist[(orderlist.Count / 2) - 1]) / 2;
            }

            return median;
        }

        #endregion

        #region Missing Number

        public static int MissingNumber1(int[] nums)
        {
            int n = nums.Length;
            for (int i=0;i<n-1;i++ ) 
            {
                int min_index = i;
                for(int j=i+1; j<n;j++)
                {
                    if (nums[min_index] >nums[j])
                    {
                        min_index = j;
                    }
                }

                int temp = nums[min_index];
                nums[min_index] = nums[i];
                nums[i] = temp;
            }
            if (nums[n - 1] != n)
            {
                return n;
            }

            if (nums[0] != 0)
            {
                return 0;
            }
            for (int i=0; i<n-1; i++)
            {
                if (nums[i]!=nums[i+1]-1)
                {
                    return  nums[i] + 1;
                }
            }
            return -1;
        }

        #endregion

        #region FindAnagaram

        #endregion

        #region Optimal Utilization

        public static int FindOptimalCost(int [] sticks)
        {
            int sum = 0;
            int n = sticks.Length;
            sticks = sticks.ToList().OrderBy(x => x).ToArray();
            for (int k = 0; k < n - 1; k++)
            {
                sticks[k + 1] = sticks[k] + sticks[k + 1];
                sum = sum + sticks[k + 1];
                for (int i = k + 1; i < n - 1; i++)
                {
                    if (sticks[i] > sticks[i + 1])
                    {
                        int temp = sticks[i];
                        sticks[i] = sticks[i + 1];
                        sticks[i + 1] = temp;
                    }
                }

            }

            return sum;
        }


        #endregion

        #region valid Prenthesis

        public static  bool IsValidParenthesis(string s)
        {
            Dictionary<char, char> dict = new Dictionary<char, char>();
            dict.Add(')', '(');
            dict.Add(']', '[');
            dict.Add('}', '{');
            bool isValid = true;
            Stack<char> stack = new Stack<char>();
            foreach (char c in s)
            {
                //closing bracket
                if (dict.ContainsKey(c))
                {
                    if (stack.Count!=0) {
                        var item = stack.Pop();
                        if (item != dict[c])
                        {
                            isValid = false;
                            break;
                        }
                    }
                    else
                    {
                        isValid = false;
                        break;
                    }
                }
                else
                {
                    stack.Push(c);
                }
            }

            return isValid && stack.Count == 0;
        }

        #endregion
    }
}