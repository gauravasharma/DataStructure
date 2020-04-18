using System;
using System.Collections.Generic;
using System.Linq;
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

        #region Group Anagrams

        public static IList<IList<string>> GroupAnagrams(string[] strs)
        {
            IList<IList<string>> result= new List<IList<string>>();
            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
            if (strs.Length != 0)
            {
                foreach (var item in strs)
                {
                    char[] charArray = item.ToCharArray();
                    Array.Sort(charArray);
                    var key = new String(charArray);
                    if (dict.ContainsKey(key))
                    {
                        var existing = dict[key];
                        existing.Add(item);
                        dict[key] = existing;
                    }
                    else
                    {
                        dict.Add(key,new List<string> { item});
                    }
                }
            }
            if (dict.Count!=0)
            {
                foreach (var item in dict)
                {
                    result.Add(dict[item.Key]);
                }
            }
            return result;
        }

        #endregion

        public static string MostCommonWord(string paragraph, string[] banned)
        {
            string str = string.Empty;
            Dictionary<string, int> dict = new Dictionary<string, int>();
            var words = paragraph.Split(' ', ',').Where(x => !banned.Contains(x.TrimEnd(',', '.', '!', '\'').ToLower())).Select(x => x.ToLower());
            //var words = paragraph.Split(' ').Where(x => !banned.Contains(x.TrimEnd(',','.','!','\'').ToLower())).Select(x => x.ToLower());
            foreach (var word in words)
            {
                if (word.Length>0) {
                    var w = word.TrimEnd(',', '.', '!', '\'');
                    if (!dict.ContainsKey(w))
                    {
                        dict.Add(w, 1);
                    }
                    else
                    {
                        dict[w] = dict[w] + 1;
                    }
                }
            }

            var def = dict.OrderByDescending(x => x.Value).FirstOrDefault();

            return def.Key != null ? def.Key : string.Empty;
        }
    }
}
