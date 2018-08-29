using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IAdjacencyMatrix
    {
        IVertex AddVertex(string name);
        IVertex GetVertex(string name);
        IEnumerable<IVertex> GetVertexes();
    }
}
