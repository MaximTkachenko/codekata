using Core.Interfaces;

namespace Core
{
    public static class AdjacencyMatrixFactory
    {
        public static IAdjacencyMatrix CreateDirected() => new AdjacencyMatrix(true);

        public static IAdjacencyMatrix CreateDirectedFromStructure(string structure) => new AdjacencyMatrix(structure, true);

        public static IAdjacencyMatrix CreateUndirected() => new AdjacencyMatrix(false);

        public static IAdjacencyMatrix CreateUndirectedFromStructure(string structure) => new AdjacencyMatrix(structure, false);
    }
}
