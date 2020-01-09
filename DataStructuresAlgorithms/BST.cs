using System;
using System.Collections.Generic;

namespace DataStructuresAlgorithms
{
    // Generic Binary Search Tree class which supports add, get, delete operations and
    // returns all keys and values.
    //
    // Tree shape depends on order of insertion and order of growth of running time
    // of all operations are based on height of BST.
    public class BST<Key, Value> where Key : IComparable<Key>
    {
        private Node root;

        public BST()
        {
            root = null;
        }

        // This method returns the number of nodes in the tree.
        public int Size()
        {
            return Size(root);
        }

        private int Size(Node cur)
        {
            if (cur == null) return 0;
            return cur.Count;
        }

        // This method adds a new node into tree if no existing key;
        // otherwise, update the existing key with new value.
        // Guarantee: O (n); Average: O (log n)
        public void Add(Key key, Value val)
        {
            if (key == null) throw new ArgumentNullException();

            if (val != null) root = Add(root, key, val);
        }

        // This helper method recursively search for position to insert new
        // node while maintaining BST properties.
        private Node Add(Node cur, Key key, Value val)
        {
            if (cur == null) return new Node(key, val, 1);
            int cmp = key.CompareTo(cur.Key);
            if (cmp < 0 )
            {
                cur.Left = Add(cur.Left, key, val);
            }
            else if (cmp > 0)
            {
                cur.Right = Add(cur.Right, key, val);
            }
            else // existing key, update val
            {
                cur.Val = val;
            }

            cur.Count = 1 + Size(cur.Left) + Size(cur.Right);

            return cur;
        }

        // This method traverses the tree and search for the target key.
        // It returns the value corresponding to the key if found;
        // otherwise, return default value of generic type Value.
        // Guarantee: O (n); Average: O (log n)
        public Value Get(Key key)
        {
            if (key == null) throw new ArgumentNullException();

            Node cur = root;
            while (cur != null)
            {
                int cmp = key.CompareTo(cur.Key);
                if (cmp < 0)
                {
                    cur = cur.Left;
                }
                else if (cmp > 0)
                {
                    cur = cur.Right;
                }
                else // cur.Key = key
                {
                    return cur.Val;
                }
            }

            return default(Value);
        }

        // This method traverses the tree and returns all the
        // keys.
        public IEnumerable<Key> Keys()
        {
            Queue<Key> queue = new Queue<Key>();
            if (root != null) Inorder(root, queue);
            return queue;
        }

        // This helper method recursively traverses the tree in inorder.
        private void Inorder(Node cur, Queue<Key> queue)
        {
            if (cur.Left != null) Inorder(cur.Left, queue);
            queue.Enqueue(cur.Key);
            if (cur.Right != null) Inorder(cur.Right, queue);
        }

        // This method traverses and return the min key in the tree.
        public Key Min()
        {
            if (Size() == 0) throw new InvalidOperationException();
            return Min(root).Key;
        }

        private Node Min(Node cur)
        {
            if (cur.Left == null)
            {
                return cur;

            } else
            {
                return Min(cur.Left);
            }
        }

        // This method traverses and return the max key in the tree.
        public Key Max()
        {
            if (Size() == 0) throw new InvalidOperationException();
            return Max(root).Key;
        }

        private Node Max(Node cur)
        {
            if (cur.Right == null)
            {
                return cur;
            } else
            {
                return Max(cur.Right);
            }
        }

        // This method calculates number of keys which are less than target key.
        public int Rank(Key key)
        {
            if (Size() == 0) throw new InvalidOperationException();
            if (key == null) throw new ArgumentNullException();
            return Rank(root, key);
        }

        // This method recursively traverse the tree and adds up
        // number of keys which are less than target key.
        private int Rank(Node cur, Key key)
        {
            if (cur == null) return 0;

            int cmp = key.CompareTo(cur.Key);
            if (cmp < 0)
            {
                return Rank(cur.Left, key);
            }
            else if (cmp > 0)
            {
                return 1 + Size(cur.Left) + Rank(cur.Right, key);
            }
            else
            {
                return Size(cur.Left);
            }
        }

        // This method finds and returns the largest key in the BST that is <= target key.
        public Key Floor(Key key)
        {
            // traverse the bst and update floor(key) along the way
            return Floor(root, key, default(Key));
        }

        // This helper method recursively traverse the tree and update better floor key for targe key.
        private Key Floor(Node cur, Key key, Key champ)
        {
            if (cur == null) return champ;
            int cmp = key.CompareTo(cur.Key);
            if (cmp < 0) // key in cur node is too large -> floor is in left subtree
            {
                return Floor(cur.Left, key, champ);
            }
            else if (cmp > 0) // key in cur node is a better candidate for floor -> update champ
            {
                return Floor(cur.Right, key, cur.Key);
            }
            else // key in cur node is a candidate for floor
            {
                return cur.Key;
            }
        }

        // This method finds and returns the smallest key in the BST that is >= target key.
        public Key Ceiling(Key key)
        {
            return Ceiling(root, key, default(Key));
        }

        // This helper method recursively traverse the tree and update better celing key for targe key.
        private Key Ceiling(Node cur, Key key, Key champ)
        {
            if (cur == null) return champ;
            int cmp = key.CompareTo(cur.Key);
            if (cmp < 0) // key in cur node is a better candidate for ceiling -> update champ
            {
                return Ceiling(cur.Left, key, cur.Key);
            }
            else if (cmp > 0) // key in cur node is too large -> celing is in left subtree
            {
                return Ceiling(cur.Right, key, champ);
            }
            else // key in cur node is a candidate for floor
            {
                return cur.Key;
            }
        }

        // This method deletes the node in the tree if exists target key.
        public void Delete(Key key)
        {
            if (key == null) throw new ArgumentNullException();
            root = Delete(root, key);
        }

        private Node Delete(Node cur, Key key)
        {
            if (cur == null) return null;

            int cmp = key.CompareTo(cur.Key);
            if (cmp < 0)
            {
                cur.Left = Delete(cur.Left, key);
            }
            else if (cmp > 0)
            {
                cur.Right = Delete(cur.Right, key);
            }
            else // cur.Key = key
            {
                if (cur.Left == null) return cur.Right;
                if (cur.Right == null) return cur.Left;
                Node temp = cur;
                cur = Min(temp.Right); // replace with min from right subtree
                cur.Right = DeleteMin(temp.Right); // handle right children in delete min 
                cur.Left = temp.Left; // min has no left child
            }
            cur.Count = Size(cur.Left) + Size(cur.Right) + 1;

            return cur;
        }

        // This helper method locate the min node in the tree and delete the node from tree
        // while adding its childer to its parent maintaining BST properties.
        private Node DeleteMin(Node cur)
        {
            if (cur.Left == null) return cur.Right;
            cur.Left = DeleteMin(cur.Left);
            cur.Right = DeleteMin(cur.Right);
            cur.Count = Size(cur.Left) + Size(cur.Right) + 1;
            return cur;
        }

        // private Node class 
        private class Node
        {
            public Key Key { get; set; }
            public Value Val { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public int Count { get; set; }

            public Node(Key key, Value val, int count)
            {
                this.Key = key;
                this.Val = val;
                this.Count = count;
                this.Left = null;
                this.Right = null;
            }
        }
    }
}
