using System;
using System.Text;

namespace StringProblems
{
    public static class StringProblem
    {

        /// <summary>
        /// Take two pointers one start from zero and second from last index.. keep swapping till start<last
        /// </summary>
        /// <param name="s"></param>
        public static string Reverse(char [] s)
        {
            int i = 0;
            int j = s.Length - 1; 
            while (i<j)
            {
                var temp = s[i];
                s[i] = s[j];
                s[j] = temp;
                i++;
                j--;
            }
            return s.ToString();
        }

        /// <summary>
        /// Reverse string of k lenth and skip next k length
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static string ReverseStr(string s, int k)
        {
            string output = string.Empty;
            bool replace = true;
            for (int count = 1; count <=s.Length; count++)
            {
                if (count%k==0)
                {
                    output = output + Reverse(s.Substring(count - k, count).ToCharArray());
                    k = 0;
                }
                k++;
            }

            return output;
        }

        #region Check if given string is palindrome

        public static bool IsPalindrome(string input)
        {
            bool isPalindrome = true;
            int l = 0, r = input.Length - 1;
            while (l<r)
            {
                if (input[l]!=input[r])
                {
                    isPalindrome = false;
                    break;
                }
                l++;
                r--;
            }
            return isPalindrome;
        }

        #endregion

        #region Find the Longest Palindrome

        public static string LongestPalindrome(string input)
        {
            int n = input.Length;
            bool[][] TEMP= new bool[n][];

            int maxLength = 1;
            for (int i = 0; i < n; i++)
            {
                TEMP[i] = new bool[n];
                TEMP[i][i] = true;
            }

            int start = 0;
            for (int i=0; i<n-1; i++)
            {
                if (input[i]==input[i+1])
                {
                    TEMP[i][i + 1] = true;
                    start = i;
                    maxLength = 2;
                }
            }

            for (int k=3; k<=n; k++)
            {
                for (int i = 0; i < n - k + 1; i++)
                {
                    int j = i + k - 1;

                    if(TEMP[i+1][j-1] && input[i]== input[j])
                    {
                        TEMP[i][j] = true;

                        if (k>maxLength) 
                        {
                            start = i;
                            maxLength = k;
                        }
                        
                    }
                }
            }

            return input.Substring(start, maxLength);
        }
        #endregion

        #region Longest Substring without repeating characters

        public static int LengthOfLongestSubstring(string s)
        {
            int length = 0;
            
            if (s.Length!=0)
            {


            }

            return length;
        }

        #endregion
    }
}
