using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array
{
    class ArrayProblems
    {
        static void Main(string[] args)
        {
            #region Given an array of integers, return indices of the two numbers such that they add up to a specific target. You may assume that each input would have exactly one solution, and you may not use the same element twice.

            int target = 9;
            int[] arr = new int[] { 2, 7, 11, 15 };

            var result = TwoSum(arr,target);
            var result1 = TwoSumUsingComplement(arr, target);
            #endregion
        }

        /// <summary>
        /// Complexity is O(n2) and space complexity is O(1)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static  int[] TwoSum(int[] nums, int target)
        {
            int i = 0;
            int j = 0;
            while (i<nums.Length)
            {
                j = i + 1;
                while (j< nums.Length)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        return new[] { i, j };
                    }
                    j++;
                }
                i++;
            }
            throw new NotImplementedException();
        }

        /// <summary>
        /// using compliment time complexity is O(n) and space complxity is O(n)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] TwoSumUsingComplement(int[] nums, int target)
        {
            var dict = new Dictionary<int, int>();
            for (int i=0;i<nums.Length;i++)
            {
                dict.Add(nums[i],i);
            }

            for (int i = 0; i < nums.Length; i++)
            {
                int compliment = target - nums[i];
                if (dict.ContainsKey(compliment))
                {
                    return new[] { i, dict[compliment] };
                }
 
                
            }
            throw new  NotImplementedException();
        }

        #region MyRegion
        public static int FindNumbers(int[] nums)
        {
            int count = 0;

            for (int i=0; i<nums.Length; i++)
            {
                if (nums[i].ToString().Length%2==0)
                {
                    count++;
                }
            }
            return count;
        }
        #endregion

        #region DayofTheWeek
        public string DayOfTheWeek(int day, int month, int year)
        {
            return new DateTime(year, month, day).DayOfWeek.ToString();

        }
        #endregion

        #region Remove Element

        public int RemoveElement(int[] nums, int val)
        {
            int i = 0;

            for (int j=0; j<nums.Length; j++ )
            {
                if (nums[j]!=val)
                {
                    nums[i] = nums[j];
                    i++;
                }
            }

            return i;
        }
        #endregion

        #region Remove Duplicates

        public int RemoveDuplicates(int[] nums)
        {
            int i = 0;

            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[j]!=nums[j+1])
                {
                    nums[i] = nums[j];
                    i++;
                }
            }

            return i;
        }

        #endregion

    }
}
