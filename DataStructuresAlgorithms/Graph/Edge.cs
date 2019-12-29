using System;
namespace DataStructuresAlgorithms.Graph
{
    public class Edge<V, E> where V : notnull where E : notnull
    {
        public static readonly int DEFAULT_WEIGHT = 1;

        private V start;
        private V end;
        private E edge;
        private int weight;

        public Edge(V start, V end, E edge)
        {
            this.start = start;
            this.end = end;
            this.weight = DEFAULT_WEIGHT;
        }

        public Edge(V start, V end, E edge, int weight)
        {
            if (weight < 0) throw new ArgumentOutOfRangeException();

            this.start = start;
            this.end = end;
            this.edge = edge;
            this.weight = weight;
        }

        public V Start
        {
            get; set;
        }

        public V End
        {
            get; set;
        }

        public E GetEdge()
        {
            return edge;
        }

        public void SetEdge(E edge)
        {

        }

        public int Weight
        {
            get; set;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
