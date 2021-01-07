using System;
using System.Collections.Generic;
using System.Linq;
using DesignDataStructures;
namespace TreeProblems
{
    public static class TreeProblem
    {
        //All four traversals require O(n) time as they visit every node exactly once.
        //Is there any difference in terms of Extra Space?
        //There is difference in terms of extra space required.

        //Extra Space required for Level Order Traversal is O(w) where w is maximum width of Binary Tree.In level order traversal, queue one by one stores nodes of different level.
        //Extra Space required for Depth First Traversals is O(h) where h is maximum height of Binary Tree.In Depth First Traversals, stack (or function call stack) stores all ancestors of a node.

        static List<int> treeData;
        #region In Order Traversal
        public static List<int> TraverseInOrder(Node root)
        {
            treeData = new List<int>();
            InOrder(root);
            return treeData;
        }

        private static void InOrder(Node node)
        {
            if (node == null)
            {
                return;
            }

            /* first recur on left child */
            InOrder(node.Left);

            /* then add the data of node */
            treeData.Add(node.Data);

            /* now recur on right child */
            InOrder(node.Right);
        }
        #endregion

        #region Pre Order Traversal
        public static List<int> TraversePreOrder(Node root)
        {
            treeData = new List<int>();
            PreOrder(root);
            return treeData;
        }
        private static void PreOrder(Node node)
        {
            if (node == null)
            {
                return;
            }

            /* first add the data of node */
            treeData.Add(node.Data);
            /* Then recur on left child */
            PreOrder(node.Left);

            /* now recur on right child */
            PreOrder(node.Right);
        }
        #endregion

        #region Post Order Traversal
        public static List<int> TraversePostOrder(Node root)
        {
            treeData = new List<int>();
            PostOrder(root);
            return treeData;
        }

        private static void PostOrder(Node node)
        {
            if (node == null)
            {
                return;
            }
            PostOrder(node.Left);
            PostOrder(node.Right);
            treeData.Add(node.Data);
        }
        #endregion

        #region BFS (Level Traversal)
        /// <summary>
        /// Time Complexity-O(n)
        /// Space Complexity-O(n)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static List<int> BFSTraverseQueue(Node root)
        {
            treeData = new List<int>();
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                var node = queue.Dequeue();
                treeData.Add(node.Data);

                if (node.Left != null)
                {
                    queue.Enqueue(node.Left);
                }
                if (node.Right != null)
                {
                    queue.Enqueue(node.Right);
                }
            }
            return treeData;
        }
        #endregion

        #region BFS Without Using Queue

        /// <summary>
        /// Time Complexity-O(n^2)
        /// Space Complexity-O(n)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static List<int> BFSTraverse(Node root)
        {
            treeData = new List<int>();
            int h = TreeHeight(root);
            int i;
            for (i = 1; i <= h; i++)
            {
                BFS(root, i);
            }

            return treeData;
        }

        private static void BFS(Node node, int level)
        {
            if (node == null)
            {
                return;
            }
            if (level == 1)
            {
                treeData.Add(node.Data);
            }
            else
            {
                BFS(node.Left, level - 1);
                BFS(node.Right, level - 1);
            }
        }
        #endregion

        #region Compute the Height  or Depth of Tree

        public static int TreeHeight(Node node)
        {
            if (node == null)
            {
                return 0;
            }
            else
            {
                /* compute the depth of each subtree */
                int lDepth = TreeHeight(node.Left);
                int rDepth = TreeHeight(node.Right);

                /* use the larger one */
                return Math.Max(lDepth, rDepth) + 1;
            }

        }

        #endregion

        public static IList<IList<int>> LevelOrder(Node root)
        {
            treeData = new List<int>();
            IList<IList<int>> collection = new List<IList<int>>();
            int h = TreeHeight(root);
            int i;
            for (i = 1; i <= h; i++)
            {
                treeData = new List<int>();
                BFS(root, i);
                collection.Add(treeData);
            }
            return collection;
        }

        #region Flood Fill
        public static int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
        {

            if (image[sr][sc] != newColor) {
                fill(image, sr, sc, image[sr][sc], newColor);
            }
            return image;
        }

        private static void fill(int[][] image, int x, int y, int prevColor, int newColor)
        {
            if (x < 0 || x >= image.Length || y < 0 || y >= image[0].Length)
            {
                return;
            }

            if (image[x][y] != prevColor)
            {
                return;
            }

            image[x][y] = newColor;
            fill(image, x - 1, y, prevColor, newColor);
            fill(image, x + 1, y, prevColor, newColor);
            fill(image, x, y - 1, prevColor, newColor);
            fill(image, x, y + 1, prevColor, newColor);


        }
        #endregion


