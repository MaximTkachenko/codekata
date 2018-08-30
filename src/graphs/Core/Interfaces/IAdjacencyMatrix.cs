using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IAdjacencyMatrix
    {
        bool IsDirected { get; }
        IVertex AddVertex(string name);
        IVertex GetVertex(string name);
        IReadOnlyList<IVertex> GetVertexes();
    }
}
