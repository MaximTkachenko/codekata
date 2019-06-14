namespace Mtk.AlgorithmsAndDataStructures.DataStructures.Graphs.AdjacencyList.Interfaces
{
    public interface IEdge
    {
        int Weight { get; }
        IVertex Vertex1 { get; }
        IVertex Vertex2 { get; }
    }
}
