using System.Collections.Generic;

namespace DataStructuresAlgorithms.Graph
{
    // This class represents a direct graph data structure which has
    // V vertex and edges connected between two vertex.
    // User is able to add/remove vertex and edges.
    public class DirectGraph<V, E> where V : notnull where E : notnull
    {
        private int Count { get; set; } // number of vertex in the graph
        private Dictionary<Vertex<V>, LinkedList<Edge<V,E>>> adj; // adjacency list
        private Dictionary<V, Vertex<V>> vertexLookup;

        // Default contructor: creates an empty graph with 0 vertex
        // and empty adjacency list;
        public DirectGraph()
        {
            this.Count = 0;
            adj = new Dictionary<Vertex<V>, LinkedList<Edge<V, E>>>();
            vertexLookup = new Dictionary<V, Vertex<V>>();
        }

        public void Clear()
        {

        }

        public void ClearEdges()
        {

        }

        public void ClearVertexInfo()
        {

        }

        // This method adds an vertex into graph.
        public void AddVertex(V v)
        {
            Count++;
        }

        // This method removes an vertex from graph if exists
        // and removes all edges connect from and to this vertex.
        public void RemoveVertex(V v)
        {

        }

        // This method creates an edge from vertex v to w if v and w are valid.
        public void AddEdge(V v1, V v2)
        {

        }

        public void AddEdge(V v1, V v2, E e)
        {

        }

        public void AddEdge(V v1, V v2, int weight)
        {

        }

        public void AddEdge(V v1, V v2, E e, int weight)
        {

        }

        // This method removes an edge from vertex v to w if v and w are valid
        // and there is an edge from vertex v to w.
        public void RemoveEdge(V v1, V v2)
        {

        }

        public void RemoveEdge(E e)
        {

        }

        public bool ContainsEdge(E e)
        {
            return true;
        }

        public bool ContainsEdge(V v1, V v2)
        {
            return true;
        }

        public bool ContainsVertex(V v)
        {
            return true;
        }

        public E Edge(V v1, V v2)
        {
            return default(E);
        }

        public ICollection<E> Edges()
        {
            return null;
        }

        public int EdgeWeight(V v1, V v2)
        {
            return 0;
        }

        public ISet<V> Neighbors(V v)
        {
            return null;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public ISet<V> Vertices()
        {
            return null;
        }
    }
}
