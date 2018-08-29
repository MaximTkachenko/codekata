using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IVertex
    {
        string Name { get; }
        IVertex AddEdge(string endVertexName, short weight = 1);
        IEnumerable<IEdge> GetEdges();
    }
}
