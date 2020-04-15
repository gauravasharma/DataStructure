using System;
using System.Collections.Generic;
using System.Text;

namespace DesignDataStructures
{
    public class BinaryTree
    {
        public Node Root { get; set; }
        public BinaryTree(int key)
        {
            Root = new Node(key);
        }
        public BinaryTree()
        {
            Root = null;
        }
    }


    //Model for Tree Structure
    public class Node
    {
        public int Data { get; set; }

        public Node Left { get; set; }

        public Node Right { get; set; }

        public Node(int key)
        {
            Data = key;
            Left = Right = null;
        }

    }
}
