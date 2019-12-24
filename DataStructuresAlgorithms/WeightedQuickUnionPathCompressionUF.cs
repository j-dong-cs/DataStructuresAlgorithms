using System.Collections.Generic;
namespace DataStructuresAlgorithms
{
    public class WeightedQuickUnionPathCompressionUF
    {
        // for test purpose: make them as public
        public int[] parent; // array of int: keep tracking the root node of each node
        public int[] size; // array of int: count the number of elements in the tree rooted at i

        // This constructor takes in an int of n which represents the number of
        // nodes and then initializes the properties of parent and size array
        // with the size of n.
        public WeightedQuickUnionPathCompressionUF(int n)
        {
            parent = new int[n];
            size = new int[n];

            for (int i = 0; i < n; i++)
            {
                // initialize the parent array with node 0 to n-1 points itself (its own parent)
                parent[i] = i;
                // initialize the size array with value 1: each node is its own tree
                size[i] = 1;
            }
        }

        // Given node p, find and return the root of node p
        public int Find(int p)
        {
            // Going down the tree to find the root of p
            while (p != parent[p]) // when i == parant[i] means i is a root
            {
                // make every other node in path point to its grandparent
                parent[p] = parent[parent[p]]; 
                p = parent[p];
            }

            return p;
        }

        // Merge the trees containing node p and q if they are not in the same tree
        public void Union(int p, int q)
        {
            int r1 = Find(p);
            int r2 = Find(q);

            if (r1 == r2) return; // if node p and q has same root, they are in the same tree

            if (size[r1] >= size[r2]) // if r1 is the root of smaller tree, swap r1 and r2
            {
                int temp = r1;
                r1 = r2;
                r2 = temp;
            }

            parent[r1] = r2; // make r1 point to root r2
            size[r2] += size[r1]; // update size
        }
    }
}
