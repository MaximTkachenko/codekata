using Core.Interfaces;

namespace Core
{
    internal sealed class Edge : IEdge
    {
        public Edge(IVertex vertex1, IVertex vertex2, short weight)
        {
            Vertex1 = vertex1;
            Vertex2 = vertex2;
            Weight = weight;
            Next = null;
        }

        public short Weight { get; }

        public IVertex Vertex1 { get; }

        public IVertex Vertex2 { get; }

        public IEdge Next { get; internal set; }
    }
}
