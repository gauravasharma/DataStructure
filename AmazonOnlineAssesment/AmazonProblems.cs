using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmazonOnlineAssesment
{
    public static class AmazonProblems
    {
        /// <summary>
        /// pair of Songs
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static int NumPairsDivisibleBy60(int[] time)
        {

            var mod = new int[60];
            int sum = 0;

            foreach (var t in time)
            {
                int seconds = t % 60;
                sum += mod[(60 - seconds) % 60];
                mod[seconds]++;
            }
            return sum;
        }
        public static List<string> popularNFeatures(int numFeatures, int topFeatures, string [] possibleFeatures, int numFeatureRequests, string [] featureRequests)
        {
            var frequentWords = new List<string>();
            var hash = new HashSet<string>();
            var dictionary = new Dictionary<string, int>();
            foreach(var str in possibleFeatures)
            {
                var strToLower = str.ToLower();
                if(!hash.Contains(strToLower)){ hash.Add(strToLower); }
            }

            foreach(var item in featureRequests)
            {
                var strAttray = item.Replace(",", " ")
                                   .Replace(".", " ")
                                   .Replace("!", " ")
                                   .Replace("?", " ")
                                   .Replace(";", " ")
                                   .Replace("'", " ")
                                   .ToLower()
                                   .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                foreach(var feature in  new HashSet<string>(strAttray))
                {
                    if(hash.Contains(feature))
                    {
                        if(!dictionary.ContainsKey(feature))
                        {
                            dictionary.Add(feature, 0);
                        }
                        dictionary[feature]++;
                    }
                }
            }

            frequentWords = dictionary.OrderByDescending(x => x.Value).Select(o => o.Key).Take(topFeatures).ToList();

            return frequentWords;
        }

        public static string [] TransactionLogs(string [] transactions, int threshold)
        {
            var result = new string[] { };
            var dictionary = new Dictionary<string, int>();

            foreach(var item in transactions)
            {
                var strArray = item.Split(' ');
                var userId1 = strArray[0];
                var userId2 = strArray[1];
                if(userId1==userId2)
                {
                    if (!dictionary.ContainsKey(userId1)) { dictionary.Add(userId1, 0); }
  
                    dictionary[userId1]++;
                }
                else
                {
                    if (!dictionary.ContainsKey(userId1)) { dictionary.Add(userId1, 0); }
  
                    dictionary[userId1]++;

                    if (!dictionary.ContainsKey(userId2)) { dictionary.Add(userId2, 0); }
 
                    dictionary[userId2]++;
                }
            }
            result = dictionary.OrderByDescending(x => x.Value).Where(o => o.Value >= threshold).OrderByDescending(z => int.Parse(z.Key)).Select(x => x.Key).ToArray();
            return result;
        }

        public static int RoverControl(int n, string [] Diretions)
        {
            int row = 0;
            int col = 0;
            foreach(var dir in Diretions)
            {            
                switch(dir)
                {
                    case "RIGHT":
                        if (col == n - 1) { continue; }
                        else { col++; }
                        break;
                    case "LEFT":
                        if (col == 0) { continue; }
                        else { col--; }
                        break;
                    case "UP":
                        if (row == 0) { continue; }
                        else { row--; }
                        break;   
                    case "DOWN":
                        if (row == n-1) { continue; }
                        else { row++; }
                        break;
                }                
            }
            return row * n + col;
        }

        public static int BaseBallGame(string[] ops)
        {
            List<int> list = new List<int>();

            for (int i = 0; i < ops.Length; i++)
            {
                if (ops[i].Equals("C"))
                {
                    list.RemoveAt(list.Count - 1);
                }
                else if (ops[i].Equals("D"))
                {
                    var item = list[list.Count - 1];
                    item = item * 2;
                    list.Add(item);
                }
                else if (ops[i].Equals("+"))
                {
                    var a = list[list.Count - 1];
                    var b = list[list.Count - 2];
                    list.Add(a + b);
                }
                else
                {
                    list.Add(Convert.ToInt32(ops[i]));
                }
            }

            return list.Sum(x => x);

        }

        public static int[][] KClosest(int[][] points, int k)
        {

            int[][] result = new int[k][];
            Dictionary<int[], double> dist = new Dictionary<int[], double>();

            for (int i = 0; i < points.Length; i++)
            {
                var a = points[i][0];
                var b = points[i][1];

                var c = Math.Sqrt(a * a + b * b);

                dist.Add(points[i], c);
            }

            var items = dist.OrderBy(x => x.Value).Take(k).Select(x => x.Key).ToList();

            for (int i = 0; i < k; i++)
            {
                result[i] = items[i];
            }
            return result;
        }

        public static int FindCircleNum_Province(int[][] isConnected)
        {

            int[] visited = new int[isConnected.Length];
            int count = 0;
            for (int i = 0; i < isConnected.Length; i++)
            {
                if (visited[i] == 0)
                {
                    DFS(isConnected, i, visited);
                    count++;
                }
            }
            return count;
        }

        private static void DFS(int[][] isConnected, int i, int[] visited)
        {
            for (int j = 0; j < isConnected[0].Length; j++)
            {
                if (isConnected[i][j] == 1 && visited[j] == 0)
                {
                    visited[j] = 1;
                    DFS(isConnected, j, visited);
                }

            }
        }

        public static int ThrottlingGateWay( int [] requestTime,int num)
        {
            int dropped = 0;
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for(int i=0; i< requestTime.Length; i++)
            {
                //Handles the scenario of having more than three request within 3 seconds
                if(i>2 && requestTime[i]== requestTime[i-3])
                {
                    if(!dict.ContainsKey(requestTime[i]) || dict[requestTime[i]]!=i)
                    {
                        dropped++;
                        dict[requestTime[i]] = i;
                    }
                }
                else if(i>19 && (requestTime[i]- requestTime[i-20])<10) // handles the scenario of having request more than 20 within 10 seconds
                {
                    if (!dict.ContainsKey(requestTime[i]) || dict[requestTime[i]] != i)
                    {
                        dropped++;
                        dict[requestTime[i]] = i;
                    }
                }
                else if(i>59 && (requestTime[i]- requestTime[i-60])>60)//handles the scenario of having 60 request within 1 minute
                {
                    if (!dict.ContainsKey(requestTime[i]) || dict[requestTime[i]] != i)
                    {
                        dropped++;
                        dict[requestTime[i]] = i;
                    }
                }
            }
            return dropped;

        }

        public static int MaximumUnits(int[][] boxTypes, int truckSize)
        {

            boxTypes = boxTypes.OrderByDescending(x => x[1]).ToArray();

            int numofbox = 0;
            int units = 0;

            for (int i = 0; i < boxTypes.Length; i++)
            {
                int box = boxTypes[i][0];
                numofbox = numofbox + box;
                if (numofbox > truckSize)
                {
                    int diff = numofbox - truckSize;
                    box = box - diff;
                }
                units = units + box * boxTypes[i][1];
            }

            return units;
        }

        public static String[] findNearestCities(int numOfPoints, String[] points, int[] xCoordinates, int[] yCoordinates,int numOfQueries, String[] queries)
        {
            string[] res = new string[numOfQueries];
            var dictionary = new Dictionary<string, int[]>();

            for(int i=0; i< numOfPoints; i++ )
            {
                var cordinates = new int[2] { xCoordinates[i], yCoordinates[i] };
                dictionary.Add(points[i], cordinates);
            }
            int k = 0;
            foreach(var city in queries)
            {
                var searchCityCordniates = dictionary[city];
                string cityName = string.Empty;
                foreach(var item in dictionary)
                {
                    if(city!= item.Key)
                    {
                        var cordinates = item.Value;
                        if(searchCityCordniates[0]== cordinates[0] || searchCityCordniates[1]==cordinates[1])
                        {
                            cityName = item.Key;
                        }

                    }
                }
                res[k] = string.IsNullOrEmpty(cityName) ? "None" : cityName;
                k++;
            }
            return res;
        }

        public static IList<IList<string>> SuggestedProducts(string[] products, string searchWord)
        {

            Dictionary<string, SortedSet<string>> map = new Dictionary<string, SortedSet<string>>();
            foreach (string p in products)
            {
                for (int i = 0; i < p.Length; i++)
                {
                    string subStr = p.Substring(0, i + 1);

                    if (!map.ContainsKey(subStr))
                    {
                        map.Add(subStr, new SortedSet<string>());
                    }
                    map[subStr].Add(p);
                }
            }

            IList<IList<string>> ans = new List<IList<string>>();
            for (int i = 0; i < searchWord.Length; i++)
            {
                string subStr = searchWord.Substring(0, i + 1);
                if (map.ContainsKey(subStr))
                {
                    ans.Add(map[subStr].Take(3).ToList());
                }
                else
                {
                    ans.Add(new List<string>());
                }
            }
            return ans;

        }

        public static char SlowestKey(int[] releaseTimes, string keysPressed)
        {

            int maxDuration = releaseTimes[0];
            char res = keysPressed[0];

            for (int i = 1; i < releaseTimes.Length; i++)
            {
                var duration = releaseTimes[i] - releaseTimes[i - 1];
                var key = keysPressed[i];
                if (duration > maxDuration)
                {
                    res = key;
                    maxDuration = duration;
                }
                else if (duration == maxDuration && key > res)
                {
                    res = key;
                }
            }

            return res;
        }

        public static int multiprocessorSystem(int[] ability, int num, int processes)
        {
            SortedSet<string> SortedSet = new SortedSet<string>();
            var random = new Random();
            for(int i=0; i< ability.Length; i++)
            {
                var str = $"{ability[i].ToString()}:{random.Next().ToString()}";
                SortedSet.Add(str);
            }

            int length = ability.Length - 1;
            int count = 0;
            while(processes>0)
            {
                var max = SortedSet.Max;
                var arr = max.Split(':');
                var maxProcess = arr[0];
                processes = processes - int.Parse(maxProcess);
                var a = Math.Floor((int.Parse(maxProcess) / 2.0));

                SortedSet.Remove(max);
                SortedSet.Add($"{a.ToString()}:{arr[1].ToString()}");
                count++;
            }
            return count;
        }

        public static string findSmallestDivisor(string str1, string str2)
        {
            string res = string.Empty;
            string s = string.Empty;
            string t = string.Empty;

            int min = int.MinValue;

            if (str1.Length >= str2.Length)
            {
                s = str1;
                t = str2;
            }
            else
            {
                t = str1;
                s = str2;
            }

            int sLength = s.Length;
            int tLength = t.Length;


            for (int i = tLength; i > 0; i--)
            {
                string subStr = t.Substring(0, i);

                if(isDivisible(t,subStr))
                {
                    if (sLength % subStr.Length == 0)
                    {
                        int k = 0;
                        int len = subStr.Length;
                        while (k <= sLength - 1)
                        {
                            if (s.Substring(k, len) != subStr) { break; }
                            k = k + len;
                        }
                        if (k == s.Length)
                        {
                            if (len > min)
                            {
                                res = subStr;
                                min = len;
                            }
                        }
                    }
                }
               
            }

            return res;
        }

        private static bool isDivisible(string str, string substring)
        {
            string str1 = string.Empty;
            while(str1.Length< str.Length)
            {
                if (string.IsNullOrEmpty(str1))
                {
                    str1 = substring;
                }
                else { str1 = str1 + substring; }
            }
            return str==str1;
        }

        public static int MaximalSquare(char[][] matrix)
        {
            if (matrix == null || matrix.Length < 1 || matrix[0] == null || matrix[0].Length < 1) return 0;

            int rows = matrix.Length, cols = matrix[0].Length;
            var dp = new int[rows + 1, cols + 1];
            var maxSize = 0;

            for (var row = 1; row <= rows; row++)
                for (var col = 1; col <= cols; col++)
                    if (matrix[row - 1][col - 1] == '1')
                    {
                        dp[row, col] = 1 + Min(
                            dp[row, col - 1],
                            dp[row - 1, col],
                            dp[row - 1, col - 1]
                        );
                        if (maxSize < dp[row, col]) maxSize = dp[row, col];
                    }
            return maxSize * maxSize;
        }

        private static int Min(int a, int b, int c)
        {
            return Math.Min(a, Math.Min(b, c));
        }

        public static IList<IList<int>> CriticalConnections(int n, IList<IList<int>> connections)
        {
            var dic = new Dictionary<int, List<int>>();
            foreach (var connection in connections)
            {
                if (dic.ContainsKey(connection[0]))
                    dic[connection[0]].Add(connection[1]);
                else dic.Add(connection[0], new List<int> { connection[1] });
                if (dic.ContainsKey(connection[1]))
                    dic[connection[1]].Add(connection[0]);
                else dic.Add(connection[1], new List<int> { connection[0] });
            }

            int[] rank = new int[dic.Count];
            for (int i = 0; i < rank.Length; i++)
                rank[i] = -2;

            var conns = new Dictionary<(int, int), int>();
            int dfs(int node, int depth)
            {
                if (rank[node] >= 0)
                    return rank[node];

                rank[node] = depth;
                int min = n;
                foreach (var neighbor in dic[node])
                {
                    if (rank[neighbor] == depth - 1)
                        continue;
                    int back_depth = dfs(neighbor, depth + 1);
                    if (back_depth <= depth)
                        conns.Add((node, neighbor), 1);
                    min = Math.Min(min, back_depth);
                }

                return min;
            }
            dfs(0, 0);

            var res = new List<IList<int>>();
            foreach (var conn in connections)
                if (!conns.ContainsKey((conn[0], conn[1])) && !conns.ContainsKey((conn[1], conn[0])))
                    res.Add(conn);

            return res;
        }

        public static bool SearchMatrix(int[][] matrix, int target)
        {

            int row = matrix.Length - 1;
            int col = 0;

            while (row >= 0 && col < matrix[0].Length)
            {
                if (matrix[row][col] > target)
                {
                    row--;
                }
                else if (matrix[row][col] < target)
                {
                    col++;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        public static bool SearchMatrixBinarySearch(int[][] matrix, int target)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;
            int left = 0;
            int right = m * n - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;
                int midElement = matrix[mid / n][mid % n];
                if (midElement == target)
                {
                    return true;
                }
                else if (midElement > target)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return false;
        }

        public static bool IsSubtree(TreeNode s, TreeNode t)
        {
            if (s == null)
                return false;
            else if (s.val == t.val && IsSameTree(s, t))
                return true;
            else
                return IsSubtree(s.left, t) || IsSubtree(s.right, t);
        }

        private static bool IsSameTree(TreeNode n1, TreeNode n2)
        {
            if (n1 == null && n2 == null)
                return true;
            else if (n1 == null && n2 != null || n1 != null && n2 == null)
                return false;

            return n1.val == n2.val && IsSameTree(n1.left, n2.left) && IsSameTree(n1.right, n2.right);
        }

        public static string Labeling(string s, int k)
        {
            string res = string.Empty;
            Dictionary<char, int> sortedDict = new Dictionary<char, int>();
            for(int i=0; i<s.Length; i++)
            {
                if(!sortedDict.ContainsKey(s[i]))
                {
                    sortedDict.Add(s[i], 0);
                }
                sortedDict[s[i]]++;
            }
            var keys = sortedDict.OrderByDescending(x => x.Key).Select(x => x.Key).ToArray(); ;
            int j = 0;
            StringBuilder sb = new StringBuilder();

            char banned = new char();

            while(j< s.Length)
            {
                int p = 0;
                while(p<k)
                {
                    foreach(var key in keys)
                    {
                        sb.Append(keys);
                        p++;
                        j++;
                        sortedDict[key]--;
                    }
 
                }
            }
            res = sb.ToString();
            return res;
        }

        public static int EarliestTimeToCompleteDeliveries(int [] buildingTime, int [] offLoadTime)
        {
            int res = int.MinValue;
            Array.Sort(buildingTime);
            offLoadTime = offLoadTime.OrderByDescending(x => x).ToArray();
            int i = 0;
            int j = 0;
            foreach(var a in buildingTime)
            {
                int count = 0;
                while(j<offLoadTime.Length && count<4)
                {
                   res = Math.Max(res, a + offLoadTime[j]);
                   j++;
                   count++;
                }
            }
            return res;
        }

        static PageNode Head;
        static PageNode Tail;
        public static int LRUCacheMiss(int [] pages, int capacity)
        {
            LinkedList<PageNode> doubleLinkedList = new LinkedList<PageNode>();
            Head = new PageNode();
            Tail = new PageNode();
            Head.next = Tail;
            Tail.prev = Head;

            int cacheMiss = 0;
            Dictionary<int, PageNode> cache = new Dictionary<int, PageNode>();
            int size = 0;
            foreach (var page in pages)
            {
                PageNode node = null;
                if(cache.ContainsKey(page))
                {
                    node = cache[page];
                }

                if(node==null)
                {
                    cacheMiss++; ;
                    node = new PageNode { value = page };
                    AddNode(node);
                    cache.Add(page, node);
                    size++;
                    if(size>capacity)
                    {
                        var tail=popTail();
                        cache.Remove(tail.value);
                        size--;
                    }                  
                }
                else
                {
                    node.value = page;
                    MoveToHead(node);
                }                
            }
            return cacheMiss;
        }

        private static void MoveToHead(PageNode node)
        {
            removeNode(node);
            AddNode(node);
        }

        private static void AddNode(PageNode node)
        {
            node.prev = Head;
            node.next = Head.next;
            Head.next.prev = node;
            Head.next = node;

        }
        private static PageNode popTail()
        {
            var res = Tail.prev;
            removeNode(res);
            return res;
        }

        private static void removeNode(PageNode res)
        {
            var prev = res.prev;
            var next = res.next;
            prev.next = next;
            next.prev = prev;
        }

        public class PageNode
        {
            public int value { get; set; }
            public PageNode next { get; set; }
            public PageNode prev { get; set; }
        }

        public static int CountTeams(int [] rating)
        {
            int teamCount = 0;
            int len = rating.Length;
            for (int i = 0; i < len; i++)
            {
                for (int j = i + 1; j < len; j++)
                {
                    for (int k = j + 1; k < len; k++)
                    {
                        if (rating[i] < rating[j] && rating[j] < rating[k] ||
                            rating[i] > rating[j] && rating[j] > rating[k])
                            teamCount++;
                    }
                }
            }
            return teamCount;
        }

        public static int DietPlanPerformance(int[] calories, int k, int lower, int upper)
        {

            int point = 0;
            int n = calories.Length;

            int i = 0;

            while (i <= n - k)
            {
                int p = 0;
                int sum = 0;
                while (p < k)
                {
                    sum = sum + calories[i + p];
                    p++;
                }
                    if (sum < lower)
                    {
                        point--;
                    }
                    else if (sum > upper)
                    {
                        point++;
                    }
                    p++;
                
                i++;
            }

            return point;

        }

        public static int CountComponents(int[][] edges)
        {

            edges = edges.OrderBy(x => x[0]).ToArray();
            for (int i = 1; i < edges.Length; i++)
            {

                if (edges[i - 1][1] >= edges[i][0])
                {
                    edges[i][0] = edges[i - 1][0];
                    edges[i][1] = edges[i - 1][1] > edges[i][1] ? edges[i - 1][1] : edges[i][1];
                    edges[i - 1] = null;
                }
                else if (edges[i - 1][0] == edges[i][0] && edges[i - 1][1] == edges[i][1])
                {
                    edges[i - 1] = null;
                }
            }
            return edges.Count(x => x != null);
        }

        public static int[] PrisonAfterNDays(int[] cells, int N)
        {
            int i = 0;
            while (i < N)
            {
                int[] res = new int[cells.Length];
                for (int j = 1; j < cells.Length - 1; j++)
                {
                    if (cells[j - 1] == cells[j + 1])
                    {
                        res[j] = 1;
                    }
                    else
                    {
                        res[j] = 0;
                    }
                }
                cells = res;
                i++;
            }

            return cells;
        }

    }
}
