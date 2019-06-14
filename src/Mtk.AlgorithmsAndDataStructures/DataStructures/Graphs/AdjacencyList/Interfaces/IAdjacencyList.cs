using System.Collections.Generic;

namespace Mtk.AlgorithmsAndDataStructures.DataStructures.Graphs.AdjacencyList.Interfaces
{
    public interface IAdjacencyList
    {
        int VertexCount { get; }
        bool IsDirected { get; }
        IVertex AddVertex(string name);
        IVertex GetVertex(string name);
        IReadOnlyList<IVertex> GetVertexes();
    }
}
