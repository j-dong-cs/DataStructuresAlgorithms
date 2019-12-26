using System.Collections.Generic;

namespace DataStructuresAlgorithms.Graph
{
    // This class represents a direct graph data structure which has
    // V vertex and edges connected between two vertex.
    // User is able to add/remove vertex and edges.
    public class DirectGraph
    {
        private int V; // number of vertex in the graph
        private Dictionary<int, LinkedList<int>> adj; // adjacency list

        // Default contructor: creates an empty graph with 0 vertex
        // and empty adjacency list;
        public DirectGraph()
        {
            this.V = 0;
            adj = new Dictionary<int, LinkedList<int>>();
        }

        // This constructor initializes number of vertex with value passed in
        // and adjacency list with V vertex.
        public DirectGraph(int V)
        {
            this.V = V;
            adj = new Dictionary<int, LinkedList<int>>();
            for (int i = 0; i < V; i++)
            {
                adj.Add(i, new LinkedList<int>());
            }
        }

        // This method adds an vertex into graph.
        public void AddVertex()
        {
            V++;
            adj.Add(V, new LinkedList<int>());
        }

        // This method removes an vertex from graph if exists
        // and removes all edges connect from and to this vertex.
        public void RemoveVertex(int v)
        {
            if (ValidateVertex(v))
            {
                adj.Remove(v); // remove all edges starting from v

                for (int i = 0; i < V; i++)
                {
                    if (adj.ContainsKey(i) && adj[i].Contains(v))
                    {
                        adj[i].Remove(v);
                    }
                }
            }
        }

        // This method creates an edge from vertex v to w if v and w are valid.
        public void AddEdge(int v, int w)
        {
            if (ValidateVertex(v) && ValidateVertex(w))
            {
                adj[v].AddFirst(w);
            }
        }

        // This method removes an edge from vertex v to w if v and w are valid
        // and there is an edge from vertex v to w.
        public void RemoveEdge(int v, int w)
        {
            if (ValidateEdge(v, w))
            {
                adj[v].Remove(w);
            }
        }

        // This method returns all edges connected from vertex v if valid;
        // otherwise, return null;
        public IEnumerable<int> Adj(int v)
        {
            if (v < 0 || v > this.V)
            {
                return null;
            }

            return adj[v];
        }

        // This helper method returns true if both two vertex are valid;
        // and returns false if either is not;
        private bool ValidateVertex(int v)
        {
            if (v < 0 || v > this.V) return false;

            return true;
        }

        // This helper method returns true if exists an edge from
        // vertex v to w; returns false if not.
        private bool ValidateEdge(int v, int w)
        {
            if (ValidateVertex(v) && ValidateVertex(w))
            {
                return adj[v].Contains(w);
            }

            return false;
        }
    }
}
