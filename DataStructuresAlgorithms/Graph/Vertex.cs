using System;

namespace DataStructuresAlgorithms.Graph
{
    public class Vertex<V> where V : notnull
    {
        protected V Name { get; set; }

        public int? Number { get; set; }

        public int? Cost { get; set; }

        public V Previous { get; set; }

        public bool Visited { get; set; }

        // Constructs information for the given vertex
        public Vertex(V v)
        {
            this.Name = v;
            this.Number = null;
            this.Cost = null;
            this.Previous = default(V);
            this.Visited = false;
        }

        // Reset the previous, visited, cost, and number data fields to their original values.
        public void Clear()
        {
            this.Cost = null;
            this.Previous = default(V);
            this.Visited = false;
        }

        public override string ToString()
        {
            return "";
        }
    }
}