        #region CheckForBinaryTree

        private static Node prev;
        public static bool IsBST(Node root)
        {

            prev = null;
            return IsBinaryTree(root);

        }
        private static bool IsBinaryTree(Node node)
        {
            if (node != null)
            {
                if (!IsBinaryTree(node.Left))
                    return false;

                // allows only distinct values node 
                if (prev != null &&
                    node.Data <= prev.Data)
                    return false;
                prev = node;
                return IsBinaryTree(node.Right);
            }
            return true;
        }
        #endregion

        #region CheckBinaryTreeUsingInorderTraversal

        static Node previous = null;
        static bool isValid = true;
        public static bool IsValidBSTree(Node root)
        {
            if (root == null || !isValid)
            {
                return false;
            }
            IsValidBSTree(root.Left);
            if (previous != null && previous.Data > root.Data)
            {
                isValid = false;
            }
            previous = root;
            IsValidBSTree(root.Right);
            return isValid;
        }

        #endregion

        #region NumberOfIslands

        public static int NumIslands(char[][] grid)
        {
            int num = 0;
            if (grid == null || grid.Length == 0)
            {
                return 0;
            }

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        num++;
                        DFSFill(grid, i, j);
                    }
                }
            }
            return num;
        }

        private static void DFSFill(char[][] grid, int r, int c)
        {
            if (r < 0 || r >= grid.Length || c < 0 || c >= grid[0].Length || grid[r][c] == '0')
            {
                return;
            }

            grid[r][c] = '0';

            DFSFill(grid, r - 1, c);
            DFSFill(grid, r + 1, c);
            DFSFill(grid, r, c - 1);
            DFSFill(grid, r, c + 1);
        }

        #endregion

        #region DiameterOfBinaryTree
        public static int DiameterOfBinaryTree(Node root)
        {
            int l = 0;
            int r = 0;
            int d = 0;
            if (root == null)
            {
                return 0;
            }

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                var node = queue.Dequeue();
                var leftNode = node.Left;
                var rightNode = node.Right;
                l = TreeHeight(leftNode);
                r = TreeHeight(rightNode);
                d = Math.Max(d, l + r);

                if (node.Left != null)
                {
                    queue.Enqueue(node.Left);
                }
                if (node.Right != null)
                {
                    queue.Enqueue(node.Right);
                }
            }

            return d;
        }
        #endregion

        #region WordSearch
        public static bool WordExist(char[][] board, string word)
        {
            if (board == null || board.Length == 0 || word.Length> board[0].Length* board.Length)
            {
                return false;
            }
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    if (word[0] == board[i][j])
                    {
                        if (isPresent(board, i, j, word, 0)) {
                            return true;
                        }
                    }
                }
            }

            return false;

        }

        private static bool isPresent(char[][] board, int x, int y, string Target, int Level)
        {
            int row = board.Length;
            int col = board[0].Length;
            if (Level == Target.Length)
            {
                return true;
            }
            if (x < 0 || x >= row || y < 0 || y >= col || board[x][y] != Target[Level])
            {
                return false;
            }

            var res = false;
            char temp = board[x][y];
            board[x][y] = '#';
            if (isPresent(board, x - 1, y, Target, Level + 1))
            {
                res = true;
            }
            else if (isPresent(board, x + 1, y, Target, Level + 1))
            {
                res = true;
            }
            else if (isPresent(board, x, y - 1, Target, Level + 1))
            {
                res = true;
            }
            else if (isPresent(board, x, y + 1, Target, Level + 1))
            {
                res = true;
            }
            board[x][y] = temp;
            return res;

        }
        #endregion

        #region FindTreasure


        public static int shortPath(char[][] land)
        {
            if (land==null)
            {
                return -1;
            }

            ShortestPathToTreasure(land, 0,0,0);
            return minPath;
        }

        static int minPath = int.MaxValue;
        public static void ShortestPathToTreasure(char [][]land, int i ,int j, int level)
        {
            int row = land.Length - 1;
            int col = land[0].Length - 1;

            if (i < 0 || i > row || j<0 || j>col || land[i][j]=='D' || land[i][j] == '#')
            {
                return;
            }
            
            if (land[i][j] == 'X')
            {
                minPath= Math.Min(minPath, level);
            }

            var temp = land[i][j];
            land[i][j] = '#';
            ShortestPathToTreasure(land, i+1,j, level+1);
            ShortestPathToTreasure(land, i-1, j, level + 1);
            ShortestPathToTreasure(land, i, j+1, level + 1);
            ShortestPathToTreasure(land, i, j-1, level + 1);
            land[i][j] = temp;
        }
       
        #endregion
    }
}
