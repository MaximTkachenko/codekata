using System.Collections.Generic;

namespace Core
{
    public interface IAdjacencyMatrix
    {
        IVertex AddVertex(string name);
        IVertex GetVertex(string name);
        IEnumerable<IVertex> GetVertexes();
    }

    public interface IVertex
    {
        string Name { get; }
        IVertex AddEdge(string endVertexName, short weight = 1);
        IEnumerable<IEdge> GetEdges();
    }

    public interface IEdge
    {
        short Weight { get; }
        IVertex Vertex1 { get; }
        IVertex Vertex2 { get; }
        IEdge Next { get; }
    }
}
