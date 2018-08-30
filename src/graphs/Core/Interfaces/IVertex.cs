using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IVertex
    {
        string Name { get; }
        IVertex AddEdge(string endVertexName, int weight = 0);
        IReadOnlyList<IEdge> GetEdges();
    }
}
