using System;
using System.Collections.Generic;
using System.Text;

namespace DesignDataStructures
{
    public class DoubleNode {
        public int key { get; set; }
        public int value { get; set; }
        public DoubleNode prev { get; set; }

        public DoubleNode next { get; set; }
    }
    public class LRUCache
    {
        int size;
        int capacity;
        DoubleNode Head;
        DoubleNode Tail;

        Dictionary<int, DoubleNode> cache = new Dictionary<int, DoubleNode>();
        public LRUCache(int capacity)
        {
            size = 0;
            this.capacity = capacity;
            Head = new DoubleNode();
            Tail = new DoubleNode();
            Head.next = Tail;
            Tail.prev = Head;

        }

        private void AddNode(DoubleNode node)
        {
            node.prev = Head;
            node.next = Head.next;
            Head.next.prev = node;
            Head.next = node;

        }
        private DoubleNode popTail()
        {
            var res = Tail.prev;
            removeNode(res);
            return res;
        }

        private void removeNode(DoubleNode res)
        {
            var prev = res.prev;
            var next = res.next;
            prev.next = next;
            next.prev = prev;
        }

        private void movetoHead(DoubleNode node)
        {
            removeNode(node);
            AddNode(node);
        }
        public int Get(int key)
        {
            DoubleNode node = null;
            if(cache.ContainsKey(key))
            {
               node = cache[key];
            }
            if (node==null)
            {
                return -1;
            }

            // move the accessed node to the head;
            movetoHead(node);

            return node.value;

        }

        public void Put(int key, int value)
        {
            DoubleNode node = null;
            if (cache.ContainsKey(key))
            {
                node = cache[key];
            }
            
            if (node==null) 
            {
                var dnode = new DoubleNode();
                dnode.key = key;
                dnode.value = value;

                cache.Add(key, dnode);
                AddNode(dnode);
                size++;

                if (size > capacity)
                {
                    var tail = popTail();
                    cache.Remove(tail.key);
                    size--;
                }
                else {
                    
                }
            }
            else
            {
                //update existing node
                node.value = value;
                movetoHead(node);
            }
        }
    }

    /**
     * Your LRUCache object will be instantiated and called as such:
     * LRUCache obj = new LRUCache(capacity);
     * int param_1 = obj.Get(key);
     * obj.Put(key,value);
     */
}
