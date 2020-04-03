using System;
using System.Collections.Generic;
using System.Linq;

namespace BinarySearchProblems
{
    public static class BinarySearchProblem
    {

        /// <summary>
        /// This Works for smaller data range and when size is known else in case of large data you will get stack over flow exception
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int FindPosition(int[] nums, int left, int right, int target)
        {
            int isPresent = -1;

            if (right >= left)
            {
                int mid = left + (right - 1) / 2;

                if (nums[mid] == target)
                {
                    return mid;
                }

                if (target < nums[mid])
                {
                    return FindPosition(nums, left, mid - 1, target);
                }
                else
                {
                    return FindPosition(nums, mid + 1, right, target);
                }
            }
            return isPresent;
        }

        /// <summary>
        /// This works with unknown data set size as well, we keep adjusting left and right until target value is found.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int FindPosition(int [] nums, int target)
        {
            int pivot=0, left = 0, right = nums.Length - 1;

            while (left<=right)
            {
                pivot = left + (right - 1) / 2;

                if (nums[pivot] == target)
                {
                    return pivot;
                }

                if (target < nums[pivot])
                {
                    right = pivot - 1;
                }
                else { left = pivot + 1; }
            }
            return -1;
        }


        /// <summary>
        /// Burute Force Techniques
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public static int [] Intersection(int[] nums1, int[] nums2)
        {
            int nums1Length = nums1.Length;
            int nums2Length = nums2.Length;
            List<int> intersection = new List<int>();

            int k = 0;
            for (int i = 0; i <= nums1.Length - 1; i++)
            {
                for (int j = 0; j <= nums2.Length - 1; j++)
                {
                    if (nums1[i]== nums2[j])
                    {
                        intersection.Add( nums1[i]);
                        k++;
                    }
                }
            }
            return nums1.Intersect(nums2).ToArray();
        }
    }
}
